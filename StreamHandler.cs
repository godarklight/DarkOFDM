using System;
using System.IO;

namespace DarkOFDM
{
    public class StreamHandler
    {
        double sampleRate;
        Stream inStream;
        Stream outStream;
        OFDM ofdm;

        public StreamHandler(Stream inStream, Stream outStream, OFDM ofdm, double sampleRate)
        {
            this.inStream = inStream;
            this.outStream = outStream;
            this.ofdm = ofdm;
            this.sampleRate = sampleRate;
        }

        public void Loop()
        {
            double value = ofdm.Loop() * 2.0;
            value = Math.Clamp(value, -1, 1);
            short outValue = (short)(short.MaxValue * value);
            byte lowBytes = (byte)(outValue & 0xFF);
            byte highBytes = (byte)((outValue & 0xFF00) >> 8);
            outStream.WriteByte(lowBytes);
            outStream.WriteByte(highBytes);            
        }
    }
}