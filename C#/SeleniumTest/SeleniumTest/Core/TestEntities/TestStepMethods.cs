using log4net;
using System;
using System.Diagnostics;

namespace SeleniumTest.Core
{
    public class TestStepMethods
    {
        private static readonly ILog log = LogManager.GetLogger("TestStep");

        public static void TestStep(string description, Action testBody)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            log.Info($"Started:  '{description}'.");

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
