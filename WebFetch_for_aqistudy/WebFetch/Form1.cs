using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Configuration;
using System.Net;
using System.Xml;
using System.Text.RegularExpressions;

namespace WebFetch
{
    public partial class Form1 : Form
    {
        public int flag = 0;
        public int timer_state = 0; //0=off  1=on
        public int count = 0; //采集次数
        
        public Form1()
        {
            InitializeComponent();
            this.timer1.Enabled = false;
            count = 0;
            flag = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //WebBrowser web = this.webBrowser1;
            //string url = @"https://" + this.textBox1.Text;
            //try
            //{
            //    web.Navigate(url);
            //    web.ScrollBarsEnabled = true;
            //}catch
            //{
            //    MessageBox.Show("网址输入格式错误，请重新输入");
            //}
            //flag = 1;
        }

        private void OnTimer(object sender, EventArgs e)
        {
            fetch();
        }// end of OnTimer

        //获取网页源代码
        public void fetch()
        {
            WebBrowser web = this.webBrowser1;
            if (timer_state == 1)
            {
                web.Refresh();
                flag = 1;
            }

            if (flag == 1) //确定已打开正确网页
            {
                /*检测table中是否有元素来检测js是否执行完成*/
                File.Delete("html.txt");

                HtmlWindowCollection htmlwc = web.Document.Window.Frames; //获取所有iframe框架
                foreach (HtmlWindow win in htmlwc)
                {
                    if (win.Document.Body != null) //记录第一层iframe框架
                    {
                        HtmlDocument hdc = win.Document;
                        foreach (HtmlElement element in hdc.Body.All)
                        {
                            if (element.TagName.ToLower().Equals("table")) //find table
                            {
                                foreach (HtmlElement child in element.All) //find the special element
                                {
                                    string id = child.GetAttribute("id").ToLower();
                                    if (id == "datagrid-row-r1-2-0") //第一行的id存在说明js已执行
                                    {
                                        string htmlStr = win.Document.Body.InnerHtml;
                                        htmlStr = htmlStr.Replace("\r\n", "");
                                        File.AppendAllText("html.txt", htmlStr);
                                        flag = 2;
                                        process(htmlStr);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //正则表达式分析网页
        public void process(string htmlStr)
        {
            string regexStr = "(?'监测点'(?<=SPAN\\stitle=)\\w+)(?:.*?datagrid-cell-c1-aqi.*?>)(?'AQI'\\d+)(?:.*?datagrid-cell-c1-quality.*?>)(?'质量等级'\\w)(?:.*?datagrid-cell-c1-pm2_5.*?>)(?'PM2_5'\\d+)(?:.*?datagrid-cell-c1-pm10.*?>)(?'PM10'\\d+)(?:.*?datagrid-cell-c1-co.*?>)(?'CO'\\d+\\.?\\d+)(?:.*?datagrid-cell-c1-no2.*?>)(?'NO2'\\d+)(?:.*?datagrid-cell-c1-o3.*?>)(?'O3'\\d+)(?:.*?datagrid-cell-c1-so2.*?>)(?'SO2'\\d+)(?:.*?c1-primary_pollutant.*?>)(?'首要污染物'.*?(?=<))";
            string regexStr_city = "(?'城市'(?<=class=cityinput\\svalue=)\\w+)";
            string regexStr_time = "(?'时间'(?<=id=timeSpan.*?>)\\w+(?=\\s实时空气质量))";


            //get city and time
            Regex reg_city = new Regex(regexStr_city);
            Match m_city = reg_city.Match(htmlStr);
            string str_city = m_city.Groups[1].ToString();
            Regex reg_time = new Regex(regexStr_time);
            Match m_time = reg_time.Match(htmlStr);
            string str_time = m_time.Groups[1].ToString();

            //file name
            DateTime dt = DateTime.Now;
            string filename = str_city + ".csv";
            if(!File.Exists(filename)) //若文件不存在，则新建文件并添加表头
            {
                string table_head = "采集时间,数据时间,监测点,AQI,质量等级,PM2.5,PM10,CO,NO2,O3,SO3,首要污染物\r\n";
                File.AppendAllText(filename, table_head);
            }

            //get data
            Regex reg = new Regex(regexStr);
            MatchCollection matches = reg.Matches(htmlStr);
            foreach(Match match in matches)
            {
                string info = dt.ToString("yyyy-MM-dd HH:mm:ss,") + str_time;
                for (int i = 1; i < 11; i++)
                {
                    info = info + "," + match.Groups[i].ToString();
                }
                info += "\r\n";
                File.AppendAllText(filename, info);
            }

            //显示采集次数
            count++;
            this.label_count.Text = count.ToString();
        }

        private void btn_timer_Click(object sender, EventArgs e)
        {
            int p = 0;
            try
            {
                p = int.Parse(this.textBox2.Text);
            }catch
            {
                MessageBox.Show("未输入正确采集周期");
                return;
            }

            timer_state = 1 - timer_state;
            if (timer_state == 1) //当前状态为开
            {
                this.timer1.Interval = p*1000;
                this.btn_timer.Text = "关闭定时采集";
                this.timer1.Enabled = true;
            }
            else
            {
                this.btn_timer.Text = "打开定时采集";
                this.timer1.Enabled = false;
            }
        }

        private void btn_fetch_Click(object sender, EventArgs e)
        {
            flag = 1;  //状态退回到刚打开网页的状态
            fetch();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            WebBrowser web = this.webBrowser1;
            web.Refresh();
        }

    }
}

