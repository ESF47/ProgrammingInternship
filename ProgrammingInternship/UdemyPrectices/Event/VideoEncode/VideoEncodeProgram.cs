using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Event.VideoEncode
{
    class VideoEncodeProgram
    {
        Video video = new Video() { Title = "Video 1" };
        VideoEncoder videoEncoder = new VideoEncoder(); //publisher
        MailService mailService = new MailService(); //subscriber
        MessageService messageService = new MessageService(); //subscriber

        public void StartVideoEncoding()
        {
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);
        }
    }
}
