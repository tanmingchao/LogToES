/*******************************************************************
*	命名空间 ：LogMonitor.Core.ESLog
*	文件名称 ：ESLoggerProvider
*	创 建 人 ：m1835
*	创建日期 ：2018/8/8 13:52:47
*   -------------------------------------------------------------
*	Copyright @ m1835 2018. All rights reserved.
*******************************************************************/
using LogMonitor.Core.ESLog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace LogMonitor.Core.ESLog
{

    public class ESLoggerProvider : ILoggerProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly FilterLoggerSettings _filter;

        public ESLoggerProvider(IServiceProvider serviceProvider, FilterLoggerSettings filter = null)
        {
            _httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
            _filter = filter ?? new FilterLoggerSettings
        {
            {"*", LogLevel.Warning}
        };
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ESLogger(_httpContextAccessor, categoryName, FindLevel(categoryName));
        }

        private LogLevel FindLevel(string categoryName)
        {
            var def = LogLevel.Warning;
            foreach (var s in _filter.Switches)
            {
                if (categoryName.Contains(s.Key))
                    return s.Value;

                if (s.Key == "*")
                    def = s.Value;
            }

            return def;
        }

        public void Dispose()
        {
        }

    }
}
