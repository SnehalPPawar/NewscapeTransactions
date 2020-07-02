using NewscapeDailySummaryReport.Model;
using System.Collections.Generic;

namespace NewscapeDailySummaryReport.DataAccess.Interfaces
{
    public interface IAccountRepository
    {
        List<Account> GetAllRecords();
    }
}
