namespace ClientGUI_v3.UI
{
    partial class DaqUI
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
            this.tbTpsk = new System.Windows.Forms.TextBox();
            this.btnSetTPsk = new System.Windows.Forms.Button();
            this.btnGetTpsk = new System.Windows.Forms.Button();
            this.btnSetAdcConfig = new System.Windows.Forms.Button();
            this.btnGetAdcConfig = new System.Windows.Forms.Button();
            this.btnGetCntConfig = new System.Windows.Forms.Button();
            this.bntSetCntConfig = new System.Windows.Forms.Button();
            this.tbAdcConfig = new System.Windows.Forms.TextBox();
            this.tbCntConfig = new System.Windows.Forms.TextBox();
            this.tbEncConfig = new System.Windows.Forms.TextBox();
            this.btnGetEncConfig = new System.Windows.Forms.Button();
            this.btnSetEncConfig = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.getTbrt = new System.Windows.Forms.Button();
            this.btnSetTbrt = new System.Windows.Forms.Button();
            this.tbTbrt = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnGetDaqDataStartTimer = new System.Windows.Forms.Button();
            this.btnGetDaqDataStopTimer = new System.Windows.Forms.Button();
            this.nudGetDataTimerInterval = new System.Windows.Forms.NumericUpDown();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnOffsetsCount = new System.Windows.Forms.Button();
            this.tbOffsetsNumSamples = new System.Windows.Forms.TextBox();
            this.tbOffsetCountTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDaqOffsetsAbort = new System.Windows.Forms.Button();
            this.btnOffsetsStatus = new System.Windows.Forms.Button();
            this.btnOffsetsGet = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudGetDataTimerInterval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbTpsk
            // 
            this.tbTpsk.Location = new System.Drawing.Point(168, 22);
            this.tbTpsk.Name = "tbTpsk";
            this.tbTpsk.Size = new System.Drawing.Size(88, 23);
            this.tbTpsk.TabIndex = 0;
            this.tbTpsk.Text = "99";
            this.tbTpsk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSetTPsk
            // 
            this.btnSetTPsk.Location = new System.Drawing.Point(87, 22);
            this.btnSetTPsk.Name = "btnSetTPsk";
            this.btnSetTPsk.Size = new System.Drawing.Size(75, 23);
            this.btnSetTPsk.TabIndex = 1;
            this.btnSetTPsk.Text = "set TPSK";
            this.btnSetTPsk.UseVisualStyleBackColor = true;
            this.btnSetTPsk.Click += new System.EventHandler(this.btnSetTPsk_Click);
            // 
            // btnGetTpsk
            // 
            this.btnGetTpsk.Location = new System.Drawing.Point(6, 22);
            this.btnGetTpsk.Name = "btnGetTpsk";
            this.btnGetTpsk.Size = new System.Drawing.Size(75, 23);
            this.btnGetTpsk.TabIndex = 2;
            this.btnGetTpsk.Text = "get TPSK";
            this.btnGetTpsk.UseVisualStyleBackColor = true;
            this.btnGetTpsk.Click += new System.EventHandler(this.btnGetTpsk_Click);
            // 
            // btnSetAdcConfig
            // 
            this.btnSetAdcConfig.Location = new System.Drawing.Point(109, 23);
            this.btnSetAdcConfig.Name = "btnSetAdcConfig";
            this.btnSetAdcConfig.Size = new System.Drawing.Size(97, 23);
            this.btnSetAdcConfig.TabIndex = 3;
            this.btnSetAdcConfig.Text = "set ADC config";
            this.btnSetAdcConfig.UseVisualStyleBackColor = true;
            this.btnSetAdcConfig.Click += new System.EventHandler(this.btnSetAdcConfig_Click);
            // 
            // btnGetAdcConfig
            // 
            this.btnGetAdcConfig.Location = new System.Drawing.Point(6, 22);
            this.btnGetAdcConfig.Name = "btnGetAdcConfig";
            this.btnGetAdcConfig.Size = new System.Drawing.Size(97, 23);
            this.btnGetAdcConfig.TabIndex = 4;
            this.btnGetAdcConfig.Text = "get ADC config";
            this.btnGetAdcConfig.UseVisualStyleBackColor = true;
            this.btnGetAdcConfig.Click += new System.EventHandler(this.btnGetAdcConfig_Click);
            // 
            // btnGetCntConfig
            // 
            this.btnGetCntConfig.Location = new System.Drawing.Point(6, 51);
            this.btnGetCntConfig.Name = "btnGetCntConfig";
            this.btnGetCntConfig.Size = new System.Drawing.Size(97, 23);
            this.btnGetCntConfig.TabIndex = 6;
            this.btnGetCntConfig.Text = "get CNT config";
            this.btnGetCntConfig.UseVisualStyleBackColor = true;
            this.btnGetCntConfig.Click += new System.EventHandler(this.btnGetCntConfig_Click);
            // 
            // bntSetCntConfig
            // 
            this.bntSetCntConfig.Location = new System.Drawing.Point(109, 52);
            this.bntSetCntConfig.Name = "bntSetCntConfig";
            this.bntSetCntConfig.Size = new System.Drawing.Size(97, 23);
            this.bntSetCntConfig.TabIndex = 5;
            this.bntSetCntConfig.Text = "set CNT config";
            this.bntSetCntConfig.UseVisualStyleBackColor = true;
            this.bntSetCntConfig.Click += new System.EventHandler(this.bntSetCntConfig_Click);
            // 
            // tbAdcConfig
            // 
            this.tbAdcConfig.Location = new System.Drawing.Point(212, 23);
            this.tbAdcConfig.Name = "tbAdcConfig";
            this.tbAdcConfig.Size = new System.Drawing.Size(56, 23);
            this.tbAdcConfig.TabIndex = 7;
            this.tbAdcConfig.Text = "15";
            this.tbAdcConfig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbCntConfig
            // 
            this.tbCntConfig.Location = new System.Drawing.Point(212, 52);
            this.tbCntConfig.Name = "tbCntConfig";
            this.tbCntConfig.Size = new System.Drawing.Size(56, 23);
            this.tbCntConfig.TabIndex = 8;
            this.tbCntConfig.Text = "0";
            this.tbCntConfig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbEncConfig
            // 
            this.tbEncConfig.Location = new System.Drawing.Point(212, 81);
            this.tbEncConfig.Name = "tbEncConfig";
            this.tbEncConfig.Size = new System.Drawing.Size(56, 23);
            this.tbEncConfig.TabIndex = 11;
            this.tbEncConfig.Text = "15";
            this.tbEncConfig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGetEncConfig
            // 
            this.btnGetEncConfig.Location = new System.Drawing.Point(6, 80);
            this.btnGetEncConfig.Name = "btnGetEncConfig";
            this.btnGetEncConfig.Size = new System.Drawing.Size(97, 23);
            this.btnGetEncConfig.TabIndex = 10;
            this.btnGetEncConfig.Text = "get Enc config";
            this.btnGetEncConfig.UseVisualStyleBackColor = true;
            this.btnGetEncConfig.Click += new System.EventHandler(this.btnGetEncConfig_Click);
            // 
            // btnSetEncConfig
            // 
            this.btnSetEncConfig.Location = new System.Drawing.Point(109, 81);
            this.btnSetEncConfig.Name = "btnSetEncConfig";
            this.btnSetEncConfig.Size = new System.Drawing.Size(97, 23);
            this.btnSetEncConfig.TabIndex = 9;
            this.btnSetEncConfig.Text = "set ENC config";
            this.btnSetEncConfig.UseVisualStyleBackColor = true;
            this.btnSetEncConfig.Click += new System.EventHandler(this.btnSetEncConfig_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 22);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 56);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Start DAQ";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(87, 22);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 56);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "Stop DAQ";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // getTbrt
            // 
            this.getTbrt.Location = new System.Drawing.Point(6, 51);
            this.getTbrt.Name = "getTbrt";
            this.getTbrt.Size = new System.Drawing.Size(75, 23);
            this.getTbrt.TabIndex = 16;
            this.getTbrt.Text = "get TBRT";
            this.getTbrt.UseVisualStyleBackColor = true;
            this.getTbrt.Click += new System.EventHandler(this.getTbrt_Click);
            // 
            // btnSetTbrt
            // 
            this.btnSetTbrt.Location = new System.Drawing.Point(87, 51);
            this.btnSetTbrt.Name = "btnSetTbrt";
            this.btnSetTbrt.Size = new System.Drawing.Size(75, 23);
            this.btnSetTbrt.TabIndex = 15;
            this.btnSetTbrt.Text = "set TBRT";
            this.btnSetTbrt.UseVisualStyleBackColor = true;
            this.btnSetTbrt.Click += new System.EventHandler(this.btnSetTbrt_Click);
            // 
            // tbTbrt
            // 
            this.tbTbrt.Location = new System.Drawing.Point(168, 51);
            this.tbTbrt.Name = "tbTbrt";
            this.tbTbrt.Size = new System.Drawing.Size(88, 23);
            this.tbTbrt.TabIndex = 14;
            this.tbTbrt.Text = "99";
            this.tbTbrt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(168, 115);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(100, 29);
            this.btnGetData.TabIndex = 17;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnGetDaqDataStartTimer
            // 
            this.btnGetDaqDataStartTimer.Location = new System.Drawing.Point(6, 84);
            this.btnGetDaqDataStartTimer.Name = "btnGetDaqDataStartTimer";
            this.btnGetDaqDataStartTimer.Size = new System.Drawing.Size(75, 56);
            this.btnGetDaqDataStartTimer.TabIndex = 18;
            this.btnGetDaqDataStartTimer.Text = "Get Data Start Timer";
            this.btnGetDaqDataStartTimer.UseVisualStyleBackColor = true;
            this.btnGetDaqDataStartTimer.Click += new System.EventHandler(this.btnGetDaqDataStartTimer_Click);
            // 
            // btnGetDaqDataStopTimer
            // 
            this.btnGetDaqDataStopTimer.Location = new System.Drawing.Point(87, 86);
            this.btnGetDaqDataStopTimer.Name = "btnGetDaqDataStopTimer";
            this.btnGetDaqDataStopTimer.Size = new System.Drawing.Size(75, 56);
            this.btnGetDaqDataStopTimer.TabIndex = 19;
            this.btnGetDaqDataStopTimer.Text = "Get Data Stop Timer";
            this.btnGetDaqDataStopTimer.UseVisualStyleBackColor = true;
            this.btnGetDaqDataStopTimer.Click += new System.EventHandler(this.btnGetDaqDataStopTimer_Click);
            // 
            // nudGetDataTimerInterval
            // 
            this.nudGetDataTimerInterval.Location = new System.Drawing.Point(168, 86);
            this.nudGetDataTimerInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudGetDataTimerInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGetDataTimerInterval.Name = "nudGetDataTimerInterval";
            this.nudGetDataTimerInterval.Size = new System.Drawing.Size(100, 23);
            this.nudGetDataTimerInterval.TabIndex = 20;
            this.nudGetDataTimerInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGetDataTimerInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(168, 22);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(100, 56);
            this.btnStatus.TabIndex = 21;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnOffsetsCount
            // 
            this.btnOffsetsCount.Location = new System.Drawing.Point(162, 22);
            this.btnOffsetsCount.Name = "btnOffsetsCount";
            this.btnOffsetsCount.Size = new System.Drawing.Size(106, 29);
            this.btnOffsetsCount.TabIndex = 22;
            this.btnOffsetsCount.Text = "Count";
            this.btnOffsetsCount.UseVisualStyleBackColor = true;
            this.btnOffsetsCount.Click += new System.EventHandler(this.btnOffsetsCount_Click);
            // 
            // tbOffsetsNumSamples
            // 
            this.tbOffsetsNumSamples.Location = new System.Drawing.Point(87, 26);
            this.tbOffsetsNumSamples.Name = "tbOffsetsNumSamples";
            this.tbOffsetsNumSamples.Size = new System.Drawing.Size(56, 23);
            this.tbOffsetsNumSamples.TabIndex = 23;
            this.tbOffsetsNumSamples.Text = "2";
            this.tbOffsetsNumSamples.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbOffsetCountTime
            // 
            this.tbOffsetCountTime.Location = new System.Drawing.Point(87, 61);
            this.tbOffsetCountTime.Name = "tbOffsetCountTime";
            this.tbOffsetCountTime.Size = new System.Drawing.Size(56, 23);
            this.tbOffsetCountTime.TabIndex = 24;
            this.tbOffsetCountTime.Text = "500000";
            this.tbOffsetCountTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "N Samples";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Count Time";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDaqOffsetsAbort);
            this.groupBox1.Controls.Add(this.btnOffsetsStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnOffsetsCount);
            this.groupBox1.Controls.Add(this.btnOffsetsGet);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbOffsetsNumSamples);
            this.groupBox1.Controls.Add(this.tbOffsetCountTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 380);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 130);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Offsets";
            // 
            // btnDaqOffsetsAbort
            // 
            this.btnDaqOffsetsAbort.Location = new System.Drawing.Point(87, 92);
            this.btnDaqOffsetsAbort.Name = "btnDaqOffsetsAbort";
            this.btnDaqOffsetsAbort.Size = new System.Drawing.Size(56, 29);
            this.btnDaqOffsetsAbort.TabIndex = 29;
            this.btnDaqOffsetsAbort.Text = "Abort";
            this.btnDaqOffsetsAbort.UseVisualStyleBackColor = true;
            this.btnDaqOffsetsAbort.Click += new System.EventHandler(this.btnDaqOffsetsAbort_Click);
            // 
            // btnOffsetsStatus
            // 
            this.btnOffsetsStatus.Location = new System.Drawing.Point(162, 92);
            this.btnOffsetsStatus.Name = "btnOffsetsStatus";
            this.btnOffsetsStatus.Size = new System.Drawing.Size(106, 29);
            this.btnOffsetsStatus.TabIndex = 27;
            this.btnOffsetsStatus.Text = "Status";
            this.btnOffsetsStatus.UseVisualStyleBackColor = true;
            this.btnOffsetsStatus.Click += new System.EventHandler(this.btnOffsetsStatus_Click);
            // 
            // btnOffsetsGet
            // 
            this.btnOffsetsGet.Location = new System.Drawing.Point(162, 57);
            this.btnOffsetsGet.Name = "btnOffsetsGet";
            this.btnOffsetsGet.Size = new System.Drawing.Size(106, 29);
            this.btnOffsetsGet.TabIndex = 28;
            this.btnOffsetsGet.Text = "Get";
            this.btnOffsetsGet.UseVisualStyleBackColor = true;
            this.btnOffsetsGet.Click += new System.EventHandler(this.btnOffsetsGet_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.btnStatus);
            this.groupBox2.Controls.Add(this.btnGetData);
            this.groupBox2.Controls.Add(this.nudGetDataTimerInterval);
            this.groupBox2.Controls.Add(this.btnGetDaqDataStartTimer);
            this.groupBox2.Controls.Add(this.btnGetDaqDataStopTimer);
            this.groupBox2.Location = new System.Drawing.Point(12, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 152);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DAQ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGetTpsk);
            this.groupBox3.Controls.Add(this.tbTpsk);
            this.groupBox3.Controls.Add(this.btnSetTPsk);
            this.groupBox3.Controls.Add(this.tbTbrt);
            this.groupBox3.Controls.Add(this.getTbrt);
            this.groupBox3.Controls.Add(this.btnSetTbrt);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 84);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Config DAQ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnGetAdcConfig);
            this.groupBox4.Controls.Add(this.btnSetAdcConfig);
            this.groupBox4.Controls.Add(this.bntSetCntConfig);
            this.groupBox4.Controls.Add(this.btnGetCntConfig);
            this.groupBox4.Controls.Add(this.tbAdcConfig);
            this.groupBox4.Controls.Add(this.tbCntConfig);
            this.groupBox4.Controls.Add(this.btnSetEncConfig);
            this.groupBox4.Controls.Add(this.tbEncConfig);
            this.groupBox4.Controls.Add(this.btnGetEncConfig);
            this.groupBox4.Location = new System.Drawing.Point(12, 102);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(276, 114);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Config Inputs";
            // 
            // DaqUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(296, 526);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DaqUI";
            this.Text = "DaqUI";
            ((System.ComponentModel.ISupportInitialize)(this.nudGetDataTimerInterval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox tbTpsk;
        private Button btnSetTPsk;
        private Button btnGetTpsk;
        private Button btnSetAdcConfig;
        private Button btnGetAdcConfig;
        private Button btnGetCntConfig;
        private Button bntSetCntConfig;
        private TextBox tbAdcConfig;
        private TextBox tbCntConfig;
        private TextBox tbEncConfig;
        private Button btnGetEncConfig;
        private Button btnSetEncConfig;
        private Button btnStart;
        private Button btnStop;
        private Button getTbrt;
        private Button btnSetTbrt;
        private TextBox tbTbrt;
        private Button btnGetData;
        private Button btnGetDaqDataStartTimer;
        private Button btnGetDaqDataStopTimer;
        private NumericUpDown nudGetDataTimerInterval;
        private Button btnStatus;
        private Button btnOffsetsCount;
        private TextBox tbOffsetsNumSamples;
        private TextBox tbOffsetCountTime;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Button btnDaqOffsetsAbort;
        private Button btnOffsetsGet;
        private Button btnOffsetsStatus;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
    }
}