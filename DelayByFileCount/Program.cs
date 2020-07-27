using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace DelayByFileCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Pauser pauser = new Pauser();

            try
            {
                var parser = new CommandLine.Parser(with => with.HelpWriter = null);
                var parserResult = parser.ParseArguments<Options>(args);
                parserResult
                  .WithParsed<Options>(options => pauser.Run(options))
                  .WithNotParsed(errors => DisplayHelp(parserResult, errors));
                parserResult.WithParsed(options => pauser.Run(options));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errors)
        {
            var helpText = HelpText.AutoBuild(result, h =>
            {
                var fvi = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
                h.Heading = string.Format("{0} {1}", fvi.ProductName, Assembly.GetEntryAssembly().GetName().Version.ToString());
                h.Copyright = fvi.LegalCopyright;
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e);
            Console.WriteLine(helpText);
        }
    }
}
