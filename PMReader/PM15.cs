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
		public Array Intervals=new DateTime[8];
		
		public PM15(string FilePath)
		{
			try {
				
				Ports=new List<NE.Port>();
				
				if(!File.Exists(FilePath)) 
				{
					Ports.Add(new NE.Port("fileNotFound"));
					return;
				}
				//all  lines in file
				var Lines=File.ReadAllLines(FilePath);
				for (int i = 0; i < Lines.Length; i++) 
				{
					var segments=Lines[i].Split(':');
					string segment=segments[1];
					switch(segments[0])
					{
					case "NE": 
					NE_Name=segment.Trim().TrimStart('"').TrimEnd('"');
						break;
					case "PO":
						string nS=segment.Split('\t')[1]; //Номер интервала
						int N=int.Parse(nS);
					string dt=segment.Split('\t')[2].TrimStart('"').TrimEnd('"')[1]; //дата интервала
					//	DateTime datetime=DateTime.Parse(dt);
					break;
					}
					
						
				#region Read Intervals
				
				#endregion
				
				}
			} catch (Exception) {
				
				throw;
			}
		}
	}
}