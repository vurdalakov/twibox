namespace Vurdalakov
{
    using System;
    using System.Collections.Generic;

    public class ImageProperties
    {
        private Dictionary<ImageAdjustmentType, Int32> adjustmentValues = new Dictionary<ImageAdjustmentType, Int32>();

        public ImageProperties()
        {
            for (var i = 1; i < (Int32)ImageAdjustmentType.MaxAdjustment; i++)
            {
                this.adjustmentValues.Add((ImageAdjustmentType)i, 0);
            }
        }

        public Boolean IsModified(ImageAdjustmentType imageAdjustmentType) => this.adjustmentValues[imageAdjustmentType] != 0;

        public Int32 Get(ImageAdjustmentType imageAdjustmentType) => this.adjustmentValues[imageAdjustmentType];

        public void Set(ImageAdjustmentType imageAdjustmentType, Int32 imageAdjustmentValue) => this.adjustmentValues[imageAdjustmentType] = imageAdjustmentValue;
    }
}
