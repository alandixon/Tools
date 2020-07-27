using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelayByFileCount
{
    public class Options
    {
        [Option('d', "Directory", Required = true, HelpText = "Directory to Watch")]
        public string DirectoryToWatch { get; set; }

        [Option('f', "FileCount", Required = true, HelpText = "\nn or +n : Pause until there are n or MORE files.\n-n : Pause until there are n or LESS files")]
        public string FileCountString { get; set; }

        private int? fileCount;
        public int? FileCount
        {
            get
            {
                if (fileCount == null)
                {
                    // This slightly non-intuitive buffering for fileCount is needed because it is a nullable type
                    int i;
                    int.TryParse(FileCountString, out i);
                    fileCount = i;
                }
                return fileCount;
            }
        }

        /// <summary>A couple of examples that get used by DisplayHelp()</summary>
        [Usage(ApplicationAlias = "DelayByFileCount")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example(@"Example 1: Pause until there are 4 or more files in c:\temp", new Options { DirectoryToWatch = @"c:\temp", FileCountString = "4" });
                yield return new Example(@"Example 2: Pause until there are 3 or less files in c:\temp", new Options { DirectoryToWatch = @"c:\temp", FileCountString = "-3" });
            }
        }


    }
}
