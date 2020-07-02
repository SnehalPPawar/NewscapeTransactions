using NewscapeDailySummaryReport.DataAccess.Interfaces;
using NewscapeDailySummaryReport.DataAccess.Repository;
using System;
using Unity;

namespace NewscapeDailySummaryReport
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Register Dependency
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IAccountRepository, AccountFileRepository>();
            container.RegisterType<IReportGenerator, ReportGenerator>();

            //Generate the report
            IReportGenerator reportGenerator = container.Resolve<IReportGenerator>();
            reportGenerator.Generatereports();
            Console.ReadLine();
        }
    }
}
