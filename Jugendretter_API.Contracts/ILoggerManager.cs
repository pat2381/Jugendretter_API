﻿using Microsoft.Extensions.Logging;


namespace Jugendretter_API.Contracts
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);

    }
}
