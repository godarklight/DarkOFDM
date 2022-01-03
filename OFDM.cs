using System;
using System.Numerics;

namespace DarkOFDM
{
    public class OFDM
    {
        double spacing;
        double sampleRate;
        Func<Complex>[] iqs;
        double[] phaseAngles;
        public OFDM(Func<Complex>[] iqs, double spacing, double sampleRate)
        {
            this.iqs = iqs;
            this.spacing = spacing;
            this.sampleRate = sampleRate;
            phaseAngles = new double[iqs.Length];
        }

        public double Loop()
        {
            double outValue = 0;
            for (int i = 0; i < iqs.Length; i++)
            {
                Complex thisIQ = iqs[i]();
                double carrier = 100 + i * spacing;
                double phaseAngle = phaseAngles[i];
                double phaseAngleAdd = ((Math.Tau * carrier) / sampleRate);
                outValue += thisIQ.Real * Math.Sin(phaseAngle);
                outValue += thisIQ.Imaginary * Math.Cos(phaseAngle);
                phaseAngles[i] = (phaseAngle + phaseAngleAdd) % Math.Tau;
            }
            return outValue / (iqs.Length * 2);
        }
    }
}