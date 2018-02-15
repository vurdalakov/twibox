namespace Vurdalakov
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    public static class ControlExtensions
    {
        public static void SetDoubleClick(this Control control)
        {
            control.SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
            control.SetStyle(ControlStyles.StandardClick, false);
        }

        public static void SetStyle(this Control control, ControlStyles flags, Boolean value)
        {
            var methodInfo = control.GetType().GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo?.Invoke(control, new Object[] { flags, value });
        }
    }

}
