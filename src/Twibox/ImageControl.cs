namespace Vurdalakov
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class ImageControl : PictureBox
    {
        private Bitmap _bitmap = new Bitmap(1, 1);

        protected override void OnPaint(PaintEventArgs e)
        {
            if ((this._bitmap.Width != this.ClientSize.Width) || (this._bitmap.Height != this.ClientSize.Height))
            {
                this._bitmap.Dispose();
                this._bitmap = null;

                this._bitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            }

            var graphics = Graphics.FromImage(this._bitmap);
            graphics.DrawImage(this.Image, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height), 0, 0, this._bitmap.Width, this._bitmap.Height, GraphicsUnit.Pixel);

            //graphics.DrawRectangle(new Pen(new SolidBrush(Color.White)), 20, 20, 100, 100);

            e.Graphics.DrawImage(this._bitmap, 0, 0);
        }
    }
}
