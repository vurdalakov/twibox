namespace Vurdalakov
{
    using System;
    using System.Linq;

    public enum ImageAdjustmentType
    {
        None,
        Contrast
    }

    public static class ImageAdjustmentTypeExtensions
    {
        public static ImageAdjustmentType ToImageAdjustmentType(this string enumValueName)
        {
            enumValueName = enumValueName.Trim();

            var enumValueNames = Enum.GetValues(typeof(ImageAdjustmentType)).Cast<ImageAdjustmentType>();
            return enumValueNames.FirstOrDefault(enumValue => enumValue.ToString().EqualsNoCase(enumValueName));
        }
    }
}
