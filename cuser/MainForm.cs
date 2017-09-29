/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2017-9-28
 * Time: 14:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace cuser
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private SysConfig _config=new SysConfig();
		public List<string> default_ManNames=new List<string>{
			  "王子昊",
			  "朱鑫如",
			  "焦玉涛",
			  "陈田格",
			  "张慧欣",
			  "黄飞雪",
			  "王昊昕",
			  "胡文琦",
			  "刘广娜",
			  "吕凭越",
			  "孙伟根",
			  "张广哲",
			  "于芳潇",
			  "袁小豹",
			  "张紫萱",
			  "孙昊强",
			  "陈芝言",
			  "孙豪伟",
			  "张梓茗",
			  "向益萱",
			  "徐路尧",
			  "张雪儿",
			  "李梓轩",
			  "邵晓玮",
			  "高正麒",
			  "王沐岳",
			  "田朋霏",
			  "田兆玉",
			  "陈子涵",
			  "朱钊莹",
			  "任宏达",
			  "徐祥轩",
			  "马钰泽",
			  "高丫茹",
			  "祁昊泽",
			  "张玉洁",
			  "刘浩宇",
			  "刘泽凯",
			  "王雅杰",
			  "方玉芳菲",
			  "蒋一飞",
			  "杨京儒",
			  "苑舒琪",
			  "田曦雅",
			  "巩宸羽",
			  "李佳",
			  "张一凡",
		};
		void Button1Click(object sender, EventArgs e)
		{
			string strJielong=textBox1.Text.Trim();
			
			int i_uncomp=0;
			
			if(strJielong.Length>0)
			{
				listView1.Items.Clear();
				foreach(String s in _config.Peoples)
				{
					if(strJielong.IndexOf(s)==-1){
						ListViewItem item=new ListViewItem();
						
						item.Text=s;
						item.SubItems.Add("未完成");
						
						listView1.Items.Add(item);
						
						i_uncomp++;
					}
				}
				
				msgLabel.Text="当前有"+i_uncomp.ToString()+@"名同学没有完成!";
			}
			else{
				MessageBox.Show("接龙名单为空，请首先粘贴接龙名单!","信息",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			_config.LoadPeoples();
		}
		void Button2Click(object sender, EventArgs e)
		{
			var cfg=new ConfigPeople{
				Names=_config.Peoples.ToArray()
			};
			
			if(cfg.ShowDialog()==DialogResult.OK){
				_config.EmptyPeoples();
				foreach(var s in cfg.Names){
					if(!String.IsNullOrEmpty(s)){
						_config.AddPeople(s);
					}
				}
			}
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			_config.WritePeoples();
		}
	}
}
