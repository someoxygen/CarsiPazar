using CarsiPazarAPI.Models;
using Google.Cloud.Firestore;

namespace CarsiPazarAPI.Services
{
    public class FirebaseService
    {
        private readonly FirestoreDb _firestoreDb;

        public FirebaseService(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }
        public async Task UploadUsersToFirestore(User user)
        {
            var collection = _firestoreDb.Collection("Users");

            var document = new Dictionary<string, object>
            {
                { "Id", user.Id },
                { "UserName", user.UserName },
                { "PasswordHash", Convert.ToBase64String(user.PasswordHash) },
                { "PasswordSalt", Convert.ToBase64String(user.PasswordSalt) }
            };

            await collection.AddAsync(document);
        }
        public async Task AddDocumentAsync(string collectionName, object data)
        {
            var collectionRef = _firestoreDb.Collection(collectionName);
            await collectionRef.AddAsync(data);
        }
        public async Task<List<User>> GetUsersFromFirestore()
        {
            var collection = _firestoreDb.Collection("Users");
            var snapshot = await collection.GetSnapshotAsync();

            var users = new List<User>();

            foreach (var document in snapshot.Documents)
            {
                var userData = document.ToDictionary();

                users.Add(new User
                {
                    Id = Convert.ToInt32(userData["Id"]),
                    UserName = userData["UserName"].ToString(),
                    PasswordHash = Convert.FromBase64String(userData["PasswordHash"].ToString()),
                    PasswordSalt = Convert.FromBase64String(userData["PasswordSalt"].ToString())
                });
            }

            return users;
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            // Users koleksiyonunu al
            var collection = _firestoreDb.Collection("Users");

            // Sorgu oluştur (UserName = testuser)
            var query = collection.WhereEqualTo("UserName", userName);

            // Sorguyu çalıştır
            var snapshot = await query.GetSnapshotAsync();

            // Sonuçlardan kullanıcıyı al
            if (snapshot.Documents.Count > 0)
            {
                var document = snapshot.Documents[0];
                var userData = document.ToDictionary();

                return new User
                {
                    Id = Convert.ToInt32(userData["Id"]),
                    UserName = userData["UserName"].ToString(),
                    PasswordHash = Convert.FromBase64String(userData["PasswordHash"].ToString()),
                    PasswordSalt = Convert.FromBase64String(userData["PasswordSalt"].ToString())
                };
            }

            return null; // Kullanıcı bulunamadıysa null döner
        }

    public async Task<List<T>> GetDocumentsAsync<T>(string collectionName) where T : class
        {
            var collectionRef = _firestoreDb.Collection(collectionName);
            var snapshot = await collectionRef.GetSnapshotAsync();
            return snapshot.Documents.Select(d => d.ConvertTo<T>()).ToList();
        }
    }
}


