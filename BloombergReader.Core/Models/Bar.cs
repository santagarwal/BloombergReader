using System;

namespace BloombergReader.Core.Models
{
    public class Bar
    {
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }

        public override string ToString()
        {
            return $"Date: {Date}; Open: {Open}; High: {High}; Low: {Low}; Close: {Close}; Volume: {Volume}";
        }
    }
}