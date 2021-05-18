using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Services
{
    using ForumApi.Interface;
    using ForumApi.Model;
    public class ReportService : IReport
    {
        public ForumDbContext dbContext_;
        public ReportService(ForumDbContext db)
        {
            dbContext_ = db;
        }
        public bool AddReport(Report report)
        {
            dbContext_.Reports.Add(report);
            return dbContext_.SaveChanges()>0;
        }
    }
}
