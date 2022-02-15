using System;
using System.IO;
using AutomationPracticeTests.Utilities.Enums;
using Newtonsoft.Json;

namespace AutomationPracticeTests.Entities
{
    public class UserCreator
    {
        public static User GetUser(UserType userType)
        {
            User user;
            string folderPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources"));
           // D:\AutomationPracticeTests\AutomationPracticeTests\Resources\usersData.json
            using (StreamReader file = File.OpenText($@"{folderPath}\usersData.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                UserList userList = serializer.Deserialize(file, typeof(UserList)) as UserList;
                user = userList.Users[(int)userType];
            }

            return user;
        }

        public static User CreateUser(string userName, string password) => new User(userName, password);
    }
}
