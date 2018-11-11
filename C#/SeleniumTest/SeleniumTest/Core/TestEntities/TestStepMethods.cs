using log4net;
using System;
using System.Diagnostics;
using System.Reflection;

namespace SeleniumTest.Core
{
    public class TestStepMethods
    {
        private static readonly ILog log = LogManager.GetLogger("TestStep");

        public static void TestStep(string description, Action testBody, out string methodName)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            log.Info($"Started:  '{description}'.");

            StackTrace stackTrace = new StackTrace();
            methodName = stackTrace.GetFrame(1).GetMethod().Name;

            try
            {                
                testBody.Invoke();
            }
            catch (Exception ex)
            {
                log.Info($"Error: '{description}'. Elapsed {stopwatch.Elapsed.Milliseconds} ms");
                log.Error($"Error message: {ex.Message}");
                log.Debug($"Stack trace: {ex.StackTrace}");

                throw ex;
            }
            finally
            {
                log.Info($"Finished: '{description}'. Elapsed {stopwatch.Elapsed.Milliseconds} ms");
            }
        }
    }
}
