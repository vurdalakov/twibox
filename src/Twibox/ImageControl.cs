namespace Vurdalakov
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public enum ImageControlMode
    {
        Normal,
        Selection
    }

    public class ImageControl : Control
    {
        private Image _image = new Bitmap(1, 1);

        private ImageControlMode _mode = ImageControlMode.Normal;

        public ImageControl()
        {
        }

        public void DrawImage(Image image)
        {
            this._image = image;
            this.Invalidate();
        }

        public void SetMode(ImageControlMode mode)
        {
            this._mode = mode;
            this.Invalidate();
        }

        protected override void OnCreateControl()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this._image, 0, 0);

            if (ImageControlMode.Selection == this._mode)
            {
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.White)), 20, 20, 100, 100);
            }
        }
    }
}
