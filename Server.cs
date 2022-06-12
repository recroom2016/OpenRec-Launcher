using System.Net;
using System.Text;
using OpenRec2;
using OpenRec2.Serverapi;

namespace OpenRec2
{
    internal class Server
    {
        public Server()
        {
            try
            {
                Program.ConsoleWrite("[Server.cs] has started.");
                Thread thread = new Thread(new ThreadStart(this.StartListen));
                thread.IsBackground = true;
                thread.Start();
                
            }
            catch (Exception ex)
            {
                Program.ConsoleWrite("An Exception Occurred while Listening :" + ex.ToString());
            }
        }
        private void StartListen()
        {
            try
            {
                Program.form1.comboBox1.SelectedIndex = Program.form1.comboBox1.Items.IndexOf("2016");
                if (Program.form1.comboBox1.SelectedIndex == 0)
                {
                    //i just deleted everything to remake it, kinda stupid but yeah
                    this.listener.Prefixes.Add("http://localhost:2016/");
                    Program.ConsoleWrite("[Server.cs] is listening.");
                    for (; ; )
                    {
                        this.listener.Start();
                        HttpListenerContext context = this.listener.GetContext();
                        HttpListenerRequest request = context.Request;
                        HttpListenerResponse response = context.Response;
                        string rawUrl = request.RawUrl;
                        string url = request.RawUrl.Remove(0, 5);
                        string api = "";
                        string text = "";

                        //gets POST data
                        using (StreamReader streamReader = new StreamReader(request.InputStream, request.ContentEncoding))
                        {
                            text = streamReader.ReadToEnd();
                        }

                        //debug
                        if (Program.debugflag == true)
                        {
                            Program.ConsoleWrite("[Server.cs] " + request.HttpMethod);
                        }

                        Program.ConsoleWrite("Game requested for " + url);

                        //startup apis
                        if (rawUrl.Contains("versioncheck"))
                        {
                            api = VersionCheckResponse;
                        }
                        if (rawUrl == "/api/players/v1/getorcreate")
                        {
                            api = getorcreate.GetOrCreate((ulong.Parse(text.Remove(0, 32).Remove(7, text.Length - 39)))); 
                        }
                        if (rawUrl == "/api/config/v2")
                        {
                            api = File.ReadAllText("SaveData\\Api\\configv2.txt");
                        }
                        if (rawUrl == "/api/avatar/v2")
                        {
                            api = File.ReadAllText("SaveData\\Profile\\avatar.txt");
                        }
                        if (rawUrl == "/api/settings/v2/")
                        {
                            api = File.ReadAllText("SaveData\\Profile\\settings.txt");
                        }
                        if (rawUrl == "/api/avatar/v3/items")
                        {
                            api = File.ReadAllText("SaveData\\Api\\avataritems.txt");
                        }
                        if (rawUrl == "/api/avatar/v2/gifts")
                        {
                            api = BracketResponse;
                        }

                        //ingame apis
                        if (rawUrl.StartsWith("/api/avatar/v2/set"))
                        {
                            File.WriteAllText("SaveData\\Profile\\avatar.txt", text);
                        }

                        //profile image
                        bool imageflag = false;
                        byte[] profileimage = null;
                        if (rawUrl.StartsWith("/api/images/v1/"))
                        {
                            imageflag = true;
                            profileimage = File.ReadAllBytes("SaveData\\Profile\\profileimage.png");
                        }


                        //debug
                        if (Program.debugflag == true)
                        {
                            if (!(rawUrl == "/api/avatar/v3/items"))
                            {
                                Program.ConsoleWrite("[Server.cs] Response:" + api);
                            }
                        }
                       
                        byte[] bytes = Encoding.UTF8.GetBytes(api);
                        if (imageflag == true)
                        {
                            bytes = profileimage;
                        }
                        response.ContentLength64 = (long)bytes.Length;
                        Stream outputStream = response.OutputStream;
                        outputStream.Write(bytes, 0, bytes.Length);
                        Thread.Sleep(100);
                        outputStream.Close();
                        this.listener.Stop();

                    }

                }
                else
                {
                    Program.ConsoleWrite("Please select a version.");
                }
            }
            catch (Exception ex4)
            {
                Program.ConsoleWrite(ex4.ToString());
                File.WriteAllText("crashdump.txt", Convert.ToString(ex4));
                this.listener.Close();
                new Server();
            }
        }


        public static string BlankResponse = "";
        public static string BracketResponse = "[]";
        public static string VersionCheckResponse = "{\"ValidVersion\":true}";
        private HttpListener listener = new HttpListener();
    }
}
