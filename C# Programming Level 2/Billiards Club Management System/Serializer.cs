using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Billiards_Club_Management_System
{
    public static class Serializer
    {
        public class Data
        {
            
            private decimal _revenue = 0;
            private int _hourlyRate = 35;
            private int _foodOrders = 0;

            [JsonPropertyName("Revenue")]
            public decimal Revenue { get { return _revenue; } set { _revenue = value; } }
            [JsonPropertyName("HourlyRate")]
            public int HourlyRate { get { return _hourlyRate; } set { _hourlyRate = value; } }
            [JsonPropertyName("FoodOrders")]
            public int FoodOrders { get { return _foodOrders; } set { _foodOrders = value; } }

            [JsonConstructor]
            public Data(decimal revenue, int hourlyRate, int foodOrders)
            {
                Revenue = revenue;
                HourlyRate = hourlyRate;
                FoodOrders = foodOrders;
            }
        }

        private static readonly string FilePath = "data.json";

        public static async Task SerializeDataAsync(Data obj)
        {
            using (FileStream writeStream = File.Create(FilePath))
            {
                await JsonSerializer.SerializeAsync(writeStream, obj);
            }
        }

        public static async Task<Data> DeserializeDataAsync()
        {
            if (!File.Exists(FilePath))
            {
                await SerializeDataAsync(new Data(0, 35, 0));
            }

            using (FileStream readStream = File.OpenRead(FilePath))
            {
                return await JsonSerializer.DeserializeAsync<Data>(readStream);
            }

        }
    }
}
