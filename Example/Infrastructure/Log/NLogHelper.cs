using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace Example.Infrastructure.Log
{
    public class NLogHelper: INLogHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILogger<NLogHelper> _logger;
        public NLogHelper(IHttpContextAccessor httpContextAccessor, ILogger<NLogHelper> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public void LogError(Exception ex)
        {
            LogMessage logMessage = new LogMessage();
            logMessage.IpAddress = _httpContextAccessor.HttpContext.Request.Host.Host;
            if (ex.InnerException != null)
                logMessage.LogInfo = ex.InnerException.Message;
            else
                logMessage.LogInfo = ex.Message;
            logMessage.StackTrace = ex.StackTrace;
            logMessage.OperationTime = DateTime.Now;
            logMessage.OperationName = "admin";
            _logger.LogError(LogFormat.ErrorFormat(logMessage));
        }
    }
}
