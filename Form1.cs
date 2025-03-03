
using System.Diagnostics;
using System.Windows.Forms;

namespace 连点器
{
    public partial class Form1 : Form
    {

        private DateTime EndDateTime;

        private bool likeHuman = true;
        private bool inProcess = false;

        // per second
        private decimal Frequency = 3;
        private int Interval = 333;

        // randomly draw a choice to minic human clicking behavior
        // in seconds
        private List<double> ClickWaitTimeChoices = new List<double> { 1, 0.5, 0.3 };

        // countdown time for mouse to get ready - seconds
        private readonly int Countdown = 1;

        private readonly Logger logger;
        private readonly ClickStimulator ClickStimulator;

        public Form1()
        {
            InitializeComponent();
            logger = new Logger(ResultBox);
            ClickStimulator = new ClickStimulator(ResultBox);

            EndDateTimePicker.Format = DateTimePickerFormat.Custom;
            EndDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            EndDateTimePicker.Value = DateTime.Now;

            CustomFrequencyInput.Enabled = !likeHuman;

            StartBtn.Enabled = !inProcess;
            StopButton.Enabled = inProcess;
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            inProcess = true;
            StartBtn.Enabled = !inProcess;
            StopButton.Enabled = inProcess;


            EndDateTime = EndDateTimePicker.Value;

            logger.Append($"Count down for {Countdown} seconds to start");
            await Task.Delay(Countdown * 1000);

            logger.Append("Countdown finished. Starting clicking...");

            while (DateTime.Now <= EndDateTime)
            {
                ClickStimulator.StimulateClick();
                if (likeHuman)
                {
                    var interval = GetRamdomClickInterval();
                    await Task.Delay(interval);
                    logger.Append($"{(likeHuman ? "human-like mode" : "machine mode")}: {interval}s.");
                }
                else
                {
                    await Task.Delay(Interval);
                    logger.Append($"{(likeHuman ? "human-like mode" : "machine mode")}: {Interval}s.");

                }
            }

            logger.Append("End clicking");
        }

        private int GetRamdomClickInterval()
        {
            Random random = new Random();
            int index = random.Next(ClickWaitTimeChoices.Count);
            return Convert.ToInt32(ClickWaitTimeChoices[index] * 1000);
        }

        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            EndDateTime = EndDateTimePicker.Value;
            if (EndDateTime > DateTime.Now)
            {
                logger.Append($"Set end date time to {EndDateTime}");
            }
            else
            {
                logger.Append("Change time picker as it is in the past");
            }

        }

        private void LikeMachineClickControl_CheckedChanged(object sender, EventArgs e)
        {
            likeHuman = !LikeMachineClickControl.Checked;
            LikeHumanClickControl.Checked = likeHuman;
            CustomFrequencyInput.Enabled = !likeHuman;

            logger.Append($"Turn on human-like click mode - ramdomly pick speed for every click from {String.Join("s, ", ClickWaitTimeChoices.ToArray())}");
        }

        private void LikeHumanClickControl_CheckedChanged(object sender, EventArgs e)
        {
            likeHuman = LikeHumanClickControl.Checked;
            LikeMachineClickControl.Checked = !likeHuman;
            CustomFrequencyInput.Enabled = !likeHuman;

            logger.Append($"Turn on machine-like click mode - clicking speed: {Frequency}/second");

        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            inProcess = false;
            StartBtn.Enabled = !inProcess;
            StopButton.Enabled = inProcess;

            // invalid the end time to stop the clicking
            EndDateTime = DateTime.Now;
        }

        private void CustomFrequencyInput_ValueChanged(object sender, EventArgs e)
        {
            Frequency = CustomFrequencyInput.Value;
            Interval = (int)(1000 / Frequency);
        }
    }
}
