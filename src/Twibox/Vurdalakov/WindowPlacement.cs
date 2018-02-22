﻿namespace Vurdalakov
{
    using System;
    using System.Runtime.InteropServices;

    // Based on:
    // https://blogs.msdn.microsoft.com/davidrickard/2010/03/08/saving-window-size-and-location-in-wpf-and-winforms/
    public static class WindowPlacement
    {
        public static String Save(IntPtr windowHandle)
        {
            try
            {
                WINDOWPLACEMENT windowPlacement = new WINDOWPLACEMENT();
                if (!GetWindowPlacement(windowHandle, out windowPlacement))
                {
                    return "";
                }

                var bytes = SerializeTool.Serialize(windowPlacement);

                return Convert.ToBase64String(bytes);
            }
            catch
            {
                return "";
            }
        }

        public static void Restore(IntPtr windowHandle, String placementBase64String)
        {
            try
            {
                var bytes = Convert.FromBase64String(placementBase64String);

                var windowPlacement = SerializeTool.Deserialize<WINDOWPLACEMENT>(bytes);

                windowPlacement.length = (UInt32)Marshal.SizeOf(typeof(WINDOWPLACEMENT));
                windowPlacement.flags = 0;
                windowPlacement.showCmd = (windowPlacement.showCmd == SW_SHOWMINIMIZED ? SW_SHOWNORMAL : windowPlacement.showCmd);

                SetWindowPlacement(windowHandle, ref windowPlacement);
            }
            catch { }
        }

        #region Win32 API

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct RECT
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct WINDOWPLACEMENT
        {
            public UInt32 length;
            public UInt32 flags;
            public UInt32 showCmd;
            public POINT ptMinPosition;
            public POINT ptMaxPosition;
            public RECT rcNormalPosition;
        }

        private const UInt32 SW_SHOWNORMAL = 1;
        private const UInt32 SW_SHOWMINIMIZED = 2;

        [DllImport("user32.dll")]
        private static extern Boolean SetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        private static extern Boolean GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        #endregion
    }
}
