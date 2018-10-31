/*******************************************************************
*	命名空间 ：LogMonitor.Core.Infrastructure
*	文件名称 ：ILogger
*	创 建 人 ：m1835
*	创建日期 ：2018/8/8 13:08:29
*   -------------------------------------------------------------
*	Copyright @ m1835 2018. All rights reserved.
*******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace LogMonitor.Core.Infrastructure
{
    /// <summary>
    ///     日志方法约束接口
    /// </summary>
    public interface ILogger<TLogEntity> where TLogEntity : IEntity
    {
        void Debug(TLogEntity logInfo);

        void Info(TLogEntity logInfo);

        void Warn(TLogEntity logInfo);

        void Error(TLogEntity logInfo);

    }
}
