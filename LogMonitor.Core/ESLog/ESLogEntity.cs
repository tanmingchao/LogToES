/*******************************************************************
*	命名空间 ：LogMonitor.Core.ESLog
*	文件名称 ：ESLogEntity
*	创 建 人 ：m1835
*	创建日期 ：2018/8/8 13:45:27
*   -------------------------------------------------------------
*	Copyright @ m1835 2018. All rights reserved.
*******************************************************************/
using LogMonitor.Core.Entity;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogMonitor.Core.ESLog
{
    /// <summary>
    ///     ES log
    /// </summary>
    public class ESLogEntity : LogInfo
    {
        [Keyword(Name = "operator")]
        public override string Operator { get; set; }
        [Keyword(Name = "host")]
        public override string Host { get; set; }
        [Keyword(Name = "action")]
        public override string Action { get; set; }
        [Text(Name = "parameter")]
        public override string Paramater { get; set; }
        [Keyword(Name = "createTime")]
        public override DateTime CreateTime { get; set; }
        [Text(Name = "exception")]
        public override string Exception { get; set; }
    }
}
