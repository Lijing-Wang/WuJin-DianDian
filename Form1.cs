using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Numerics;
using System.Runtime.InteropServices;
using 连点器.Lib;
using 连点器.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace 连点器
{
    public partial class Form1 : Form
    {

        private static DateTime _endDateTime;
        // click speed
        private bool _likeHuman = true;

        // operation control
        private bool _isStimulating = false;
        private bool _isRecording = false;

        // mode control
        private bool _quickStart = true;

        // recording plan switch
        private bool _marchRecording = false;

        // number is in x/per second
        private decimal _frequency = 3;
        // number is in milliseconds
        private int _interval = 333;

        // used in human-like clicking mode, randomly draw a frequency
        // number is in seconds
        private List<double> _clickWaitTimeChoices = [1, 0.5, 0.3];
        // used in advanced replay
        private List<double> _replayWaitTimeTrend = [0, 1];
        private List<int> _accelerateReplayRange = [10, 20];
        private List<int> _decelerateReplayRange = [30, 40];

        // countdown time for mouse to get ready
        // number is in seconds
        private readonly int _countdown = 1;

        private static Logger _logger;

        private readonly ClickStimulator _clickStimulator;

        private readonly MouseHook _mouseHook;
        private readonly KeyHook _keyHook;

        public Form1()
        {
            InitializeComponent();
            _logger = new Logger(ResultBox);
            _clickStimulator = new ClickStimulator(ResultBox);

            EndDateTimePicker.Format = DateTimePickerFormat.Custom;
            EndDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            EndDateTimePicker.Value = DateTime.Now;

            _mouseHook = new MouseHook();
            _keyHook = new KeyHook();
        }

#region "controls"

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateDatetime()) return;

            _isStimulating = true;
            ToggleStartStopButton();

            _logger.Log($"Count down for {_countdown} seconds to start");
            await Task.Delay(_countdown * 1000);

            KeyHook.KeyHookID = KeyHook.SetKeyHook();
            KeyHook.ContinueClicking = true;

            while (KeyHook.ContinueClicking && DateTime.Now <= _endDateTime)
            {
                if (_quickStart)
                {
                    await RunQuickStartClicks();
                }
                else
                {
                    if (ValidateRecordingPlans())
                    {
                        await RunAdvancedClicks();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            _logger.Append("Clicking is paused.");
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _mouseHook.UnhookMouse();
            _keyHook.UnhookKey();

            KeyHook.ContinueClicking = false;
            _isStimulating = false;

            ToggleStartStopButton();

            _logger.Log("Stop and ready to restart.");
        }


        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _endDateTime = EndDateTimePicker.Value;
            ValidateDatetime();
        }

        private void LikeMachineClickControl_CheckedChanged(object sender, EventArgs e)
        {
            UpdateClickingFrequencyForQuickStart(!QuickStartLikeMachineClickControl.Checked);
        }

        private void LikeHumanClickControl_CheckedChanged(object sender, EventArgs e)
        {

            UpdateClickingFrequencyForQuickStart(QuickStartLikeHumanClickControl.Checked);
        }

        private void CustomFrequencyInput_ValueChanged(object sender, EventArgs e)
        {
            _frequency = CustomFrequencyInput.Value;
            _interval = (int)(1000 / _frequency);

            _logger.Log($"Changen machine-like clicking speed to {_frequency}/s");
        }

        private void StartCursorRecordingButton_Click(object sender, EventArgs e)
        {
            if (!ValidateRecordingChecks()) return;

            if (_marchRecording)
            {
                MouseHook.MouseHookID = MouseHook.SetMouseHook(RecordedPlanName.March);
            }
            else
            {
                MouseHook.MouseHookID = MouseHook.SetMouseHook(RecordedPlanName.Heal);
            }

            _isRecording = true;

            ToggleRecordingButton();

            _logger.Log($"In recording mode.");
        }

        private void StopCursorRecordingButton_Click(object sender, EventArgs e)
        {
            _mouseHook.UnhookMouse();

            if (MouseHook.PlanNameInRecording == RecordedPlanName.March)
            {
                MouseHook.MarchPlan.PopulateWaitTime();
            }
            else if (MouseHook.PlanNameInRecording == RecordedPlanName.Heal)
            {
                MouseHook.HealPlan.PopulateWaitTime();
            }

            _isRecording = false;

            ToggleRecordingButton();

            _logger.Log($"End recording. Click traks: {(MarchRecordingCheckBox.Checked ? MouseHook.MarchPlan.PrintTracks() : MouseHook.HealPlan.PrintTracks())}");
        }

        private void QuickStartRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _quickStart = QuickStartRadioBtn.Checked;
            ToggleQuickOrAdvancedMode();
        }

        private void AdvancedRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _quickStart = !AdvancedRadioBtn.Checked;
            ToggleQuickOrAdvancedMode();
        }

        private void MarchRecordingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MarchRecordingCheckBox.Checked)
            {
                _marchRecording = true;
                HealRecordingCheckBox.Checked = false;
                MarchRandomReplayControl.Checked = false;
            }
        }

        private void HealRecordingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (HealRecordingCheckBox.Checked)
            {
                _marchRecording = false;
                MarchRecordingCheckBox.Checked = true;
                HealRandomReplayControl.Checked = false;
            }
        }

        private void March_LikeHumanClickControl_CheckedChanged(object sender, EventArgs e)
        {
            if (MarchLikeHumanClickControl.Checked)
            {
                MouseHook.MarchPlan.LikeHuman = true;
                UpdateClickingFrequencyForRecordingPlan(MouseHook.MarchPlan, nameof(MouseHook.MarchPlan.LikeHuman));

                MarchLikeMachineClickControl.Checked = false;
                MarchReplayControl.Checked = false;
                MarchRandomReplayControl.Checked = false;
            }
        }

        private void Heal_LikeHumanClickControl_CheckedChanged(object sender, EventArgs e)
        {
            if (HealLikeHumanClickControl.Checked)
            {
                MouseHook.HealPlan.LikeHuman = true;
                UpdateClickingFrequencyForRecordingPlan(MouseHook.HealPlan, nameof(MouseHook.HealPlan.LikeHuman));

                HealLikeMachineClickControl.Checked = false;
                HealReplayControl.Checked = false;
                HealRandomReplayControl.Checked = false;
            }
        }

        private void March_LikeMachineClickControl_CheckedChanged(object sender, EventArgs e)
        {
            if (MarchLikeMachineClickControl.Checked)
            {
                MouseHook.MarchPlan.LikeMachine = true;
                UpdateClickingFrequencyForRecordingPlan(MouseHook.MarchPlan, nameof(MouseHook.MarchPlan.LikeMachine));

                MarchLikeHumanClickControl.Checked = false;
                MarchReplayControl.Checked = false;
                MarchRandomReplayControl.Checked = false;
            }
        }

        private void Heal_LikeMachineClickControl_CheckedChanged(object sender, EventArgs e)
        {
            if (HealLikeMachineClickControl.Checked)
            {
                MouseHook.HealPlan.LikeMachine = true;
                UpdateClickingFrequencyForRecordingPlan(MouseHook.HealPlan, nameof(MouseHook.HealPlan.LikeMachine));

                HealLikeHumanClickControl.Checked = false;
                HealReplayControl.Checked = false;
                HealRandomReplayControl.Checked = false;
            }
        }

        private void March_ReplayClickControl_CheckedChanged(object sender, EventArgs e)
        {
            if (MarchReplayControl.Checked)
            {
                MouseHook.MarchPlan.Replay = true;
                UpdateClickingFrequencyForRecordingPlan(MouseHook.MarchPlan, nameof(MouseHook.MarchPlan.Replay));

                MarchLikeMachineClickControl.Checked = false;
                MarchLikeHumanClickControl.Checked = false;
                MarchRandomReplayControl.Checked = false;
            }
        }

        private void MarchRandomReplayControl_CheckedChanged(object sender, EventArgs e)
        {
            if (MarchRandomReplayControl.Checked)
            {
                MouseHook.MarchPlan.RandomReplay = true;
                UpdateClickingFrequencyForRecordingPlan(MouseHook.MarchPlan, nameof(MouseHook.MarchPlan.Replay));

                MarchLikeMachineClickControl.Checked = false;
                MarchLikeHumanClickControl.Checked = false;
                MarchReplayControl.Checked = false;
            }
        }

        private void HealRandomReplayControl_CheckedChanged(object sender, EventArgs e)
        {
            if (HealRandomReplayControl.Checked)
            {
                MouseHook.HealPlan.RandomReplay = true;
                UpdateClickingFrequencyForRecordingPlan(MouseHook.HealPlan, nameof(MouseHook.HealPlan.Replay));

                HealLikeMachineClickControl.Checked = false;
                HealLikeHumanClickControl.Checked = false;
                HealReplayControl.Checked = false;
            }
        }

        private void Heal_ReplayClickControl_CheckedChanged(object sender, EventArgs e)
        {
            if (HealReplayControl.Checked)
            {
                MouseHook.HealPlan.Replay = true;
                UpdateClickingFrequencyForRecordingPlan(MouseHook.HealPlan, nameof(MouseHook.HealPlan.Replay));

                HealLikeMachineClickControl.Checked = false;
                HealLikeHumanClickControl.Checked = false;
            }
        }

        private void MarchRepeatDurationTextBox_TextChanged(object sender, EventArgs e)
        {
            MouseHook.MarchPlan.RepeatDuration = TimeSpan.FromMinutes(Convert.ToDouble(MarchRepeatDurationTextBox.Text));

            _logger.Log($"Set March plan repeat duration. ");

        }

        private void HealRepeatDurationTextBox_TextChanged(object sender, EventArgs e)
        {
            MouseHook.HealPlan.RepeatDuration = TimeSpan.FromMinutes(Convert.ToDouble(HealRepeatDurationTextBox.Text));

            _logger.Log($"Set Heal plan repeat duration. ");

        }

