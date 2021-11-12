﻿using System.Text;

namespace Example.Infrastructure.Log
{
    public class LogFormat
    {
        public static string ErrorFormat(LogMessage logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("1. 操作時間: " + logMessage.OperationTime + " \r\n");
            strInfo.Append("2. 操作人: " + logMessage.OperationName + " \r\n");
            strInfo.Append("3. Ip  : " + logMessage.IpAddress + "\r\n");
            strInfo.Append("4. 錯誤內容: " + logMessage.LogInfo + "\r\n");
            strInfo.Append("5. 追蹤訊息: " + logMessage.StackTrace + "\r\n");
            strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }
    }
}
