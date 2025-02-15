using System.Linq;
using System.Xml.XPath;

namespace 连点器
{
    public partial class Form1 : Form
    {
        private decimal Frequency { get; set; }
        private decimal SleepTime { get; set; }

        // countdown time for mouse to get ready - seconds
        private readonly int Countdown = 10;

        public Form1()
        {
            InitializeComponent();
            ResultBox.Text = "Results:";
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            // wait for Countdown seconds
            Log($"Count down for {Countdown} seconds to start");
        }

        private void FrequencyInput_ValueChanged(object sender, EventArgs e)
        {
            Frequency = FrequencyInput.Value;
            Log($"Set frequency to {Frequency}");
            
        }

        private void SleepTimeInput_ValueChanged(object sender, EventArgs e)
        {
            SleepTime = SleepTimeInput.Value;
            Log($"Set sleep time to {SleepTime}");

        }

        private void Log(string message)
        {
            ResultBox.Text = message;
        }
    }
}
