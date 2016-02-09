using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkIt
{

    public class NonNegativeAverageNumber : AverageNumber
    {
        private int _numInAvg;

        public NonNegativeAverageNumber(IEnumerable<double> collection) : base(collection) { }
        public NonNegativeAverageNumber(AverageNumber avgNum) : base(avgNum) { }

        public override void Replace(IEnumerable<double> newVals)
        {
            _numInAvg = 0;
            base.Replace(newVals);
        }

        protected override void CalculateNewAverage(double val)
        {
            if (val >= 0)
            {
                _numInAvg++;
                Average += CalculateIncrementalAverageIncrease(val, Average, _numInAvg);
            }
        }
    }
}
