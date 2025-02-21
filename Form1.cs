
using System.Windows.Forms;

namespace 连点器
{
    public partial class Form1 : Form
    {
        private decimal Frequency;
        private DateTime EndDateTime;
        private DateTime StartDateTime = DateTime.Now;

        private int TotalClicks;
        private int ClickInterval; 

        // countdown time for mouse to get ready - seconds
        private readonly int Countdown = 1;

        private readonly Logger logger;
        private readonly ClickStimulator ClickStimulator;

        public Form1()
        {
            InitializeComponent();
            logger = new Logger(ResultBox);
            ClickStimulator = new ClickStimulator(ResultBox);

            Frequency = FrequencyInput.Value;

            EndDateTimePicker.Format = DateTimePickerFormat.Custom;
            EndDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            EndDateTimePicker.Value = StartDateTime;
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            logger.Log($"Count down for {Countdown} seconds to start");
            await Task.Delay(Countdown * 1000); // Countdown is in seconds, Task.Delay takes milliseconds

            logger.Log("Countdown finished. Starting process...");

            GetTotalClicks();
            SetClickInterval();

            for (int i = 0; i < TotalClicks; i++)
            {
                ClickStimulator.StimulateClick(i+1);
                await Task.Delay(ClickInterval);
            }   
        }

        private void GetTotalClicks()
        {
            TotalClicks = (int)((EndDateTime - StartDateTime).TotalSeconds / (double)Frequency);
            logger.Log($"Total clicks will be {TotalClicks}");

        }

        private void SetClickInterval()
        {
            ClickInterval = (int)(1000 / Frequency);
            logger.Log($"Click interval will be {ClickInterval}");

        }

        private void FrequencyInput_ValueChanged(object sender, EventArgs e)
        {
            Frequency = FrequencyInput.Value;
            logger.Log($"Set frequency to {Frequency}");

        }

        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            EndDateTime = EndDateTimePicker.Value;
            logger.Log($"Set end date time to {EndDateTime}");

        }
    }
}
