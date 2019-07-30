/*
 * Created by SharpDevelop.
 * User: ВКС
 * Date: 01.07.2019
 * Time: 17:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Text;
namespace PMReader
{
	
 
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class PM15
	{
		public string NE_Name;
		public List<NE.Port> Ports; //список портов в файле
		public override string ToString()
        {
            return String.Format(NE_Name);
        }
		private DateTime[] Intervals=new DateTime[16];
		
		public PM15(string FilePath)
		{
			try {
				
				Ports=new List<NE.Port>();
				NE.Port currentPort=new NE.Port();
				NE.Statistics currentStat=new NE.Statistics(1);
				int currentInteral=0;
				bool firstPort=true;
				string nS;// text of NumberInterval
				if(!File.Exists(FilePath)) 
				{
					//Ports.Add(new NE.Port("fileNotFound"));
					NE_Name = FilePath;
					return;
				}
				//all  lines in file
				var Lines=File.ReadAllLines(FilePath);
		for (int i = 0; i < Lines.Length; i++) //проход по всем строкам
				{
					var segments=Lines[i].Split('\t');
					
					switch(segments[0])
					{
					case "NE:": 
							NE_Name=segments[1].Trim().TrimStart('"').TrimEnd('"');
						break;
					case "PO:":	//get all intervals into Intervals[]
						nS=segments[1]; //Номер интервала
						int N=int.Parse(nS);       			//Номер интервала
						string dt=segments[2].TrimStart('"').TrimEnd('"'); //дата интервала
					DateTime datetime=DateTime.ParseExact(dt,"dd:MM:yyyy HH:mm:ss",CultureInfo.InvariantCulture);	//дата интервала
					Intervals[N]=datetime;
					break;
				case "PP:": //port name
					var port_Name=segments[1].Trim('"');
					//save prev port
					if(!firstPort) 
					{
						currentPort.Stat.Add(currentStat);
						Ports.Add(currentPort);
					}
					else {
						currentPort=new NE.Port(port_Name);
						firstPort=false;
					}
					break;
				case "BL:": //errors interval
					 nS=segments[1]; //Номер интервала
						currentInteral=int.Parse(nS); 
						if(currentInteral!=0) currentPort.Stat.Add(currentStat);
						currentStat=new NE.Statistics(1);
						currentStat.Date=Intervals[currentInteral];
					break;
				case "ME:":  //ERRORS
					var erType=segments[1];
					int erCount=int.Parse(segments[2].Trim());
					switch(erType)
					{
						case "NEUAS":
							currentStat.NEUAS=erCount;
							break;
						case "SES":
							currentStat.SES=erCount;
							break;
						case "ES":
							currentStat.ES=erCount;
						break;
						case "BBE":
						currentStat.BBE=erCount;
						break;
						case "FEBBE":
						currentStat.FEBBE=erCount;
						break;
						case "FEES":
						currentStat.FEES=erCount;
						break;
						case "FESES":
						currentStat.FESES=erCount;
						break;
						case "FEUAS":
						currentStat.FEUAS=erCount;
						break;
					}
					break;
					}
					
					if(i==Lines.Length-1) 
					{
						currentPort.Stat.Add(currentStat);
						Ports.Add(currentPort);
					}
				}
	
			} catch (Exception Ex) {
				
				throw new Exception("PM15",Ex);
			}
		}
	}
}