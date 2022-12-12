using System;

namespace Watermetter.Models
{
    public class History
    {
        public int IdArduino { get; set; }
        public string IdOwner { get; set; }
        public DateTime? Begin { get; set; }
        public DateTime? End { get; set; }
        public DateTime Date { get; set; }
        public decimal Waterflow { get; set; }

    }
}
