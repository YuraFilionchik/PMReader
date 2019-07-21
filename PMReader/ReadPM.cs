using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace PMReader
{
  public  class ReadPM
    {
        public string Filename;
        public string FileDir;
        public string NE_Name;
        public DateTime Date;
        public List<NE.Port> Ports; //список портов в файле
        public override string ToString()
        {
            return String.Format(NE_Name);
        }

        public ReadPM()
        {
        }

        public ReadPM(string FileDir, string Filename)
        {
            try
            {
                int a;
                this.FileDir = FileDir;
                this.Filename = Filename;
                StreamReader f;
                string Line;
				NE.Port newPort=new NE.Port(1);
                NE.Statistics newStat=new NE.Statistics(1);
                Ports=new List<NE.Port>();
                string filepath = FileDir + "/" + Filename;
                string PortName;
             
                if (File.Exists(filepath))
                {
                	var tFile=File.ReadAllText(filepath);
                	if(tFile.Contains("15 minutes")) //read pm15 file
                	   {
						return;
                	   }
                    f = new StreamReader(filepath);
                    Line = f.ReadLine();
                    var ListLine = Line.Split(':');
                    NE_Name = ListLine[1].Trim().TrimStart('"').TrimEnd('"');
                    Line = f.ReadLine();
                    ListLine = Line.Split();
                    Date = DateTime.ParseExact(ListLine[2].TrimStart('"').TrimEnd('"'), "dd:MM:yyyy",CultureInfo.InvariantCulture);
                    
                    while (!f.EndOfStream) //повторять до конца файла
                    {
                        
                        if (Line.Split()[0] == "PP:")
                            PortName = Line.Split()[1].TrimStart('"').TrimEnd('"'); //PortName
                        else
                        {
                            Line = f.ReadLine(); // порт
                            continue;
                        }
                        int ind = Ports.FindIndex(p => p.PortName == PortName);  //index of port in Ports
                        if (ind == -1)
                        {
                            newStat = new NE.Statistics(1);
                            newStat.Date = Date.Date; //Date
                        }
                        
                        f.ReadLine(); // next
                        f.ReadLine(); //next
                        Line = f.ReadLine();
                        if (String.IsNullOrEmpty(Line)) continue;
                        while (Line.Split()[0].Trim() == "ME:")
                        {
                            
                            switch (Line.Split()[1].Trim())
                            {
                                case "FEBBE":
                                    int.TryParse(Line.Split()[2].Trim(), out newStat.FEBBE);
                                    break;
                                case "BBE":
                                    int.TryParse(Line.Split()[2].Trim(), out newStat.BBE);
                                    break;
                                case "FEES":
                                    int.TryParse(Line.Split()[2].Trim(), out newStat.FEES);
                                    break;
                                case "ES":
                                    int.TryParse(Line.Split()[2].Trim(), out newStat.ES);
                                    break;
                                case "SES":
                                    int.TryParse(Line.Split()[2].Trim(), out newStat.SES);
                                    break;
                                case "FESES":
                                    int.TryParse(Line.Split()[2].Trim(), out newStat.FESES);
                                    break;
                                case "FEUAS":
                                    int.TryParse(Line.Split()[2].Trim(), out newStat.FEUAS);
                                    break;
                                case "NEUAS":
                                    int.TryParse(Line.Split()[2].Trim(), out newStat.NEUAS);
                                    break;
                            }
                            Line = f.ReadLine();
                            if (String.IsNullOrEmpty(Line)) break;
                        }
                        

                        //if (Line.Split()[1].Trim() == "FEBBE")
                        //    int.TryParse(Line.Split()[2].Trim(), out newStat.FEBBE);
                        //else int.TryParse(Line.Split()[2].Trim(),out newStat.BBE);
                        //Line = f.ReadLine(); //ES FEES
                        //if (Line.Split()[1].Trim() == "FEES") int.TryParse(Line.Split()[2].Trim(),out newStat.FESES);
                        //else int.TryParse(Line.Split()[2].Trim(),out newStat.ES);
                        //Line = f.ReadLine(); //SES   FESES
                        //if (Line.Split()[1].Trim() == "FESES") int.TryParse(Line.Split()[2].Trim(), out newStat.FESES);
                        //else int.TryParse(Line.Split()[2].Trim(), out newStat.SES);
                        //Line = f.ReadLine(); //UAS
                        //if (Line.Split()[1].Trim() == "FEUAS") int.TryParse(Line.Split()[2].Trim(),out newStat.FEUAS);
                        //else int.TryParse(Line.Split()[2].Trim(), out newStat.NEUAS);
                        if (ind == -1)
                        {
                            //порт не найден
                            newPort = new NE.Port(1);
                            newPort.PortName = PortName;
                            newPort.Stat.Add(newStat);
                            Ports.Add(newPort);  //добавление нового порта
                        }
                        else //порт найден. добавляем stat в существующий
                        {
                            var removeStat=Ports[ind].Stat.FindIndex(s => s.Date.Date == newStat.Date.Date);
                            if (removeStat==-1) Ports[ind].Stat.Add(newStat); //нету такой статы
                            else //удаляем существующую стату чтобы добавить новую
                            {
                                Ports[ind].Stat.Remove(Ports[ind].Stat[removeStat]); 
                                Ports[ind].Stat.Add(newStat);
                            }
                        }
                    } //конец чтения файла

                    f.Close();


                }
                else
                {
                    MessageBox.Show("Ошибка открытия файла" + filepath,"ReadPM Class");
                }
                

            }
            catch (Exception)
            {
                
                throw;
            }
            
            

        }
    }
}
