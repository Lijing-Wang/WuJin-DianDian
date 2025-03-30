using System.Diagnostics;
using System.Runtime.InteropServices;
using 连点器.Models;

namespace 连点器.Lib
{
    internal class MouseHook : Hook
    {
        // Import the necessary functions from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern nint SetWindowsHookEx(int idHook, MouseProc lpfn, nint hMod, uint dwThreadId);


        private const int WH_MOUSE_LL = 14;
        private const int WM_LBUTTONDOWN = 0x0201;
        private static MouseProc _mouseProc = MouseHookCallback;
        private delegate nint MouseProc(int nCode, nint wParam, nint lParam);

        internal static nint MouseHookID = nint.Zero;

        internal static RecordedPlan MarchPlan  = new RecordedPlan();
        internal static RecordedPlan HealPlan = new RecordedPlan();

        internal static string PlanNameInRecording { get; set; } = "";

        internal static RecordedPlan GetRecordedPlan(string planName)
        {
            return planName == RecordedPlanName.March ? MarchPlan : HealPlan;
        }

        internal static nint SetMouseHook(string recordedPlanName)
        {
            PlanNameInRecording = recordedPlanName;

            if(PlanNameInRecording == RecordedPlanName.March)
            {
                MarchPlan.NewTrack();
            }
            else if (PlanNameInRecording == RecordedPlanName.Heal)
            {
                HealPlan.NewTrack();
            }

            using Process curProcess = Process.GetCurrentProcess();
            using ProcessModule curModule = curProcess.MainModule;
            return SetWindowsHookEx(WH_MOUSE_LL, _mouseProc, GetModuleHandle(curModule.ModuleName), 0);
        }

        private static nint MouseHookCallback(int nCode, nint wParam, nint lParam)
        {
            if (nCode >= 0 && wParam == WM_LBUTTONDOWN)
            {
                // Cast lParam to MOUSEHOOKSTRUCT
                HookStructs mouseHookStruct = Marshal.PtrToStructure<HookStructs>(lParam);

                // Add the track to ClickTracks
                if (PlanNameInRecording == RecordedPlanName.March)
                {
                    MarchPlan.AddTrack(new Point(mouseHookStruct.pt.x, mouseHookStruct.pt.y));
                }
                else if (PlanNameInRecording == RecordedPlanName.Heal)
                {
                    HealPlan.AddTrack(new Point(mouseHookStruct.pt.x, mouseHookStruct.pt.y));
                }
            }
            return CallNextHookEx(MouseHookID, nCode, wParam, lParam);
        }

        internal void UnhookMouse()
        {
            UnhookWindowsHookEx(MouseHookID);
        }
    }
}
