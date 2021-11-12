using Microsoft.AspNetCore.Mvc.Filters;
using Example.Infrastructure.Log;
using System.Threading.Tasks;

namespace Example.Filter
{
    /// <summary>
    /// 異步版本自定義全局異常過濾器
    /// </summary>
    public class CustomerGlobalExceptionFilterAsync : IAsyncExceptionFilter
    {

        private readonly INLogHelper _logHelper;

        public CustomerGlobalExceptionFilterAsync(INLogHelper logHelper)
        {
            _logHelper = logHelper;
        }

        /// <summary>
        /// 重新OnExceptionAsync方法
        /// </summary>
        /// <param name="context">異常信息</param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            // 如果異常沒有被處理，則進行處理
            if (context.ExceptionHandled == false)
            {
                // 記錄錯誤信息
                _logHelper.LogError(context.Exception);
                // 設置為true，表示異常已經被處理了，其它捕獲異常的地方就不會再處理了
                context.ExceptionHandled = true;
            }

            return Task.CompletedTask;
        }
    }
}
