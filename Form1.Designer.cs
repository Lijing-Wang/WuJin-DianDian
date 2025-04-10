namespace WuJinDianDian
{
    partial class WuJinDianDian
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StartButton = new Button();
            label2 = new Label();
            ResultBox = new TextBox();
            EndDateTimePicker = new DateTimePicker();
            QuickStartLikeHumanClickControl = new RadioButton();
            QuickStartLikeMachineClickControl = new RadioButton();
            StopButton = new Button();
            CustomFrequencyInput = new NumericUpDown();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            AdvancedRadioBtn = new RadioButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label10 = new Label();
            MarchLikeHumanClickControl = new CheckBox();
            MarchLikeMachineClickControl = new CheckBox();
            MarchReplayControl = new CheckBox();
            HealLikeHumanClickControl = new CheckBox();
            HealLikeMachineClickControl = new CheckBox();
            HealReplayControl = new CheckBox();
            MarchRepeatDurationTextBox = new TextBox();
            HealRepeatDurationTextBox = new TextBox();
            label1 = new Label();
            label5 = new Label();
            MarchRecordingCheckBox = new CheckBox();
            HealRecordingCheckBox = new CheckBox();
            label9 = new Label();
            MarchRandomReplayControl = new CheckBox();
            HealRandomReplayControl = new CheckBox();
            QuickStartRadioBtn = new RadioButton();
            StopCursorRecordingButton = new Button();
            StartCursorRecordingButton = new Button();
            AdvancedGroupBox = new GroupBox();
            QuickStartGroupBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)CustomFrequencyInput).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            AdvancedGroupBox.SuspendLayout();
            QuickStartGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.Location = new Point(29, 548);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(108, 25);
            StartButton.TabIndex = 0;
            StartButton.Text = "倒数并开始";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 43);
            label2.Name = "label2";
            label2.Size = new Size(70, 17);
            label2.TabIndex = 2;
            label2.Text = "截至时间";
            // 
            // ResultBox
            // 
            ResultBox.Location = new Point(14, 588);
            ResultBox.Multiline = true;
            ResultBox.Name = "ResultBox";
            ResultBox.ReadOnly = true;
            ResultBox.ScrollBars = ScrollBars.Both;
            ResultBox.Size = new Size(327, 124);
            ResultBox.TabIndex = 5;
            // 
            // EndDateTimePicker
            // 
            EndDateTimePicker.CustomFormat = "";
            EndDateTimePicker.Location = new Point(76, 37);
            EndDateTimePicker.Name = "EndDateTimePicker";
            EndDateTimePicker.Size = new Size(221, 25);
            EndDateTimePicker.TabIndex = 6;
            EndDateTimePicker.ValueChanged += EndDateTimePicker_ValueChanged;
            // 
            // QuickStartLikeHumanClickControl
            // 
            QuickStartLikeHumanClickControl.AutoSize = true;
            QuickStartLikeHumanClickControl.Checked = true;
            QuickStartLikeHumanClickControl.Location = new Point(18, 34);
            QuickStartLikeHumanClickControl.Name = "QuickStartLikeHumanClickControl";
            QuickStartLikeHumanClickControl.Size = new Size(88, 21);
            QuickStartLikeHumanClickControl.TabIndex = 7;
            QuickStartLikeHumanClickControl.TabStop = true;
            QuickStartLikeHumanClickControl.Text = "拟人点击";
            QuickStartLikeHumanClickControl.UseVisualStyleBackColor = true;
            QuickStartLikeHumanClickControl.CheckedChanged += LikeHumanClickControl_CheckedChanged;
            // 
            // QuickStartLikeMachineClickControl
            // 
            QuickStartLikeMachineClickControl.AutoSize = true;
            QuickStartLikeMachineClickControl.Location = new Point(112, 34);
            QuickStartLikeMachineClickControl.Name = "QuickStartLikeMachineClickControl";
            QuickStartLikeMachineClickControl.Size = new Size(117, 21);
            QuickStartLikeMachineClickControl.TabIndex = 8;
            QuickStartLikeMachineClickControl.TabStop = true;
            QuickStartLikeMachineClickControl.Text = "机器快速点击";
            QuickStartLikeMachineClickControl.UseVisualStyleBackColor = true;
            QuickStartLikeMachineClickControl.CheckedChanged += LikeMachineClickControl_CheckedChanged;
            // 
            // StopButton
            // 
            StopButton.Enabled = false;
            StopButton.Location = new Point(228, 548);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(83, 25);
            StopButton.TabIndex = 9;
            StopButton.Text = "终止Esc";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // CustomFrequencyInput
            // 
            CustomFrequencyInput.Enabled = false;
            CustomFrequencyInput.Location = new Point(231, 30);
            CustomFrequencyInput.Name = "CustomFrequencyInput";
            CustomFrequencyInput.Size = new Size(60, 25);
            CustomFrequencyInput.TabIndex = 10;
            CustomFrequencyInput.Value = new decimal(new int[] { 3, 0, 0, 0 });
            CustomFrequencyInput.ValueChanged += CustomFrequencyInput_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(QuickStartLikeHumanClickControl);
            groupBox1.Controls.Add(QuickStartLikeMachineClickControl);
            groupBox1.Controls.Add(CustomFrequencyInput);
            groupBox1.Location = new Point(7, 24);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(297, 74);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "点击速度";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(EndDateTimePicker);
            groupBox3.Location = new Point(9, 436);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(335, 85);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            // 
            // AdvancedRadioBtn
            // 
            AdvancedRadioBtn.AutoSize = true;
            AdvancedRadioBtn.Location = new Point(9, 172);
            AdvancedRadioBtn.Name = "AdvancedRadioBtn";
            AdvancedRadioBtn.Size = new Size(118, 21);
            AdvancedRadioBtn.TabIndex = 1;
            AdvancedRadioBtn.Text = "高级录制模式";
            AdvancedRadioBtn.UseVisualStyleBackColor = true;
            AdvancedRadioBtn.CheckedChanged += AdvancedRadioBtn_CheckedChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.6356964F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.638298F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5896654F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.8936167F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5896654F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6778116F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.2370815F));
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(label4, 1, 0);
            tableLayoutPanel1.Controls.Add(label6, 2, 0);
            tableLayoutPanel1.Controls.Add(label7, 3, 0);
            tableLayoutPanel1.Controls.Add(label8, 4, 0);
            tableLayoutPanel1.Controls.Add(label10, 6, 0);
            tableLayoutPanel1.Controls.Add(MarchLikeHumanClickControl, 2, 1);
            tableLayoutPanel1.Controls.Add(MarchLikeMachineClickControl, 3, 1);
            tableLayoutPanel1.Controls.Add(MarchReplayControl, 4, 1);
            tableLayoutPanel1.Controls.Add(HealLikeHumanClickControl, 2, 2);
            tableLayoutPanel1.Controls.Add(HealLikeMachineClickControl, 3, 2);
            tableLayoutPanel1.Controls.Add(HealReplayControl, 4, 2);
            tableLayoutPanel1.Controls.Add(MarchRepeatDurationTextBox, 6, 1);
            tableLayoutPanel1.Controls.Add(HealRepeatDurationTextBox, 6, 2);
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(label5, 1, 2);
            tableLayoutPanel1.Controls.Add(MarchRecordingCheckBox, 0, 1);
            tableLayoutPanel1.Controls.Add(HealRecordingCheckBox, 0, 2);
            tableLayoutPanel1.Controls.Add(label9, 5, 0);
            tableLayoutPanel1.Controls.Add(MarchRandomReplayControl, 5, 1);
            tableLayoutPanel1.Controls.Add(HealRandomReplayControl, 5, 2);
            tableLayoutPanel1.Enabled = false;
            tableLayoutPanel1.Location = new Point(3, 55);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43.018322F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 28.49084F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 28.49084F));
            tableLayoutPanel1.Size = new Size(329, 140);
            tableLayoutPanel1.TabIndex = 15;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(24, 60);
            label3.TabIndex = 0;
            label3.Text = "将录制方案";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(44, 13);
            label4.Name = "label4";
            label4.Size = new Size(23, 34);
            label4.TabIndex = 1;
            label4.Text = "目的";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(79, 13);
            label6.Name = "label6";
            label6.Size = new Size(39, 34);
            label6.TabIndex = 3;
            label6.Text = "拟人点击";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(127, 13);
            label7.Name = "label7";
            label7.Size = new Size(39, 34);
            label7.TabIndex = 4;
            label7.Text = "机器点击";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(176, 13);
            label8.Name = "label8";
            label8.Size = new Size(38, 34);
            label8.TabIndex = 5;
            label8.Text = "原速播放";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left;
            label10.AutoSize = true;
            label10.Location = new Point(269, 13);
            label10.Name = "label10";
            label10.Size = new Size(55, 34);
            label10.TabIndex = 7;
            label10.Text = "执行时长（分）";
            // 
            // MarchLikeHumanClickControl
            // 
            MarchLikeHumanClickControl.Anchor = AnchorStyles.None;
            MarchLikeHumanClickControl.AutoSize = true;
            MarchLikeHumanClickControl.Checked = true;
            MarchLikeHumanClickControl.CheckState = CheckState.Checked;
            MarchLikeHumanClickControl.Location = new Point(92, 72);
            MarchLikeHumanClickControl.Name = "MarchLikeHumanClickControl";
            MarchLikeHumanClickControl.Size = new Size(15, 14);
            MarchLikeHumanClickControl.TabIndex = 12;
            MarchLikeHumanClickControl.UseVisualStyleBackColor = true;
            MarchLikeHumanClickControl.CheckedChanged += March_LikeHumanClickControl_CheckedChanged;
            // 
            // MarchLikeMachineClickControl
            // 
            MarchLikeMachineClickControl.Anchor = AnchorStyles.None;
            MarchLikeMachineClickControl.AutoSize = true;
            MarchLikeMachineClickControl.Location = new Point(141, 72);
            MarchLikeMachineClickControl.Name = "MarchLikeMachineClickControl";
            MarchLikeMachineClickControl.Size = new Size(15, 14);
            MarchLikeMachineClickControl.TabIndex = 13;
            MarchLikeMachineClickControl.UseVisualStyleBackColor = true;
            MarchLikeMachineClickControl.CheckedChanged += March_LikeMachineClickControl_CheckedChanged;
            // 
            // MarchReplayControl
            // 
            MarchReplayControl.Anchor = AnchorStyles.None;
            MarchReplayControl.AutoSize = true;
            MarchReplayControl.Location = new Point(189, 72);
            MarchReplayControl.Name = "MarchReplayControl";
            MarchReplayControl.Size = new Size(15, 14);
            MarchReplayControl.TabIndex = 14;
            MarchReplayControl.UseVisualStyleBackColor = true;
            MarchReplayControl.CheckedChanged += March_ReplayClickControl_CheckedChanged;
            // 
            // HealLikeHumanClickControl
            // 
            HealLikeHumanClickControl.Anchor = AnchorStyles.None;
            HealLikeHumanClickControl.AutoSize = true;
            HealLikeHumanClickControl.Checked = true;
            HealLikeHumanClickControl.CheckState = CheckState.Checked;
            HealLikeHumanClickControl.Location = new Point(92, 112);
            HealLikeHumanClickControl.Name = "HealLikeHumanClickControl";
            HealLikeHumanClickControl.Size = new Size(15, 14);
            HealLikeHumanClickControl.TabIndex = 19;
            HealLikeHumanClickControl.UseVisualStyleBackColor = true;
            HealLikeHumanClickControl.CheckedChanged += Heal_LikeHumanClickControl_CheckedChanged;
            // 
            // HealLikeMachineClickControl
            // 
            HealLikeMachineClickControl.Anchor = AnchorStyles.None;
            HealLikeMachineClickControl.AutoSize = true;
            HealLikeMachineClickControl.Location = new Point(141, 112);
            HealLikeMachineClickControl.Name = "HealLikeMachineClickControl";
            HealLikeMachineClickControl.Size = new Size(15, 14);
            HealLikeMachineClickControl.TabIndex = 20;
            HealLikeMachineClickControl.UseVisualStyleBackColor = true;
            HealLikeMachineClickControl.CheckedChanged += Heal_LikeMachineClickControl_CheckedChanged;
            // 
            // HealReplayControl
            // 
            HealReplayControl.Anchor = AnchorStyles.None;
            HealReplayControl.AutoSize = true;
            HealReplayControl.Location = new Point(189, 112);
            HealReplayControl.Name = "HealReplayControl";
            HealReplayControl.Size = new Size(15, 14);
            HealReplayControl.TabIndex = 21;
            HealReplayControl.UseVisualStyleBackColor = true;
            HealReplayControl.CheckedChanged += Heal_ReplayClickControl_CheckedChanged;
            // 
            // MarchRepeatDurationTextBox
            // 
            MarchRepeatDurationTextBox.Location = new Point(269, 63);
            MarchRepeatDurationTextBox.Name = "MarchRepeatDurationTextBox";
            MarchRepeatDurationTextBox.Size = new Size(40, 25);
            MarchRepeatDurationTextBox.TabIndex = 24;
            MarchRepeatDurationTextBox.TextChanged += MarchRepeatDurationTextBox_TextChanged;
            // 
            // HealRepeatDurationTextBox
            // 
            HealRepeatDurationTextBox.Location = new Point(269, 102);
            HealRepeatDurationTextBox.Name = "HealRepeatDurationTextBox";
            HealRepeatDurationTextBox.Size = new Size(40, 25);
            HealRepeatDurationTextBox.TabIndex = 25;
            HealRepeatDurationTextBox.TextChanged += HealRepeatDurationTextBox_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(47, 62);
            label1.Name = "label1";
            label1.Size = new Size(23, 34);
            label1.TabIndex = 26;
            label1.Text = "出征";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(46, 102);
            label5.Name = "label5";
            label5.Size = new Size(24, 34);
            label5.TabIndex = 27;
            label5.Text = "治疗";
            // 
            // MarchRecordingCheckBox
            // 
            MarchRecordingCheckBox.Anchor = AnchorStyles.None;
            MarchRecordingCheckBox.AutoSize = true;
            MarchRecordingCheckBox.Checked = true;
            MarchRecordingCheckBox.CheckState = CheckState.Checked;
            MarchRecordingCheckBox.Location = new Point(13, 72);
            MarchRecordingCheckBox.Name = "MarchRecordingCheckBox";
            MarchRecordingCheckBox.Size = new Size(15, 14);
            MarchRecordingCheckBox.TabIndex = 28;
            MarchRecordingCheckBox.UseVisualStyleBackColor = true;
            MarchRecordingCheckBox.CheckedChanged += MarchRecordingCheckBox_CheckedChanged;
            // 
            // HealRecordingCheckBox
            // 
            HealRecordingCheckBox.Anchor = AnchorStyles.None;
            HealRecordingCheckBox.AutoSize = true;
            HealRecordingCheckBox.Location = new Point(13, 112);
            HealRecordingCheckBox.Name = "HealRecordingCheckBox";
            HealRecordingCheckBox.Size = new Size(15, 14);
            HealRecordingCheckBox.TabIndex = 29;
            HealRecordingCheckBox.UseVisualStyleBackColor = true;
            HealRecordingCheckBox.CheckedChanged += HealRecordingCheckBox_CheckedChanged;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Location = new Point(224, 13);
            label9.Name = "label9";
            label9.Size = new Size(38, 34);
            label9.TabIndex = 30;
            label9.Text = "比例播放";
            // 
            // MarchRandomReplayControl
            // 
            MarchRandomReplayControl.Anchor = AnchorStyles.None;
            MarchRandomReplayControl.AutoSize = true;
            MarchRandomReplayControl.Location = new Point(236, 72);
            MarchRandomReplayControl.Name = "MarchRandomReplayControl";
            MarchRandomReplayControl.Size = new Size(15, 14);
            MarchRandomReplayControl.TabIndex = 31;
            MarchRandomReplayControl.UseVisualStyleBackColor = true;
            MarchRandomReplayControl.CheckedChanged += MarchRandomReplayControl_CheckedChanged;
            // 
            // HealRandomReplayControl
            // 
            HealRandomReplayControl.Anchor = AnchorStyles.None;
            HealRandomReplayControl.AutoSize = true;
            HealRandomReplayControl.Location = new Point(236, 112);
            HealRandomReplayControl.Name = "HealRandomReplayControl";
            HealRandomReplayControl.Size = new Size(15, 14);
            HealRandomReplayControl.TabIndex = 32;
            HealRandomReplayControl.UseVisualStyleBackColor = true;
            HealRandomReplayControl.CheckedChanged += HealRandomReplayControl_CheckedChanged;
            // 
            // QuickStartRadioBtn
            // 
            QuickStartRadioBtn.AutoSize = true;
            QuickStartRadioBtn.Checked = true;
            QuickStartRadioBtn.Location = new Point(9, 12);
            QuickStartRadioBtn.Name = "QuickStartRadioBtn";
            QuickStartRadioBtn.Size = new Size(88, 21);
            QuickStartRadioBtn.TabIndex = 5;
            QuickStartRadioBtn.Text = "简单模式";
            QuickStartRadioBtn.UseVisualStyleBackColor = true;
            QuickStartRadioBtn.CheckedChanged += QuickStartRadioBtn_CheckedChanged;
            // 
            // StopCursorRecordingButton
            // 
            StopCursorRecordingButton.Enabled = false;
            StopCursorRecordingButton.Location = new Point(223, 24);
            StopCursorRecordingButton.Name = "StopCursorRecordingButton";
            StopCursorRecordingButton.Size = new Size(83, 25);
            StopCursorRecordingButton.TabIndex = 17;
            StopCursorRecordingButton.Text = "结束录制";
            StopCursorRecordingButton.UseVisualStyleBackColor = true;
            StopCursorRecordingButton.Click += StopCursorRecordingButton_Click;
            // 
            // StartCursorRecordingButton
            // 
            StartCursorRecordingButton.Enabled = false;
            StartCursorRecordingButton.Location = new Point(30, 24);
            StartCursorRecordingButton.Name = "StartCursorRecordingButton";
            StartCursorRecordingButton.Size = new Size(83, 25);
            StartCursorRecordingButton.TabIndex = 16;
            StartCursorRecordingButton.Text = "开始录制";
            StartCursorRecordingButton.UseVisualStyleBackColor = true;
            StartCursorRecordingButton.Click += StartCursorRecordingButton_Click;
            // 
            // AdvancedGroupBox
            // 
            AdvancedGroupBox.Controls.Add(tableLayoutPanel1);
            AdvancedGroupBox.Controls.Add(StopCursorRecordingButton);
            AdvancedGroupBox.Controls.Add(StartCursorRecordingButton);
            AdvancedGroupBox.Location = new Point(6, 199);
            AdvancedGroupBox.Name = "AdvancedGroupBox";
            AdvancedGroupBox.Size = new Size(332, 231);
            AdvancedGroupBox.TabIndex = 18;
            AdvancedGroupBox.TabStop = false;
            // 
            // QuickStartGroupBox
            // 
            QuickStartGroupBox.Controls.Add(groupBox1);
            QuickStartGroupBox.Location = new Point(9, 39);
            QuickStartGroupBox.Name = "QuickStartGroupBox";
            QuickStartGroupBox.Size = new Size(332, 110);
            QuickStartGroupBox.TabIndex = 19;
            QuickStartGroupBox.TabStop = false;
            // 
            // WuJinDianDian
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 724);
            Controls.Add(AdvancedRadioBtn);
            Controls.Add(groupBox3);
            Controls.Add(QuickStartRadioBtn);
            Controls.Add(QuickStartGroupBox);
            Controls.Add(AdvancedGroupBox);
            Controls.Add(StopButton);
            Controls.Add(ResultBox);
            Controls.Add(StartButton);
            Name = "WuJinDianDian";
            Text = "无尽点点";
            ((System.ComponentModel.ISupportInitialize)CustomFrequencyInput).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            AdvancedGroupBox.ResumeLayout(false);
            QuickStartGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartButton;
        private Label label2;
        private TextBox ResultBox;
        private DateTimePicker EndDateTimePicker;
        private RadioButton QuickStartLikeHumanClickControl;
        private RadioButton QuickStartLikeMachineClickControl;
        private Button StopButton;
        private NumericUpDown CustomFrequencyInput;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private RadioButton AdvancedRadioBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label10;
        private CheckBox MarchLikeHumanClickControl;
        private CheckBox MarchLikeMachineClickControl;
        private CheckBox MarchReplayControl;
        private CheckBox HealLikeHumanClickControl;
        private CheckBox HealLikeMachineClickControl;
        private CheckBox HealReplayControl;
        private TextBox MarchRepeatDurationTextBox;
        private TextBox HealRepeatDurationTextBox;
        private RadioButton QuickStartRadioBtn;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button StopCursorRecordingButton;
        private Button StartCursorRecordingButton;
        private GroupBox AdvancedGroupBox;
        private GroupBox QuickStartGroupBox;
        private Label label1;
        private Label label5;
        private CheckBox MarchRecordingCheckBox;
        private CheckBox HealRecordingCheckBox;
        private Label label9;
        private CheckBox MarchRandomReplayControl;
        private CheckBox HealRandomReplayControl;
    }
}
