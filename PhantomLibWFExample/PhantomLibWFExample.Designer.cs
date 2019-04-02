namespace PhantomLibWFExample
{
    partial class PhantomLibWFExample
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.phantomListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.speed1 = new System.Windows.Forms.Label();
            this.speed2 = new System.Windows.Forms.Label();
            this.speed3 = new System.Windows.Forms.Label();
            this.temperature = new System.Windows.Forms.Label();
            this.battery = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.last_updated_rms = new System.Windows.Forms.Label();
            this.last_updated_data = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sensortype = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.IsSoftShadows = false;
            this.chart1.Location = new System.Drawing.Point(17, 58);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(810, 310);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            // 
            // phantomListBox
            // 
            this.phantomListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.phantomListBox.FormattingEnabled = true;
            this.phantomListBox.Location = new System.Drawing.Point(13, 34);
            this.phantomListBox.Name = "phantomListBox";
            this.phantomListBox.Size = new System.Drawing.Size(163, 576);
            this.phantomListBox.TabIndex = 1;
            this.phantomListBox.SelectedValueChanged += new System.EventHandler(this.phantomListBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Phantoms:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Updated:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sensor type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Module Temperature:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Last speed RMS (channel1):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Last speed RMS  (channel2):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Last speed RMS  (channel3):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Updated:";
            // 
            // speed1
            // 
            this.speed1.AutoSize = true;
            this.speed1.Location = new System.Drawing.Point(175, 108);
            this.speed1.Name = "speed1";
            this.speed1.Size = new System.Drawing.Size(42, 13);
            this.speed1.TabIndex = 10;
            this.speed1.Text = "0 mm/s";
            // 
            // speed2
            // 
            this.speed2.AutoSize = true;
            this.speed2.Location = new System.Drawing.Point(175, 133);
            this.speed2.Name = "speed2";
            this.speed2.Size = new System.Drawing.Size(42, 13);
            this.speed2.TabIndex = 11;
            this.speed2.Text = "0 mm/s";
            // 
            // speed3
            // 
            this.speed3.AutoSize = true;
            this.speed3.Location = new System.Drawing.Point(175, 158);
            this.speed3.Name = "speed3";
            this.speed3.Size = new System.Drawing.Size(42, 13);
            this.speed3.TabIndex = 12;
            this.speed3.Text = "0 mm/s";
            // 
            // temperature
            // 
            this.temperature.AutoSize = true;
            this.temperature.Location = new System.Drawing.Point(175, 58);
            this.temperature.Name = "temperature";
            this.temperature.Size = new System.Drawing.Size(23, 13);
            this.temperature.TabIndex = 13;
            this.temperature.Text = "0 C";
            // 
            // battery
            // 
            this.battery.AutoSize = true;
            this.battery.Location = new System.Drawing.Point(175, 83);
            this.battery.Name = "battery";
            this.battery.Size = new System.Drawing.Size(23, 13);
            this.battery.TabIndex = 15;
            this.battery.Text = "0 V";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Module battery:";
            // 
            // last_updated_rms
            // 
            this.last_updated_rms.AutoSize = true;
            this.last_updated_rms.Location = new System.Drawing.Point(232, 19);
            this.last_updated_rms.Name = "last_updated_rms";
            this.last_updated_rms.Size = new System.Drawing.Size(51, 13);
            this.last_updated_rms.TabIndex = 16;
            this.last_updated_rms.Text = "Updated:";
            // 
            // last_updated_data
            // 
            this.last_updated_data.AutoSize = true;
            this.last_updated_data.Location = new System.Drawing.Point(69, 35);
            this.last_updated_data.Name = "last_updated_data";
            this.last_updated_data.Size = new System.Drawing.Size(51, 13);
            this.last_updated_data.TabIndex = 17;
            this.last_updated_data.Text = "Updated:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sensortype);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.last_updated_rms);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.battery);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.temperature);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.speed3);
            this.groupBox1.Controls.Add(this.speed1);
            this.groupBox1.Controls.Add(this.speed2);
            this.groupBox1.Location = new System.Drawing.Point(207, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 190);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensor Data";
            // 
            // sensortype
            // 
            this.sensortype.AutoSize = true;
            this.sensortype.Location = new System.Drawing.Point(87, 22);
            this.sensortype.Name = "sensortype";
            this.sensortype.Size = new System.Drawing.Size(66, 13);
            this.sensortype.TabIndex = 17;
            this.sensortype.Text = "Sensor type:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chart1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.last_updated_data);
            this.groupBox2.Location = new System.Drawing.Point(207, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(854, 392);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time Domain Data:";
            // 
            // PhantomLibWFExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 625);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.phantomListBox);
            this.Name = "PhantomLibWFExample";
            this.Text = "EI Phantom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PhantomLibWFExample_FormClosing);
            this.Load += new System.EventHandler(this.PhantomLibWFExample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox phantomListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label speed1;
        private System.Windows.Forms.Label speed2;
        private System.Windows.Forms.Label speed3;
        private System.Windows.Forms.Label temperature;
        private System.Windows.Forms.Label battery;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label last_updated_rms;
        private System.Windows.Forms.Label last_updated_data;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label sensortype;
    }
}

