using System.Runtime.InteropServices;


namespace 连点器
{
    internal class ClickStimulator
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        internal static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        internal const int MOUSEEVENTF_LEFTDOWN = 0x02;
        internal const int MOUSEEVENTF_LEFTUP = 0x04;

        private Logger logger;

        public ClickStimulator(TextBox resultBox)
        {
            this.logger = new Logger(resultBox);

        }

        internal void StimulateClick()
        {
            Point CurrentCursorPosition;
            var findPoint = GetCursorPos(out CurrentCursorPosition);
            if (findPoint)
            {
                int x = CurrentCursorPosition.X;
                int y = CurrentCursorPosition.Y;
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                logger.Log($"Clicked at {x}, {y}");
            }
            else
            {
                logger.Log("Failed to get cursor position");
            }
        }
    }
}
