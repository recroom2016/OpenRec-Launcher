using System;
using System.IO;
using Newtonsoft.Json;

namespace OpenRec2.Serverapi
{

    internal class getorcreate
    {
        public static string GetOrCreate(ulong userid)
        {
            
            return JsonConvert.SerializeObject(new Profiles
            {
                Id = userid,
                Username = File.ReadAllText("SaveData\\Profile\\username.txt"),
                DisplayName = File.ReadAllText("SaveData\\Profile\\username.txt"),
                XP = 48,
                Level = int.Parse(File.ReadAllText("SaveData\\Profile\\level.txt")),
                Reputation = 0,
                Verified = true,
                Developer = bool.Parse(File.ReadAllText("SaveData\\Profile\\isdev.txt")),
                HasEmail = true,
                CanReceiveInvites = false,
                ProfileImageName = File.ReadAllText("SaveData\\Profile\\username.txt"),
                HasBirthday = true
            });
        }
       
        public static string GetOrCreateArray(ulong userid)
        {
            
            return JsonConvert.SerializeObject(new Profiles[]
            {
                new Profiles
                {
                    Id = userid,
                    Username = File.ReadAllText("SaveData\\Profile\\username.txt"),
                    DisplayName = File.ReadAllText("SaveData\\Profile\\username.txt"),
                    XP = 48,
                    Level = int.Parse(File.ReadAllText("SaveData\\Profile\\level.txt")),
                    Reputation = 0,
                    Verified = true,
                    Developer = bool.Parse(File.ReadAllText("SaveData\\Profile\\isdev.txt")),
                    HasEmail = true,
                    CanReceiveInvites = false,
                    ProfileImageName = File.ReadAllText("SaveData\\Profile\\username.txt"),
                    JuniorProfile = bool.Parse(File.ReadAllText("SaveData\\Profile\\isjun.txt")),
                    ForceJuniorImages = bool.Parse(File.ReadAllText("SaveData\\Profile\\isjun.txt")),
                    HasBirthday = true
                }
            });
        }
        class Profiles
        {
            public ulong Id { get; set; }
            public string Username { get; set; }
            public string DisplayName { get; set; }
            public int XP { get; set; }
            public int Level { get; set; }
            public int Reputation { get; set; }
            public bool Verified { get; set; }
            public bool Developer { get; set; }
            public bool HasEmail { get; set; }
            public bool CanReceiveInvites { get; set; }
            public string ProfileImageName { get; set; }
            public bool JuniorProfile { get; set; }
            public bool ForceJuniorImages { get; set; }
            public bool PendingJunior { get; set; }
            public bool HasBirthday { get; set; }
            public string PhoneLastFour { get; set; }
        }
    }
}
