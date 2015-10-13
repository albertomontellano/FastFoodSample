using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Hosting;

namespace FastFoodWebApplication.Utils
{
    public class PictureHandler :IPictureHandler
    {
        private const string PictureFolderPath = "~/ProductImages/";
    
        public void SavePictureInFile(byte[] pictureBinary, string fileName)
        {
            var imagesDirectoryPath = MapPath(PictureFolderPath);
            var filePath = Path.Combine(imagesDirectoryPath, fileName);


            var ms = new MemoryStream(pictureBinary);
            var imgPhotoOriginal = Image.FromStream(ms);

            var memoryStream = new MemoryStream();
            var imgPhoto = FixeSizeForBigandSmallImages(imgPhotoOriginal, 300, 220);

            imgPhoto.Save(memoryStream, ImageFormat.Jpeg);
            File.WriteAllBytes(filePath, memoryStream.ToArray());
            imgPhoto.Dispose();

        }

        public virtual string MapPath(string path)
        {
            if (HostingEnvironment.IsHosted)
            {
                //hosted
                return HostingEnvironment.MapPath(path);
            }
       
            //not hosted. For example, run in unit tests
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
            return Path.Combine(baseDirectory, path);
        }

        public Image FixeSizeForBigandSmallImages(Image imgPhoto, int width, int height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            int destWidth = 0;
            int destHeight = 0;

            nPercentW = ((float)width / (float)sourceWidth);
            nPercentH = ((float)height / (float)sourceHeight);

            if (sourceWidth > width || sourceHeight > height)
            {
                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentH;
                    destX = (int)((width - (sourceWidth * nPercent)) / 2);
                }
                else
                {
                    nPercent = nPercentW;
                    destY = (int)((height - (sourceHeight * nPercent)) / 2);
                }
                destWidth = (int)(sourceWidth * nPercent);
                destHeight = (int)(sourceHeight * nPercent);
            }
            else
            {
                nPercent = 1;
                destWidth = sourceWidth;
                destHeight = sourceHeight;
                destX = (int)((width - (sourceWidth * nPercent)) / 2);
                destY = (int)((height - (sourceHeight * nPercent)) / 2);
            }



            var bmPhoto = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
    }
}