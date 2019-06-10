using System;
using System.Diagnostics;

namespace Contracts.Services
{
   /// <summary>
   /// Very basic logger class, using the System.Diagnostics.Trace.
   /// </summary>
   public static class SimpleLogger
   {
      public static void LogError(string message)
      {
         string error = $"[ERROR][{DateTime.Now.ToString()}] -- {message}";
         Log(error);
      }

      public static void LogInfo(string message)
      {
         string info = $"[INFO][{DateTime.Now.ToString()}] -- {message}";
         Log(info);
      }

      private static void Log(string message)
      {
         foreach(TraceListener listener in Trace.Listeners)
         {
            listener.WriteLine(message);
            listener.Flush();
         }
      }
   }
}
