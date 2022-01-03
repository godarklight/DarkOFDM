using System;
using System.IO;
using System.Numerics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace DarkOFDM
{
    public class WaterfallGenerator
    {
        int xVal = 0;
        int currentSample = 0;
        int samplesPerPixel = 512;
        Image<Rgba32> image;


        public bool Done
        {
            private set;
            get;
        }

        public WaterfallGenerator(string filename)
        {
            byte[] fileBytes = File.ReadAllBytes(filename);
            image = Image<Rgba32>.Load(fileBytes);
        }

        public int GetHeight()
        {
            return image.Height;
        }

        public void NextSample()
        {
            currentSample++;
            if (currentSample == samplesPerPixel)
            {
                currentSample = 0;
                xVal++;
                if (xVal == image.Width)
                {
                    Done = true;
                    xVal = 0;
                }
            }
        }

        public Complex SampleIQ(int carrier)
        {
            Rgba32 pixel = image[xVal, image.Height - carrier - 1];
            double value = (pixel.R + pixel.G + pixel.B) * (pixel.A / 255.0);
            value = value / (3.0 * 255.0);
            return new Complex(value, 0.0);
        }
    }
}