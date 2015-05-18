namespace Kannel_Informer_v2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Хост = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ConsoleOut = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.originator = new System.Windows.Forms.TextBox();
            this.portint = new System.Windows.Forms.TextBox();
            this.ip = new System.Windows.Forms.TextBox();
            this.from = new System.Windows.Forms.TextBox();
            this.text = new System.Windows.Forms.TextBox();
            this.to = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 186);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 28);
            this.button2.TabIndex = 33;
            this.button2.Text = "Время в текст";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "От:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Сообщение:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Телефон:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 186);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 24;
            this.button1.Text = "Отправить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Хост,
            this.Column9});
            this.dataGridView1.Location = new System.Drawing.Point(3, 234);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1351, 340);
            this.dataGridView1.TabIndex = 34;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "№";
            this.Column1.Name = "Column1";
            this.Column1.Width = 47;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Тип";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Статус";
            this.Column3.Name = "Column3";
            this.Column3.Width = 78;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Ответ от провайдера";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Отправитель";
            this.Column5.Name = "Column5";
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Получатель";
            this.Column6.Name = "Column6";
            this.Column6.Width = 112;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "Время";
            this.Column7.Name = "Column7";
            this.Column7.Width = 75;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.HeaderText = "Идентификатор SMS";
            this.Column8.Name = "Column8";
            this.Column8.Width = 157;
            // 
            // Хост
            // 
            this.Хост.HeaderText = "Хост";
            this.Хост.Name = "Хост";
            this.Хост.Visible = false;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column9.HeaderText = "Время отчета";
            this.Column9.Name = "Column9";
            this.Column9.Width = 114;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // ConsoleOut
            // 
            this.ConsoleOut.BackColor = System.Drawing.Color.Black;
            this.ConsoleOut.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConsoleOut.ForeColor = System.Drawing.Color.Lime;
            this.ConsoleOut.Location = new System.Drawing.Point(520, 0);
            this.ConsoleOut.Margin = new System.Windows.Forms.Padding(4);
            this.ConsoleOut.Multiline = true;
            this.ConsoleOut.Name = "ConsoleOut";
            this.ConsoleOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleOut.Size = new System.Drawing.Size(832, 226);
            this.ConsoleOut.TabIndex = 35;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "IP сервера:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(368, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Порт подключения:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(368, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 17);
            this.label7.TabIndex = 40;
            this.label7.Text = "Отправитель:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(368, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 17);
            this.label8.TabIndex = 42;
            this.label8.Text = "Логин:";
            // 
            // pass
            // 
            this.pass.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Kannel_Informer_v2.Properties.Settings.Default, "pass", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pass.Location = new System.Drawing.Point(369, 204);
            this.pass.Margin = new System.Windows.Forms.Padding(4);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(143, 22);
            this.pass.TabIndex = 45;
            this.pass.Text = global::Kannel_Informer_v2.Properties.Settings.Default.pass;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(368, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 44;
            this.label9.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 46;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // user
            // 
            this.user.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Kannel_Informer_v2.Properties.Settings.Default, "login", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.user.Location = new System.Drawing.Point(369, 162);
            this.user.Margin = new System.Windows.Forms.Padding(4);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(143, 22);
            this.user.TabIndex = 43;
            this.user.Text = global::Kannel_Informer_v2.Properties.Settings.Default.login;
            // 
            // originator
            // 
            this.originator.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Kannel_Informer_v2.Properties.Settings.Default, "originator", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.originator.Location = new System.Drawing.Point(369, 115);
            this.originator.Margin = new System.Windows.Forms.Padding(4);
            this.originator.Name = "originator";
            this.originator.Size = new System.Drawing.Size(143, 22);
            this.originator.TabIndex = 41;
            this.originator.Text = global::Kannel_Informer_v2.Properties.Settings.Default.originator;
            // 
            // portint
            // 
            this.portint.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Kannel_Informer_v2.Properties.Settings.Default, "serverport", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.portint.Location = new System.Drawing.Point(369, 68);
            this.portint.Margin = new System.Windows.Forms.Padding(4);
            this.portint.Name = "portint";
            this.portint.Size = new System.Drawing.Size(143, 22);
            this.portint.TabIndex = 39;
            this.portint.Text = global::Kannel_Informer_v2.Properties.Settings.Default.serverport;
            // 
            // ip
            // 
            this.ip.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Kannel_Informer_v2.Properties.Settings.Default, "serverip", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ip.Location = new System.Drawing.Point(369, 24);
            this.ip.Margin = new System.Windows.Forms.Padding(4);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(143, 22);
            this.ip.TabIndex = 37;
            this.ip.Text = global::Kannel_Informer_v2.Properties.Settings.Default.serverip;
            // 
            // from
            // 
            this.from.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Kannel_Informer_v2.Properties.Settings.Default, "from", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.from.Location = new System.Drawing.Point(93, 24);
            this.from.Margin = new System.Windows.Forms.Padding(4);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(132, 22);
            this.from.TabIndex = 31;
            this.from.Text = global::Kannel_Informer_v2.Properties.Settings.Default.from;
            // 
            // text
            // 
            this.text.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Kannel_Informer_v2.Properties.Settings.Default, "text", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text.Location = new System.Drawing.Point(93, 54);
            this.text.Margin = new System.Windows.Forms.Padding(4);
            this.text.Multiline = true;
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(268, 124);
            this.text.TabIndex = 30;
            this.text.Text = global::Kannel_Informer_v2.Properties.Settings.Default.text;
            this.text.TextChanged += new System.EventHandler(this.text_TextChanged);
            // 
            // to
            // 
            this.to.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Kannel_Informer_v2.Properties.Settings.Default, "tel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.to.Location = new System.Drawing.Point(93, 0);
            this.to.Margin = new System.Windows.Forms.Padding(4);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(268, 22);
            this.to.TabIndex = 26;
            this.to.Text = global::Kannel_Informer_v2.Properties.Settings.Default.tel;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 575);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.originator);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.portint);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ConsoleOut);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.from);
            this.Controls.Add(this.text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.to);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kannel Informer v2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox from;
        private System.Windows.Forms.TextBox text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox to;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox ConsoleOut;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Хост;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox portint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox originator;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;

    }
}

