using System.Numerics;

namespace DarkOFDM
{
    public class WaterfallPosition
    {
        public WaterfallGenerator generator;
        public int carrierID;
        public WaterfallPosition(WaterfallGenerator generator, int carrierID)
        {
            this.generator = generator;
            this.carrierID = carrierID;
        }

        public Complex SampleIQ()
        {
            return generator.SampleIQ(carrierID);
        }
    }
}