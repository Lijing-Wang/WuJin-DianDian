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
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            button1 = new Button();
            button2 = new Button();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)CustomFrequencyInput).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // StartBtn
            // 
            StartBtn.Location = new Point(9, 383);
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
            ResultBox.Location = new Point(9, 426);
            ResultBox.Multiline = true;
            ResultBox.Name = "ResultBox";
            ResultBox.ReadOnly = true;
            ResultBox.ScrollBars = ScrollBars.Both;
            ResultBox.Size = new Size(297, 122);
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
            StopButton.Location = new Point(223, 383);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(83, 25);
            StopButton.TabIndex = 9;
            StopButton.Text = "终止";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // CustomFrequencyInput
            // 
            CustomFrequencyInput.Enabled = false;
            CustomFrequencyInput.Location = new Point(229, 30);
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
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(radioButton2);
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Location = new Point(9, 218);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(297, 131);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "点击位置";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(18, 40);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(117, 21);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "鼠标当前位置";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(18, 67);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(120, 21);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "预录鼠标轨迹";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(36, 94);
            button1.Name = "button1";
            button1.Size = new Size(83, 25);
            button1.TabIndex = 2;
            button1.Text = "开始录制";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(146, 94);
            button2.Name = "button2";
            button2.Size = new Size(83, 25);
            button2.TabIndex = 3;
            button2.Text = "结束录制";
            button2.UseVisualStyleBackColor = true;
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
            ClientSize = new Size(328, 560);
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
        private RadioButton radioButton1;
        private Button button2;
        private Button button1;
        private RadioButton radioButton2;
        private GroupBox groupBox3;
    }
}
