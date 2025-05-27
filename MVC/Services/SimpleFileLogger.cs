﻿namespace MVC.Services
{
    public class SimpleFileLogger
    {
        public void Log(string message)
        {
            File.AppendAllText(DateTime.Today.ToString("yyyyMMdd") + ".txt", message);

        }
    }
}
