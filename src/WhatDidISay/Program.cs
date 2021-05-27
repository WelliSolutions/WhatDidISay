using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommandLine;
using WhatDidISay.Properties;

namespace WhatDidISay
{
    static class Program
    {
        /// <summary>
        /// Main program: parse command line options and start the UI
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            // Parse command line options
            var parserResult = Parser.Default.ParseArguments<Options>(args);
            Options options = null;
            parserResult.WithParsed(o => options = o);
            if (parserResult.Tag == ParserResultType.NotParsed)
            {
                ShowError(string.Format(Resource.InvalidArguments, string.Join(" ", args)), null);
                return 1;
            }


            // Test validity of command line options
            if (!options.AllowedBitsPerSample.Contains(options.BitsPerSample))
            {
                ShowError(string.Format(Resources.InvalidBitsPerSample, options.BitsPerSample), options.AllowedBitsPerSample);
                return 2;
            }

            if (!options.AllowedChannels.Contains(options.Channels))
            {
                ShowError(string.Format(Resource.InvalidChannels, options.Channels), options.AllowedChannels);
                return 3;
            }

            if (!options.AllowedSampleRates.Contains(options.SampleRate))
            {
                ShowError(string.Format(Resource.InvalidSampleRate, options.SampleRate), options.AllowedSampleRates);
                return 4;
            }

            if (options.BufferTimeInMinutes < 1) options.BufferTimeInMinutes = 1;
            if (options.BufferTimeInMinutes > 60) options.BufferTimeInMinutes = 60;

            // Run the application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new Form1 {Options = options};
            Application.Run(mainForm);

            return 0;
        }

        private static void ShowError(string message, IList<int> allowedValues)
        {
            if (allowedValues != null && allowedValues.Count > 0)
            {
                message = message + @" " + TryOneOf(allowedValues);
            }
            MessageBox.Show(message,
                Resource.ErrorParsingCommandLineOptions,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        static string TryOneOf(IList<int> values)
        {
            return string.Format(Resource.TryXYorZ, string.Join(Resource.TryXySeparator, values.Take(values.Count - 1)), values[values.Count - 1]);
        }
    }
}