#endregion


#region "cliks"

        private async Task ReplayRecordedClicks(RecordedPlan plan)
        {
            foreach (var track in plan.Tracks)
            {
                if (KeyHook.ContinueClicking)
                {
                    _clickStimulator.StimulateClickAt(track.Position);
                    await Task.Delay(track.WaitTimeBeforeNextClick);

                    _logger.Append($"Replay and wait for {track.WaitTimeBeforeNextClick}ms.");
                }
            }
        }

        private async Task RandomlyReplayRecordedClicks(RecordedPlan plan)
        {
            foreach (var track in plan.Tracks)
            {
                if (KeyHook.ContinueClicking)
                {
                    _clickStimulator.StimulateClickAt(track.Position);

                    await Task.Delay(RandomizeRecordedFrequency(track.WaitTimeBeforeNextClick));

                    _logger.Append($"Replay and wait for {track.WaitTimeBeforeNextClick}ms.");
                }
            }
        }

        private int RandomizeRecordedFrequency(int waitTime)
        {
            Random random = new Random();

            // randomly pick 0 or 1 to accelarate or slow down
            var trendIndex = random.Next(_replayWaitTimeTrend.Count);
            var trend = _replayWaitTimeTrend[trendIndex];

            // accelarate
            if (trend == 0)
            {
                var persantage = random.Next(_accelerateReplayRange[0], _accelerateReplayRange[1]);
                return Convert.ToInt32(waitTime * 1000 * (1 - persantage / 100));
            }
            // slow down
            else
            {
                var persantage = random.Next(_decelerateReplayRange[0], _decelerateReplayRange[1]);
                return Convert.ToInt32(waitTime * 1000 * (1 + persantage / 100));
            }
        }

        private async Task ClickLikeHuman(RecordedPlan? plan = null)
        {
            var setting = plan != null ? plan.LikeHuman : _likeHuman;

            // advanced mode
            if (plan?.Tracks?.Count > 0)
            {
                foreach (var track in plan.Tracks)
                {
                    if (KeyHook.ContinueClicking)
                    {
                        _clickStimulator.StimulateClickAt(track.Position);
                        await WaitLikeHuman(setting);
                    }
                }
            }
            // quick start mode
            else
            {
                if (KeyHook.ContinueClicking)
                {
                    _clickStimulator.StimulateClickAtCurrentPosition();
                    await WaitLikeHuman(setting);
                }

            }
        }

        private async Task ClickLikeMachine(RecordedPlan? plan = null)
        {
            var setting = plan != null ? plan.LikeMachine : !_likeHuman;

            // advanced mode
            if (plan?.Tracks?.Count > 0)
            {
                foreach (var track in plan.Tracks)
                {
                    if (KeyHook.ContinueClicking)
                    {
                        _clickStimulator.StimulateClickAt(track.Position);
                        await WaitLikeMachine(setting);
                    }
                }
            }
            // quick start mode
            else
            {
                if (KeyHook.ContinueClicking)
                {
                    _clickStimulator.StimulateClickAtCurrentPosition();
                    await WaitLikeMachine(setting);
                }

            }
        }

        private async Task WaitLikeHuman(bool likeHumanSetting)
        {
            var interval = GetRandomClickInterval();
            await Task.Delay(interval);

            _logger.Append($"{(likeHumanSetting ? "human-like mode" : "machine mode")}: {interval}ms.");
        }

        private async Task WaitLikeMachine(bool likeMachineSetting)
        {
            await Task.Delay(_interval);
            _logger.Append($"{(likeMachineSetting ? "human-like mode" : "machine mode")}: {_interval}ms.");
        }

        private async Task RunQuickStartClicks()
        {
            if (_likeHuman)
            {
                await ClickLikeHuman();
            }
            else
            {
                await ClickLikeMachine();
            }
        }

        private async Task RunAdvancedClicks()
        {
            if (KeyHook.ContinueClicking)
            {
                if (MouseHook.MarchPlan.Tracks.Count > 0)
                {
                    var startTime = DateTime.Now;
                    while (KeyHook.ContinueClicking && DateTime.Now - startTime < MouseHook.MarchPlan.RepeatDuration)
                    {
                        await ExecuteAdvancedClicks(RecordedPlanName.March);
                    }
                }

                if (MouseHook.HealPlan.Tracks.Count > 0)
                {
                    var startTime = DateTime.Now;
                    while (KeyHook.ContinueClicking && DateTime.Now - startTime < MouseHook.HealPlan.RepeatDuration)
                    {
                        await ExecuteAdvancedClicks(RecordedPlanName.Heal);
                    }
                }
            }
        }

        private async Task ExecuteAdvancedClicks(string planName)
        {
            var plan = MouseHook.GetRecordedPlan(planName);

            if (plan.LikeHuman)
            {
                await ClickLikeHuman(plan);
            }
            else if (plan.LikeMachine)
            {
                await ClickLikeMachine(plan);
            }
            else if (plan.Replay)
            {
                await ReplayRecordedClicks(plan);
            }
            else if (plan.RandomReplay)
            {
                await RandomlyReplayRecordedClicks(plan);
            }
        }

        private int GetRandomClickInterval()
        {
            Random random = new Random();
            int index = random.Next(_clickWaitTimeChoices.Count);
            return Convert.ToInt32(_clickWaitTimeChoices[index] * 1000);
        }


        #endregion


