namespace Vurdalakov
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public enum ImageAdjustmentType
    {
        None,
        Contrast,
        MaxAdjustment
    }

    public static class ImageAdjustmentTypeExtensions
    {
        public static ImageAdjustmentType ToImageAdjustmentType(this String enumValueName)
        {
            enumValueName = enumValueName.Trim();

            var enumValueNames = Enum.GetValues(typeof(ImageAdjustmentType)).Cast<ImageAdjustmentType>();
            return enumValueNames.FirstOrDefault(enumValue => enumValue.ToString().EqualsNoCase(enumValueName));
        }

        public static ImageAdjustmentType ToImageAdjustmentType(this Control adjustmentControl)
        {
            return adjustmentControl?.Tag?.ToString().ToImageAdjustmentType() ?? ImageAdjustmentType.None;
        }
    }
}
