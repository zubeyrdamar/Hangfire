using System;
using System.Drawing;
using System.IO;

namespace Hangfire.Web.Jobs
{
    public class Delayed
    {
        public static string Job_AddWatermark(string filename, string watermark)
        {
            return Hangfire.BackgroundJob.Schedule(() => ApplyWatermark(filename, watermark), TimeSpan.FromSeconds(10));
        }

        public static void ApplyWatermark(string filename, string watermarkText)
        {
            // set file path
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", filename);

            // initializing a new image (holds image)
            using (var bitmap = Bitmap.FromFile(path))
            {
                // initializing a new image frame (holds empty frame with image's height and width)
                using(Bitmap tempBitmap = new Bitmap(bitmap.Width, bitmap.Height))
                {
                    // add text on image
                    using(Graphics graphics = Graphics.FromImage(tempBitmap))
                    {
                        graphics.DrawImage(bitmap, 0, 0);
                        var font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                        var color = Color.FromArgb(255, 0, 0);
                        var brush = new SolidBrush(color);
                        var point = new Point(20, bitmap.Height - 50);
                        graphics.DrawString(watermarkText, font, brush, point);

                        tempBitmap.Save(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/watermarks", filename));
                    }
                }
            }
        }
    }
}
