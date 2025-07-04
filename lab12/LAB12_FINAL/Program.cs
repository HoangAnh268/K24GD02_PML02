using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;


namespace LAB12_FINAL
{
    internal class Program
    {
        public class Player
        {
            public string Name { get; set; }
            public int Level { get; set; }
            public int Gold { get; set; }
            public int Coins { get; set; }
            public bool IsActive { get; set; }
            public int VipLevel { get; set; }
            public string Region { get; set; }
            public DateTime LastLogin { get; set; }
        }
        static FirebaseClient firebase = new FirebaseClient("https://lab12-b9526-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static string link = "https://lab12-b9526-default-rtdb.asia-southeast1.firebasedatabase.app/";
        static async Task<List<Player>> LoadPlayersAsync()
        {
            try
            {
                string responseBody = await client.GetStringAsync("https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/refs/heads/main/lab12_players.json");
                return JsonConvert.DeserializeObject<List<Player>>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Lỗi HTTP khi tải dữ liệu: {e.Message}");
                return null;
            }
            catch (JsonSerializationException e)
            {
                Console.WriteLine($"Lỗi Deserialize JSON (Newtonsoft.Json): {e.Message}");
                return null;
            }
        }
        private static readonly HttpClient client = new HttpClient();
        public static async Task Players(List<Player> player)
        {
            Console.WriteLine("Bài 1: Người chơi cơ bản");
            var firebase = new FirebaseClient(link);
            DateTime now = new DateTime(2025, 07, 01, 0, 0, 0, DateTimeKind.Utc);
            var lowplayer = player
                .Where(p => (!p.IsActive || p.LastLogin <= now.AddDays(-10)) && p.Level <= 8)
                .Select(p => new { p.Name, p.IsActive, p.Level, p.LastLogin })
                .ToList();

            Console.WriteLine("Người chơi có cấp độ thấp và không hoạt động quá 10 ngày");          
            foreach (var p in lowplayer)
            {
                Console.WriteLine($"Name: {p.Name} | Active: {p.IsActive} | Level: {p.Level} | LastLogin: {p.LastLogin}");                                            
            }
            await firebase.Child("inactive_lowlevel_players").PutAsync(lowplayer);
            

            var highlevelrich = player
                .Where(p => p.Level >=12 && p.Gold > 2000)
                .Select(p => new {p.Name, p.Gold, p.Level})
                .ToList();
            Console.WriteLine("\nNgười chơi có cấp độ cao và giàu có:");
            foreach (var p in highlevelrich)
            {               
                Console.WriteLine($"Name:{p.Name} | CurrentGold:{p.Gold} | Level:{p.Level}  ");                  
            }
            await firebase.Child("highlevel_rich_players").PutAsync(highlevelrich);

            Console.WriteLine("\nBài 2: Trao thưởng người chơi hoạt động tích cực");
            var richplayer = player
                .Where(p => p.IsActive && p.LastLogin >= now.AddDays(-3))
                .OrderByDescending(p => p.Coins)
                .Take(3)
                .Select((p, index) => new {p.Name, p.Level, p.Coins,AwardedCoinAmount = index == 0 ? 3000 : index == 1 ? 2000 : 1000 })
                .ToList();
            Console.WriteLine("Top 3 người chơi có số Goin cao nhất và đăng nhập gần đây");
            foreach (var p in richplayer)
            {
                Console.WriteLine($"Name: {p.Name} | Level: {p.Level} | Coins: {p.Coins} | Thưởng: {p.AwardedCoinAmount}");                            
            }
            await firebase.Child("top3_active_coin_awards").PutAsync(richplayer);

        }
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var players = await LoadPlayersAsync();
            await Players(players);
            Console.ReadLine();
        }
    }
}
