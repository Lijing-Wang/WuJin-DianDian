
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using 连点器.Lib;

namespace 连点器
{
    public partial class Form1 : Form
    {

        private static DateTime EndDateTime;

        private bool likeHuman = true;
        private bool inProcess = false;
        private bool useCurrentPosition = true;

        // per second
        private decimal Frequency = 3;
        private int Interval = 333;

        // randomly draw a choice to minic human clicking behavior
        // in seconds
        private List<double> ClickWaitTimeChoices = new List<double> { 1, 0.5, 0.3 };

        // countdown time for mouse to get ready - seconds
        private readonly int Countdown = 1;

        private static Logger logger;

        private readonly ClickStimulator ClickStimulator;

        internal MouseHook MouseHook { get; }
        internal KeyHook KeyHook { get; }

        public Form1()
        {
            InitializeComponent();
            logger = new Logger(ResultBox);
            ClickStimulator = new ClickStimulator(ResultBox);

            EndDateTimePicker.Format = DateTimePickerFormat.Custom;
            EndDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            EndDateTimePicker.Value = DateTime.Now;

            MouseHook = new MouseHook();
            KeyHook = new KeyHook();
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            if (!DatetimeValidator()) return;
            
            StartStopButtonSwitch(true);

            logger.Log($"Count down for {Countdown} seconds to start");
            await Task.Delay(Countdown * 1000);

            KeyHook._keyHookID = KeyHook.SetKeyHook();

            KeyHook.continueClicking = true;

            while (KeyHook.continueClicking && DateTime.Now <= EndDateTime)
            {
                if (useCurrentPosition)
                {
                    ClickStimulator.StimulateClickAtCurrentPosition();
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
                else
                {
                    foreach (var track in MouseHook.ClickTracks.Tracks)
                    {
                        if (KeyHook.continueClicking)
                        {
                            ClickStimulator.StimulateClickAt(track.Position);
                            await Task.Delay(track.waitTimeBeforeNextClick);
                            logger.Append($"Waiting for {track.waitTimeBeforeNextClick / 1000}s.");
                        }
                    }
                }
            }

            logger.Append("End clicking");
        }

        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            EndDateTime = EndDateTimePicker.Value;
            DatetimeValidator();
        }

        private void LikeMachineClickControl_CheckedChanged(object sender, EventArgs e)
        {
            ClickingModeButtonSwich(!LikeMachineClickControl.Checked);
        }

        private void LikeHumanClickControl_CheckedChanged(object sender, EventArgs e)
        {

            ClickingModeButtonSwich(LikeHumanClickControl.Checked);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            MouseHook.UnhookMouse();
            KeyHook.UnhookKey();

            KeyHook.continueClicking = false;
            StartStopButtonSwitch(false);

            logger.Log("Stop and ready to restart.");
        }

        private void CustomFrequencyInput_ValueChanged(object sender, EventArgs e)
        {
            Frequency = CustomFrequencyInput.Value;
            Interval = (int)(1000 / Frequency);
        }

        private void UseCurrentPositionButton_CheckedChanged(object sender, EventArgs e)
        {
            CursorPositionModeSwitching(UseCurrentPositionButton.Checked);
        }

        private void UseRecordedCursorButton_CheckedChanged(object sender, EventArgs e)
        {
            CursorPositionModeSwitching(!UseRecordedCursorButton.Checked);

        }

        private void StartCursorRecordingButton_Click(object sender, EventArgs e)
        {
            MouseHook.ClickTracks.ClearTracks();
            MouseHook._mouseHookID = MouseHook.SetMouseHook();

            logger.Log($"In recording mode.");
        }

        private void StopCursorRecordingButton_Click(object sender, EventArgs e)
        {
            MouseHook.UnhookMouse();

            // order tracks and populate waittime
            MouseHook.ClickTracks.PopulateWaitTime();
            logger.Log($"End recording. Click traks: {MouseHook.ClickTracks.Print()}");
        }

        private void StartStopButtonSwitch(bool inProgress)
        {
            inProcess = inProgress;
            StartBtn.Enabled = !inProcess;
            StopButton.Enabled = inProcess;
        }

        private void ClickingModeButtonSwich(bool likeHumanChecked)
        {
            likeHuman = likeHumanChecked;

            if (likeHuman)
            {
                LikeMachineClickControl.Checked = !likeHuman;

                logger.Log($"Use human-like click mode - click speed from {String.Join("s, ", ClickWaitTimeChoices.ToArray())}");
            }
            else
            {
                LikeHumanClickControl.Checked = likeHuman;

                logger.Log($"Use custom set click mode - click speed: {Frequency}/second");

            }
            CustomFrequencyInput.Enabled = !likeHuman;

        }

        private void CursorPositionModeSwitching(bool useCurrent)
        {
            useCurrentPosition = useCurrent;
            if (useCurrent)
            {
                UseRecordedCursorButton.Checked = !useCurrentPosition;
                StartCursorRecordingButton.Enabled = !useCurrentPosition;
                StopCursorRecordingButton.Enabled = !useCurrentPosition;
                logger.Log("Use current cursor position");
            }
            else
            {
                UseCurrentPositionButton.Checked = useCurrent;
                StartCursorRecordingButton.Enabled = !useCurrentPosition;
                StopCursorRecordingButton.Enabled = !useCurrentPosition;
                logger.Log("Use recorded cursor");
            }
        }

        private int GetRamdomClickInterval()
        {
            Random random = new Random();
            int index = random.Next(ClickWaitTimeChoices.Count);
            return Convert.ToInt32(ClickWaitTimeChoices[index] * 1000);
        }

        private bool DatetimeValidator()
        {
            if (EndDateTime > DateTime.Now)
            {
                logger.Log($"Set end date time to {EndDateTime}");
                return true;
            }
            else
            {
                logger.Log("ERROR: Change time picker as it is in the past");
                return false;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            MouseHook.UnhookMouse();
            KeyHook.UnhookKey();
            base.OnFormClosed(e);
        }


    }
}
