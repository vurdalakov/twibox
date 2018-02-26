namespace Vurdalakov
{
    using System;
    using Nancy;

    public class AdjustmentModule : NancyModule
    {
        public AdjustmentModule(WebServiceContext webServiceContext) : base("/api/adjustment")
        {
            Put["/{adjustmentName}"] = parameters => SetAdjustment(webServiceContext, parameters.adjustmentName, parameters.diff, parameters.value);
        }

        private void SetAdjustment(WebServiceContext webServiceContext, String adjustmentName, String adjustmentDiff, String adjustmentValue)
        {
            var adjustmentType = adjustmentName.ToImageAdjustmentType();

            if (Int32.TryParse(adjustmentDiff, out Int32 diff))
            {
                webServiceContext.MainForm.SetAdjustment(adjustmentType, diff, 0);
            }
            else if (Int32.TryParse(adjustmentValue, out Int32 value))
            {
                webServiceContext.MainForm.SetAdjustment(adjustmentType, 0, value);
            }

            // TODO
        }
    }
}
