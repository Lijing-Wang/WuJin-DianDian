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
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)CustomFrequencyInput).BeginInit();
            SuspendLayout();
            // 
            // StartBtn
            // 
            StartBtn.Location = new Point(12, 213);
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
            label2.Location = new Point(12, 89);
            label2.Name = "label2";
            label2.Size = new Size(70, 17);
            label2.TabIndex = 2;
            label2.Text = "截至时间";
            // 
            // ResultBox
            // 
            ResultBox.Location = new Point(12, 284);
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
            EndDateTimePicker.Location = new Point(88, 83);
            EndDateTimePicker.Name = "EndDateTimePicker";
            EndDateTimePicker.Size = new Size(221, 25);
            EndDateTimePicker.TabIndex = 6;
            EndDateTimePicker.ValueChanged += EndDateTimePicker_ValueChanged;
            // 
            // LikeHumanClickControl
            // 
            LikeHumanClickControl.AutoSize = true;
            LikeHumanClickControl.Checked = true;
            LikeHumanClickControl.Location = new Point(12, 31);
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
            LikeMachineClickControl.Location = new Point(118, 31);
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
            StopButton.Location = new Point(226, 213);
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
            CustomFrequencyInput.Location = new Point(241, 27);
            CustomFrequencyInput.Name = "CustomFrequencyInput";
            CustomFrequencyInput.Size = new Size(60, 25);
            CustomFrequencyInput.TabIndex = 10;
            CustomFrequencyInput.Value = new decimal(new int[] { 3, 0, 0, 0 });
            CustomFrequencyInput.ValueChanged += CustomFrequencyInput_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 255);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
            label1.TabIndex = 11;
            label1.Text = "Status";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 434);
            Controls.Add(label1);
            Controls.Add(CustomFrequencyInput);
            Controls.Add(StopButton);
            Controls.Add(LikeMachineClickControl);
            Controls.Add(LikeHumanClickControl);
            Controls.Add(EndDateTimePicker);
            Controls.Add(ResultBox);
            Controls.Add(label2);
            Controls.Add(StartBtn);
            Name = "Form1";
            Text = "点点";
            ((System.ComponentModel.ISupportInitialize)CustomFrequencyInput).EndInit();
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
        private Label label1;
    }
}
