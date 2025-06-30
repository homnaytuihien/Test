using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitapkiemtra
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        public static string url = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/main/simple_players.json";
        public static string firebaseUrl = "https://lab11-1e6b9-default-rtdb.asia-southeast1.firebasedatabase.app/";
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var players = await GetPlayersFromJsonAsync();
            await GetsPlayerAbove1000Goldand100Coins(players);
            await TotalPlayerThatVipLevelAbove0(players);
            Console.ReadLine();
        }
        static async Task<List<Player>> GetPlayersFromJsonAsync()
        {
            HttpClient client = new HttpClient();
            try
            {
                string responseBody = await client.GetStringAsync(url);
                // Sử dụng Newtonsoft.Json để deserialize chuỗi JSON này
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
            catch (Exception e)
            {
                Console.WriteLine($"Đã xảy ra lỗi không mong muốn: {e.Message}");
                return null;
            }
        }
        public static async Task GetsPlayerAbove1000Goldand100Coins(List<Player> players)
        {
            var firebase = new FirebaseClient(firebaseUrl);
            var richplayers = players
            .Where(p => p.Gold > 1000 && p.Coins > 100)
            .OrderByDescending(p => p.Coins)
            .Select(p => new
            {
                p.Name,
                p.Gold,
                p.Coins,
            }).ToList();
            foreach (var p in richplayers)
            {
                Console.WriteLine($"Đã push: {p.Name} - Gold: {p.Gold} - Coins: {p.Coins}");
            }
            for (int i = 0; i < richplayers.Count; i++)
            {
                await firebase.Child("quiz_bai1_richPlayers").PutAsync(richplayers);
            }
        }
        public static async Task TotalPlayerThatVipLevelAbove0(List<Player> players)
        {
            var firebase = new FirebaseClient(firebaseUrl);
            int vipPlayerCountQuery = (from p in players
                                       where p.VipLevel > 0
                                       select p).Count();
            Console.WriteLine($"Số người chơi có VipLevel > 0: {vipPlayerCountQuery}");
            var vipCountsByRegion = from player in players
                                    where player.VipLevel > 0
                                    group player by player.Region into regionGroup
                                    select new
                                    {
                                        Region = regionGroup.Key,
                                        VipCount = regionGroup.Count()
                                    };

            foreach (var group in vipCountsByRegion)
            {
                Console.WriteLine($"Khu vực: {group.Region}, Số VIP: {group.VipCount}");
            }
            DateTime now = new DateTime(2025, 06, 30, 0, 0, 0);
            Console.WriteLine("\n Số lượng người chơi VIP mới đăng nhập");
            var recentPlayers = from p in players
                                where p.VipLevel > 0 && (now - p.LastLogin).TotalDays <= 2
                                select new
                                {
                                    p.Name,
                                    p.VipLevel,
                                    p.LastLogin
                                };
            foreach (var player in recentPlayers)
            {
                Console.WriteLine($"Name: {player.Name}, Vip Level: {player.VipLevel},, Last Login: {player.LastLogin}); ");
            }
            await firebase.Child("quiz_bai2_recentVipPlayers").PutAsync(recentPlayers);
        }
        public class Player
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Level { get; set; }
            public int Gold { get; set; }
            public int Coins { get; set; }
            public bool IsActive { get; set; }
            public int VipLevel { get; set; }
            public string Region { get; set; }
            public DateTime LastLogin { get; set; }


            public Player()
            {

            }
            public Player(int ID, string NAME, int LEVEL, int GOLD, int COINS, bool ISACTIVE, int VIPLEVEL, string REGION, DateTime LASTLOGIN)
            {
                this.Id = ID;
                this.Gold = GOLD;
                this.Coins = COINS;
                this.IsActive = ISACTIVE;
                this.VipLevel = VIPLEVEL;
                this.Region = REGION;
                this.LastLogin = LASTLOGIN;
            }
        }
    }
}
