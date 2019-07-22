using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using SixLabors.Primitives;

namespace WXAMPService.Infrastructures
{
    public class SySImageHandle
    {
        /// <summary>
        /// 目标宽度
        /// </summary>
        public const int TargetWidth = 400;
        /// <summary>
        /// 目标比例
        /// </summary>
        public const float TargetScale = 0.8F;


        public static Image<Rgba32> NormalizationImage(FileStream fileStream)
        {
            Image<Rgba32> image = Image.Load(fileStream);
            int width = image.Width;
            int height = image.Height;
            image = CutAndResizeImage(image, TargetScale);
            return image;
        }
        public static void NormalizationImageAndSave(string fileDir)
        {
            FileStream fileStream = null;
            try
            {
                fileStream = File.Open(fileDir, FileMode.Open);
                Image<Rgba32> image = Image.Load(fileStream);
                image = CutAndResizeImage(image, TargetScale);
                image.SaveAsPng(fileStream);
            }
            catch (Exception ex)
            { }
            finally
            {
                fileStream.Close();
            }
            return;
        }
        public static Image<Rgba32> CutAndResizeImage(Image<Rgba32> image, float scale)
        {
            int width = image.Width;
            int height = image.Height;
            if (width > height)
            {
                int h = (int)(width * SySImageHandle.TargetScale);
                if (h < height)
                {
                    image = CutImage(image, 0, h);
                }
                else
                {
                    int w = (int)(height / SySImageHandle.TargetScale);
                    image = CutImage(image, w, 0);
                }
                
            }
            else
            {
                int w = (int)(height * SySImageHandle.TargetScale);
                if (w < width)
                {
                    image = CutImage(image,w , 0);
                }
                else
                {
                    int h = (int)(width / SySImageHandle.TargetScale);
                    image = CutImage(image, 0, h);
                }
            }
            int targetHeight = height / (width / SySImageHandle.TargetWidth);
            image.Mutate(x => x.Resize(SySImageHandle.TargetWidth, targetHeight).Grayscale());
            return image;
        }
        public static Image<Rgba32> CutImage(Image<Rgba32> image, int width=0, int height=0)
        {
            int x = 0;
            int y = 0;
            if (width == 0)
            {
                width = image.Width;
            }
            else
            {
                if (image.Width > width)
                {
                    x = (image.Width - width) / 2;
                }
                else
                {
                    width = image.Width;
                }
            }
            if (height == 0)
            {
                height = image.Height;
            }
            else
            {
                if (image.Height > height)
                {
                    x = (image.Height - height) / 2;
                }
                else
                {
                    height = image.Height;
                }
            }
            image.Mutate(i => i.Crop(new Rectangle(x, y, width, height)).Grayscale());
            return image;
     
        }
    }
}
