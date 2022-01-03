//This looks suspiciously a lot like DRM but I do not have the will to actually code it right now. Maybe one day :)
/*
using System;
using System.Numerics;

namespace DarkOFDM
{
    public class OFDMSettings
    {
        public enum Mode
        {
            A,
            B,
            C,
            D,
        }
        public enum Bandwidth
        {
            KHZ_9,
            KHZ_10,
            KHZ_18,
            KHZ_20,
        }
        public Mode mode;
        public Bandwidth bandwidth;
        public double SymbolLength
        {
            get
            {
                switch (mode)
                {
                    case Mode.C:
                        return 0.02;
                    case Mode.D:
                        return 0.0166;
                    default:
                        return 0.0266;
                }
            }
        }

        public double GuardLength
        {
            get
            {
                switch (mode)
                {
                    case Mode.A:
                        return 0.00266;
                    case Mode.D:
                        return 0.00733;
                    default:
                        return 0.00533;
                }
            }
        }

        public int SymbolsPerFrame
        {
            get
            {
                switch (mode)
                {
                    case Mode.C:
                        return 20;
                    case Mode.D:
                        return 24;
                    default:
                        return 15;
                }
            }
        }

        public double CarrierSpacing
        {
            get
            {
                switch (mode)
                {
                    case Mode.A:
                        return 41.66;
                    case Mode.B:
                        return 46.88;
                    case Mode.C:
                        return 68.18;
                    case Mode.D:
                        return 107.14;
                    default:
                        return 0;
                }
            }
        }

        public int Carriers
        {
            get
            {
                if (mode == Mode.A)
                {
                    switch (bandwidth)
                    {
                        case Bandwidth.KHZ_9:
                            return 204;
                        case Bandwidth.KHZ_10:
                            return 228;
                        case Bandwidth.KHZ_18:
                            return 412;
                        case Bandwidth.KHZ_20:
                            return 460;
                    }
                }
                if (mode == Mode.B)
                {
                    switch (bandwidth)
                    {
                        case Bandwidth.KHZ_9:
                            return 182;
                        case Bandwidth.KHZ_10:
                            return 206;
                        case Bandwidth.KHZ_18:
                            return 366;
                        case Bandwidth.KHZ_20:
                            return 410;
                    }
                }
                if (mode == Mode.C)
                {
                    switch (bandwidth)
                    {
                        case Bandwidth.KHZ_10:
                            return 138;
                        case Bandwidth.KHZ_20:
                            return 280;
                    }
                }
                if (mode == Mode.D)
                {
                    switch (bandwidth)
                    {
                        case Bandwidth.KHZ_10:
                            return 88;
                        case Bandwidth.KHZ_20:
                            return 178;
                    }
                }
                return 0;
            }
        }

        public OFDMSettings(Bandwidth bandwidth, Mode mode)
        {
            this.bandwidth = bandwidth;
            this.mode = mode;
        }
    }
}
*/