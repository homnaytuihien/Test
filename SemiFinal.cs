using Firebase;
using Firebase.Database;
using Firebase.Database.Extensions;
using Firebase.Database.Query;
using FirebaseAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SEMI_FINAL
{
    internal class Program
    {
        public static string link = "https://demo1-f3510-default-rtdb.asia-southeast1.firebasedatabase.app/";
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            await GenerateData(10);
            Console.WriteLine("Đã cập nhật người chơi");
            List<Player> players = new List<Player>();
            players = await GetData();
            Console.WriteLine("Trước khi update Gold:");
            foreach (Player p in players)
            {
                Console.WriteLine($"\nGold: {p.Gold}\nName: {p.Name}\nId: {p.ID}\nScore: {p.Score}");
            }
            Console.WriteLine("Nhập id: ");
            string idup = Console.ReadLine();
            Console.WriteLine("Nhập Gold: ");
            int gold = int.Parse(Console.ReadLine());
            Console.WriteLine("Sau khi update Gold:");
            await UpdateGold(idup, gold);
            players = await GetData();
            foreach (Player p in players)
            {
                Console.WriteLine($"\nGold: {p.Gold}\nName: {p.Name}\nId: {p.ID}\nScore: {p.Score}");
            }
            Console.WriteLine("Nhập id cần xóa");
            string id = Console.ReadLine();
            await DeletePlayer(id);
            players = await GetData();
            Console.WriteLine("Sau khi xóa");
            foreach (Player p in players)
            {
                Console.WriteLine($"\nGold: {p.Gold}\nName: {p.Name}\nId: {p.ID}\nScore: {p.Score}");
            }
            players = await Top5();
            Console.WriteLine("Xuất bảng xếp hạng");
            foreach (Player p in players)
            {
                Console.WriteLine($"\nGold: {p.Gold}\nName: {p.Name}\nId: {p.ID}\nScore: {p.Score}");
            }
            Console.WriteLine("Sắp xếp theo thứ tự giảm dần: ");
            await NewNode();
            players = await GetData1();
            foreach (Player p in players)
            {
                Console.WriteLine($"\nGold: {p.Gold}\nName: {p.Name}\nId: {p.ID}\nScore: {p.Score}");
            }
        }

        static async Task GenerateData(int number)
        {
            var firebase = new FirebaseClient(link);
            Random rand = new Random();
            for (int i = 0; i < number; i++)
            {
                Player player = new Player(rand.Next(5000, 10000), $"Player {i + 1}", $"p{i + 1}", rand.Next(0, 100));
                await firebase.Child("Players").Child(player.Name).PutAsync(player);
            }
        }
        static async Task NewNode()
        {
            var firebase = new FirebaseClient(link);
            List<Player> players = new List<Player>();
            players = await GetData();
            players = players.OrderByDescending(x => x.Score).Take(5).ToList();
            for (int i = 0; i < 5; i++)
            {
                await firebase.Child("TopScore").Child($"Player {i + 1}").PutAsync(players[i]);
            }
        }

        static async Task<List<Player>> GetData()
        {
            var firebase = new FirebaseClient(link);
            List<Player> listPlayers = new List<Player>();
            var data = await firebase.Child("Players").OnceAsync<Player>();

            foreach (var item in data)
            {
                listPlayers.Add(item.Object);
            }
            return listPlayers;
        }
        static async Task<List<Player>> GetData1()
        {
            var firebase = new FirebaseClient(link);
            List<Player> listPlayers = new List<Player>();
            var data = await firebase.Child("TopScore").OnceAsync<Player>();

            foreach (var item in data)
            {
                listPlayers.Add(item.Object);
            }
            return listPlayers;
        }
        static async Task UpdateGold(string updateid, int gold)
        {
            var firebase = new FirebaseClient(link);
            var data = await firebase.Child("Players").OnceAsync<Player>();
            Random rand = new Random();
            var updateData = new
            {
                Gold = gold
            };
            for (int i = 0; i < data.Count - 1; i++)
            {
                string players = $"Player {i + 1}";
                string id = $"p{i + 1}";
                if (updateid == id)
                {
                    await firebase.Child("Players").Child(players).PatchAsync(updateData);
                    break;
                }
            }
        }
        public static async Task DeletePlayer(string deleteid)
        {
            var firebase = new FirebaseClient(link);
            var data = await firebase.Child("Players").OnceAsync<Player>();
            for (int i = 0; i < data.Count - 1; i++)
            {
                string players = $"Player {i + 1}";
                string id = $"p{i + 1}";
                if (deleteid == id)
                {
                    await firebase.Child("Players").Child(players).DeleteAsync();
                    Console.WriteLine("Dữ liệu đã bị xóa khỏi Firebase!");
                    break;
                }
            }
        }
        public static async Task<List<Player>> Top5()
        {
            var firebase = new FirebaseClient(link);
            List<Player> players = new List<Player>();
            players = await GetData();
            players = players.OrderByDescending(x => x.Gold).Take(5).ToList();
            return players;
        }
    }
    public class Player
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }
        public int Score { get; set; }
        public Player()
        {

        }
        public Player(int gold, string name, string playerID, int score)
        {
            this.Name = name;
            this.Gold = gold;
            this.Score = score;
            this.ID = playerID;
        }
    }
}
