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
            label1 = new Label();
            label2 = new Label();
            FrequencyInput = new NumericUpDown();
            SleepTimeInput = new NumericUpDown();
            ResultBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)FrequencyInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SleepTimeInput).BeginInit();
            SuspendLayout();
            // 
            // StartBtn
            // 
            StartBtn.Location = new Point(286, 64);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(83, 25);
            StartBtn.TabIndex = 0;
            StartBtn.Text = "倒数开始";
            StartBtn.UseVisualStyleBackColor = true;
            StartBtn.Click += StartBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(39, 17);
            label1.TabIndex = 1;
            label1.Text = "频率";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 89);
            label2.Name = "label2";
            label2.Size = new Size(40, 17);
            label2.TabIndex = 2;
            label2.Text = "时长";
            // 
            // FrequencyInput
            // 
            FrequencyInput.Location = new Point(77, 27);
            FrequencyInput.Name = "FrequencyInput";
            FrequencyInput.Size = new Size(132, 25);
            FrequencyInput.TabIndex = 3;
            FrequencyInput.ValueChanged += FrequencyInput_ValueChanged;
            // 
            // SleepTimeInput
            // 
            SleepTimeInput.Location = new Point(77, 81);
            SleepTimeInput.Name = "SleepTimeInput";
            SleepTimeInput.Size = new Size(132, 25);
            SleepTimeInput.TabIndex = 4;
            SleepTimeInput.ValueChanged += SleepTimeInput_ValueChanged;
            // 
            // ResultBox
            // 
            ResultBox.Location = new Point(55, 140);
            ResultBox.Multiline = true;
            ResultBox.Name = "ResultBox";
            ResultBox.ReadOnly = true;
            ResultBox.Size = new Size(256, 109);
            ResultBox.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 273);
            Controls.Add(ResultBox);
            Controls.Add(SleepTimeInput);
            Controls.Add(FrequencyInput);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(StartBtn);
            Name = "Form1";
            Text = "点点";
            ((System.ComponentModel.ISupportInitialize)FrequencyInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)SleepTimeInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartBtn;
        private Label label1;
        private Label label2;
        private NumericUpDown FrequencyInput;
        private NumericUpDown SleepTimeInput;
        private TextBox ResultBox;
    }
}
