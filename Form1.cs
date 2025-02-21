
namespace 连点器
{
    public partial class Form1 : Form
    {
        private decimal Frequency { get; set; }
        private decimal SleepTime { get; set; }

        // countdown time for mouse to get ready - seconds
        private readonly int Countdown = 1;

        private Logger logger;
        private ClickStimulator ClickStimulator;

        public Form1()
        {
            InitializeComponent();
            this.logger = new Logger(ResultBox);
            this.ClickStimulator = new ClickStimulator(ResultBox);
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            logger.Log($"Count down for {Countdown} seconds to start");
            await Task.Delay(Countdown * 1000); // Countdown is in seconds, Task.Delay takes milliseconds

            logger.Log("Countdown finished. Starting process...");
            // start mouse clicking
            ClickStimulator.StimulateClick();
        }

        private void FrequencyInput_ValueChanged(object sender, EventArgs e)
        {
            Frequency = FrequencyInput.Value;
            logger.Log($"Set frequency to {Frequency}");
            
        }

        private void SleepTimeInput_ValueChanged(object sender, EventArgs e)
        {
            SleepTime = SleepTimeInput.Value;
            logger.Log($"Set sleep time to {SleepTime}");

        }

    }
}
