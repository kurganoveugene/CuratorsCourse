using System;
using AutoIt;
using System.Threading;

namespace AutoItLib
{
    public static class AutoItUtil
    {
        public static void UploadFile(string path) 
        {
            AutoItX.WinActivate("Открытие");
            AutoItX.Sleep(500);
            AutoItX.Send(path);
            AutoItX.Sleep(1000);
            AutoItX.Send("{Enter}");
        }

    }
}
