using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace YouTube_Downloader.Services
{
    public static class Serializer
    {

        private static readonly string FilePath = "Downloads.json";

        public static async Task SerializeObjectAsync(YouTubeVideo obj)
        {
            string jsonLine = JsonSerializer.Serialize(obj);
            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                await writer.WriteLineAsync(jsonLine);
            }
        }
        public static async Task SerializeListAsync(BindingList<YouTubeVideo> videos)
        {
            using (StreamWriter writer = new StreamWriter(FilePath, false))
            {
                foreach (YouTubeVideo video in videos)
                {
                    string jsonLine = JsonSerializer.Serialize(video);
                    await writer.WriteLineAsync(jsonLine);
                }
            }
        }

        public static async Task<BindingList<YouTubeVideo>> LoadVideosAsync()
        {
            if (!File.Exists(FilePath))
                return null;

            BindingList<YouTubeVideo> downloads = new BindingList<YouTubeVideo>();


            using (StreamReader reader = new StreamReader(FilePath))
            {
                string line;

                while (( line = await reader.ReadLineAsync() ) != null)
                {
                    YouTubeVideo video = JsonSerializer.Deserialize<YouTubeVideo>(line);
                    if (video != null)
                        downloads.Add(video);
                }

                return downloads;
            }
        }
    }
}
