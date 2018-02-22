namespace Vurdalakov
{
    using System;
    using System.Windows.Forms;

    public static class FormExtensions
    {
        //
        // 1. Add settings with name "UpgradeUserSettings", type "bool", scope "User" and value "True" to Properties/Settings.settings file.
        //
        // 2. Restore position in Load event handler:
        //
        //        private void MainForm_Load(Object sender, EventArgs e)
        //        {
        //            this.UpgradeUserSettings();
        //        }
        //

        public static void UpgradeUserSettings(this Form form, String settingName = "UpgradeUserSettings")
        {
            // Got System.Configuration.SettingsPropertyNotFoundException exception? Then do step 1 above.
            if ((Boolean)Properties.Settings.Default[settingName])
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default[settingName] = false;
                Properties.Settings.Default.Save();
            }
        }

        //
        // 1. Add settings with name "MainFormPlacement", type "string" and scope "User" to Properties/Settings.settings file.
        //
        // 2. Restore position in Load event handler:
        //
        //        private void MainForm_Load(Object sender, EventArgs e)
        //        {
        //            this.RestoreWindowPlacement();
        //        }
        //
        // 3. Save position in FormClosing event handler:
        //
        //        private void MainForm_FormClosing(Object sender, FormClosingEventArgs e)
        //        {
        //            this.SaveWindowPlacement();
        //        }
        //

        private const String DefaultWindowPlacementSettingName = "MainFormPlacement";

        public static void SaveWindowPlacement(this Form form, String settingName = DefaultWindowPlacementSettingName)
        {
            Properties.Settings.Default[settingName] = WindowPlacement.Save(form.Handle);
            Properties.Settings.Default.Save();
        }

        public static void RestoreWindowPlacement(this Form form, String settingName = DefaultWindowPlacementSettingName)
        {
            // Got System.Configuration.SettingsPropertyNotFoundException exception? Then do step 1 above.
            WindowPlacement.Restore(form.Handle, Properties.Settings.Default[settingName] as String);
        }
    }
}
