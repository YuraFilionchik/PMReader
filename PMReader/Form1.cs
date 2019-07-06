using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using BytesRoad.Net.Ftp;

namespace PMReader
{
    public partial class Form1 : Form
    {
        private delegate void delevent();
        private event delevent run;
        delegate int del(object o);

        private int nDirs;//количество обработанных папок
        private int nDirsAll; //all
        private int nFiles;//количество обработанных файлов
            int indexOfFile=0; //номер файл
        private int count;
        DateTime FromDate, ToDate;
        DateTime dateNow = DateTime.Now.Date;
        private string DirLocal = Properties.Settings.Default.PM_Path_Local;
        private ParameterizedThreadStart readFtpThread1;
        private ParameterizedThreadStart readFtpThread2;
        BaseNE BASE=new BaseNE();
        public Form1()
        {
            try
            {
 InitializeComponent();
            #region create dir PM
		 if (!Directory.Exists(DirLocal)) System.IO.Directory.CreateDirectory(DirLocal);
           #endregion
           
           comboBox1.Items.AddRange(Enum.GetNames(typeof(SeriesChartType)));
           
            count = 0;
            dateTimePicker1.Value = dateNow;
            dateTimePicker2.Value = dateNow;
            FromDate = dateTimePicker1.Value;
            ToDate = dateTimePicker2.Value;
            dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
            dateTimePicker2.ValueChanged += new EventHandler(dateTimePicker2_ValueChanged);
            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            comboBox1.SelectedIndexChanged+=comboBoxSelect;
            tabControl1.TabIndexChanged+= tabIndexchanged;
            run += new delevent(run_secont_thread);
            #region test pm15
            string filePM15="10_64";
            PM15 pm15=new PM15(filePM15);
            
            #endregion

            }
            catch (Exception)
            {
                
                throw;
            }
           
           
        }

        void run_secont_thread()
        {
            if (count < 1)
            {
            readFtpThread2 = new ParameterizedThreadStart(ReadAndCopyFiles);
            Thread readThread2 = new Thread(readFtpThread2);
            readThread2.Start(Properties.Settings.Default.PM_Path_Server101);
            }
            
        }

