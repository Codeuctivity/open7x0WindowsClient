using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Open7x0Client
{
    public class Open7x0EncodingQueueEntry : VdrInfo.InfoVdrParser.InfoVdr
    {
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
            this.VdrsPaths = baseInfo.VdrsPaths;
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
            int foo = 0;
            foreach (var item in baseInfo.VdrsPaths)
            {
                string enumerateOutput = string.Empty;
                if (baseInfo.VdrsPaths.Count > 1)
                {
                    enumerateOutput = foo.ToString() + "/" + baseInfo.VdrsPaths.Count.ToString();
                    foo++;
                }
                OutputDestinations.Add(new Uri(outputDirectory + "\\" + parseToValidFilename(baseInfo, outputFilePattern, enumerateOutput) + outputFileExtension));
            }
        }

        public bool ShouldBeDeleteAfterSuccessfullEncoded { get; set; }

        public List<Uri> OutputDestinations { get; set; }

        public string mencoderparamterAudio = string.Empty;
        public string mencoderparamterVideo = string.Empty;

        private string parseToValidFilename(VdrInfo.InfoVdrParser.InfoVdr url, string p, string autoincrement)
        {
            string parsed = p.Replace("%shortDescription%", url.ShortDescription).Replace("%title%", url.Titel).Trim().Replace("%eventID%", url.EventID).Replace("%autoIncrement%", autoincrement).Replace("%timerInfo%", url.TimerInfo);
            foreach (var item in Path.GetInvalidFileNameChars())
            {
                parsed = parsed.Replace(item, '_');
            }
            return parsed;
        }

        private string parseToValidFilename(VdrInfo.InfoVdrParser.InfoVdr url, string p)
        {
            string parsed = p.Replace("%shortDescription%", url.ShortDescription).Replace("%title%", url.Titel).Trim().Replace("%eventID%", url.EventID).Replace("%autoIncrement%", "").Replace("%timerInfo%", url.TimerInfo);
            foreach (var item in Path.GetInvalidFileNameChars())
            {
                parsed = parsed.Replace(item, '_');
            }
            return parsed;
        }
    }
}