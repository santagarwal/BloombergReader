using System;

namespace BloombergReader.Model
{
    /// <summary>
    /// Data model to represent an open/high/low/close (OHLC) bar 
    /// Please check this link for further details: http://www.investorguide.com/article/13079/how-to-read-forex-bar-charts-wc/
    /// </summary>
    public class Bar
    {
        public DateTime Time
        {
            get;
            internal set;
        }

        public decimal Open
        {
            get;
            internal set;
        }

        public decimal High
        {
            get;
            internal set;
        }

        public decimal Low
        {
            get;
            internal set;
        }

        public decimal Close
        {
            get;
            internal set;
        }

        public BarTypes BarType
        {
            get
            {
                if (Close > Open)
                {
                    return BarTypes.Bull;
                }
                
                if (Close < Open)
                {
                    return BarTypes.Bear;
                }

                return BarTypes.NotDefined;
            }
        }
    }
}
