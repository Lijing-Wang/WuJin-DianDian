
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace 连点器
{
    public partial class Form1 : Form
    {

        private static DateTime EndDateTime;

        private bool likeHuman = true;
        private bool inProcess = false;
        private bool useCurrentPosition = true;
        private static bool continueClicking = true;

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

        private static ClickTracks ClickTracks = new ClickTracks();

        // Import the necessary functions from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr SetWindowsHookEx(int idHook, MouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyBoardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);



        private const int WH_MOUSE_LL = 14;
        private const int WM_LBUTTONDOWN = 0x0201;
        private static MouseProc _mouseProc = MouseHookCallback;
        private delegate IntPtr MouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static IntPtr _mouseHookID = IntPtr.Zero;

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int VK_ESCAPE = 0x1B;
        private static KeyBoardProc _keyProc = KeyHookCallback;
        private delegate IntPtr KeyBoardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static IntPtr _keyHookID = IntPtr.Zero;



        public Form1()
        {
            InitializeComponent();
            logger = new Logger(ResultBox);
            ClickStimulator = new ClickStimulator(ResultBox);

            EndDateTimePicker.Format = DateTimePickerFormat.Custom;
            EndDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            EndDateTimePicker.Value = DateTime.Now;
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            if (!DatetimeValidator()) return;
            
            StartStopButtonSwitch(true);

            logger.Log($"Count down for {Countdown} seconds to start");
            await Task.Delay(Countdown * 1000);

            _keyHookID = SetKeyHook(_keyProc);

            continueClicking = true;

            while (continueClicking && DateTime.Now <= EndDateTime)
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
                    foreach (var track in ClickTracks.Tracks)
                    {
                        if (continueClicking)
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
            UnhookWindowsHookEx(_keyHookID);
            UnhookWindowsHookEx(_mouseHookID);

            continueClicking = false;
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
            ClickTracks.ClearTracks();
            _mouseHookID = SetMouseHook(_mouseProc);

            logger.Log($"In recording mode.");
        }

        private void StopCursorRecordingButton_Click(object sender, EventArgs e)
        {
            UnhookWindowsHookEx(_mouseHookID);

            // order tracks and populate waittime
            ClickTracks.PopulateWaitTime();
            logger.Log($"End recording. Click traks: {ClickTracks.Print()}");
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

        private static IntPtr SetMouseHook(MouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr SetKeyHook(KeyBoardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONDOWN)
            {
                // Cast lParam to MOUSEHOOKSTRUCT
                HookStruct mouseHookStruct = Marshal.PtrToStructure<HookStruct>(lParam);

                // Add the track to ClickTracks
                ClickTracks.AddTrack(new Point(mouseHookStruct.pt.x, mouseHookStruct.pt.y));
            }
            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
        }

        private static IntPtr KeyHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                // Marshal the lParam to a KBDLLHOOKSTRUCT
                KBDLLHOOKSTRUCT kbHookStruct = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

                // Check if the key pressed is VK_ESCAPE
                if (kbHookStruct.vkCode == VK_ESCAPE)
                {
                    continueClicking = false;
                }
            }
            return CallNextHookEx(_keyHookID, nCode, wParam, lParam);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            UnhookWindowsHookEx(_mouseHookID);
            UnhookWindowsHookEx(_keyHookID);
            base.OnFormClosed(e);
        }


    }
}
