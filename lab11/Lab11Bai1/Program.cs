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
using static Lab11Bai1.Program;


namespace Lab11Bai1
{
    internal class Program
    {
        static FirebaseClient firebase = new FirebaseClient("https://lab11-6e6bd-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static string link = "https://lab11-6e6bd-default-rtdb.asia-southeast1.firebasedatabase.app/";
        
        
        public class Player
        {           
            public string Name {  get; set; }
            public int Level { get; set; }
            public int Gold {  get; set; }
            public int Coins {  get; set; }
            public bool IsActive { get; set; }
            public int VipLevel {  get; set; }
            public string Region {  get; set; }
            public DateTime LastLogin { get; set; }
        }
        static async Task<List<Player>> LoadPlayersAsync()
        {           
            try
            {
                string responseBody = await client.GetStringAsync("https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/main/simple_players.json");               
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
        public static async Task SearchGoldandCoins(List<Player> player)
        {
            var firebase = new FirebaseClient(link);
            var richplayer = player
                .Where(p => p.Gold > 1000 && p.Coins > 100)
                .OrderByDescending(p => p.Coins)
                .Select(p => new {p.Name, p.Gold, p.Coins})
                .ToList();
            Console.WriteLine("Người chơi giàu nhất:");
            foreach(var p in  richplayer)
            {
                Console.WriteLine($"{p.Name} - Gold: {p.Gold} - Coins: {p.Coins}");
            }
            await firebase.Child("quiz_bai1_richPlayers").PutAsync(richplayer);
        }
        public static async Task VIPPlayers(List<Player> player)
        {
            var firebase =new FirebaseClient(link);
            Console.WriteLine("\nTổng số người chơi VIP:");
            int TongSoVIP = player.Count(p => p.VipLevel > 0);
            Console.WriteLine($"VIP Player: {TongSoVIP}");


            var VIPRegion = player
                .Where(p => p.VipLevel > 0)
                .GroupBy(p => p.Region)
                .Select(g => new { Region = g.Key, Count = g.Count()});
            Console.WriteLine("\nSố lượng Người chơi VIP theo khu vực:");
            foreach(var group in VIPRegion)
            {
                Console.WriteLine($"Khu vực:{group.Region}, Số người chơi VIP:{group.Count}");
            }


            Console.WriteLine("\nNgười chơi VIP mới đăng nhập");
            DateTime now = new DateTime(2025, 06, 30, 0, 0, 0);
            var RecentPlayer = player
                .Where(p => p.VipLevel > 0 && (now - p.LastLogin).TotalDays <= 2)
                .Select(p => new {p.Name, p.VipLevel, p.LastLogin});
            foreach (var p in RecentPlayer)
            {
                Console.WriteLine($"{p.Name} - VIPLevel:{p.VipLevel} - Thời gian đăng nhập lần cuối:{p.LastLogin}");
            }
            await firebase.Child("quiz_bai2_recentVipPlayers").PutAsync(RecentPlayer);
        }
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var players = await LoadPlayersAsync();
            await SearchGoldandCoins(players);
            await VIPPlayers(players);
            Console.ReadLine();
        }

    }
}
