/*
 * Created by SharpDevelop.
 * User: fungchu
 * Date: 2014/11/8
 * Time: 下午 05:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace countdown
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int mini,seci,minp,secp,pause=0;
		System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Application.StartupPath+"\\music.wav");
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
		
		void count(int min,int sec)
		{
			if(pause==0)
			{
				button2.Visible=true;
			}
			button1.Enabled=false;
			for(mini=min;mini>=0;mini--)
			{
				//MessageBox.Show(Convert.ToString(mini));  //debug
					
				minlabel.Text=Convert.ToString(mini);
				for(seci=sec;seci>=0;seci--)
				{
					//MessageBox.Show(Convert.ToString(seci));  //debug
					seclabel.Text=Convert.ToString(seci);
					Application.DoEvents();
					Thread.Sleep(1000);

				}
				sec=59;
				}
			if(pause==0 || pause==2)
				{
					button3.Visible=false;
					button2.Visible=false;
					button1.Enabled=true;
				}
			
			if(pause==0)
				{
					sp.Play();
					MessageBox.Show("時間到了喔!!","鈴鈴鈴!!");	
				}
		}
		
		void Button1Click(object sender, EventArgs e)
		{	
			
			int min,sec;
			try
			{	
				if(minbox.Text=="")
				{
					min=0;
				}
				else
				{
					min=Convert.ToInt32(minbox.Text);
				}
				if(secbox.Text=="")
				{
					sec=0;
				}
				else
				{
					sec=Convert.ToInt32(secbox.Text);
				}
				if(sec>=60)
				{
					MessageBox.Show("懶惰鬼!!秒數不會自己換算一下喔....","Hey You!!!!");
					min+=sec/60;
					sec%=60;
				}
				count(min,sec);
				
				
								
			} 
			catch (Exception)
			{
				
				MessageBox.Show("哎哎哎!!!輸入的格式有誤喔","哎哎哎!!!");
				button1.Enabled=true;
				button2.Visible=false;				
				//throw;
			}
			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			if(pause==0)
			{
				minp=mini;
				secp=seci;
				mini=0;
				seci=0;
				pause=1;
				button2.Text="繼續";
				button3.Visible=true;
				button1.Enabled=false;
			}
			else
			{
				mini=minp;
				seci=secp;
				pause=0;
				button2.Text="暫停";
				button3.Visible=false;
				count(minp,secp);
			}
			
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			pause=2;
			mini=0;
			seci=0;
			minlabel.Text=Convert.ToString(0);
			seclabel.Text=Convert.ToString(0);
			button3.Visible=false;
			button2.Visible=false;
			Application.DoEvents();			
			button2.Text="暫停";
			pause=0;
			button1.Enabled=true;
			
			
		}
	}
}
