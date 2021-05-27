using System.Collections.Generic;
using CommandLine;

namespace WhatDidISay
{
    internal class Options
    {
        public readonly IList<int> AllowedSampleRates = new List<int> { 44100, 22050, 11025};
            
        [Option('s', "samplerate", Required = false, Default = 44100, HelpText = "Sample rate; use 44100 (default), 22050 or 11025. The higher the better the quality.")]
        public int SampleRate { get; set; }

        public readonly IList<int> AllowedBitsPerSample = new List<int> {8, 16};

        [Option('b', "bits", Required = false, Default = 16, HelpText = "Bits per sample; Use 16 (default) or 8. The higher the better the quality.")]
        public int BitsPerSample { get; set; }

        public readonly IList<int> AllowedChannels = new List<int> { 1, 2 };

        [Option('c', "channels", Required = false, Default = 2, HelpText = "Number of channels; Use 2 (stereo; default) or 1 (mono).")]
        public int Channels { get; set; }

        [Option('t', "time", Required = false, Default = 5, HelpText = "Audio buffer time in minutes.")]
        public int BufferTimeInMinutes { get; set; }
    }
}