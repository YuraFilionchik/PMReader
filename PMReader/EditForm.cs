/*
 * Created by SharpDevelop.
 * User: user
 * Date: 29.07.2021
 * Time: 11:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PMReader
{
	/// <summary>
	/// Description of EditForm.
	/// </summary>
	public partial class EditForm : Form
	{
		public string Label="";
		public EditForm(string label)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Label=label;
			textBox1.Text=label;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtOKClick(object sender, EventArgs e)
		{
			Label=textBox1.Text;
			this.Close();
		}
	}
}
