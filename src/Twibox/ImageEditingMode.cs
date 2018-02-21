namespace Vurdalakov
{
    using System;
    using System.Windows.Forms;

    public enum ImageEditingMode
    {
        None,
        Adjust,
        Crop
    }

    public static class ImageEditingModeExtensions
    {
        public static ImageEditingMode GetImageEditingMode(this Control control)
        {
            var tag = control?.Tag as String;
            return tag?.ToImageEditingMode() ?? ImageEditingMode.None;
        }

        public static ImageEditingMode ToImageEditingMode(this String imageEditingModeName)
        {
            if (String.IsNullOrEmpty(imageEditingModeName))
            {
                return ImageEditingMode.None;
            }

            var modes = Enum.GetValues(typeof(ImageEditingMode));

            foreach (ImageEditingMode mode in modes)
            {
                if (imageEditingModeName.Equals(mode.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return mode;
                }
            }

            return ImageEditingMode.None;
        }

        public static Boolean IsImageEditingMode(this Control control, ImageEditingMode mode)
        {
            return GetImageEditingMode(control) == mode;
        }

        public static Boolean IsImageEditingMode(this String imageEditingModeName, ImageEditingMode mode)
        {
            return ToImageEditingMode(imageEditingModeName) == mode;
        }
    }
}
