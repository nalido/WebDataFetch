namespace WebFetch
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btn_fetch = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_timer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_count = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.OnTimer);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(13, 36);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(874, 828);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.Url = new System.Uri("http://www.aqistudy.cn/", System.UriKind.Absolute);
            // 
            // btn_fetch
            // 
            this.btn_fetch.Location = new System.Drawing.Point(554, 9);
            this.btn_fetch.Name = "btn_fetch";
            this.btn_fetch.Size = new System.Drawing.Size(90, 20);
            this.btn_fetch.TabIndex = 4;
            this.btn_fetch.Text = "采集表格数据";
            this.btn_fetch.UseVisualStyleBackColor = true;
            this.btn_fetch.Click += new System.EventHandler(this.btn_fetch_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(750, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(86, 21);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "采集周期(s)";
            // 
            // btn_timer
            // 
            this.btn_timer.Location = new System.Drawing.Point(652, 9);
            this.btn_timer.Name = "btn_timer";
            this.btn_timer.Size = new System.Drawing.Size(90, 20);
            this.btn_timer.TabIndex = 6;
            this.btn_timer.Text = "打开定时采集";
            this.btn_timer.UseVisualStyleBackColor = true;
            this.btn_timer.Click += new System.EventHandler(this.btn_timer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "已采集次数：";
            // 
            // label_count
            // 
            this.label_count.AutoSize = true;
            this.label_count.Location = new System.Drawing.Point(99, 12);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(11, 12);
            this.label_count.TabIndex = 7;
            this.label_count.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(839, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "秒";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(419, 9);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(126, 20);
            this.btn_refresh.TabIndex = 9;
            this.btn_refresh.Text = "更换城市后点此刷新";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 876);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_timer);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btn_fetch);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Form1";
            this.Text = "网页数据采集（开发：nalido）";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btn_fetch;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_count;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_refresh;
    }
}

