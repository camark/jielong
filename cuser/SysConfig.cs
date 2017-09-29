/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2017-9-28
 * Time: 15:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace cuser
{
	/// <summary>
	/// Description of SysConfig.
	/// </summary>
	public class SysConfig
	{
		public SysConfig()
		{
		}
		
		private List<String> ManNames=new List<String>();
		
		public void LoadPeoples()
		{
			string detailFile=Application.StartupPath+@"\Detail.txt";
			
			if(System.IO.File.Exists(detailFile)){
				using(var reader=new StreamReader(new FileStream(detailFile,FileMode.Open))){
					string line=String.Empty;
					
					while((line=reader.ReadLine())!=null){
						if(!String.IsNullOrEmpty(line)){
							ManNames.Add(line);
						}
					}
				}
			}
		}
		
		public void EmptyPeoples(){
			ManNames.Clear();
		}
		
		public void AddPeople(string peoplename){
			ManNames.Add(peoplename);
		}
		
		public void WritePeoples()
		{
			string detailFile=Application.StartupPath+@"\Detail.txt";
			using(var reader=new StreamWriter(new FileStream(detailFile,FileMode.OpenOrCreate)))
			{
				foreach(var s in ManNames){
					reader.WriteLine(s);
				}
			}
		}
		
		public List<String> Peoples{
			get{
				return ManNames;
			}
			set{
				ManNames.Clear();
				
				foreach(String s in value){
					ManNames.Add(s);
				}
			}
		}
	}
}
