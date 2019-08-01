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
        private int c_pm24;//count of pm24 files
        private int c_pm15;//count of pm15 files
        DateTime FromDate, ToDate;
        DateTime dateNow = DateTime.Now.Date;
        private string DirLocal = Properties.Settings.Default.PM_Path_Local;
        private ParameterizedThreadStart readFtpThread1;
        private ParameterizedThreadStart readFtpThread2;
        BaseNE BASE=new BaseNE(); //база элементов NE
        const string pm24Dir="pm24Dir";
        const string pm15Dir="pm15Dir";
        const string dom100 = "emlDom_100";
        const string dom101 = "emlDom_101";
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
            c_pm15=0;
            c_pm24=0;
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
            BASE.AddingNE+= AddItemToListbox;//подписка на событие добавления нового элемента в БД
                    
                    }
            catch (Exception)
            {
                
                throw;
            }
           
           
        }

        private void AddItemToListbox(string name)
        {
            consts.AddItemToListBox(listBox1, name);
        }
        //TODO1 thread for Display
        //TODO COLOR and error counter for items in listbox1
        //TODO3 context menu READ stat for selected NE in listbox1
        //SELECT PORT
        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var c = (ComboBox)sender;
            DrawPortToChart(BASE.GetPM24().First(x=>x.NE_Name==listBox1.SelectedItem.ToString()).
                Ports.First(p=>p.PortName==c.SelectedItem.ToString()),true,true);
          
        }
        //SELECT PORT
        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var c = (ComboBox)sender;
            DrawPortToChart(BASE.GetPM15().First(x => x.NE_Name == listBox1.SelectedItem.ToString()).
                Ports.First(p => p.PortName == c.SelectedItem.ToString()), true, true);
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
        //переключение вкладок
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
            int nNe;
            if (tabControl1.SelectedIndex == 0 && (listBox1.SelectedItems.Count != 0))
            {
                nNe= BASE.NeList.FindIndex(n => n.NE_Name == listBox1.SelectedItem.ToString()
                                           && !n.ISPM15);
                DrawDataGrid(nNe,true,checkBox1.Checked);
            }
            else if (tabControl1.SelectedIndex == 2 && (listBox1.SelectedItems.Count != 0))
            {
                nNe = BASE.NeList.FindIndex(n => n.NE_Name == listBox1.SelectedItem.ToString()
                                            && n.ISPM15);
                DrawDataGrid(nNe, false, checkBox1.Checked);
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
	c_pm15=0;
	c_pm24=0;
                BASE=new BaseNE(); //Base of NE
                    BASE.AddingNE += AddItemToListbox;

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
        /// <summary>
        /// Check existing local file
        /// </summary>
        /// <param name="Dom">name of dom directory</param>
        /// <param name="DateDir">name of Date directory</param>
        /// <param name="typePM">name typePM directory (pm24 or pm15)</param>
        /// <param name="fileName">shot file name</param>
        /// <returns></returns>
        public bool ExistLocalFile(string Dom,string DateDir, string typePM, string fileName)
        {
            
			string filePath = Properties.Settings.Default.PM_Path_Local + "\\" +
			                     			 Dom+"\\"+ DateDir + "\\"+typePM+"\\" + fileName;
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
                //dom100/date/Dir24pm/file
               c_pm24=0;
               c_pm15=0;
                string oldBut = button2.Text;
                Invoke(new Action<string>(s => button2.Text = s), "Идет процесс анализа локальных файлов...");
                Invoke(new Action<bool>(s => button2.Enabled = s), false);
                    Invoke(new Action<bool>(s => button1.Enabled = s), false);
                    string PM_path_Local = (string)O;
                string dom100_path = PM_path_Local + "\\" + dom100;
                string dom101_path = PM_path_Local + "\\" + dom101;
                ReadLocalDOM(dom100_path);
                ReadLocalDOM(dom101_path);
                Invoke(new Action<bool>(s => button2.Enabled = s), true);
                Invoke(new Action<bool>(s => button1.Enabled = s), true);
                Invoke(new Action<string>(s => button2.Text = s), oldBut);
             string text = "Прочитано файлов pm24= "+c_pm24.ToString()+" и pm15= "+c_pm15+
                            	". Всего ="+(c_pm24+c_pm15).ToString();
                            Invoke(new Action<string>(s => label4.Text = s), text);
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), ex.Message);
            }
            
            
        }
        public void ReadAndCopyFiles(object O)
        {
string oldBut = button1.Text;
            try
            {
                mutexObj.WaitOne();//wait until read dom100
                
                Invoke(new Action<string>(s => button1.Text = s), "Идет процесс анализа...");
                Invoke(new Action<bool>(s => button1.Enabled = s), false);
                Invoke(new Action<bool>(s => button2.Enabled = s), false);
                Invoke(new Action<bool>(s => listBox1.Enabled = s), false);
                string PM_path_server = (string)O;
                string currentDOM = "";
                if (PM_path_server.Split('\\').Last() == dom100) currentDOM = dom100;
                else currentDOM = dom101;
                FtpClient client = new FtpClient();
                del Mydel = n => listBox1.Items.Add(n);
                int nNE;


                //Задаём параметры клиента.
                client.PassiveMode = true; //Включаем пассивный режим.
                int TimeoutFTP = 30000; //Таймаут.
                //string FTP_SERVER = Properties.Settings.Default.ftp_Address;
                string FTP_SERVER = "127.0.0.1";
                //int FTP_PORT = Properties.Settings.Default.ftp_Port; 
                int FTP_PORT= 21;
                string FTP_USER = Properties.Settings.Default.ftp_User;
                string FTP_PASSWORD = Properties.Settings.Default.ftp_Pass;

                //Подключаемся к FTP серверу.
                Ping p = new Ping();
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
                if (listftp.Count() == 0)
                {
                    //    MessageBox.Show("В каталоге " + PM_path_server+" ничего нет", "GetDirectoryList");
                    Invoke(new Action<string>(s => button1.Text = s), oldBut);
                    Invoke(new Action<bool>(s => button1.Enabled = s), true);
                    Invoke(new Action<bool>(s => button2.Enabled = s), true);
                    Invoke(new Action<bool>(s => listBox1.Enabled = s), true);
                    Thread.CurrentThread.Abort();
                }
                ReadPM pm24;
                NE NEstat;
                DateTime DirDate;
                int countErr = 0;
                string text;//строка отчета о количестве папок
             //перебор всех папок DirDate
                foreach (var ftpItem in listftp)
                {
                    //перевод названия папки в дату    
                    if (ftpItem.ItemType != FtpItemType.Directory) continue;
                    Invoke(new Action<int>(s => nDirsAll += s), 1);
                    if (!DateTime.TryParseExact(ftpItem.Name, "yyyyMMdd", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out DirDate))
                    {
                        countErr += 1;
                        continue;
                    }
                    if (countErr != 0) MessageBox.Show("Пропущено " + countErr + " папок при чтении с сервера");


                    //фильтр папок по дате
                    if (DirDate.Date > FromDate.Date && (DirDate.Date + new TimeSpan(1, 0, 0, 0)) <= ToDate.Date)
                    {
                        //    MessageBox.Show("папка " + ftpItem.Name + " прошла фильтр времени");
                        Invoke(new Action<int>(s => nDirs += s), 1);
                        //copy Directories from server
                        if (!Directory.Exists(DirLocal)) Directory.CreateDirectory(DirLocal);
                        //пропуск существующих кроме последней
                        // if (localdirs.Contains(DirDate.ToString("yyyyMMdd")) && localdirs.Last()!=DirDate.ToString("yyyyMMdd")) continue;
                        var dirInfo = Directory.CreateDirectory(DirLocal + "/"+currentDOM+"/" + ftpItem.Name);//date dir

                        client.ChangeDirectory(TimeoutFTP, ftpItem.Name);//переход в директорию DirDate


                        string dir24pm = ""; //имя промежуточной папки
                        string dir15pm = "";
                        var listDir = client.GetDirectoryList(TimeoutFTP);

                        foreach (var dir in listDir)
                        {
                            if (dir.Name ==pm24Dir)
                            {
                                dir24pm = pm24Dir;
                                Directory.CreateDirectory(dirInfo.FullName + "/" + dir24pm);
                            }

                            if (dir.Name == pm15Dir)
                            {
                                dir15pm = pm15Dir;
                                Directory.CreateDirectory(dirInfo.FullName + "/" + dir15pm);
                            }
                        }
                        FtpItem[] Files;
                        string DestDir15 = DirLocal + "/" //pm
                                    + currentDOM + "/" +                     //dom100
                                    dirInfo.Name + "/" +                  //dateDir
                                    pm15Dir + "/";                          //Dir15pm

                        string DestDir24 = DirLocal + "/" //pm
                            + currentDOM + "/" +                     //dom100
                            dirInfo.Name + "/" +                  //dateDir
                            pm24Dir + "/";
                        //read files pm24
                        if (!String.IsNullOrWhiteSpace(dir24pm))
                        {
                            client.ChangeDirectory(TimeoutFTP, dir24pm);//зашли в папку ~PM24dir ~
                            Files = client.GetDirectoryList(TimeoutFTP); //список файлов статистики
                            foreach (var file in Files)
                            {//заносим инфу из каждого файла в структуру BASE
                                #region look local files
                                // skip existing local files
                               if (ExistLocalFile(currentDOM, ftpItem.Name, pm24Dir, file.Name))
                                {
                                   BASE.AddNE(new ReadPM(DestDir24, file.Name));
                                    continue;
                                }
                                #endregion
                                if (file.Size == -1) continue;
                                Invoke(new Action<int>(s => nFiles += s), 1);
                                //copy file from server to local Dir
                                client.GetFile(TimeoutFTP, DestDir24 + file.Name, file.Name);
                                pm24 = new ReadPM(DestDir24, file.Name);//считали и проанализировали локальный файл
                                BASE.AddNE(pm24);//add to base
								c_pm24++;
                            }
                            client.ChangeDirectoryUp(TimeoutFTP);//in dirdate
                        }
                        //now into a Dirdate
                        //read files pm15
                        if (!String.IsNullOrWhiteSpace(dir15pm))
                        {
                           client.ChangeDirectory(TimeoutFTP, dir15pm);//зашли в папку ~PM15dir ~
                                Files = client.GetDirectoryList(TimeoutFTP); //список файлов статистики
                                foreach (var file in Files)
                                {//заносим инфу из каждого файла в структуру BASE
                                    #region look local files
                                    // skip existing local files
                                    if (ExistLocalFile(currentDOM, ftpItem.Name, dir15pm, file.Name))
                                    {
                                        BASE.AddNE(new PM15(DestDir15 + file.Name));
                                        continue;
                                    }

                                    #endregion
                                    if (file.Size == -1) continue;
                                    Invoke(new Action<int>(s => nFiles += s), 1);
                                    //copy file from server to local Dir
                                    client.GetFile(TimeoutFTP, DestDir15 + file.Name, file.Name);
                                    var pm15 = new PM15(DestDir15 + file.Name);//считали и проанализировали локальный файл
                                    BASE.AddNE(pm15);//add to base
									c_pm15++;
                                }
                                client.ChangeDirectoryUp(TimeoutFTP);//in dirdate

                            
                           // client.ChangeDirectoryUp(TimeoutFTP);//in dom100
                            text = "Обработано файлов: " + nFiles+
                            	"; Скопировано с сервера="+c_pm24.ToString()+"pm24 и ="+c_pm15+
                            	"pm15. Всего ="+(c_pm24+c_pm15).ToString();
                            Invoke(new Action<string>(s => label4.Text = s), text);

                        }//if (pm15dir exist)
                        client.ChangeDirectoryUp(TimeoutFTP);//up from dirdate
                    } //Filter DATE
                } //foreach DirDates
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
                 Invoke(new Action<string>(s => button1.Text = s), oldBut);
                    Invoke(new Action<bool>(s => button1.Enabled = s), true);
                    Invoke(new Action<bool>(s => button2.Enabled = s), true);
                    Invoke(new Action<bool>(s => listBox1.Enabled = s), true);
                mutexObj.ReleaseMutex();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
                {
                    nFiles = 0; //количество обработанных файлов
                    nDirs = 0;//количество обработанных папок
                    nDirsAll = 0;
                    count = 0;
                    
                    BASE = new BaseNE();
                    BASE.AddingNE +=AddItemToListbox;
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
//TODO get coordinates items and add new lables with count of errors (colorized)
        public void AnalizeListBox()
        {
        	for (int i = 0; i < listBox1.Items.Count; i++) {
				var item = listBox1.Items[i];
				#region get NE
				var NEs = BASE.NeList.Where(x => x.NE_Name == item.ToString());
				int FarEnd = 0;
				int NearEnd = 0;
				if(NEs.Count()!=0) foreach (var ne in NEs)
				{
						FarEnd += ne.FarEndTotal;
						NearEnd += ne.NearTotal;
				}
				#endregion
				var rectItem=listBox1.GetItemRectangle(i);
				var pointLB = listBox1.Location;
				var start_Point = new Point(listBox1.Width+1,rectItem.Location.Y+pointLB.Y);
				var lb = new Label();
					lb.Tag = item.ToString();
					lb.Size=new Size(lb.Size.Width,rectItem.Height-1) ;
				lb.Font = new Font("Times New Roman", 8);
				//var defaultColor = lb.BackColor;
				if(FarEnd!=0||NearEnd!=0)
				lb.BackColor = Color.Orange;
				else {
					lb.BackColor = DefaultBackColor;
					lb.Text = "------";
				}
				if(FarEnd!=0)
				lb.Text = "FE:"+FarEnd.ToString();//count errors
				if(NearEnd!=0)
				lb.Text = "NE:"+NearEnd.ToString();//count errors
				lb.Location = start_Point;
				
				
					this.Controls.Add(lb);
			
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

                Chart chart = pm24 ? chart1 : chart2;
                ComboBox cb_line = pm24? comboBox1:comboBox2;
                ComboBox cb_ports = pm24? comboBox3:comboBox4;
                
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
                Chart chart = pm24 ? chart1 : chart2;
                ComboBox cb_line = pm24 ? comboBox1 : comboBox2;
                ComboBox cb_ports = pm24 ? comboBox3 : comboBox4;
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
                chart.ChartAreas[0].RecalculateAxesScale();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DrawPortToChart Method");
            }
        }
       
        
        /// <summary>
        /// Show stat into Datagrid and Chart
        /// </summary>
        /// <param name="all">Show all items or only with errors</param>
       private void Display(bool all)
        {        	
        	bool pm24=true;
        	 try
            {
        	 	if(tabControl1.SelectedIndex==0) pm24=true;
        	 	else if(tabControl1.SelectedIndex==2) pm24=false;
               int nNE = BASE.NeList.FindIndex(n => n.NE_Name == listBox1.SelectedItem.ToString()
       	                               && n.ISPM15!=pm24);  
        	 	int nrow;
                if (nNE != -1 )
                {
                	if(tabControl1.SelectedIndex==1){
                		DrawChart(BASE.GetPM24(),true);
                        return;//only draw chart
                	}
                	else if(tabControl1.SelectedIndex==3) {
                		DrawChart(BASE.GetPM15(), false); return;//only draw chart
                	}
                	DrawDataGrid(nNE,pm24,all);
                    
                }
                //else MessageBox.Show("Нет данной статистики за выбранный период");

            }
            catch (Exception)
            {
                
                throw;
            }
        }
       public void DrawDataGrid(int nNe,bool pm24, bool all)
       {
       	
       	if(pm24) {
       		dataGridView1.Rows.Clear();
       	}else{
       		dataGridView2.Rows.Clear();
       	}
//                int nNE = BASE.NeList.FindIndex(n => n.NE_Name == listBox1.SelectedItem.ToString()
//       	                               && n.ISPM15!=pm24);
                int nrow;
                if (nNe != -1 )
                {  
                	
                	foreach (var port in BASE.NeList[nNe].Ports)
                    { 
							if (port.PortName == "fileNotFound")
								continue;
							if(!all && !port.HaveError()) continue;
							nrow=pm24?dataGridView1.Rows.Add():dataGridView2.Rows.Add();
							if(pm24){
                        dataGridView1.Rows[nrow].Cells["ports"].Value = port.PortName;
                        dataGridView1.Rows[nrow].DefaultCellStyle.BackColor = Color.BlanchedAlmond;
                        }
                        else
                        {
                        dataGridView2.Rows[nrow].Cells["ports15"].Value = port.PortName;
                        dataGridView2.Rows[nrow].DefaultCellStyle.BackColor = Color.BlanchedAlmond;
                        }
                        foreach (var st in port.Stat)
                        {
                        if (!st.HaveError()) continue;
                        nrow =pm24?dataGridView1.Rows.Add():dataGridView2.Rows.Add();
                       
                            if (pm24)
                            {
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
                            else 
                            {
                            dataGridView2.Rows[nrow].DefaultCellStyle.BackColor = Color.Honeydew;
                            dataGridView2.Rows[nrow].Cells["date15"].Value = st.Date.ToShortDateString()+"--"+st.Date.ToShortTimeString();
                            dataGridView2.Rows[nrow].Cells["BBE15"].Value = st.BBE;
                            dataGridView2.Rows[nrow].Cells["ES15"].Value = st.ES;
                            dataGridView2.Rows[nrow].Cells["SES15"].Value = st.SES;
                            dataGridView2.Rows[nrow].Cells["NEUAS15"].Value = st.NEUAS;
                            dataGridView2.Rows[nrow].Cells["FEBBE15"].Value = st.FEBBE;
                            dataGridView2.Rows[nrow].Cells["FEES15"].Value = st.FEES;
                            dataGridView2.Rows[nrow].Cells["FESES15"].Value = st.FESES;
                            dataGridView2.Rows[nrow].Cells["FEUAS15"].Value = st.FEUAS;
                            }

                            
                            
                        }
                         nrow=pm24?dataGridView1.Rows.Add():dataGridView2.Rows.Add();
                         if(pm24)dataGridView1.Rows[nrow].DefaultCellStyle.BackColor = Color.Indigo;
                         else dataGridView2.Rows[nrow].DefaultCellStyle.BackColor = Color.Indigo;
                }
                	
                    
                    }
               // else MessageBox.Show("DrawDataGrid","Ошибка выбора listbox");
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
        public void ReadLocalDirDateFiles(string dateDir_path)
        {
            string Dir24pm, Dir15pm;
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
            string[] Files24 = String.IsNullOrWhiteSpace(Dir24pm)?new string[0]:Directory.GetFiles(Dir24pm); //список файлов статистики
            string[] Files15 = String.IsNullOrWhiteSpace(Dir15pm) ? new string[0] : Directory.GetFiles(Dir15pm); //список файлов статистики
            #region read24 files
            if (!String.IsNullOrWhiteSpace(Dir24pm)&& Files24.Any())
            { 
                Invoke(new Action<int>(s => nFiles += s), Files24.Count());
                ReadPM pm24;
                foreach (var File in Files24)
                { //перебор файлов в конечной папке//заносим инфу из каждого файла в структуру BASE
                    var file = File.Split('\\').Last();
                    pm24 = new ReadPM(Dir24pm, file);//считали и проанализировали локальный файл
                    BASE.AddNE(pm24);
                        c_pm24++;
                }
            }
            #endregion
            #region read15 files
            if (!String.IsNullOrWhiteSpace(Dir15pm)&& Files15.Any())
            {
                Invoke(new Action<int>(s => nFiles += s), Files15.Count());
                PM15 pm15;

                foreach (var File in Files15)
                { //перебор файлов в конечной папке//заносим инфу из каждого файла в структуру BASE
                    pm15 = new PM15(File);//считали и проанализировали локальный файл
					BASE.AddNE(pm15);
						c_pm15++;
                }
            }
            #endregion
        }

        /// <summary>
        /// read all files from dom100 or dom101 with subdirs into BASE
        /// </summary>
        /// <param name="dom">full path of dom100 or dom101</param>
        public void ReadLocalDOM(string dom)
        {
            if (!Directory.Exists(dom)) return;
            var LocalDirDates = Directory.GetDirectories(dom);
            if (LocalDirDates.Count() != 0)
            {
                DateTime DirDate;
                int countErr = 0;
                string text;//строка отчета о количестве папок;

                //перебор всех локальных папок date в DOM
                foreach (var dateDir_path in LocalDirDates)
                {
                    var ftpItem = dateDir_path.Split('\\').Last();
                    //перевод названия папки в дату    
                    //if (ftpItem.ItemType != FtpItemType.Directory) continue;
                    Invoke(new Action<int>(s => nDirsAll += s), 1);
                    if (!DateTime.TryParseExact(ftpItem, "yyyyMMdd", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out DirDate))
                    {
                        countErr += 1;
                        continue;
                    }

                    //фильтр папок по дате
                    if (DirDate.Date > FromDate.Date && (DirDate.Date + new TimeSpan(1, 0, 0, 0)) <= ToDate.Date)
                    {
                        Invoke(new Action<int>(s => nDirs += s), 1);
                        ReadLocalDirDateFiles(dateDir_path);
                        text = "Найдено " + nDirsAll + "локальных папок; Отфильтровано по дате " + nDirs +
                                      "; Обработано файлов: " + nFiles;
                        Invoke(new Action<string>(s => label4.Text = s), text);

                    }
                }

                if (countErr != 0) MessageBox.Show("Пропущено " + countErr + " локальных папок при чтении ", "ошибка распознавание даты в имени папки");
                //Invoke(new Action<string>(s => button2.Text = s), oldBut);
                

            }
            else
            {
                // Invoke(new Action<string>(s => button2.Text = s), oldBut);
                
                MessageBox.Show("папка " + dom + " не содержит подпапок с файлами");
                
            }
        }
		void Form1Load(object sender, EventArgs e)
		{
	
		}
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
	
		}
		void Button3Click(object sender, EventArgs e)
		{
			AnalizeListBox();
		}
    }
}
