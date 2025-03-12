using System.Diagnostics;
using System.Runtime.InteropServices;
using 连点器.Models;

namespace 连点器.Lib
{
    internal class KeyHook : Hook
    {
        // Import the necessary functions from user32.dll
         [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern nint SetWindowsHookEx(int idHook, KeyBoardProc lpfn, nint hMod, uint dwThreadId);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int VK_ESCAPE = 0x1B;
        private static KeyBoardProc _keyProc = KeyHookCallback;
        private delegate nint KeyBoardProc(int nCode, nint wParam, nint lParam);
        internal static nint KeyHookID = nint.Zero;

        internal static bool ContinueClicking = false;

        internal static nint SetKeyHook()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, _keyProc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static nint KeyHookCallback(int nCode, nint wParam, nint lParam)
        {
            if (nCode >= 0 && wParam == WM_KEYDOWN)
            {
                // Marshal the lParam to a KBDLLHOOKSTRUCT
                KBDLLHOOKSTRUCT kbHookStruct = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

                // Check if the key pressed is VK_ESCAPE
                if (kbHookStruct.vkCode == VK_ESCAPE)
                {
                    ContinueClicking = false;
                }
            }
            return CallNextHookEx(KeyHookID, nCode, wParam, lParam);
        }

        internal void UnhookKey()
        {
            ContinueClicking = false;
            UnhookWindowsHookEx(KeyHookID);
        }
    }
}
