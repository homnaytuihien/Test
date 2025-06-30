using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
namespace Demo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("FireSharp installed successfully!");
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("serviceAccountKey.json")
            });
            Console.WriteLine("Firebase Admin SDK đã được khởi tạo thành công!");
            await AddTestData();
            await ReadTestData();
            await UpdateTestData();
            await ReadTestData();
            await DeleteTestData();
        }
        public static async Task AddTestData()
        {
            try
            {
                var firebase = new FirebaseClient("https://thanh-ta-default-rtdb.asia-southeast1.firebasedatabase.app/");
                var testData = new
                {
                    Message = "Hello Firebase!",
                    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                };
                await firebase.Child("test").PutAsync(testData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
            Console.WriteLine("Dữ liệu đã được thêm vào Firebase!");
        }
        public static async Task ReadTestData()
        {
            var firebase = new FirebaseClient("https://thanh-ta-default-rtdb.asia-southeast1.firebasedatabase.app/");
            var testData = await firebase.Child("test").OnceSingleAsync<dynamic>();
            Console.WriteLine($"Message: {testData.Message}");
            Console.WriteLine($"Timestamp: {testData.Timestamp}");
        }
        public static async Task UpdateTestData()
        {
            var firebase = new FirebaseClient("https://thanh-ta-default-rtdb.asia-southeast1.firebasedatabase.app/");
            var testData = new
            {
                Message = "Updated Message!",
                Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
            };
            await firebase.Child("test").PatchAsync(testData);
            Console.WriteLine("Dữ liệu đã được cập nhật trong Firebase!");
        }
        public static async Task UpdateStudent()
        {
            var firebase = new FirebaseClient("https://thanh-ta-default-rtdb.asia-southeast1.firebasedatabase.app/");
            var testData = new
            {
                Message = "Updated Message!",
                Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
            };
            await firebase.Child("test").PatchAsync(testData);
            Console.WriteLine("Dữ liệu đã được cập nhật trong Firebase!");
        }
        public static async Task DeleteTestData()
        {
            var firebase = new FirebaseClient("https://thanh-ta-default-rtdb.asia-southeast1.firebasedatabase.app/");
            await firebase.Child("test").DeleteAsync();
            Console.WriteLine("Dữ liệu đã bị xóa khỏi Firebase!");
        }
    }
}
