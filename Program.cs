using System;
using System.IO;
using System.Numerics;

namespace DarkOFDM
{
    public static class Program
    {
        private const double SAMPLE_RATE = 48000;
        private static int currentSample = 0;
        private static long startTime = DateTime.UtcNow.Ticks;
        private static bool running = true;
        public static void Main()
        {
            //Stream inStream = Console.OpenStandardInput();
            Stream outStream;
            bool wav = true;
            
            //wav = false;
            if (wav)
            {
                File.Delete("out.wav");
                outStream = new FileStream("out.wav", FileMode.Create);
                Wav.WriteWavHeader(outStream);
            }
            else
            {
                outStream = Console.OpenStandardOutput();
            }

            //Init IQ channels
            int bandwidth = 10000;
            double spacing = 46.87;
            int carriers = (int)(bandwidth / spacing);
            Func<Complex>[] iqs = new Func<Complex>[carriers];
            WaterfallGenerator wfg = new WaterfallGenerator("input.png");
            double scaling = 0.99 * wfg.GetHeight() / (double)iqs.Length;
            for (int i = 0; i < iqs.Length; i++)
            {
                WaterfallPosition wfp = new WaterfallPosition(wfg, (int)(i * scaling));
                iqs[i] = wfp.SampleIQ;
            }

            //ODFM generator
            OFDM odfm = new OFDM(iqs, spacing, SAMPLE_RATE);
            StreamHandler sh = new StreamHandler(null, outStream, odfm, SAMPLE_RATE);
            
            //Run!
            while (running)
            {
                sh.Loop();
                wfg.NextSample();
                running = !wfg.Done;
            }

            //inStream.Close();
            outStream.Close();

            if (wav)
            {
                Wav.WriteWavLength();
            }
        }

        public static void Stop()
        {
            running = false;
        }



        private static Complex Test()
        {
            double runTime = currentSample / SAMPLE_RATE;
            double phaseQ = Math.Sin(Math.Tau * runTime);
            //double phaseI = Math.Cos(runTime * 1.0 * Math.Tau);
            double phaseI = 0.0;
            return new Complex(phaseQ, phaseI);
        }
    }
}