using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewscapeDailySummaryReport.Model
{
    public class AccountReport
    {
        public string AccountNumber { get; set; }
        public float TotalCredits { get; set; }
        public float TotalDebits { get; set; }
        public float Balance { get { return TotalCredits - TotalDebits; } }
    }
}