#region "helpers"
        private bool ValidateRecordingChecks()
        {
            if (!MarchRecordingCheckBox.Checked && !HealRecordingCheckBox.Checked)
            {
                _logger.Log("ERROR: Choose a recording plan.");
                return false;
            }

            return true;
        }

        private void UpdateClickingFrequencyForRecordingPlan(RecordedPlan plan, string modeName)
        {
            if (modeName == nameof(plan.LikeHuman))
            {
                plan.LikeMachine = !plan.LikeHuman;
                plan.Replay = !plan.LikeHuman;
                plan.RandomReplay = !plan.LikeHuman;

                _logger.Log("Set plan's clicking speed to human-like.");
            }
            else if (modeName == nameof(plan.LikeMachine))
            {
                plan.LikeHuman = !plan.LikeMachine;
                plan.Replay = !plan.LikeMachine;
                plan.RandomReplay = !plan.LikeMachine;

                _logger.Log("Set plan's clicking speed to machine-like.");
            }
            else if (modeName == nameof(plan.Replay))
            {
                plan.LikeHuman = !plan.Replay;
                plan.LikeMachine = !plan.Replay;
                plan.RandomReplay = !plan.Replay;

                _logger.Log("Set plan's clicking speed to original replay.");
            }
            else if (modeName == nameof(plan.RandomReplay))
            {
                plan.LikeHuman = !plan.RandomReplay;
                plan.LikeMachine = !plan.RandomReplay;
                plan.Replay = !plan.LikeMachine;

                _logger.Log("Set plan's clicking speed to random replay.");
            }
        }

        private void UpdateClickingFrequencyForQuickStart(bool likeHumanChecked)
        {
            _likeHuman = likeHumanChecked;

            if (_likeHuman)
            {
                QuickStartLikeMachineClickControl.Checked = !_likeHuman;

                _logger.Log($"Human-like click - speed from {String.Join("s, ", _clickWaitTimeChoices.ToArray())}");
            }
            else
            {
                QuickStartLikeHumanClickControl.Checked = _likeHuman;

                _logger.Log($"Custom set click - speed: {_frequency}/second");

            }
            CustomFrequencyInput.Enabled = !_likeHuman;
        }

        private void ToggleStartStopButton()
        {
            StartBtn.Enabled = !_isStimulating;
            StopButton.Enabled = _isStimulating;
        }

        private void ToggleRecordingButton()
        {
            StartCursorRecordingButton.Enabled = !_isRecording;
            StopCursorRecordingButton.Enabled = _isRecording;
        }

        private void ToggleQuickOrAdvancedMode()
        {
            QuickStartRadioBtn.Checked = _quickStart;
            AdvancedRadioBtn.Checked = !_quickStart;

            foreach (var control in QuickStartGroupBox.Controls)
            {
                control.GetType().GetProperty("Enabled")?.SetValue(control, _quickStart);
            }

            foreach (var control in AdvancedGroupBox.Controls)
            {
                control.GetType().GetProperty("Enabled")?.SetValue(control, !_quickStart);
            }
        }

        private static bool ValidateDatetime()
        {
            if (_endDateTime > DateTime.Now)
            {
                _logger.Log($"Set end date time to {_endDateTime}");
                return true;
            }
            else
            {
                _logger.Log("ERROR: Change time picker as it is in the past");
                return false;
            }
        }

        private static bool ValidateRecordingPlans()
        {
            var validMarchCounts = MouseHook.MarchPlan.Tracks.Count > 0;
            var validHealCounts = MouseHook.HealPlan.Tracks.Count > 0;

            if (!validMarchCounts && !validHealCounts)
            {
                _logger.Log("ERROR: No any tracks recorded.");
                return false;
            }
            else
            {
                return ValidateClickingDuration(MouseHook.MarchPlan) && ValidateClickingDuration(MouseHook.HealPlan);
            }

        }

        private static bool ValidateClickingDuration(RecordedPlan tracks)
        {
            if (tracks.Tracks.Count > 0)
            {
                if (tracks.RepeatDuration > TimeSpan.Zero)
                {
                    return true;
                }
                else
                {
                    _logger.Log("ERROR: fill in march repeat duration.");
                    return false;
                }
            }
            return true;
        }

#endregion

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _mouseHook.UnhookMouse();
            _keyHook.UnhookKey();
            base.OnFormClosed(e);
        }
    }
}
