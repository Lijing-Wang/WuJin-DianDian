using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.XPath;

namespace 连点器
{
    public partial class Form1 : Form
    {
        private decimal Frequency { get; set; }
        private decimal SleepTime { get; set; }

        // countdown time for mouse to get ready - seconds
        private readonly int Countdown = 1;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);


        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        public Form1()
        {
            InitializeComponent();
            ResultBox.Text = "Results:";
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            Log($"Count down for {Countdown} seconds to start");
            await Task.Delay(Countdown * 1000); // Countdown is in seconds, Task.Delay takes milliseconds

            Log("Countdown finished. Starting process...");
            // start mouse clicking
            StimulateClick();
        }

        private void StimulateClick()
        {
            Point CurrentCursorPosition;
            var findPoint = GetCursorPos(out CurrentCursorPosition);
            if (findPoint)
            {
                int x = CurrentCursorPosition.X;
                int y = CurrentCursorPosition.Y;
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                Log($"Clicked at {x}, {y}");
            }
            else
            {
                Log("Failed to get cursor position");
            }
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
