using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Model
{
    public class Report
    {//举报类
        public virtual int Id { get; set; }
        public virtual int PostId { get; set; }//帖子编号
        public virtual int ReportId { get; set; }//举报者编号
        public virtual string HarmfulContent { get; set; }//违规内容
        public virtual string ReportDescription { get; set; }//举报描述
    }
}
