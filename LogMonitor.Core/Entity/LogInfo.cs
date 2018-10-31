/*******************************************************************
*	命名空间 ：LogMonitor.Core.Entity
*	文件名称 ：LogInfo
*	创 建 人 ：m1835
*	创建日期 ：2018/8/8 13:10:26
*   -------------------------------------------------------------
*	Copyright @ m1835 2018. All rights reserved.
*******************************************************************/
using LogMonitor.Core.Infrastructure;
using Nest;
using System;

namespace LogMonitor.Core.Entity
{
    /// <summary>
    ///     日志模型
    /// </summary>
    public abstract class LogInfo : IEntity
    {
        /// <summary>
        ///     操作人
        /// </summary>
        public abstract string Operator { get; set; }
        /// <summary>
        ///     客户端地址
        /// </summary>
        public abstract string Host { get; set; }
        /// <summary>
        ///     执行的方法名称
        /// </summary>
        public abstract string Action { get; set; }
        /// <summary>
        ///     执行的方法的参数
        /// </summary>
        public abstract string Paramater { get; set; }
        /// <summary>
        ///     创建时间
        /// </summary>
        public abstract DateTime CreateTime { get; set; }
        /// <summary>
        ///     错误信息
        /// </summary>
        public abstract string Exception { get; set; }
    }
}
