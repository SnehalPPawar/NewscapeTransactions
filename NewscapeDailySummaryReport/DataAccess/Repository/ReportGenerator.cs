using NewscapeDailySummaryReport.DataAccess.Interfaces;
using NewscapeDailySummaryReport.DataAccess.Repository;
using NewscapeDailySummaryReport.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity;

namespace NewscapeDailySummaryReport.DataAccess.Repository
{
    public class ReportGenerator: IReportGenerator
    {
        private readonly IAccountRepository _IAccountFileRepository;

        public ReportGenerator()
        {
            IUnityContainer container = new UnityContainer();
            _IAccountFileRepository = container.Resolve<AccountFileRepository>();
        }

        public void Generatereports()
        {
            List<Account> result = GetAllRecords();

            List<AccountReport> ReportData = result.GroupBy(x => x.acctNo).Select(x => new AccountReport
            {
                AccountNumber = x.Key,
                TotalCredits = x.Sum(y => y.creditAmt),
                TotalDebits = x.Sum(y => y.debitAmt)
            }).ToList<AccountReport>(); ;

            Console.WriteLine("Acc No \t TotalCredits \t TotalDebits \t Balance");
            foreach (AccountReport item in ReportData)
            {
                Console.WriteLine(item.AccountNumber + "\t\t" + item.TotalCredits + "\t\t" + item.TotalDebits + "\t" + item.Balance);
            }
        }

        private List<Account> GetAllRecords()
        {
            return _IAccountFileRepository.GetAllRecords();
        }
    }
}
