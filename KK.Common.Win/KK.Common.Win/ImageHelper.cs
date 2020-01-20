using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace KK.Common.Win
{
    public class ImageHelper
    {

        public static System.Drawing.Imaging.ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codes = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codes)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static Boolean CompressImage(String imgFile, Int32 level)
        {
            Image img = Image.FromFile(imgFile);
            System.IO.Stream stream = CompressImage(img, level);
            img = Image.FromStream(stream);
            img.Save(@"D:\ttt.jpeg");
            return true;
        }


        private static System.IO.Stream CompressImage(Image img, Int32 level)
        {
            System.IO.Stream result = null;
            using (Bitmap bmp = new Bitmap(img))
            {
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, level);
                myEncoderParameters.Param[0] = myEncoderParameter;
                result = new System.IO.MemoryStream();
                bmp.Save(result, jpgEncoder, myEncoderParameters);
            }
            return result;
        }


    }
}