		void comboBoxSelect(object sender, EventArgs e)
		{
			if(chart1.Series.Count!=0 && !String.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()))
			for(int i=0;i<chart1.Series.Count;i++)
			{
				chart1.Series[i].ChartType=(SeriesChartType)Enum.Parse(typeof(SeriesChartType),comboBox1.SelectedItem.ToString());
			}
		}
        //вывод информации из базы
        void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
#region old code
//
//try
//            {
//               dataGridView1.Rows.Clear();
//                int nNE = BASE.NeList.FindIndex(n => n.NE_Name == listBox1.SelectedItem.ToString());
//                int nrow;
//                if (nNE != -1)
//                    foreach (var port in BASE.NeList[nNE].Ports)
//                    { 
//                        nrow=dataGridView1.Rows.Add();
//                        dataGridView1.Rows[nrow].Cells["ports"].Value = port.PortName;
//                        dataGridView1.Rows[nrow].DefaultCellStyle.BackColor = Color.BlanchedAlmond;
//                        
//                        foreach (var st in port.Stat)
//                        {
//                            nrow = dataGridView1.Rows.Add();
//                            dataGridView1.Rows[nrow].DefaultCellStyle.BackColor = Color.Honeydew;
//                            dataGridView1.Rows[nrow].Cells["date"].Value = st.Date.ToShortDateString();
//                            dataGridView1.Rows[nrow].Cells["bbe"].Value = st.BBE;
//                            dataGridView1.Rows[nrow].Cells["ES"].Value = st.ES;
//                            dataGridView1.Rows[nrow].Cells["SES"].Value = st.SES;
//                            dataGridView1.Rows[nrow].Cells["NEUAS"].Value = st.NEUAS;
//                            dataGridView1.Rows[nrow].Cells["FEBBE"].Value = st.FEBBE;
//                            dataGridView1.Rows[nrow].Cells["FEES"].Value = st.FEES;
//                            dataGridView1.Rows[nrow].Cells["FESES"].Value = st.FESES;
//                            dataGridView1.Rows[nrow].Cells["FEUAS"].Value = st.FEUAS;
//                        }
//                        nrow = dataGridView1.Rows.Add();
//                        dataGridView1.Rows[nrow].DefaultCellStyle.BackColor = Color.Indigo;
//                    }
//                else MessageBox.Show("Ошибка выбора listbox");
//
//            }
//            catch (Exception)
//            {
//                
//                throw;
//            }
#endregion
	if (checkBox1.Checked) Display (false);
	else Display(true);
	
        }

        #region events
        void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
            ToDate = dateTimePicker2.Value;
        }
        void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
                FromDate = dateTimePicker1.Value;
           
        }

		void tabIndexchanged(object sender, EventArgs e)
		{
			//tabControl1.TabIndex==1&&
			if(tabControl1.TabIndex==1&& (listBox1.SelectedItems.Count!=0))
			{						
				DrawChart(BASE);
			}

		}

        #endregion
        


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
if (dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
{
    nFiles = 0; //количество обработанных файлов
    nDirs = 0;
    nDirsAll = 0;
    indexOfFile=0;
                count = 0;
                BASE=new BaseNE();
                listBox1.Items.Clear();
                readFtpThread1 = new ParameterizedThreadStart(ReadAndCopyFiles);
                Thread readThread1 = new Thread(readFtpThread1);
                readThread1.Start(Properties.Settings.Default.PM_Path_Server100);
                
            }
            else MessageBox.Show("Выбран неверный временной интервал!", "oops");
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        
        public void ReadLocal(object O)
        {
            try
            {
                    string oldBut = button2.Text;
                    Invoke(new Action<string>(s => button2.Text = s), "Идет процесс анализа локальных файлов...");
                    Invoke(new Action<bool>(s => button2.Enabled = s), false);
                    Invoke(new Action<bool>(s => button1.Enabled = s), false);
                    string PM_path_Local = (string)O;
                    del Mydel = n => listBox1.Items.Add(n);
                    int nNE;
                //список папок в локальной папке PM
                var listftp = Directory.GetDirectories(PM_path_Local);
                 
                    if (listftp.Count()==0)
                    {
                        Invoke(new Action<string>(s => button2.Text = s), oldBut);
                        Invoke(new Action<bool>(s => button1.Enabled = s), true);
                        Invoke(new Action<bool>(s => button2.Enabled = s), true);
                        MessageBox.Show("папка " + PM_path_Local + " не содержит подпапок с файлами");
                        Thread.CurrentThread.Abort();
                    }
                    ReadPM ne;
                    NE NEstat;
                    DateTime DirDate;
                    int countErr = 0;
                string text;//строка отчета о количестве папок;
                string CurDir;
                    //перебор всех папок на сервере
                    foreach (var Item in listftp)
                    {
                        var ftpItem = Item.Split('\\')[1];
                        //перевод названия папки в дату    
                        //if (ftpItem.ItemType != FtpItemType.Directory) continue;
                        Invoke(new Action<int>(s => nDirsAll+=s), 1);
                        if (!DateTime.TryParseExact(ftpItem, "yyyyMMdd", CultureInfo.InvariantCulture,
                                DateTimeStyles.None, out DirDate))
                        {
                            countErr += 1;
                            continue;
                        }
                        if (countErr != 0) MessageBox.Show("Пропущено " + countErr + " папок при чтении с сервера","ошибка распознавание даты в имени папки");
                        //фильтр папок по дате
                        if (DirDate.Date >= FromDate.Date && DirDate.Date <= ToDate.Date)
                        {
                        Invoke(new Action<int>(s => nDirs += s), 1);
                         CurDir=PM_path_Local+"/"+ftpItem;
                            string[] Files = Directory.GetFiles(CurDir); //список файлов статистики
                            if (Files.Count() == 0) continue;
                            Invoke(new Action<int>(s => nFiles += s), Files.Count());

                            foreach (var File in Files) //перебор файлов в конечной папке
                            {//заносим инфу из каждого файла в структуру BASE
                                var file = File.Split('\\')[1];
                                ne = new ReadPM(CurDir,file);//считали и проанализировали локальный файл
                                nNE = BASE.NeList.FindIndex(n => n.NE_Name == ne.NE_Name);//поиск такого элемента в базе
                                if (nNE == -1)
                                {//новый аппарат
                                    NEstat = new NE(ne);
                                    BASE.AddNewNE(NEstat);
                                    Invoke(Mydel, ne); //вывод названия NE  в lisybox1
                                }
                                else
                                {//данный аппарат уже имеется в базе
                                    //добавляем новую инфу из файла в базу по Аппарату nNE
                                    BASE.NeList[nNE].AddInfo(ne);
                                }

                            }
                            text = "Найдено " + nDirsAll + "локальных папок; Отфильтровано по дате " + nDirs +
                                          "; Обработано файлов: " + nFiles;
                            Invoke(new Action<string>(s => label4.Text = s), text);

                        }
                    }
                    Invoke(new Action<string>(s => button2.Text = s), oldBut);
                    Invoke(new Action<bool>(s => button2.Enabled = s), true);
                    Invoke(new Action<bool>(s => button1.Enabled = s), true);
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), ex.Message);
            }
            Invoke(new Action<int>(s => count+=s), 1);
            
        }
        public void ReadAndCopyFiles(object O)
        {
            
            try
            {
                    string oldBut = button1.Text;
                    Invoke(new Action<string>(s => button1.Text = s), "Идет процесс анализа...");
                    Invoke(new Action<bool>(s => button1.Enabled = s), false);
                    Invoke(new Action<bool>(s => button2.Enabled = s), false);
                    Invoke(new Action<bool>(s => listBox1.Enabled = s), false);
                    string PM_path_server = (string)O;
                    FtpClient client = new FtpClient();
                    del Mydel = n => listBox1.Items.Add(n);
                    int nNE;
                

                    //Задаём параметры клиента.
                    client.PassiveMode = true; //Включаем пассивный режим.
                    int TimeoutFTP = 30000; //Таймаут.
                    string FTP_SERVER = Properties.Settings.Default.ftp_Address;
                    int FTP_PORT = Properties.Settings.Default.ftp_Port; ;
                    string FTP_USER = Properties.Settings.Default.ftp_User;
                    string FTP_PASSWORD = Properties.Settings.Default.ftp_Pass;

                    //Подключаемся к FTP серверу.
               Ping p=new Ping();
                if (p.Send(FTP_SERVER).Status != IPStatus.Success)
                {
                    MessageBox.Show("Адрес " + FTP_SERVER + " не доступен");
                    Invoke(new Action<string>(s => button1.Text = s), oldBut);
                    Invoke(new Action<bool>(s => button1.Enabled = s), true);
                    Invoke(new Action<bool>(s => button2.Enabled = s), true);
                     Invoke(new Action<bool>(s => listBox1.Enabled = s), true);
                    Thread.CurrentThread.Abort();
                }
                    client.Connect(TimeoutFTP, FTP_SERVER, FTP_PORT);
                    client.Login(TimeoutFTP, FTP_USER, FTP_PASSWORD);
                
                    //Меняет директорию на указанную.
                    //Можно переходить вверх указав вместо имени папки ".." либо в любую папку расположенную в текущей.
                    client.ChangeDirectory(TimeoutFTP, PM_path_server);//переход в директорию DOM100
            
                    //Получает список содержимого текущего каталога с FTP.
                    var listftp = client.GetDirectoryList(TimeoutFTP);
                                     if (listftp.Count()==0)
                    {
                    //    MessageBox.Show("В каталоге " + PM_path_server+" ничего нет", "GetDirectoryList");
                        Invoke(new Action<string>(s => button1.Text = s), oldBut);
                        Invoke(new Action<bool>(s => button1.Enabled = s), true);
                        Invoke(new Action<bool>(s => button2.Enabled = s), true);
                         Invoke(new Action<bool>(s => listBox1.Enabled = s), true);
                        Thread.CurrentThread.Abort();
                    }
                    ReadPM ne;
                    NE NEstat;
                    DateTime DirDate;
                    int countErr = 0;
                string text;//строка отчета о количестве папок
                    //перебор всех папок на сервере
                    foreach (var ftpItem in listftp)
                    {
                        //перевод названия папки в дату    
                        if (ftpItem.ItemType != FtpItemType.Directory) continue;
                        Invoke(new Action<int>(s => nDirsAll+=s), 1);
                        if (!DateTime.TryParseExact(ftpItem.Name, "yyyyMMdd", CultureInfo.InvariantCulture,
                                DateTimeStyles.None, out DirDate))
                        {
                            countErr += 1;
                            continue;
                        }
                        if (countErr != 0) MessageBox.Show("Пропущено " + countErr + " папок при чтении с сервера");
                        //фильтр папок по дате
                        if (DirDate.Date >= FromDate.Date && DirDate.Date <= ToDate.Date)
                        {
                        //    MessageBox.Show("папка " + ftpItem.Name + " прошла фильтр времени");
                            Invoke(new Action<int>(s => nDirs += s), 1);
                            //copy Directories from server
                            if (!Directory.Exists(DirLocal)) Directory.CreateDirectory(DirLocal);
                            var dirInfo = Directory.CreateDirectory(DirLocal + "/" + ftpItem.Name);
                           // client.ChangeDirectory(TimeoutFTP, PM_path_server);
                            client.ChangeDirectory(TimeoutFTP, ftpItem.Name);//переход в директорию DirDate
                        //    MessageBox.Show("Перешли в папку " + ftpItem.Name);

                            string dir24pm ="" ; //имя промежуточной папки
                            var listDir= client.GetDirectoryList(TimeoutFTP);
                            foreach (var dir in listDir)
                            {
                                if (dir.Name == "pm24Dir") dir24pm = "pm24Dir";
                            }
                            if (String.IsNullOrEmpty(dir24pm))
                            {
                                Invoke(new Action<string>(s => button1.Text = s), oldBut);
                                Invoke(new Action<bool>(s => button1.Enabled = s), true);
                                Invoke(new Action<bool>(s => button2.Enabled = s), true);
                                 Invoke(new Action<bool>(s => listBox1.Enabled = s), true);
                                MessageBox.Show(dir24pm,"Ошибка промежуточной папки");//или пропустить continue ??
                                client.ChangeDirectory(TimeoutFTP, PM_path_server);//переход в директорию PM_path_server
                                continue;
                                Thread.CurrentThread.Abort();
                            }
                            client.ChangeDirectory(TimeoutFTP, dir24pm);//зашли в папку ~PM24dir ~
                         
                            var Files = client.GetDirectoryList(TimeoutFTP); //список файлов статистики
                            if (Files.Count() == 0)
                            {
                                client.ChangeDirectoryUp(TimeoutFTP);//in dirdate
                                client.ChangeDirectoryUp(TimeoutFTP);//in dom100
                                continue;
                            }
                          //  Invoke(new Action<int>(s => nFiles += s), Files.Count());
string fname="";
                            foreach (var file in Files) //перебор файлов в конечной папке
                            {//заносим инфу из каждого файла в структуру BASE
                                if (file.Size==-1) continue;
                                if (File.Exists(DirLocal + "/" + dirInfo.Name + "/" + file.Name)) //если файл уже существует
                                {fname=file.Name+"_0";
                                Invoke(new Action<int>(s => nFiles += s), 1);
                                client.GetFile(TimeoutFTP, DirLocal + "/" + dirInfo.Name + "/" + fname, file.Name);
                                }
                                else 
                                {
                                	fname=file.Name;
                                Invoke(new Action<int>(s => nFiles += s), 1);
                                client.GetFile(TimeoutFTP, DirLocal + "/" + dirInfo.Name + "/" + fname, file.Name);
                                }
                                
                                ne = new ReadPM(DirLocal + "/" + dirInfo.Name, fname);//считали и проанализировали локальный файл
                                nNE = BASE.NeList.FindIndex(n => n.NE_Name == ne.NE_Name);//поиск такого элемента в базе
                                
                                if (nNE == -1)
                                {//новый аппарат
                                    NEstat = new NE(ne);
                                    BASE.AddNewNE(NEstat);
                                   // Interlocked.Exchange(ref BASE, BASE);
                                    Invoke(Mydel, ne); //вывод названия NE  в lisybox1
                                }
                                else
                                {//данный аппарат уже имеется в базе
                                    //добавляем новую инфу из файла в базу по Аппарату nNE
                                    BASE.NeList[nNE].AddInfo(ne);
                                }
                                if (File.Exists(DirLocal + "/" + dirInfo.Name + "/" + ne.NE_Name)) //если файл уже существует
                                {
                                	File.Delete(DirLocal + "/" + dirInfo.Name + "/" + fname);
                                	if (fname!=file.Name)File.Delete(DirLocal + "/" + dirInfo.Name + "/" + file.Name);
                                }
                                else //переименовываем файл
                                {
                                	File.Move(DirLocal + "/" + dirInfo.Name + "/" + fname, DirLocal + "/" + dirInfo.Name + "/" + ne.NE_Name);
                                	if (fname!=file.Name)File.Delete(DirLocal + "/" + dirInfo.Name + "/" + file.Name);
                                }
                                

                            }
                            client.ChangeDirectoryUp(TimeoutFTP);//in dirdate
                            client.ChangeDirectoryUp(TimeoutFTP);//in dom100
                            text = "Найдено " + nDirsAll + " папок; Отфильтровано по дате " + nDirs +
                                          "; Обработано файлов: " + nFiles;
                            Invoke(new Action<string>(s => label4.Text = s), text);

                        }
                    }
                    //Отключаемся от ФТП сервера
                    client.Disconnect(TimeoutFTP);
                    Invoke(new Action<string>(s => button1.Text = s), oldBut);
                    Invoke(new Action<bool>(s => button1.Enabled = s), true);
                    Invoke(new Action<bool>(s => button2.Enabled = s), true);
                     Invoke(new Action<bool>(s => listBox1.Enabled = s), true);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), ex.Message);
            }
            run();
            Invoke(new Action<int>(s => count+=s), 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
                {
                    nFiles = 0; //количество обработанных файлов
                    nDirs = 0;
                    nDirsAll = 0;
                    count = 0;
                    BASE = new BaseNE();
                    listBox1.Items.Clear();
                    readFtpThread1 = new ParameterizedThreadStart(ReadLocal);
                    Thread readThread1 = new Thread(readFtpThread1);
                    readThread1.Start(Properties.Settings.Default.PM_Path_Local);

                }
                else MessageBox.Show("Выбран неверный временной интервал!", "oops");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        
        private void DrawChart(BaseNE B)
        {
        	try{
        		chart1.Series.Clear();
        		int nNE = B.NeList.FindIndex(n => n.NE_Name == listBox1.SelectedItem.ToString());
        		if (nNE != -1)
        		{int c=0;//номер series
    
        			foreach (var port in B.NeList[nNE].Ports)
                		{ if (!IsClearPort(port))
        				{ if(c!=0)//>1 series (>1 ports)
        					{
        						Series s=chart1.Series[0];
        						s.Color=Color.FromArgb(new Random().Next(0,255));
        			List<int> bbeList=new List<int>();
        			List<DateTime> dates=new List<DateTime>();
        			foreach(var bbe in port.Stat)
        			{
        				bbeList.Add(bbe.BBE);
        				dates.Add(bbe.Date);
        				s.Points.AddXY(bbe.Date,bbe.BBE);
        			}
        			s.LegendText = port.PortName;
        			chart1.Series.Add(s);
        			c++;
        					}
        					else//First series (first port)
        					{
        						#region series s1
        						Series s1=new Series();
        						s1.ChartArea = "ChartArea1";
        						if(comboBox1.SelectedItem!=null)s1.ChartType =(SeriesChartType)Enum.Parse(typeof(SeriesChartType),comboBox1.SelectedItem.ToString());
        						else s1.ChartType=SeriesChartType.SplineRange;
        	s1.Color = System.Drawing.Color.Red;
        	s1.CustomProperties = "EmptyPointValue=Zero";
        	s1.Legend = "Legend1";
        	s1.LegendText = "BBE";
        	s1.Name = "Series1";
        	s1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
        	s1.YValuesPerPoint = 2;
        	s1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
        						#endregion
        			List<int> bbeList=new List<int>();
        			List<DateTime> dates=new List<DateTime>();
        			foreach(var bbe in port.Stat)
        			{
        				bbeList.Add(bbe.BBE);
        				dates.Add(bbe.Date);
        				s1.Points.AddXY(bbe.Date,bbe.BBE);
        			}
        			//s1.Legend = port.PortName.Substring(0,5);
        			s1.LegendText=port.PortName;
        					chart1.Series.Add(s1);
         					
         				
         					c++;
        					}
        					
        					
                				
                			}//end if ClearPort
                     
                		}//end foreach NE.Ports
        		}
        			for(int i=0;i<comboBox1.Items.Count;i++)
            {
        				if(chart1.Series.Count!=0)
		if(chart1.Series[0].ChartType.ToString()==comboBox1.Items[i].ToString())
			comboBox1.SelectedItem=comboBox1.Items[i];
            }
        		}
        		
        	catch(Exception ex)
        	{
        		MessageBox.Show(ex.Message, "DrawChart Method");
        	}
        }
        private void Display(bool all)
        {        	
        	 try
            {
               dataGridView1.Rows.Clear();
                int nNE = BASE.NeList.FindIndex(n => n.NE_Name == listBox1.SelectedItem.ToString());
                int nrow;
                if (nNE != -1)
                {
                	DrawChart(BASE);
                	if (all)
                	foreach (var port in BASE.NeList[nNE].Ports)
                    { 
                        nrow=dataGridView1.Rows.Add();
                        dataGridView1.Rows[nrow].Cells["ports"].Value = port.PortName;
                        dataGridView1.Rows[nrow].DefaultCellStyle.BackColor = Color.BlanchedAlmond;
                        
                        foreach (var st in port.Stat)
                        {
                            nrow = dataGridView1.Rows.Add();
                            dataGridView1.Rows[nrow].DefaultCellStyle.BackColor = Color.Honeydew;
                            dataGridView1.Rows[nrow].Cells["date"].Value = st.Date.ToShortDateString();
                            dataGridView1.Rows[nrow].Cells["bbe"].Value = st.BBE;
                            dataGridView1.Rows[nrow].Cells["ES"].Value = st.ES;
                            dataGridView1.Rows[nrow].Cells["SES"].Value = st.SES;
                            dataGridView1.Rows[nrow].Cells["NEUAS"].Value = st.NEUAS;
                            dataGridView1.Rows[nrow].Cells["FEBBE"].Value = st.FEBBE;
                            dataGridView1.Rows[nrow].Cells["FEES"].Value = st.FEES;
                            dataGridView1.Rows[nrow].Cells["FESES"].Value = st.FESES;
                            dataGridView1.Rows[nrow].Cells["FEUAS"].Value = st.FEUAS;
                        }
                        nrow = dataGridView1.Rows.Add();
                        dataGridView1.Rows[nrow].DefaultCellStyle.BackColor = Color.Indigo;
                }
                	else //не отображать пустые
                	{
                		foreach (var port in BASE.NeList[nNE].Ports)
                		{ if (!IsClearPort(port))
                			{                				
                		nrow=dataGridView1.Rows.Add();
                        dataGridView1.Rows[nrow].Cells["ports"].Value = port.PortName;
                        dataGridView1.Rows[nrow].DefaultCellStyle.BackColor = Color.BlanchedAlmond;
                        
                        
                        foreach (var st in port.Stat)
                        {
                            nrow = dataGridView1.Rows.Add();
                            dataGridView1.Rows[nrow].DefaultCellStyle.BackColor = Color.Honeydew;
                            dataGridView1.Rows[nrow].Cells["date"].Value = st.Date.ToShortDateString();
                            dataGridView1.Rows[nrow].Cells["bbe"].Value = st.BBE;
                            dataGridView1.Rows[nrow].Cells["ES"].Value = st.ES;
                            dataGridView1.Rows[nrow].Cells["SES"].Value = st.SES;
                            dataGridView1.Rows[nrow].Cells["NEUAS"].Value = st.NEUAS;
                            dataGridView1.Rows[nrow].Cells["FEBBE"].Value = st.FEBBE;
                            dataGridView1.Rows[nrow].Cells["FEES"].Value = st.FEES;
                            dataGridView1.Rows[nrow].Cells["FESES"].Value = st.FESES;
                            dataGridView1.Rows[nrow].Cells["FEUAS"].Value = st.FEUAS;
                        }
                        nrow = dataGridView1.Rows.Add();
                        dataGridView1.Rows[nrow].DefaultCellStyle.BackColor = Color.Indigo;
                				
                			}
                     
                		}
                	}
                    
                    }
                else MessageBox.Show("Ошибка выбора listbox");

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
     public   bool IsClearPort(NE.Port port)
        { bool M=true;
        	foreach (var st in port.Stat)
        	{
        		if (st.BBE!=0||st.ES!=0||st.FEBBE!=0||st.FEES!=0||st.FESES!=0||st.FEUAS!=0||st.NEUAS!=0||st.SES!=0) 
        		return false;
        	}
        	return M;
        }
        void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
        	if (listBox1.SelectedItems.Count!=0)
        	if (checkBox1.Checked) Display (false);
	else Display(true);
        }
		void Chart1Click(object sender, EventArgs e)
		{
			 
	DrawChart(BASE);
		}
    }
}
