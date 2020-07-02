using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewscapeDailySummaryReport.Model
{
    public class Account
    {
        public string acctNo { get; set; }
        public float creditAmt { get; set; }
        public float debitAmt { get; set; }
        public float closureAmt { get; set; }
        public DateTime date { get; set; }
    }
}
