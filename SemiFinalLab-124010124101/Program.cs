using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using FirebaseNet.Database;
using Google.Apis.Auth.OAuth2;
using static System.Formats.Asn1.AsnWriter;
using static SemiFinalLab_124010124101.Program;
namespace SemiFinalLab_124010124101
{
    internal class Program
    {
        public class Player
        {
            public string PlayerID { get; set; }
            public string Name { get; set; }
            public int Gold { get; set; }
            public int Score { get; set; }
            public int Index {  get; set; }
        }   

        
        public static string link = "https://project-7775521499500165313-default-rtdb.asia-southeast1.firebasedatabase.app/";
        static async Task Main(string[] args)
        {
            int i = 10;
            Console.OutputEncoding = Encoding.UTF8;                                 
            Console.WriteLine("FireSharp installed successfully!");
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("project-7775521499500165313.json")

            });
            Console.WriteLine("Firebase Admin SDK đã được khởi tạo thành công");

            while (true)
            {
                Console.WriteLine("\n========= MENU =========");
                Console.WriteLine("1. Thêm 10 player");
                Console.WriteLine("2. Xuất danh sách players");
                Console.WriteLine("3. Cập nhật Gold và Score");
                Console.WriteLine("4. Xóa Player");
                Console.WriteLine("5. Top Gold");
                Console.WriteLine("6. Top Score");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");
                string chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                    {
                        await AddPlayers(i);
                        break;
                    }
                    case "2":
                    {
                        await DisplayAllPlayers();
                        break;
                    }
                    case"3":
                    {
                        await UpdatePlayer();
                        break;
                    }
                    case "4":
                    {
                        await DeletePlayer();
                        break;
                    }
                    case "5":
                    {
                        await ShowTopGold();
                        break;
                    }
                    case "6":
                    {
                        await ShowTopScore();
                        break;
                    }
                    case "0":
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;

                }
                
            }                     
        }                
        public static async Task AddPlayers(int num)
        {
            var firebase = new FirebaseClient(link);
            for (int i = 1; i <= 10; i++)
            {
                var player = new Player
                {
                    PlayerID = $"P{i:00}",
                    Name = "Hoang Anh",
                    Gold = new Random().Next(1000, 10000),
                    Score = new Random().Next(0, 1000)
                };
                await firebase.Child("Players").Child(player.PlayerID).PutAsync(player);
            }
            Console.WriteLine("Đã thêm 10 player.");
        }
        static async Task DisplayAllPlayers()
        {
            var firebase = new FirebaseClient(link);
            var players = await firebase.Child("Players").OnceAsync<Player>();
            foreach (var player in players)
            {
                var p = player.Object;
                Console.WriteLine($"{p.PlayerID} - {p.Name} - Gold: {p.Gold} - Score: {p.Score}");
            }
        }
        static async Task UpdatePlayer()
        {
            var firebase = new FirebaseClient(link);
            Console.Write("Nhập PlayerID: ");
            string id = Console.ReadLine();
            var player = await firebase.Child("Players").Child(id).OnceSingleAsync<Player>();
            if (player == null) 
            { 
                Console.WriteLine("Không tìm thấy player."); 
                return;
            }
            Console.Write("Cập nhật Gold (G) hay Score (S)? ");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "G")
            {
                Console.Write("Nhập giá trị Gold mới: ");
                player.Gold = int.Parse(Console.ReadLine());
            }
            else if (choice == "S")
            {
                Console.Write("Nhập giá trị Score mới: ");
                player.Score = int.Parse(Console.ReadLine());
            }
            await firebase.Child("Players").Child(id).PutAsync(player);
            Console.WriteLine("Đã cập nhật thành công.");
        }
        static async Task DeletePlayer()
        {
            var firebase = new FirebaseClient(link);
            Console.Write("Nhập PlayerID để xóa: ");
            string id = Console.ReadLine();
            await firebase.Child("Players").Child(id).DeleteAsync();
            Console.WriteLine("Đã xóa player.");
        }
        static async Task ShowTopGold()
        {
            var firebase =new FirebaseClient(link);
            var topGold = (await firebase.Child("Players").OnceAsync<Player>())
                .Select(per => per.Object)
                .OrderByDescending(per => per.Gold)
                .Take(5);

            Console.WriteLine("Top 5 người chơi có Gold cao nhất:");
            foreach (var per in topGold)
            {
                Console.WriteLine($"{per.PlayerID} - {per.Name} - Gold: {per.Gold}");
            }
        }
        static async Task ShowTopScore()
        {
            var firebase = new FirebaseClient(link);
            
            var topScore = (await firebase.Child("Players").OnceAsync<Player>())
                
                .Select(per => per.Object)
                .OrderByDescending(per => per.Score)
                .Take(5)
                .ToList();
            Console.WriteLine("Top 5 người chơi có Score cao nhất:");
            for (int i = 0; i < topScore.Count; i++)
            {
                await firebase.Child("TopScore").Child((i + 1).ToString()).PutAsync(topScore[i]);
            }
            Console.WriteLine("Đã lưu Top 5 Score vào Firebase.");

        }

    }
}
