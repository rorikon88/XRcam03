using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
//using System.Windows;



namespace ConsoleApplication1
{
    class Program
    {
       
        //public static class Clipboard;
        static async Task Main(string[] args)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDRhElrJPoezreOrV30GXJddw4wBOcyLCo"
            });


            //string liveChatId = GetliveChatID("RxkGOEIvIKM", youtubeService);
            string liveChatId = GetliveChatID("LHNwLqza37k", youtubeService);

            await GetLiveChatMessage(liveChatId, youtubeService, null);


        }

       
            // 將字串寫入TXT檔
           
        

        static public string GetliveChatID(string videoId, YouTubeService youtubeService)
        {
            //引数で取得したい情報を指定
            var videosList = youtubeService.Videos.List("LiveStreamingDetails");
            videosList.Id = videoId;
            //動画情報の取得
            var videoListResponse = videosList.Execute();
            //LiveChatIDを返す
            foreach (var videoID in videoListResponse.Items)
            {
                return videoID.LiveStreamingDetails.ActiveLiveChatId;
            }
            //動画情報取得できない場合はnullを返す
            return null;
        }

        static public async Task GetLiveChatMessage(string liveChatId, YouTubeService youtubeService, string nextPageToken)
        {
            var liveChatRequest = youtubeService.LiveChatMessages.List(liveChatId, "snippet,authorDetails");
            liveChatRequest.PageToken = nextPageToken;

            var liveChatResponse = await liveChatRequest.ExecuteAsync();
            foreach (var liveChat in liveChatResponse.Items)
            {
                try
                {
                    Console.WriteLine($"{liveChat.Snippet.DisplayMessage},{liveChat.AuthorDetails.DisplayName}");
                    StreamWriter str = new StreamWriter(@"D:\XRcam_Arduino_003_demo\Assets\Scrip\Resources\Write.TXT");
                    //str.Write("  ");
                    str.Write(liveChat.AuthorDetails.DisplayName);
                    //str.WriteLine(",");
                    str.Write(liveChat.Snippet.DisplayMessage);
                    //printf('00000');
                    //Clipboard.SetData(DataFormats.Text, (Object)textData);
                    //Clipboard.SetData(DataFormats.Text, "123丟進剪貼簿");
                    //Clipboard.SetDataObject(textBox1.SelectedText);
          

                    str.Close();
                }
                catch { }

            }
            await Task.Delay((int)liveChatResponse.PollingIntervalMillis);
            await GetLiveChatMessage(liveChatId, youtubeService, liveChatResponse.NextPageToken);
        }
    }
}