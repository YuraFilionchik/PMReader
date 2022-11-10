/*
 * Created by SharpDevelop.
 * User: user
 * Date: 08.01.2020
 * Time: 10:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PMReader
{
	/// <summary>
	/// Description of LogForm.
	/// </summary>
	public partial class LogForm : Form
	{
		public LogForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void AddText(string text)
		{
			tbLog.Text+="\r\n"+DateTime.Now.ToShortTimeString()+" => "+text;
			
		}
		public void ClearForm()
		{
			tbLog.Clear();
		}
	}
}
