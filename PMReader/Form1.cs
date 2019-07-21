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
using System.Reflection;
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
        delegate void del(object o);
        static Mutex mutexObj = new Mutex(); //для очередности процессов разных доменов 100,101
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
        const string pm24Dir="pm24Dir";
        const string pm15Dir="pm15Dir";
        public class MyListBox:ListBox
        {
        	public void AddItem(string item)
        	{
				if (!this.Items.Contains(item))
					Items.Add(item);
        	}
        }
        public Form1()
        {
            try
            {
 InitializeComponent();
            #region create dir PM
		 if (!Directory.Exists(DirLocal)) System.IO.Directory.CreateDirectory(DirLocal);
           #endregion
           Text="PM reader v"+ Assembly.GetExecutingAssembly().GetName().Version.ToString();
                comboBox1.Items.AddRange(Enum.GetNames(typeof(SeriesChartType)));
            comboBox2.Items.AddRange(Enum.GetNames(typeof(SeriesChartType)));
                count = 0;
            dateTimePicker1.Value = dateNow;
            dateTimePicker2.Value = dateNow;
            FromDate = dateTimePicker1.Value;
            ToDate = dateTimePicker2.Value;
            dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
            dateTimePicker2.ValueChanged += new EventHandler(dateTimePicker2_ValueChanged);
            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            comboBox1.SelectedIndexChanged+=comboBoxSelect;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += ComboBox3_SelectedIndexChanged;
            comboBox4.SelectedIndexChanged += ComboBox4_SelectedIndexChanged;
            tabControl1.SelectedIndexChanged+= tabIndexchanged;
            
            }
            catch (Exception)
            {
                
                throw;
            }
           
           
        }

        //SELECT PORT
        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var c = (ComboBox)sender;
            DrawPortToChart(BASE.GetPM24().First(x=>x.NE_Name==listBox1.SelectedItem.ToString()).
                Ports.First(p=>p.PortName==c.SelectedItem.ToString()),true,true);
            if (chart1.Series.Count != 0 && !String.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()))
                for (int i = 0; i < chart1.Series.Count; i++)
                {
                    chart1.Series[i].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), comboBox1.SelectedItem.ToString());
                }
        }
        //SELECT PORT
        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var c = (ComboBox)sender;
            DrawPortToChart(BASE.GetPM15().First(x => x.NE_Name == listBox1.SelectedItem.ToString()).
                Ports.First(p => p.PortName == c.SelectedItem.ToString()), true, true);
            if (chart2.Series.Count != 0 && !String.IsNullOrWhiteSpace(comboBox2.SelectedItem.ToString()))
                for (int i = 0; i < chart2.Series.Count; i++)
                {
                    chart2.Series[i].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), comboBox2.SelectedItem.ToString());
                }
        }

        /// <summary>
        /// Select line type in chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chart2.Series.Count != 0 && !String.IsNullOrWhiteSpace(comboBox2.SelectedItem.ToString()))
                for (int i = 0; i < chart2.Series.Count; i++)
                {
                    chart2.Series[i].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), comboBox2.SelectedItem.ToString());
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
			if(tabControl1.SelectedIndex==1&& (listBox1.SelectedItems.Count!=0))
			{						
				DrawChart(BASE.GetPM24(), true);
			} else if(tabControl1.SelectedIndex == 3 && (listBox1.SelectedItems.Count != 0))
            {
                DrawChart(BASE.GetPM15(), false);
            }

		}

        #endregion
        

        //read from server
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
                BASE=new BaseNE(); //Base of NE
                listBox1.Items.Clear();
                readFtpThread1 = new ParameterizedThreadStart(ReadAndCopyFiles);
                Thread readThread1 = new Thread(readFtpThread1);
                readThread1.Start(Properties.Settings.Default.PM_Path_Server100);


             readFtpThread2 = new ParameterizedThreadStart(ReadAndCopyFiles);
             Thread readThread2 = new Thread(readFtpThread2);
             readThread2.Start(Properties.Settings.Default.PM_Path_Server101);
                }
            else MessageBox.Show("Выбран неверный временной интервал!", "oops");
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        public bool ExistLocalFile(string DateDir, string Type, string fileName)
        {
			string filePath = Properties.Settings.Default.PM_Path_Local + "\\" +
			                     			  DateDir + "\\" + fileName;
			if (File.Exists(filePath))
				return true;
			else
				return false;
        }
        public void ReadLocal(object O)
        {
            try
            {
            	//структура локальных папок
            	//date/Dir24pm/file
            
                    string oldBut = button2.Text;
                    Invoke(new Action<string>(s => button2.Text = s), "Идет процесс анализа локальных файлов...");
                    Invoke(new Action<bool>(s => button2.Enabled = s), false);
                    Invoke(new Action<bool>(s => button1.Enabled = s), false);
                    string PM_path_Local = (string)O;
                    del Mydel = n => listBox1.AddItem(n.ToString());
                    
                    int nNE;
                //список папок в локальной папке PM
                var LocalDirDates = Directory.GetDirectories(PM_path_Local);
                 
                    if (LocalDirDates.Count()==0)
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
                string Dir24pm;
				string Dir15pm;
                    //перебор всех локальных папок date
                    foreach (var dateDir_path in LocalDirDates)
                    {
                    	var ftpItem = dateDir_path.Split('\\').Last();
                        //перевод названия папки в дату    
                        //if (ftpItem.ItemType != FtpItemType.Directory) continue;
                        Invoke(new Action<int>(s => nDirsAll+=s), 1);
                        if (!DateTime.TryParseExact(ftpItem, "yyyyMMdd", CultureInfo.InvariantCulture,
                                DateTimeStyles.None, out DirDate))
                        {
                            countErr += 1;
                            continue;
                        }
                        
                        //фильтр папок по дате
                        if (DirDate.Date > FromDate.Date && (DirDate.Date+new TimeSpan(1,0,0,0)) <= ToDate.Date)
                        {
                        Invoke(new Action<int>(s => nDirs += s), 1);
						#region Check Dir24pm 15pm
                        if (Directory.Exists(dateDir_path + "\\" + pm24Dir))
							Dir24pm = dateDir_path + "\\" + pm24Dir;
						else
							Dir24pm = "";
						if (Directory.Exists(dateDir_path + "\\" + pm15Dir))
							Dir15pm = dateDir_path + "\\" + pm15Dir;
						else
							Dir15pm = "";
						#endregion
						#region read24 files
						if (!String.IsNullOrWhiteSpace(Dir24pm)) 
						{
							string[] Files24 = Directory.GetFiles(Dir24pm); //список файлов статистики
							if (!Files24.Any())
								continue;
							Invoke(new Action<int>(s => nFiles += s), Files24.Count());

							foreach (var File in Files24) { //перебор файлов в конечной папке//заносим инфу из каждого файла в структуру BASE
								var file = File.Split('\\').Last();
								ne = new ReadPM(Dir24pm, file);//считали и проанализировали локальный файл
								nNE = BASE.GetPM24().FindIndex(n => n.NE_Name == ne.NE_Name );//поиск такого элемента в базе
								if (nNE == -1) {//новый аппарат
									NEstat = new NE(ne);
									BASE.AddNewNE(NEstat);
									Invoke(Mydel, ne); //вывод названия NE  в lisybox1
								} else {//данный аппарат уже имеется в базе
									//добавляем новую инфу из файла в базу по Аппарату nNE
									BASE.NeList[nNE].AddInfo(ne);
								}

							}
						}
						#endregion
						#region read15 files
						if (!String.IsNullOrWhiteSpace(Dir15pm)) 
						{
							string[] Files15 = Directory.GetFiles(Dir15pm); //список файлов статистики
							if (!Files15.Any()) 	continue; //no files
							Invoke(new Action<int>(s => nFiles += s), Files15.Count());
							PM15 pm15Read;

							foreach (var File in Files15) { //перебор файлов в конечной папке//заносим инфу из каждого файла в структуру BASE
							var file = File.Split('\\').Last();
								pm15Read = new PM15(file);//считали и проанализировали локальный файл
								nNE = BASE.GetPM15().FindIndex(n => n.NE_Name == pm15Read.NE_Name);//поиск такого элемента в базе
								if (nNE == -1) {//новый аппарат
									NEstat = new NE(pm15Read);
									BASE.AddNewNE(NEstat);
									if(!String.IsNullOrWhiteSpace(pm15Read.ToString()))
										Invoke(Mydel, pm15Read); //вывод названия NE  в lisybox1
								} else {//данный аппарат уже имеется в базе
									//добавляем новую инфу из файла в базу по Аппарату nNE
									BASE.NeList[nNE].AddInfo(pm15Read);
								}

							}
						}
						#endregion
                            text = "Найдено " + nDirsAll + "локальных папок; Отфильтровано по дате " + nDirs +
                                          "; Обработано файлов: " + nFiles;
                            Invoke(new Action<string>(s => label4.Text = s), text);

                        }
                    }
                    if (countErr != 0) MessageBox.Show("Пропущено " + countErr + " папок при чтении с сервера","ошибка распознавание даты в имени папки");
                    Invoke(new Action<string>(s => button2.Text = s), oldBut);
                    Invoke(new Action<bool>(s => button2.Enabled = s), true);
                    Invoke(new Action<bool>(s => button1.Enabled = s), true);
                
//Invoke(new Action<int>(s => count+=s), 1);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), ex.Message);
            }
            
            
        }
        public void ReadAndCopyFiles(object O)
        {
            
            try
            {
                mutexObj.WaitOne();
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

                    #region look local directories

                    var localdirs = Directory.GetDirectories(DirLocal);


                    #endregion
                    //фильтр папок по дате
                    if (DirDate.Date >= FromDate.Date && DirDate.Date <= ToDate.Date)
                        {
                        //    MessageBox.Show("папка " + ftpItem.Name + " прошла фильтр времени");
                            Invoke(new Action<int>(s => nDirs += s), 1);
                            //copy Directories from server
                            if (!Directory.Exists(DirLocal)) Directory.CreateDirectory(DirLocal);
                            //пропуск существующих кроме последней
                       // if (localdirs.Contains(DirDate.ToString("yyyyMMdd")) && localdirs.Last()!=DirDate.ToString("yyyyMMdd")) continue;
                            var dirInfo = Directory.CreateDirectory(DirLocal + "/" + ftpItem.Name);
                           // client.ChangeDirectory(TimeoutFTP, PM_path_server);
                            client.ChangeDirectory(TimeoutFTP, ftpItem.Name);//переход в директорию DirDate
                        //    MessageBox.Show("Перешли в папку " + ftpItem.Name);

                            string dir24pm ="" ; //имя промежуточной папки
                            string dir15pm=""; 
                            var listDir= client.GetDirectoryList(TimeoutFTP);
                            foreach (var dir in listDir)
                            {
                                if (dir.Name == "pm24Dir") dir24pm = "pm24Dir";
                                   if (dir.Name == "pm15Dir") dir15pm = "pm15Dir";
                            }
//                            if (String.IsNullOrEmpty(dir24pm))
//                            {
//                                Invoke(new Action<string>(s => button1.Text = s), oldBut);
//                                Invoke(new Action<bool>(s => button1.Enabled = s), true);
//                                Invoke(new Action<bool>(s => button2.Enabled = s), true);
//                                 Invoke(new Action<bool>(s => listBox1.Enabled = s), true);
//                                MessageBox.Show(dir24pm,"Ошибка промежуточной папки");//или пропустить continue ??
//                                client.ChangeDirectory(TimeoutFTP, PM_path_server);//переход в директорию PM_path_server
//                                continue;
//                                Thread.CurrentThread.Abort();
//                            }
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
                                {//fname=file.Name+"_0";
                                
                                File.Delete(DirLocal + "/" + dirInfo.Name + "/" + file.Name);
                                
                                }
                                Invoke(new Action<int>(s => nFiles += s), 1);
                             	client.GetFile(TimeoutFTP, DirLocal + "/" + dirInfo.Name + "/" + file.Name, file.Name);
                                
                                ne = new ReadPM(DirLocal + "/" + dirInfo.Name, file.Name);//считали и проанализировали локальный файл
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
                            if (File.Exists(DirLocal + "/" + dirInfo.Name + "/" + file.Name)) //если файл уже существует
                                                                                              //переименовываем файл
                            {
                                File.Move(DirLocal + "/" + dirInfo.Name + "/" + fname, DirLocal + "/" + dirInfo.Name + "/" + "PM24="+ne.NE_Name);
                               
                            }


                        }
                        #region get pm15
                        if (!String.IsNullOrWhiteSpace(dir15pm)) 
                            {
                            client.ChangeDirectoryUp(TimeoutFTP);//in dirdate
                            client.ChangeDirectory(TimeoutFTP, dir15pm);//зашли в папку ~PM15dir ~
                            Files = client.GetDirectoryList(TimeoutFTP); //список файлов статистики
                            if (Files.Count() == 0)
                            {
                                client.ChangeDirectoryUp(TimeoutFTP);//in dirdate
                                client.ChangeDirectoryUp(TimeoutFTP);//in dom100
                                continue;
                            }
                          //  Invoke(new Action<int>(s => nFiles += s), Files.Count());

                          foreach (var file in Files) //перебор файлов в конечной папке
                            {//заносим инфу из каждого файла в структуру BASE
                                if (file.Size==-1) continue;
                                if (File.Exists(DirLocal + "/" + dirInfo.Name + "/" + file.Name)) //если файл уже существует
                                {//fname=file.Name+"_0";
                                
                                File.Delete(DirLocal + "/" + dirInfo.Name + "/" + file.Name);
                                
                                }
                                Invoke(new Action<int>(s => nFiles += s), 1);
                             	client.GetFile(TimeoutFTP, DirLocal + "/" + dirInfo.Name + "/" + file.Name, file.Name);
                                
                                ne = new ReadPM(DirLocal + "/" + dirInfo.Name, file.Name);//считали и проанализировали локальный файл
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
                                if (File.Exists(DirLocal + "/" + dirInfo.Name + "/" + file.Name)) //если файл уже существует
                                    //переименовываем файл
                                {
                                    File.Move(DirLocal + "/" + dirInfo.Name + "/" + fname, DirLocal + "/" + dirInfo.Name + "/" + "PM15=" + ne.NE_Name);

                                }

                            }

                        }
                            #endregion
                            
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
                mutexObj.ReleaseMutex();
            }
            catch (Exception ex)
            {
                if (ex.Message != "Поток находился в процессе прерывания.") 
                MessageBox.Show(ex.ToString(), ex.Message);
            }
           
            
            
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
        
        /// <summary>
        /// View BASENE to chart
        /// </summary>
        /// <param name="B"></param>
        /// <param name="pm24"></param>
        private void DrawChart(List<NE> B, bool pm24)
        {
        	try{

                ref Chart chart=ref chart1;
                ref ComboBox cb_line = ref comboBox1;
                ref ComboBox cb_ports = ref comboBox3;
                // ComboBox cb_line, cb_ports;
                if (pm24)
                {
                  chart =ref chart1;
                    cb_line =ref comboBox1;
                    cb_ports =ref comboBox3;
                }
                else
                {
                    chart = ref chart2;
                   cb_line =ref comboBox2;
                    cb_ports =ref comboBox4;
                }
        		chart.Series.Clear();
                cb_ports.Items.Clear();
        		int nNE = B.FindIndex(n => n.NE_Name == listBox1.SelectedItem.ToString());
        		if (nNE != -1)
        		{
                       

                    //select first port with errors
                    var ports_with_errors = B[nNE].Ports.Where(x => x.HaveError());
                    if (ports_with_errors.Count() == 0) return;
                    var port = ports_with_errors.First();
                    cb_ports.Items.Clear();
                    //add to combobox-ports
                    foreach (var p  in ports_with_errors)
                    {
                        cb_ports.Items.Add(p.PortName);
                    }
                    int ind_port_list = cb_ports.Items.IndexOf(port.PortName);
                    cb_ports.SelectedItem = cb_ports.Items[ind_port_list];
                    DrawPortToChart(port, pm24, true);
                    //if (pm24)
                    //{
                    //    chart1 = chart;
                    //     comboBox1=cb_line;
                    //     comboBox3=cb_ports ;
                    //}
                    //else
                    //{
                    //    chart2 = chart;
                    //    comboBox2 = cb_line;
                    //    comboBox4 = cb_ports;
                    //}
                }

                for (int i = 0; i <cb_line.Items.Count; i++)
                {
                    if (chart.Series.Count != 0)
                        if (chart.Series[0].ChartType.ToString() == cb_line.Items[i].ToString())
                            cb_line.SelectedItem = cb_line.Items[i];
                }
                
            }
        		
        	catch(Exception ex)
        	{
        		MessageBox.Show(ex.Message, "DrawChart Method");
        	}
        }

        /// <summary>
        /// clear current chart and draw new from port
        /// </summary>
        /// <param name="port"></param>
        /// <param name="pm24"></param>
        private void DrawPortToChart(NE.Port port, bool pm24, bool ClearPrevSerias)
        {
            try
            {
                ref Chart chart = ref chart1;
                ref ComboBox cb_line = ref comboBox1;
                ref ComboBox cb_ports = ref comboBox3;
                // ComboBox cb_line, cb_ports;
                if (pm24)
                {
                    chart = ref chart1;
                    cb_line = ref comboBox1;
                    cb_ports = ref comboBox3;
                }
                else
                {
                    chart = ref chart2;
                    cb_line = ref comboBox2;
                    cb_ports = ref comboBox4;
                }
                if (ClearPrevSerias) chart.Series.Clear();

                    #region series s1
                    Series s1 = new Series();
                    s1.ChartArea = "ChartArea1";
                    if (cb_line.SelectedItem != null) s1.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), cb_line.SelectedItem.ToString());
                    else s1.ChartType = SeriesChartType.SplineRange;
                    s1.Color = System.Drawing.Color.Red;
                    s1.CustomProperties = "EmptyPointValue=Zero";
                    s1.Legend = "Legend1";
                    s1.LegendText = "BBE";
                    s1.Name = port.PortName;
                    s1.IsVisibleInLegend = true;
                    s1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                    s1.YValuesPerPoint = 2;
                    s1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    #endregion
                    List<int> bbeList = new List<int>();
                    List<DateTime> dates = new List<DateTime>();
                if(port.Stat_Have_BBE())
                    foreach (var stat in port.Stat)
                    { 
                        bbeList.Add(stat.BBE);
                        dates.Add(stat.Date);
                        s1.Points.AddXY(stat.Date, stat.BBE);
                    }else if(port.Stat_Have_FEBBE())
                {
                    foreach (var stat in port.Stat)
                    {
                        bbeList.Add(stat.FEBBE);
                        dates.Add(stat.Date);
                        s1.Points.AddXY(stat.Date, stat.FEBBE);
                    }
                    s1.LegendText = "FEBBE";
                }

                    //s1.LegendText = port.PortName;
                    chart.Series.Add(s1);
              
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DrawPortToChart Method");
            }
        }
        //TODO display pm15
        private void Display(bool all)
        {        	
          
        	 try
            {
               dataGridView1.Rows.Clear();
                int nNE = BASE.NeList.FindIndex(n => n.NE_Name == listBox1.SelectedItem.ToString());
                int nrow;
                if (nNE != -1 )
                {
                	if(tabControl1.SelectedIndex==1)DrawChart(BASE.GetPM24(),true);
                   else if(tabControl1.SelectedIndex==3) DrawChart(BASE.GetPM15(), false);
                    if (all)
                	foreach (var port in BASE.NeList[nNE].Ports)
                    { 
							if (port.PortName == "fileNotFound")
								continue;
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
                		{ 
                			if (port.PortName == "fileNotFound")
								continue;
                			if (port.HaveError())
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
			 
	//DrawChart(BASE);
		}
    }
}
