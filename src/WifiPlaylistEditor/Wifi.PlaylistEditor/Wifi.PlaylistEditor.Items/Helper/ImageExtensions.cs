using System;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using Encoder = System.Drawing.Imaging.Encoder;

namespace Wifi.PlaylistEditor.Items.Helper
{
    public static class ImageExtensions
    {
        /// <summary>
        /// Resizes the image to the provided canvas values
        /// </summary>
        /// <param name="image">The image to resize</param>
        /// <param name="canvasWidth">The new width of the image</param>
        /// <param name="canvasHeight">The new height of the image</param>
        /// <returns></returns>
        public static Image Resize(this Image image, int canvasWidth, int canvasHeight)
        {
            double originalWidth = image.Width;
            double originalHeight = image.Height;

            Image thumbnail = new Bitmap(canvasWidth, canvasHeight); // changed parm names
            var graphic = Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            // Figure out the ratio
            double ratioX = (double)canvasWidth / (double)originalWidth;

            double ratioY = (double)canvasHeight / (double)originalHeight;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(originalHeight * ratio);
            int newWidth = Convert.ToInt32(originalWidth * ratio);

            // Now calculate the X,Y position of the upper-left corner 
            // (one of these will always be zero)
            int posX = Convert.ToInt32((canvasWidth - (originalWidth * ratio)) / 2);
            int posY = Convert.ToInt32((canvasHeight - (originalHeight * ratio)) / 2);

            graphic.Clear(Color.White); // white padding
            graphic.DrawImage(image, posX, posY, newWidth, newHeight);

            var info = ImageCodecInfo.GetImageEncoders();

            var encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

            using (var ms = new MemoryStream())
            {
                thumbnail.Save(ms, info[1], encoderParameters);
                return Image.FromStream(ms);
            }
        }
    }
}
