using Newtonsoft.Json;
using System;
using System.IO;
using Yandex.Enums;

namespace Yandex.Entities
{
    public class UserCreator
    {
        public static User GetUser(UserType userType)
        {
            User user;
            string folderPath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);

            using (StreamReader file = File.OpenText($@"{folderPath}\credentials.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                UserList userList = serializer.Deserialize(file, typeof(UserList)) as UserList;
                user = userList.Users[(int)userType];
            }

            return user;
        }
    }
}
