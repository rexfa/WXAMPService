using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;

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
        public static void NormalizationImage(FileStream fileStream)
        {
            Image<Rgba32> image = Image.Load(fileStream);
            int width = image.Width;
            int height = image.Height;
            if (width > height)
            {

            }
            else
            {

            }
            int targetHeight = height / (width / SySImageHandle.TargetWidth);
            image.Mutate(x => x.Resize(SySImageHandle.TargetWidth, targetHeight).Grayscale());

        }
    }
}
