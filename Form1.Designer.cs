namespace 连点器
{
    partial class Form1
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
            StartBtn = new Button();
            label2 = new Label();
            ResultBox = new TextBox();
            EndDateTimePicker = new DateTimePicker();
            LikeHumanClickControl = new RadioButton();
            LikeMachineClickControl = new RadioButton();
            StopButton = new Button();
            CustomFrequencyInput = new NumericUpDown();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            PointInput13 = new TextBox();
            PointInput14 = new TextBox();
            PointInput15 = new TextBox();
            PointInput10 = new TextBox();
            PointInput11 = new TextBox();
            PointInput12 = new TextBox();
            StartCursorRecordingButton = new Button();
            PointInput7 = new TextBox();
            StopCursorRecordingButton = new Button();
            PointInput8 = new TextBox();
            PointInput9 = new TextBox();
            PointInput4 = new TextBox();
            PointInput5 = new TextBox();
            PointInput6 = new TextBox();
            PointInput3 = new TextBox();
            PointInput2 = new TextBox();
            PointInput1 = new TextBox();
            AddNewPointButton = new RadioButton();
            UseRecordedCursorButton = new RadioButton();
            UseCurrentPositionButton = new RadioButton();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)CustomFrequencyInput).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // StartBtn
            // 
            StartBtn.Location = new Point(9, 544);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(108, 25);
            StartBtn.TabIndex = 0;
            StartBtn.Text = "倒数并开始";
            StartBtn.UseVisualStyleBackColor = true;
            StartBtn.Click += StartBtn_Click;
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
            ResultBox.Location = new Point(9, 588);
            ResultBox.Multiline = true;
            ResultBox.Name = "ResultBox";
            ResultBox.ReadOnly = true;
            ResultBox.ScrollBars = ScrollBars.Both;
            ResultBox.Size = new Size(297, 124);
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
            // LikeHumanClickControl
            // 
            LikeHumanClickControl.AutoSize = true;
            LikeHumanClickControl.Checked = true;
            LikeHumanClickControl.Location = new Point(18, 34);
            LikeHumanClickControl.Name = "LikeHumanClickControl";
            LikeHumanClickControl.Size = new Size(88, 21);
            LikeHumanClickControl.TabIndex = 7;
            LikeHumanClickControl.TabStop = true;
            LikeHumanClickControl.Text = "拟人点击";
            LikeHumanClickControl.UseVisualStyleBackColor = true;
            LikeHumanClickControl.CheckedChanged += LikeHumanClickControl_CheckedChanged;
            // 
            // LikeMachineClickControl
            // 
            LikeMachineClickControl.AutoSize = true;
            LikeMachineClickControl.Location = new Point(112, 34);
            LikeMachineClickControl.Name = "LikeMachineClickControl";
            LikeMachineClickControl.Size = new Size(117, 21);
            LikeMachineClickControl.TabIndex = 8;
            LikeMachineClickControl.TabStop = true;
            LikeMachineClickControl.Text = "机器快速点击";
            LikeMachineClickControl.UseVisualStyleBackColor = true;
            LikeMachineClickControl.CheckedChanged += LikeMachineClickControl_CheckedChanged;
            // 
            // StopButton
            // 
            StopButton.Enabled = false;
            StopButton.Location = new Point(223, 544);
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
            groupBox1.Controls.Add(LikeHumanClickControl);
            groupBox1.Controls.Add(LikeMachineClickControl);
            groupBox1.Controls.Add(CustomFrequencyInput);
            groupBox1.Location = new Point(9, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(297, 74);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "点击模式";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(PointInput13);
            groupBox2.Controls.Add(PointInput14);
            groupBox2.Controls.Add(PointInput15);
            groupBox2.Controls.Add(PointInput10);
            groupBox2.Controls.Add(PointInput11);
            groupBox2.Controls.Add(PointInput12);
            groupBox2.Controls.Add(StartCursorRecordingButton);
            groupBox2.Controls.Add(PointInput7);
            groupBox2.Controls.Add(StopCursorRecordingButton);
            groupBox2.Controls.Add(PointInput8);
            groupBox2.Controls.Add(PointInput9);
            groupBox2.Controls.Add(PointInput4);
            groupBox2.Controls.Add(PointInput5);
            groupBox2.Controls.Add(PointInput6);
            groupBox2.Controls.Add(PointInput3);
            groupBox2.Controls.Add(PointInput2);
            groupBox2.Controls.Add(PointInput1);
            groupBox2.Controls.Add(AddNewPointButton);
            groupBox2.Controls.Add(UseRecordedCursorButton);
            groupBox2.Controls.Add(UseCurrentPositionButton);
            groupBox2.Location = new Point(9, 218);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(297, 306);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "点击位置";
            // 
            // PointInput13
            // 
            PointInput13.Enabled = false;
            PointInput13.Location = new Point(189, 244);
            PointInput13.Name = "PointInput13";
            PointInput13.Size = new Size(72, 25);
            PointInput13.TabIndex = 19;
            // 
            // PointInput14
            // 
            PointInput14.Enabled = false;
            PointInput14.Location = new Point(111, 244);
            PointInput14.Name = "PointInput14";
            PointInput14.Size = new Size(72, 25);
            PointInput14.TabIndex = 18;
            // 
            // PointInput15
            // 
            PointInput15.Enabled = false;
            PointInput15.Location = new Point(33, 244);
            PointInput15.Name = "PointInput15";
            PointInput15.Size = new Size(72, 25);
            PointInput15.TabIndex = 17;
            // 
            // PointInput10
            // 
            PointInput10.Enabled = false;
            PointInput10.Location = new Point(189, 214);
            PointInput10.Name = "PointInput10";
            PointInput10.Size = new Size(72, 25);
            PointInput10.TabIndex = 16;
            // 
            // PointInput11
            // 
            PointInput11.Enabled = false;
            PointInput11.Location = new Point(111, 214);
            PointInput11.Name = "PointInput11";
            PointInput11.Size = new Size(72, 25);
            PointInput11.TabIndex = 15;
            // 
            // PointInput12
            // 
            PointInput12.Enabled = false;
            PointInput12.Location = new Point(33, 214);
            PointInput12.Name = "PointInput12";
            PointInput12.Size = new Size(72, 25);
            PointInput12.TabIndex = 14;
            // 
            // StartCursorRecordingButton
            // 
            StartCursorRecordingButton.Enabled = false;
            StartCursorRecordingButton.Location = new Point(33, 275);
            StartCursorRecordingButton.Name = "StartCursorRecordingButton";
            StartCursorRecordingButton.Size = new Size(83, 25);
            StartCursorRecordingButton.TabIndex = 2;
            StartCursorRecordingButton.Text = "开始录制";
            StartCursorRecordingButton.UseVisualStyleBackColor = true;
            StartCursorRecordingButton.Click += StartCursorRecordingButton_Click;
            // 
            // PointInput7
            // 
            PointInput7.Enabled = false;
            PointInput7.Location = new Point(189, 183);
            PointInput7.Name = "PointInput7";
            PointInput7.Size = new Size(72, 25);
            PointInput7.TabIndex = 13;
            // 
            // StopCursorRecordingButton
            // 
            StopCursorRecordingButton.Enabled = false;
            StopCursorRecordingButton.Location = new Point(178, 275);
            StopCursorRecordingButton.Name = "StopCursorRecordingButton";
            StopCursorRecordingButton.Size = new Size(83, 25);
            StopCursorRecordingButton.TabIndex = 3;
            StopCursorRecordingButton.Text = "结束录制";
            StopCursorRecordingButton.UseVisualStyleBackColor = true;
            StopCursorRecordingButton.Click += StopCursorRecordingButton_Click;
            // 
            // PointInput8
            // 
            PointInput8.Enabled = false;
            PointInput8.Location = new Point(111, 183);
            PointInput8.Name = "PointInput8";
            PointInput8.Size = new Size(72, 25);
            PointInput8.TabIndex = 12;
            // 
            // PointInput9
            // 
            PointInput9.Enabled = false;
            PointInput9.Location = new Point(33, 183);
            PointInput9.Name = "PointInput9";
            PointInput9.Size = new Size(72, 25);
            PointInput9.TabIndex = 11;
            // 
            // PointInput4
            // 
            PointInput4.Enabled = false;
            PointInput4.Location = new Point(189, 152);
            PointInput4.Name = "PointInput4";
            PointInput4.Size = new Size(72, 25);
            PointInput4.TabIndex = 10;
            // 
            // PointInput5
            // 
            PointInput5.Enabled = false;
            PointInput5.Location = new Point(111, 152);
            PointInput5.Name = "PointInput5";
            PointInput5.Size = new Size(72, 25);
            PointInput5.TabIndex = 9;
            // 
            // PointInput6
            // 
            PointInput6.Enabled = false;
            PointInput6.Location = new Point(33, 152);
            PointInput6.Name = "PointInput6";
            PointInput6.Size = new Size(72, 25);
            PointInput6.TabIndex = 8;
            // 
            // PointInput3
            // 
            PointInput3.Enabled = false;
            PointInput3.Location = new Point(189, 121);
            PointInput3.Name = "PointInput3";
            PointInput3.Size = new Size(72, 25);
            PointInput3.TabIndex = 7;
            // 
            // PointInput2
            // 
            PointInput2.Enabled = false;
            PointInput2.Location = new Point(111, 121);
            PointInput2.Name = "PointInput2";
            PointInput2.Size = new Size(72, 25);
            PointInput2.TabIndex = 6;
            // 
            // PointInput1
            // 
            PointInput1.Enabled = false;
            PointInput1.Location = new Point(34, 121);
            PointInput1.Name = "PointInput1";
            PointInput1.Size = new Size(72, 25);
            PointInput1.TabIndex = 5;
            // 
            // AddNewPointButton
            // 
            AddNewPointButton.AutoSize = true;
            AddNewPointButton.Location = new Point(18, 94);
            AddNewPointButton.Name = "AddNewPointButton";
            AddNewPointButton.Size = new Size(87, 21);
            AddNewPointButton.TabIndex = 4;
            AddNewPointButton.TabStop = true;
            AddNewPointButton.Text = "添加坐标";
            AddNewPointButton.UseVisualStyleBackColor = true;
            AddNewPointButton.CheckedChanged += AddNewPointButton_CheckedChanged;
            // 
            // UseRecordedCursorButton
            // 
            UseRecordedCursorButton.AutoSize = true;
            UseRecordedCursorButton.Location = new Point(18, 67);
            UseRecordedCursorButton.Name = "UseRecordedCursorButton";
            UseRecordedCursorButton.Size = new Size(120, 21);
            UseRecordedCursorButton.TabIndex = 1;
            UseRecordedCursorButton.Text = "预录鼠标轨迹";
            UseRecordedCursorButton.UseVisualStyleBackColor = true;
            UseRecordedCursorButton.CheckedChanged += UseRecordedCursorButton_CheckedChanged;
            // 
            // UseCurrentPositionButton
            // 
            UseCurrentPositionButton.AutoSize = true;
            UseCurrentPositionButton.Checked = true;
            UseCurrentPositionButton.Location = new Point(18, 40);
            UseCurrentPositionButton.Name = "UseCurrentPositionButton";
            UseCurrentPositionButton.Size = new Size(117, 21);
            UseCurrentPositionButton.TabIndex = 0;
            UseCurrentPositionButton.TabStop = true;
            UseCurrentPositionButton.Text = "鼠标当前位置";
            UseCurrentPositionButton.UseVisualStyleBackColor = true;
            UseCurrentPositionButton.CheckedChanged += UseCurrentPositionButton_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(EndDateTimePicker);
            groupBox3.Location = new Point(9, 125);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(297, 68);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "点击时长";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 724);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(StopButton);
            Controls.Add(ResultBox);
            Controls.Add(StartBtn);
            Name = "Form1";
            Text = "·";
            ((System.ComponentModel.ISupportInitialize)CustomFrequencyInput).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartBtn;
        private Label label2;
        private TextBox ResultBox;
        private DateTimePicker EndDateTimePicker;
        private RadioButton LikeHumanClickControl;
        private RadioButton LikeMachineClickControl;
        private Button StopButton;
        private NumericUpDown CustomFrequencyInput;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RadioButton UseCurrentPositionButton;
        private Button StopCursorRecordingButton;
        private Button StartCursorRecordingButton;
        private RadioButton UseRecordedCursorButton;
        private GroupBox groupBox3;
        private RadioButton AddNewPointButton;
        private TextBox PointInput1;
        private TextBox PointInput3;
        private TextBox PointInput2;
        private TextBox PointInput13;
        private TextBox PointInput14;
        private TextBox PointInput15;
        private TextBox PointInput10;
        private TextBox PointInput11;
        private TextBox PointInput12;
        private TextBox PointInput7;
        private TextBox PointInput8;
        private TextBox PointInput9;
        private TextBox PointInput4;
        private TextBox PointInput5;
        private TextBox PointInput6;
    }
}
