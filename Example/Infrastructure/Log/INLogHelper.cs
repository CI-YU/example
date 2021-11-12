using System;

namespace Example.Infrastructure.Log
{
    public interface INLogHelper
    {
        void LogError(Exception ex);
    }
}
