namespace Vurdalakov
{
    using System;
    using System.IO;
    using ImageSharp;

    public class ImageBuilder : IDisposable
    {
        private ImageControl _imageControl;
        private MemoryStream _originalStream = new MemoryStream();
        private MemoryStream _modifiedStream = new MemoryStream();
        private MemoryStream _resizedStream = new MemoryStream();

        public ImageProperties ImageProperties = new ImageProperties();

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

        public void UpdateImage()
        {
            var elapsedTime = new ElapsedTime("BuildImage");

            this._originalStream.Seek(0, SeekOrigin.Begin);
            using (var image = Image.Load(this._originalStream))
            {
                if (true)
                {
                    if (this.ImageProperties.Contrast != 0)
                    {
                        image.Contrast(this.ImageProperties.Contrast);
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

        #region IDisposable

        private Boolean isDisposed = false;

        protected virtual void Dispose(Boolean disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    // dispose managed objects
                    this._originalStream.Dispose();
                    this._modifiedStream.Dispose();
                    this._resizedStream.Dispose();
                }

               isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
