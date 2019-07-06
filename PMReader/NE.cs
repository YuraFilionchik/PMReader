using System;
using System.Collections.Generic;
using System.Text;

namespace PMReader
{
  public  class NE
    {
        public string NE_Name;
        public List<Port> Ports;

        public struct Statistics
        {
            public DateTime Date;
            public int FEBBE;
            public int FEES;
            public int FESES;
            public int FEUAS;
            public int BBE;
            public int ES;
            public int SES;
            public int NEUAS;
            public bool ISPM15;

            public Statistics(int a)
            {
                Date = DateTime.Now.Date;
                FEBBE = 0;
                BBE = 0;
                FEES = 0;
                ES = 0;
                FESES = 0;
                SES = 0;
                FEUAS = 0;
                NEUAS = 0;
                ISPM15=false;
            }
        }
       public struct Port
        {
            public string PortName;
            public List<Statistics> Stat;

           public Port(int i)
           {
               PortName = "";
               Stat=new List<Statistics>();
           }
		public Port(string portName)
           {
               PortName = portName;
               Stat=new List<Statistics>();
           }
        }

        public NE()
        {
            
        }
        public NE(ReadPM PM)
        {
            this.NE_Name = PM.NE_Name;
            Ports = PM.Ports;

        }

        public void AddInfo(ReadPM PM)
        {
            try
            {
                if (PM.NE_Name == this.NE_Name)
                {
                    int nPort;
                    int nStat;
                    foreach (var port in PM.Ports)
                    {
                        nPort=this.Ports.FindIndex(p => p.PortName == port.PortName);
                        if (nPort == -1)
                        {
//такого порта нету, добавляем в список 
                            this.Ports.Add(port);
                        }
                        else //порта уже имеется
                        {//проверяем наличие статы по дате на порту nPort
                            foreach (var stat in port.Stat)
                            {
                                nStat = this.Ports[nPort].Stat.FindIndex(s => s.Date == stat.Date);
                                if (nStat == -1)
                                {
//такой даты не найдено
                                    //добавляем stat в список данного порта nPort
                                    this.Ports[nPort].Stat.Add(stat);
                                }
                                
                            }
                        }
                    }



                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
