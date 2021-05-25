using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Interface
{
    using ForumApi.Model;
    public interface IReport
    {
        bool AddReport(Report report);
        bool DeleteReport(int id);
    }
}
