namespace Vurdalakov
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using ImageSharp;

    public class ImageBuilder
    {
        private ImageControl _imageControl;
        private MemoryStream _originalStream = new MemoryStream();
        private MemoryStream _modifiedStream = new MemoryStream();
        private MemoryStream _resizedStream = new MemoryStream();

        public void Init(ImageControl imageControl, Stream stream)
        {
            this._imageControl = imageControl;

            stream.Seek(0, SeekOrigin.Begin);
            this._originalStream.SetLength(stream.Length);
            stream.CopyTo(this._originalStream);

            stream.Seek(0, SeekOrigin.Begin);
            this._modifiedStream.SetLength(stream.Length);
            stream.CopyTo(this._modifiedStream);

            stream.Seek(0, SeekOrigin.Begin);
            this._resizedStream.SetLength(stream.Length);
            stream.CopyTo(this._resizedStream);
        }

        public void UpdateImage(ImageProperties imageProperties = null)
        {
            var elapsedTime = new ElapsedTime("BuildImage");

            var resizeOnly = null == imageProperties;
            var stream = resizeOnly ? this._modifiedStream : this._originalStream;

            stream.Seek(0, SeekOrigin.Begin);
            using (var image = Image.Load(stream))
            {
                if (!resizeOnly)
                {
                    if (imageProperties.Contrast != 0)
                    {
                        image.Contrast(imageProperties.Contrast);
                    }

                    this._modifiedStream.Seek(0, SeekOrigin.Begin);
                    image.Save(this._modifiedStream, ImageFormats.Bitmap);
                }

                image.Resize(this._imageControl.Width, this._imageControl.Height);

                lock (this._resizedStream)
                {
                    this._resizedStream.Seek(0, SeekOrigin.Begin);
                    image.Save(this._resizedStream, ImageFormats.Bitmap);
                }
            }

            elapsedTime.Lapse();

            this.DrawImage();
        }

        private delegate void DrawImageEventDelegate();
        private DrawImageEventDelegate _drawImageEventDelegate = null;

        private void DrawImage()
        {
            if (this._imageControl.InvokeRequired)
            {
                if (null == this._drawImageEventDelegate)
                {
                    this._drawImageEventDelegate = new DrawImageEventDelegate(this.DrawImage);
                }

                this._imageControl.BeginInvoke(this._drawImageEventDelegate, new object[] { });

                return;
            }

            var elapsedTime = new ElapsedTime("UpdateImage");

            lock (this._resizedStream)
            {
                this._imageControl.DrawImage(System.Drawing.Bitmap.FromStream(this._resizedStream));
            }

            elapsedTime.Lapse();
        }
    }
}
