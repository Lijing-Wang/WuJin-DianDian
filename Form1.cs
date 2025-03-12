using 连点器.Lib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace 连点器
{
    public partial class Form1 : Form
    {

        private static DateTime _endDateTime;
        private bool _likeHuman = true;
        private bool _inProcess = false;
        private bool _useCurrentPosition = true;
        private bool _inRecording = false;
        private bool _addNewPoint = false;

        // number is in x/per second
        private decimal _frequency = 3;
        // number is in milliseconds
        private int _interval = 333;

        // used in human-like clicking mode, randomly draw a frequency
        // number is in seconds
        private List<double> _clickWaitTimeChoices = new List<double> { 1, 0.5, 0.3 };

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

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateDatetime()) return;

            ToggleStartStopButton(true);

            _logger.Log($"Count down for {_countdown} seconds to start");
            await Task.Delay(_countdown * 1000);

            KeyHook.KeyHookID = KeyHook.SetKeyHook();
            KeyHook.ContinueClicking = true;

            while (KeyHook.ContinueClicking && DateTime.Now <= _endDateTime)
            {
                if (_useCurrentPosition)
                {
                    await ClickAtCurrentPositionWithCustomFrequency();
                }
                else if (_inRecording)
                {
                    await ReplayRecordedClicks();
                }
                else if (_addNewPoint)
                {
                    await ClickAtRecordedPointWithCustomFrequency();
                }
            }

            _logger.Append("End clicking");
        }

        private async Task ClickAtCurrentPositionWithCustomFrequency()
        {
            if (KeyHook.ContinueClicking)
            {
                _clickStimulator.StimulateClickAtCurrentPosition();
                await WaitForNextClick();
            }
        }

        private async Task ReplayRecordedClicks()
        {
            foreach (var track in MouseHook.ClickTracks.Tracks)
            {
                if (KeyHook.ContinueClicking)
                {
                    _clickStimulator.StimulateClickAt(track.Position);
                    await Task.Delay(track.WaitTimeBeforeNextClick);
                    _logger.Append($"Waiting for {track.WaitTimeBeforeNextClick / 1000}s.");
                }
            }
        }

        private async Task ClickAtRecordedPointWithCustomFrequency()
        {
            foreach (var track in MouseHook.ClickTracks.Tracks)
            {
                if (KeyHook.ContinueClicking)
                {
                    _clickStimulator.StimulateClickAt(track.Position);
                    await WaitForNextClick();
                }
            }
        }

        private async Task WaitForNextClick()
        {
            if (_likeHuman)
            {
                var interval = GetRandomClickInterval();
                await Task.Delay(interval);
                _logger.Append($"{(_likeHuman ? "human-like mode" : "machine mode")}: {interval}s.");
            }
            else
            {
                await Task.Delay(_interval);
                _logger.Append($"{(_likeHuman ? "human-like mode" : "machine mode")}: {_interval}s.");
            }
        }

        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _endDateTime = EndDateTimePicker.Value;
            ValidateDatetime();
        }

        private void LikeMachineClickControl_CheckedChanged(object sender, EventArgs e)
        {
            UpdateClickingFrequency(!LikeMachineClickControl.Checked);
        }

        private void LikeHumanClickControl_CheckedChanged(object sender, EventArgs e)
        {

            UpdateClickingFrequency(LikeHumanClickControl.Checked);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _mouseHook.UnhookMouse();
            _keyHook.UnhookKey();

            KeyHook.ContinueClicking = false;
            ToggleStartStopButton(false);

            _logger.Log("Stop and ready to restart.");
        }

        private void CustomFrequencyInput_ValueChanged(object sender, EventArgs e)
        {
            _frequency = CustomFrequencyInput.Value;
            _interval = (int)(1000 / _frequency);
        }

        private void UseCurrentPositionButton_CheckedChanged(object sender, EventArgs e)
        {
            if (UseCurrentPositionButton.Checked)
            {
                _useCurrentPosition = true;
                _inRecording = false;
                _addNewPoint = false;
                SwitchClickingMode();
            }
        }

        private void UseRecordedCursorButton_CheckedChanged(object sender, EventArgs e)
        {
            if (UseRecordedCursorButton.Checked)
            {
                _useCurrentPosition = false;
                _inRecording = true;
                _addNewPoint = false;
                SwitchClickingMode();
            }
        }

        private void AddNewPointButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AddNewPointButton.Checked)
            {
                _useCurrentPosition = false;
                _inRecording = false;
                _addNewPoint = true;
                SwitchClickingMode();
            }
        }

        private void StartCursorRecordingButton_Click(object sender, EventArgs e)
        {
            MouseHook.ClickTracks.ClearTracks();
            MouseHook.MouseHookID = MouseHook.SetMouseHook();

            _logger.Log($"In recording mode.");
        }

        private void StopCursorRecordingButton_Click(object sender, EventArgs e)
        {
            _mouseHook.UnhookMouse();

            // sort out tracks and populate waittime attributes
            MouseHook.ClickTracks.PopulateWaitTime();
            // populate UI boxes
            PopulatePointBoxes();

            _logger.Log($"End recording. Click traks: {MouseHook.ClickTracks.PrintTracks()}");
        }

        private void ToggleStartStopButton(bool inProgress)
        {
            _inProcess = inProgress;
            StartBtn.Enabled = !_inProcess;
            StopButton.Enabled = _inProcess;
        }

        private void UpdateClickingFrequency(bool likeHumanChecked)
        {
            _likeHuman = likeHumanChecked;

            if (_likeHuman)
            {
                LikeMachineClickControl.Checked = !_likeHuman;

                _logger.Log($"Human-like click - speed from {String.Join("s, ", _clickWaitTimeChoices.ToArray())}");
            }
            else
            {
                LikeHumanClickControl.Checked = _likeHuman;

                _logger.Log($"Custom set click - speed: {_frequency}/second");

            }
            CustomFrequencyInput.Enabled = !_likeHuman;
        }

        private void SwitchClickingMode()
        {
            if (_useCurrentPosition)
            {
                UseRecordedCursorButton.Checked = false;
                AddNewPointButton.Checked = false;

                _logger.Log("Use current cursor position");
            }
            else if (_inRecording)
            {
                UseCurrentPositionButton.Checked = false;
                AddNewPointButton.Checked = false;

                _logger.Log("Use recorded cursor");
            }
            else if (_addNewPoint)
            {
                UseCurrentPositionButton.Checked = false;
                UseRecordedCursorButton.Checked = false;

                _logger.Log("Use add-point mode");
            }

            StartCursorRecordingButton.Enabled = _inRecording || _addNewPoint;
            StopCursorRecordingButton.Enabled = _inRecording || _addNewPoint;
        }

        private int GetRandomClickInterval()
        {
            Random random = new Random();
            int index = random.Next(_clickWaitTimeChoices.Count);
            return Convert.ToInt32(_clickWaitTimeChoices[index] * 1000);
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

        private void PopulatePointBoxes()
        {
            var pointboxes = GetPointBoxes();

            foreach (var track in MouseHook.ClickTracks.Tracks)
            {
                var box = GetPointBoxes().FirstOrDefault(x => String.IsNullOrEmpty(x.Text));
                box.Text = track.GetCorodinates();  
            }

        }

        private List<TextBox> GetPointBoxes()
        {
            var pointboxes = groupBox2.Controls.OfType<TextBox>();
            pointboxes = pointboxes.OrderBy(x => x.TabIndex);

            return pointboxes.ToList<TextBox>();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _mouseHook.UnhookMouse();
            _keyHook.UnhookKey();
            base.OnFormClosed(e);
        }
    }
}
