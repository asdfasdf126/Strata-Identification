using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GeoscienceMath
{
    public class ValidateRange
    {
        private Dictionary<LogTypes, LogMeasurements> lithology;

        public ValidateRange()
        {
            lithology = new Dictionary<LogTypes, LogMeasurements>(); 
            initializeLithology();
        }

        public void setValues(LogTypes type, double min, double max, double weight)
        {
            LogMeasurements lm = lithology[type];

            lm.Min = min;
            lm.Max = max;
            lm.Weight = weight;
        }

        public double checkRange(LogTypes type, double value)
        { return lithology[type].inRangeShale(value); }

        public LogMeasurements getType(LogTypes logtype)
        { return lithology[logtype]; }

        private void initializeLithology()
        {
            lithology.Add(LogTypes.PEF, getPef());
            lithology.Add(LogTypes.NPHI, getNphi());
            lithology.Add(LogTypes.RHOZ, getRhoz());
            lithology.Add(LogTypes.CALI, getCali());
            lithology.Add(LogTypes.GR, getGamma());
            lithology.Add(LogTypes.RID, getRid());
            lithology.Add(LogTypes.RIM, getRim());
        }
        
        private LogMeasurements getPef()
        {
            LogMeasurements pef = new LogMeasurements();
            pef.Description = "PEF";
            pef.Min = 2.5;
            pef.Max = 4;
            pef.Weight = .01;

            return pef;
        }

        private LogMeasurements getNphi()
        {
            LogMeasurements nphi = new LogMeasurements();
            nphi.Description = "NPHI";
            nphi.Min = .1;
            nphi.Max = .4;
            nphi.Weight = .1;

            return nphi;
        }

        private LogMeasurements getRhoz()
        {
            LogMeasurements rhoz = new LogMeasurements();
            rhoz.Description = "RHOZ";
            rhoz.Min = 2 * 1000;
            rhoz.Max = 2.4 * 1000;
            rhoz.Weight = .15;

            return rhoz;
        }

        private LogMeasurements getCali()
        {
            LogMeasurements cali = new LogMeasurements();
            cali.Description = "CALI";
            cali.Min = .85;
            cali.Max = .88;
            cali.Weight = .04;

            return cali;
        }

        private LogMeasurements getGamma()
        {
            LogMeasurements gamma = new LogMeasurements();
            gamma.Description = "GR";
            gamma.Min = 200;
            gamma.Max = 500;
            gamma.Weight = .4;

            return gamma;
        }

        private LogMeasurements getRid()
        {
            LogMeasurements rid = new LogMeasurements();
            rid.Description = "RID";
            rid.Min = 90;
            rid.Max = 1400;
            rid.Weight = .15;

            return rid;
        }

        private LogMeasurements getRim()
        {
            LogMeasurements rim = new LogMeasurements();
            rim.Description = "RIM";
            rim.Min = 90;
            rim.Max = 900;
            rim.Weight = .15;

            return rim;
        }
    }
}
