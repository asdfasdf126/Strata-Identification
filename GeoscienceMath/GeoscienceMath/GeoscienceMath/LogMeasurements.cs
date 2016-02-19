using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoscienceMath
{
    public class LogMeasurements
    {
        private string description;
        private double min, max, weight;
        private bool invert;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Max
        {
            get { return max; }
            set { max = value; }
        }

        public double Min
        {
            get { return min; }
            set { min = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public LogMeasurements(bool invert = false)
        { this.invert = invert; }

        public double inRangeShale(double y)
        {
            if (double.IsNaN(y))
                return double.NaN;
            else if (y >= min && y <= max && !invert)
                return 1.00 * weight;
            else if ((y < min || y > max) && invert)
                return 1.00 * weight;

            return 0;
        }

        public override string ToString()
        {
            return description;
        }
    }
}
