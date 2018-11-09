using log4net;
using System;
using System.Diagnostics;

namespace SeleniumTest.Core.TestEntities
{
    public class TestCaseMethods
    {
        private static readonly ILog log = LogManager.GetLogger("TestCase");

        public static void TestCase(string description, Action testBody)
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

                throw ex;
            }
            finally
            {
                log.Info($"Finished: '{description}'. Elapsed {stopwatch.Elapsed.Milliseconds} ms");
            }
        }
    }
}
