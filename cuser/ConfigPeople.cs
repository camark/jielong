/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2017-9-28
 * Time: 15:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ExcelDataReader;
using System.Data;

namespace cuser
{
	/// <summary>
	/// Description of ConfigPeople.
	/// </summary>
	public partial class ConfigPeople : Form
	{
		public ConfigPeople()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public string[] Names{
			get{
				return textBox1.Lines;
			}
			set{
				textBox1.Lines=value;
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			if(openFileDialog1.ShowDialog()==DialogResult.OK){
				var filePath=openFileDialog1.FileName;
				
				try{
				using(FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
				{
				//1. Reading from a binary Excel file ('97-2003 format; *.xls)
					IExcelDataReader excelReader;
					if(filePath.EndsWith(".xls")){
						excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
					}
					//...
					//2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
					else
					{
						excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
					}
					//...
					//3. DataSet - The result of each spreadsheet will be created in the result.Tables
					//DataSet result = excelReader.AsDataSet();
					//...
					//4. DataSet - Create column names from first row
					//excelReader. = chb_FirstColumn.Checked;
					
					//DataSet result = excelReader.
					
					//5. Data Reader methods
					if(chb_FirstColumn.Checked){
						excelReader.Read();
					}
					
					textBox1.Text=String.Empty;
					while (excelReader.Read())
					{
						textBox1.Text+=excelReader.GetString(0)+Environment.NewLine;
					}
					
					//6. Free resources (IExcelDataReader is IDisposable)
					excelReader.Close();
				}
				}catch(Exception ex){
					MessageBox.Show("导入Excel错误,错误原因:"+ex.Message);
				}
			}
		}
	}
}
