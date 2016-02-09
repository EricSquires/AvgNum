using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkIt
{
    public class AverageNumber
    {
        private List<double> _collection;

        public double Low
        {
            get;
            private set;
        }

        public double High
        {
            get;
            private set;
        }

        public double Average
        {
            get;
            protected set;
        }

        public AverageNumber(IEnumerable<double> collection)
        {
            Replace(collection);
        }

        public AverageNumber(AverageNumber avgNum)
        {
            Replace(avgNum._collection);
        }

        public void AddValue(double val)
        {
            _collection.Add(val);
            CalculateNewStats(val);
        }

        protected virtual void CalculateNewStats(double val)
        {
            if (val < Low)
            {
                Low = val;
            }

            if (val > High)
            {
                High = val;
            }

            CalculateNewAverage(val);
        }

        protected virtual void CalculateNewAverage(double val)
        {
            // Perform an incremental average so we don't need to run through a potentially huge list whenever we need it.
            // Tradeoff here is the accumulation of round-off error with all these divisions going on.
            Average += CalculateIncrementalAverageIncrease(val, Average, _collection.Count);
        }

        protected double CalculateIncrementalAverageIncrease(double newVal, double oldAvg, double newNumElements)
        {
            return (newVal - oldAvg) / newNumElements;
        }

        public virtual void Replace(IEnumerable<double> newVals)
        {
            _collection = new List<double>();

            Low = double.MaxValue;
            High = double.MinValue;
            Average = 0;

            foreach(var val in newVals)
            {
                AddValue(val);
            }
        }

        public Tuple<double, double> GetHighLow()
        {
            return Tuple.Create(High, Low);
        }

        public double GetAverage()
        {
            return Average;
        }
    }
}
