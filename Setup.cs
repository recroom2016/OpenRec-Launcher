using OpenRec2.Launcherapi;
using System.Net;

namespace OpenRec2
{
    class Setup
    {
        public static bool firsttime = false;
        public static void setup()
        {
            //sets up all the important files so openrec doesnt crash like lame vaultserver xD

            //creates directories
            Directory.CreateDirectory("SaveData\\App\\");
            Directory.CreateDirectory("SaveData\\Profile\\");
            Directory.CreateDirectory("SaveData\\Images\\");
            Directory.CreateDirectory("SaveData\\Api\\");
            Directory.CreateDirectory("SaveData\\Rooms\\Downloaded\\");

            //application setup
            if (!(File.Exists("SaveData\\App\\firsttime.txt")))
            {
                File.WriteAllText("SaveData\\App\\firsttime.txt", "this text file has no use other than to tell the program whether to bring up the intro or not, so i can just write random shit here. among us balls, you suck mad dick you big fat fa----");
                firsttime = true;
            }
            if (!(File.Exists("SaveData\\App\\facefeaturesadd.txt")))
            {
                File.WriteAllText("SaveData\\App\\facefeaturesadd.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/facefeaturesadd.txt"));
            }

            //api setup
            if (!(File.Exists("SaveData\\Api\\configv2.txt")))
            {
                File.WriteAllText("SaveData\\Api\\configv2.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/configv2.txt"));
            }
            if (!(File.Exists("SaveData\\Api\\avataritems.txt")))
            {
                File.WriteAllText("SaveData\\Api\\avataritems.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/avataritems.txt"));
            }
            if (!(File.Exists("SaveData\\Api\\avataritems2.txt")))
            {
                File.WriteAllText("SaveData\\Api\\avataritems2.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/avataritems2.txt"));
            }
            if (!(File.Exists("SaveData\\Api\\equipment.txt")))
            {
                File.WriteAllText("SaveData\\Api\\equipment.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/equipment.txt"));
            }
            if (!(File.Exists("SaveData\\Api\\consumables.txt")))
            {
                File.WriteAllText("SaveData\\Api\\consumables.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/consumables.txt"));
            }
            if (!(File.Exists("SaveData\\Api\\gameconfigs.txt")))
            {
                File.WriteAllText("SaveData\\Api\\gameconfigs.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/gameconfigs.txt"));
            }
            if (!(File.Exists("SaveData\\Api\\storefronts2.txt")))
            {
                File.WriteAllText("SaveData\\Api\\storefronts2.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/storefront2.txt"));
            }
            if (!(File.Exists("SaveData\\Api\\baserooms.txt")))
            {
                File.WriteAllText("SaveData\\Api\\baserooms.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/baserooms.txt"));
            }
            if (!(File.Exists("SaveData\\Api\\myrooms.txt")))
            {
                File.WriteAllText("SaveData\\Api\\myrooms.txt", "[]");
            }



            //profile / user setup
            if (!(File.Exists("SaveData\\Profile\\avatar.txt")))
            {
                File.WriteAllText("SaveData\\Profile\\avatar.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/avatar.txt"));
            }
            else if (File.ReadAllText("SaveData\\Profile\\avatar.txt") == "")
            {
                File.WriteAllText("SaveData\\Profile\\avatar.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/avatar.txt"));
            }
            if (!(File.Exists("SaveData\\Profile\\username.txt")))
            {
                File.WriteAllText("SaveData\\Profile\\username.txt", "User#" + new Random().Next(0, 1000000));
            }
            if (!(File.Exists("SaveData\\Profile\\level.txt")))
            {
                File.WriteAllText("SaveData\\Profile\\level.txt", "10");
            }
            if (!(File.Exists("SaveData\\Profile\\userid.txt")))
            {
                File.WriteAllText("SaveData\\Profile\\userid.txt", "10000000");
            }
            if (!(File.Exists("SaveData\\Profile\\settings.txt")))
            {
                File.WriteAllText("SaveData\\Profile\\settings.txt", Newtonsoft.Json.JsonConvert.SerializeObject(Settings.CreateDefaultSettings()));
            }
            if (!(File.Exists("SaveData\\Profile\\profileimage.png")))
            {
                File.WriteAllBytes("SaveData\\Profile\\profileimage.png", new WebClient().DownloadData("https://github.com/OpenRecRoom/OpenRec/raw/main/profileimage.png"));
            }
            if (!File.Exists("SaveData\\Profile\\isdev.txt"))
            {
                File.WriteAllText("SaveData\\Profile\\isdev.txt", "true");
            }
            if (!File.Exists("SaveData\\Profile\\isjun.txt"))
            {
                File.WriteAllText("SaveData\\Profile\\isjun.txt", "false");
            }



            //settings setup
            if (!(File.Exists("SaveData\\App\\privaterooms.txt")))
            {
                File.WriteAllText("SaveData\\App\\privaterooms.txt", "false");
            }
            goto customroom;

        customroom:
            if (!File.Exists("SaveData\\Rooms\\Downloaded\\roomname.txt"))
            {
                try
                {
                    CustomRooms.RoomGet("gogo9");
                }
                catch
                {
                    goto customroom;
                }

            }

        }

        public static void reset()
        {

            File.WriteAllText("SaveData\\App\\firsttime.txt", "this text file has no use other than to tell the program whether to bring up the intro or not, so i can just write random shit here. among us balls, you suck mad dick you big fat fa----");
            firsttime = true;

            File.WriteAllText("SaveData\\App\\facefeaturesadd.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/facefeaturesadd.txt"));


            //api setup

            File.WriteAllText("SaveData\\Api\\avataritems.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/avataritems.txt"));

            File.WriteAllText("SaveData\\Api\\avataritems2.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/avataritems2.txt"));

            File.WriteAllText("SaveData\\Api\\equipment.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/equipment.txt"));

            File.WriteAllText("SaveData\\Api\\consumables.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/consumables.txt"));

            File.WriteAllText("SaveData\\Api\\gameconfigs.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/gameconfigs.txt"));

            File.WriteAllText("SaveData\\Api\\storefronts2.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/storefront2.txt"));

            File.WriteAllText("SaveData\\Api\\baserooms.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/baserooms.txt"));

            File.WriteAllText("SaveData\\Api\\myrooms.txt", "[]");



            //profile / user setup

            File.WriteAllText("SaveData\\Profile\\avatar.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/avatar.txt"));

            File.WriteAllText("SaveData\\Profile\\avatar.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/avatar.txt"));

            File.WriteAllText("SaveData\\Profile\\username.txt", "User#" + new Random().Next(0, 1000000));

            File.WriteAllText("SaveData\\Profile\\level.txt", "10");

            File.WriteAllText("SaveData\\Profile\\userid.txt", "10000000");

            File.WriteAllText("SaveData\\Profile\\settings.txt", Newtonsoft.Json.JsonConvert.SerializeObject(Settings.CreateDefaultSettings()));

            File.WriteAllBytes("SaveData\\Profile\\profileimage.png", new WebClient().DownloadData("https://github.com/OpenRecRoom/OpenRec/raw/main/profileimage.png"));

            File.WriteAllText("SaveData\\Profile\\isdev.txt", "true");

            File.WriteAllText("SaveData\\Profile\\isjun.txt", "false");




            //settings setup

            File.WriteAllText("SaveData\\App\\privaterooms.txt", "false");

            goto customroom;

        customroom:
            try
            {
                CustomRooms.RoomGet("gogo9");
            }
            catch
            {
                goto customroom;
            }

        }

    }
}
	
