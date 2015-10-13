using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace FastFoodWebApplication.DataAccess
{
    public class PictureHanldler :IPictureHandler
    {
        private const string pictureFolderPath= "~/ProductImages/";
    
    public void SavePictureInFile(byte[] pictureBinary, string fileName)
    {
        var imagesDirectoryPath = MapPath(pictureFolderPath);
        var filePath = Path.Combine(imagesDirectoryPath, fileName);


        MemoryStream ms = new MemoryStream(pictureBinary);
        System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
        Image imgPhotoOriginal = System.Drawing.Image.FromStream(ms);

        MemoryStream ms2 = new MemoryStream();
        Image imgPhoto = null;
        imgPhoto = FixeSizeForBigandSmallImages(imgPhotoOriginal, 300, 220);

        imgPhoto.Save(ms2, ImageFormat.Jpeg);
        File.WriteAllBytes(filePath, ms2.ToArray());
        imgPhoto.Dispose();

    }

    public virtual string MapPath(string path)
    {
        if (HostingEnvironment.IsHosted)
        {
            //hosted
            return HostingEnvironment.MapPath(path);
        }
        else
        {
            //not hosted. For example, run in unit tests
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
            return Path.Combine(baseDirectory, path);
        }
    }

    public Image FixeSizeForBigandSmallImages(Image imgPhoto, int Width, int Height)
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

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);

        if (sourceWidth > Width || sourceHeight > Height)
        {
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = (int)((Width - (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = (int)((Height - (sourceHeight * nPercent)) / 2);
            }
            destWidth = (int)(sourceWidth * nPercent);
            destHeight = (int)(sourceHeight * nPercent);
        }
        else
        {
            nPercent = 1;
            destWidth = sourceWidth;
            destHeight = sourceHeight;
            destX = (int)((Width - (sourceWidth * nPercent)) / 2);
            destY = (int)((Height - (sourceHeight * nPercent)) / 2);
        }



        Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
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