using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace DelayByFileCount
{
    public class Pauser
    {
        private readonly int checkPeriodSeconds = 2;

        private Options options;

        private bool terminate = false;

        public void Run(Options options)
        {
            this.options = options;

            bool success = true;

            if (options.FileCount == null)
            {
                Console.WriteLine($"Can't parse the file count: {options.FileCountString}");
                success = false;
            }

            if (string.IsNullOrWhiteSpace(options.DirectoryToWatch) || !Directory.Exists(options.DirectoryToWatch))
            {
                Console.WriteLine($"Can't find the directory: {options.DirectoryToWatch}");
                success = false;
            }

            if (!success)
            {
                throw new ArgumentException();
            }

            // Check folder every checkPeriodSeconds
            while (!terminate)
            {
                terminate = CheckForConditionMet();
                if (!terminate)
                {
                    Thread.Sleep(checkPeriodSeconds * 1000);
                }
            }
        }

        /// <summary>Check for filecount meeting the spec </summary>
        /// <returns>True if met</returns>
        private bool CheckForConditionMet()
        {
            bool conditionMet = false;

            int foundFileCount = Directory.EnumerateFiles(options.DirectoryToWatch).Count();
            if (options.FileCount.Value > 0)
            {
                // Terminate if we have found at least (+n)
                conditionMet = foundFileCount >= options.FileCount;
            }
            else if (options.FileCount.Value < 0)
            {
                // Terminate if we have found (-n) or less
                conditionMet = foundFileCount <= (-options.FileCount.Value);
            }
            else
            {
                conditionMet = true;
            }

            return conditionMet;
        }
    }
}
