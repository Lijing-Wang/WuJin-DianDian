using System.Runtime.InteropServices;


namespace 连点器.Lib
{
    internal class ClickStimulator
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        internal static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        internal const int MOUSEEVENTF_LEFTDOWN = 0x02;
        internal const int MOUSEEVENTF_LEFTUP = 0x04;

        private readonly Logger logger;

        public ClickStimulator(TextBox resultBox)
        {
            logger = new Logger(resultBox);
        }

        internal void StimulateClickAtCurrentPosition()
        {
            Point CurrentCursorPosition;
            var findPoint = GetCursorPos(out CurrentCursorPosition);
            if (findPoint)
            {
                int x = CurrentCursorPosition.X;
                int y = CurrentCursorPosition.Y;
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                logger.Append($"Clicked at {x}, {y}.");
            }
            else
            {
                logger.Append("Failed to get cursor position");
            }
        }

        internal void StimulateClickAt(Point point)
        {
            SetCursorPos(point.X, point.Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, point.X, point.Y, 0, 0);
            logger.Append($"Clicked at {point.X}, {point.Y}.");
        }
    }
}
