using System.Net;
using System.IO;
using OpenRec2.Launcherapi;

namespace OpenRec2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //needs to be first or else gives an error bc its stoopid
            ApplicationConfiguration.Initialize();

            //sets up program
            Setup.setup();

            //debug
            if (Program.debugflag == true)
            {
                //debug to test out custom working console
                ConsoleWrite("pizza");
                ConsoleWrite("love");
                ConsoleWrite("i");
            }
           
            //fills in gui 

            //form1 - main menu
            form1.label1.Text = File.ReadAllText("SaveData\\Profile\\username.txt");
            form1.label5.Text = "Lvl " + File.ReadAllText("SaveData\\Profile\\level.txt");
            form1.pictureBox1.Image = Images.bytearraytoimage(File.ReadAllBytes("SaveData\\Profile\\profileimage.png"));
            form1.comboBox1.DisplayMember = "Select version.";
            form1.checkBox1.Checked = bool.Parse(File.ReadAllText("SaveData\\Profile\\isdev.txt"));
            form1.checkBox2.Checked = bool.Parse(File.ReadAllText("SaveData\\Profile\\isjun.txt"));
            form1.label11.Text = news;
            consolewindowopen = false;
            form1.checkBox3.Checked = bool.Parse(File.ReadAllText("SaveData\\App\\privaterooms.txt"));
            form1.label10.Text = "^" + File.ReadAllText("SaveData\\Rooms\\Downloaded\\roomname.txt");
            form1.label11.ForeColor = Color.Black;
            form1.label4.Text = "Version:" + version;

            //form2 - profile
            form2.Visible = false;

            //form3 - settings
            form3.Visible = false;

            //runs the form
            Application.Run(form1);
 
        }

        //main menu
        public static void Form1SetValues()
        {
            form1.label1.Text = File.ReadAllText("SaveData\\Profile\\username.txt");
            form1.label5.Text = "Lvl " + File.ReadAllText("SaveData\\Profile\\level.txt");
            form1.pictureBox1.Image = Images.bytearraytoimage(File.ReadAllBytes("SaveData\\Profile\\profileimage.png"));
            form1.checkBox1.Checked = bool.Parse(File.ReadAllText("SaveData\\Profile\\isdev.txt"));
            form1.checkBox2.Checked = bool.Parse(File.ReadAllText("SaveData\\Profile\\isjun.txt"));
            form1.checkBox3.Checked = bool.Parse(File.ReadAllText("SaveData\\App\\privaterooms.txt"));
            form1.label10.Text = "^" + File.ReadAllText("SaveData\\Rooms\\Downloaded\\roomname.txt");
            form1.label4.Text = "Version: " + version;

        }

        public static void Form1ButtonOnOff()
        {
            if (openrecopen == false)
            {
                form1.button1.Text = "Clear Console";
                openrecopen = true;
            }
            else if (openrecopen == true)
            {
                Program.ConsoleClear();
            }
            
        }

        //profile menu
        public static void Form2Visible()
        {
            form2.Visible = true;
        }
        public static void Form2Hide()
        {
            form2.Visible = false;
        }
        public static void Form2Save()
        {
            File.WriteAllText("SaveData\\Profile\\username.txt", form2.textBox1.Text);
            File.WriteAllText("SaveData\\Profile\\level.txt", form2.textBox2.Text);
            File.WriteAllText("SaveData\\Profile\\isdev.txt", Convert.ToString(form2.checkBox1.Checked));
            File.WriteAllText("SaveData\\Profile\\isjun.txt", Convert.ToString(form2.checkBox2.Checked));
        }
        public static void Form2SetValues()
        {
            form2.textBox1.Text = File.ReadAllText("SaveData\\Profile\\username.txt");
            form2.textBox2.Text = File.ReadAllText("SaveData\\Profile\\level.txt");
            form2.checkBox1.Checked = bool.Parse(File.ReadAllText("SaveData\\Profile\\isdev.txt"));
            form2.checkBox2.Checked = bool.Parse(File.ReadAllText("SaveData\\Profile\\isjun.txt"));
            form2.pictureBox1.Image = Images.bytearraytoimage(File.ReadAllBytes("SaveData\\Profile\\profileimage.png"));

        }

        //settings menu
        public static void Form3SetValues()
        {
            form3.checkBox1.Checked = bool.Parse(File.ReadAllText("SaveData\\App\\privaterooms.txt"));
            form3.textBox2.Text = File.ReadAllText("SaveData\\Rooms\\Downloaded\\roomname.txt");
        }
        public static void Form3Save()
        {
            File.WriteAllText("SaveData\\App\\privaterooms.txt", Convert.ToString(form3.checkBox1.Checked));
            CustomRooms.RoomGet(form3.textBox2.Text);
        }
        public static void Form3Hide()
        {
            form3.Visible = false;
        }
        public static void Form3Visible()
        {
            form3.Visible = true;
        }

        //console section of the menu
        public static void ConsoleShow()
        {
            Font SmallFont = new Font("Microsoft Sans Serif", 11);
            consolewindowopen = true;
            form1.label11.Text = console;
            form1.panel1.BackgroundImage = consolebackground;
            form1.label11.ForeColor = Color.White;
            form1.label11.Font = SmallFont;
        }
        

        public static void ConsoleHide()
        {

            Font BigFont = new Font("Microsoft Sans Serif", 14);
            consolewindowopen = false;
            form1.label11.Text = news;
            form1.panel1.BackgroundImage = newsbackground;
            form1.label11.ForeColor = Color.Black;
            form1.label11.Font = BigFont;
        }
        public static void ConsoleWrite(string info)
        {
            while (inuse == true)
            {
            }
            inuse = true;
            apinumber++;
            console = "[" + apinumber + "] " + info + Environment.NewLine + console;
            if (consolewindowopen == true)
            {
                form1.label11.Text = console;
            }
            inuse = false;
        }
        public static void ConsoleClear()
        {
            while (inuse == true)
            {
            }
            inuse = true;
            console = "";
            apinumber = 0;
            if (consolewindowopen == true)
            {
                form1.label11.Text = console;
            }
            inuse = false;
        }

        //this is here so i can reference non static objects i think | edit: yeah it is its pretty cool too thanks to whoever helped with this on stackexchange or whatever

        //form things
        public static Form1 form1 = new Form1();
        private static Form2 form2 = new Form2();
        private static Form3 form3 = new Form3();
        public static string version = "0.0.2";
        public static bool openrecopen = false;

        //console
        public static string console = "";
        public static bool consolewindowopen = false;
        public static int apinumber = 0;
        public static bool inuse;
        public static bool endopenrec = false; //closes openrec server thread | edit: nvm it dont work this is obselete stfu

        //does nothing ignore this lmao
        public static bool debugflag = false;

        //download news
        public static string news = new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Launcher/changelog.txt");
        public static Image newsbackground = Images.bytearraytoimage(new WebClient().DownloadData("https://github.com/recroom2016/OpenRec/raw/master/Launcher/ProfileComputer_Background01.png"));
        public static Image consolebackground = Images.bytearraytoimage(new WebClient().DownloadData("https://github.com/recroom2016/OpenRec/raw/master/Launcher/Untitled.png"));

        //gamesession
        public static OpenRec2.Serverapi.GameSessions.SessionInstance gamesession = new OpenRec2.Serverapi.GameSessions.SessionInstance();
    }
}