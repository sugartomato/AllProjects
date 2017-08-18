using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZS.Common;

namespace ZS.Common.Test
{
    [TestClass]
    public class ImageHelperTest
    {
        [TestMethod]
        public void GetEncoderByMimeType()
        {
            System.Drawing.Imaging.ImageCodecInfo codec = ImageHelper.GetEncoder("image/jpeg");
            if (codec != null)
            {
                Console.WriteLine(codec.CodecName);
                Console.WriteLine(codec.MimeType);
                Console.WriteLine(codec.FormatID);
                Console.WriteLine(codec.Version);
            }
        }

        //

        [TestMethod]
        public void ResizeTest()
        {
            String imgPath = @"D:\Camera\已上传\刀刀\IMG_20170521_213512.jpg";
            //System.Drawing.Bitmap img = new System.Drawing.Bitmap(@"D:\Camera\倒流香\IMG_20170503_211130.jpg");
            ImageHelper.Resize(imgPath, @"D:\Camera\已上传\刀刀\IMG_20170521_213512.jpg", 800, 600, ImageHelper.ResizeType.FixedWidth, 50);
        }

        [TestMethod]
        public void ResizeBySettingTest()
        {
            String imgPath = @"D:\IMG_20170607_140727.jpg";
            ImageHelper.ResizeSetting setting = new ImageHelper.ResizeSetting();
            setting.CompressionLevel = 100;
            setting.ResizeMode = ImageHelper.ResizeType.FixedHeight;
            setting.TargetHeight = 800;
            setting.TargetNamePrefix = "DKDK";
            //System.Drawing.Bitmap img = new System.Drawing.Bitmap(@"D:\Camera\倒流香\IMG_20170503_211130.jpg");
            ImageHelper.Resize(imgPath, @"D:\kk\22\33",setting);
            Console.WriteLine(setting.SavedPath);

        }


        [TestMethod]
        public void GetEncoderByImageFormat()
        {
            System.Drawing.Imaging.ImageCodecInfo codec = ImageHelper.GetEncoder(System.Drawing.Imaging.ImageFormat.Jpeg);
            if (codec != null)
            {
                Console.WriteLine(codec.CodecName);
                Console.WriteLine(codec.MimeType);
                Console.WriteLine(codec.FormatID);
                Console.WriteLine(codec.Version);
            }
        }

        [TestMethod]
        public void CompressTest()
        {
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(@"D:\DHD\Work_SK\信息\设备型号序列号信息\三层复印机 - 副本.jpg");
            System.IO.Stream result = ImageHelper.Compress(img, 10);
            if (result != null)
            {
                System.Drawing.Image imgN = System.Drawing.Image.FromStream(result);
                imgN.Save(@"D:\112.jpg");
            }
        }

        [TestMethod]
        public void CompressFileAndSaveTest()
        {
            string imgPath = @"D:\Camera\倒流香\";

            String[] files = System.IO.Directory.GetFiles(imgPath);
            foreach (var file in files)
            {
                if (file.EndsWith(".jpg"))
                {
                    if (ImageHelper.Compress(file, 90))
                    {
                        Console.WriteLine("成功");
                    }
                    else
                    {
                        Console.WriteLine("失败了");
                    }

                }
            }

        }

    }
}
