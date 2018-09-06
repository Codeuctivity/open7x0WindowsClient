using System;
using System.Collections.Generic;
using System.IO;

namespace Open7x0Client
{
    internal class Open7x0EncodingQueueEntry : VdrInfo.InfoVdrParser.InfoVdr
    {
        public string mencoderparamterAudio = string.Empty;

        public string mencoderparamterVideo = string.Empty;

        public Open7x0EncodingQueueEntry(VdrInfo.InfoVdrParser.InfoVdr baseInfo, dvbTEncodingInfo mencoderParamters, bool shouldBeDeleteAfterSuccessfullEncoded, string outputDirectory, string outputFilePattern, string outputFileExtension)
        {
            this.AudioChannels = baseInfo.AudioChannels;
            this.AudioLanguages = baseInfo.AudioLanguages;
            this.ChannelID = baseInfo.ChannelID;
            this.Description = baseInfo.Description;
            this.Directory = baseInfo.Directory;
            this.EventID = baseInfo.EventID;
            this.infoVdrPath = baseInfo.infoVdrPath;
            this.RawAudiostreaminfos = baseInfo.RawAudiostreaminfos;
            this.RawVideostreaminfos = baseInfo.RawVideostreaminfos;
            this.ShortDescription = baseInfo.ShortDescription;
            this.TimerInfo = baseInfo.TimerInfo;
            this.Titel = baseInfo.Titel;
            this.Unknowninfos = baseInfo.Unknowninfos;
            this.VdrsPaths = new List<UriAndState>();
            int foo = 0;
            foreach (var item in baseInfo.VdrsPaths)
            {
                string enumerateOutput = string.Empty;
                if (baseInfo.VdrsPaths.Count > 1)
                {
                    enumerateOutput = foo.ToString() + "/" + baseInfo.VdrsPaths.Count.ToString();
                    foo++;
                }
                this.VdrsPaths.Add(new UriAndState { vdrpath = item, encodingState = EncodingState.Qued, OutputDestination = new Uri(outputDirectory + "\\" + parseToValidFilename(baseInfo, outputFilePattern, enumerateOutput) + outputFileExtension) });
            }
            this.ConcatedOuptupFilename = new Uri(outputDirectory + "\\" + parseToValidFilename(baseInfo, outputFilePattern) + outputFileExtension);

            this.VideoWidthHeightRatios = baseInfo.VideoWidthHeightRatios;
            this.VpsInfo = baseInfo.VpsInfo;

            if (baseInfo.AudioChannels.Contains(VdrInfo.InfoVdrParser.AudioChannel.Surround))
                mencoderparamterAudio = mencoderParamters.AudioAc3;
            else
                mencoderparamterAudio = mencoderParamters.AudioStero;
            if (baseInfo.VideoWidthHeightRatios.Contains(VdrInfo.InfoVdrParser.VideoWidthHeightRatio.Widescreen))
                mencoderparamterVideo = mencoderParamters.Video169;
            else
                mencoderparamterVideo = mencoderParamters.Video43;
            ShouldBeDeleteAfterSuccessfullEncoded = shouldBeDeleteAfterSuccessfullEncoded;
            encodingState = EncodingState.Qued;
        }

        public Uri ConcatedOuptupFilename { get; set; }

        public EncodingState encodingState { get; set; }

        public bool ShouldBeDeleteAfterSuccessfullEncoded { get; set; }

        /// <summary>
        /// Paths of corresponding vdr files containing the ps stream
        /// </summary>
        public new List<UriAndState> VdrsPaths { get; set; }

        private string parseToValidFilename(VdrInfo.InfoVdrParser.InfoVdr url, string p, string autoincrement)
        {
            string parsed = p.Replace("%shortDescription%", url.ShortDescription).Replace("%title%", url.Titel).Trim().Replace("%eventID%", url.EventID).Replace("%autoIncrement%", autoincrement).Replace("%timerInfo%", url.TimerInfo);
            foreach (var item in Path.GetInvalidFileNameChars())
            {
                parsed = parsed.Replace(item, '_');
            }
            return parsed.Trim();
        }

        private string parseToValidFilename(VdrInfo.InfoVdrParser.InfoVdr url, string p)
        {
            string parsed = p.Replace("%shortDescription%", url.ShortDescription).Replace("%title%", url.Titel).Trim().Replace("%eventID%", url.EventID).Replace("%autoIncrement%", "").Replace("%timerInfo%", url.TimerInfo);
            foreach (var item in Path.GetInvalidFileNameChars())
            {
                parsed = parsed.Replace(item, '_');
            }
            return parsed.Trim();
        }
    }
}