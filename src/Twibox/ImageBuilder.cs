namespace Vurdalakov
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using ImageSharp;

    public class ImageBuilder
    {
        private MemoryStream _originalStream;

        public void SetImage(Stream stream)
        {
            if (this._originalStream != null)
            {
                this._originalStream.Dispose();
                this._originalStream = null;
            }

            this._originalStream = new MemoryStream((Int32)stream.Length);
            stream.CopyTo(this._originalStream);
        }

        public void ApplyTo(PictureBox pictureBox, ImageProperties imageProperties)
        {
            var elapsedTime = new ElapsedTime("BuildImage");

            var memoryStream = new MemoryStream(this._originalStream.Capacity);

            this._originalStream.Seek(0, SeekOrigin.Begin);

            using (var image = Image.Load(this._originalStream))
            {
                if (imageProperties.Contrast != 0)
                {
                    image.Contrast(imageProperties.Contrast);
                }

                image.Save(memoryStream, ImageFormats.Bitmap);
            }

            elapsedTime.Lapse();

            this.UpdateImage(pictureBox, memoryStream);
        }

        private delegate void UpdateImageEventDelegate(PictureBox pictureBox, MemoryStream memoryStream);
        private UpdateImageEventDelegate _updateImageEventDelegate = null;

        public void UpdateImage(PictureBox pictureBox, Stream stream)
        {
            if (pictureBox.InvokeRequired)
            {
                if (null == this._updateImageEventDelegate)
                {
                    this._updateImageEventDelegate = new UpdateImageEventDelegate(this.UpdateImage);
                }

                pictureBox.BeginInvoke(this._updateImageEventDelegate, new object[] { pictureBox, stream });

                return;
            }

            var elapsedTime = new ElapsedTime("UpdateImage");

            pictureBox.Image = System.Drawing.Bitmap.FromStream(stream);

            stream.Dispose();

            elapsedTime.Lapse();
        }
    }
}
