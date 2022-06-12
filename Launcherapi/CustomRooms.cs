﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace OpenRec2.Launcherapi
{
    class CustomRooms
    {
        public static void RoomGet(string roomnames)
        {
            try
            {
                string webdata = new WebClient().DownloadString("https://rooms.rec.net/rooms?name=" + roomnames + "&include=297");
                ModernRooms.Root root2 = JsonConvert.DeserializeObject<ModernRooms.Root>(webdata);
                room = new Room
                {
                    RoomId = 29,
                    Name = root2.Name,
                    Description = "OpenRec Downloaded Room",
                    ImageName = root2.ImageName,
                    CreatorPlayerId = Convert.ToUInt64(File.ReadAllText("SaveData\\Profile\\userid.txt")),
                    State = 0,
                    Accessibility = 1,
                    SupportsLevelVoting = false,
                    IsAGRoom = false,
                    CloningAllowed = false,
                    SupportsScreens = true,
                    SupportsWalkVR = true,
                    SupportsTeleportVR = true,
                    ReplicationId = null,
                    ReleaseStatus = 0

                };
                scene = new List<Scene>
            {
                new Scene()
                {
                    RoomSceneId = 1,
                    RoomId = 29,
                    RoomSceneLocationId = root2.SubRooms[0].UnitySceneId,
                    Name = "Home",
                    IsSandbox = true,
                    DataBlobName =  root2.SubRooms[0].DataBlob,
                    MaxPlayers = 20,
                    CanMatchmakeInto = true,
                    DataModifiedAt = root2.SubRooms[0].DataSavedAt,
                    ReplicationId = null,
                    UseLevelBasedMatchmaking = false,
                    UseAgeBasedMatchmaking = false,
                    UseRecRoyaleMatchmaking = false,
                    ReleaseStatus = 0,
                    SupportsJoinInProgress = true
                }
            };
                root = new Root
                {
                    Room = room,
                    Scenes = scene,
                    CoOwners = new List<ulong>(),
                    InvitedCoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    InvitedHosts = new List<ulong>(),
                    CheerCount = root2.Stats.CheerCount,
                    FavoriteCount = root2.Stats.FavoriteCount,
                    VisitCount = root2.Stats.VisitCount,
                    Tags = new List<aTag>
                {
                    new aTag()
                    {
                        Tag = "rro",
                        Type = 2
                    }
                }

                };
                File.WriteAllText("SaveData\\Rooms\\Downloaded\\roomname.txt", root2.Name);
                File.WriteAllText("SaveData\\Rooms\\Downloaded\\roomid.txt", Convert.ToString(root2.RoomId));
                File.WriteAllText("SaveData\\Rooms\\Downloaded\\datablob.txt", root2.SubRooms[0].DataBlob);
                File.WriteAllText("SaveData\\Rooms\\Downloaded\\roomsceneid.txt", root2.SubRooms[0].UnitySceneId);
                File.WriteAllText("SaveData\\Rooms\\Downloaded\\imagename.txt", root2.ImageName);
                File.WriteAllText("SaveData\\Rooms\\Downloaded\\cheercount.txt", Convert.ToString(root2.Stats.CheerCount));
                File.WriteAllText("SaveData\\Rooms\\Downloaded\\favcount.txt", Convert.ToString(root2.Stats.FavoriteCount));
                File.WriteAllText("SaveData\\Rooms\\Downloaded\\visitcount.txt", Convert.ToString(root2.Stats.VisitCount));
                File.WriteAllText("SaveData\\Rooms\\Downloaded\\RoomDetails.json", JsonConvert.SerializeObject(root));
            }
            catch
            {

            }
        }



        public static Room room { get; set; }
        public static List<Scene> scene { get; set; }
        public static Root root { get; set; }
        //2018 rooms
        public class Room
        {
            public ulong RoomId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public ulong CreatorPlayerId { get; set; }
            public string ImageName { get; set; }
            public int State { get; set; }
            public int Accessibility { get; set; }
            public bool SupportsLevelVoting { get; set; }
            public bool IsAGRoom { get; set; }
            public bool CloningAllowed { get; set; }
            public bool SupportsScreens { get; set; }
            public bool SupportsWalkVR { get; set; }
            public bool SupportsTeleportVR { get; set; }
            public object ReplicationId { get; set; }
            public int ReleaseStatus { get; set; }
        }

        public class Scene
        {
            public int RoomSceneId { get; set; }
            public ulong RoomId { get; set; }
            public string RoomSceneLocationId { get; set; }
            public string Name { get; set; }
            public bool IsSandbox { get; set; }
            public string DataBlobName { get; set; }
            public int MaxPlayers { get; set; }
            public bool CanMatchmakeInto { get; set; }
            public DateTime DataModifiedAt { get; set; }
            public object ReplicationId { get; set; }
            public bool UseLevelBasedMatchmaking { get; set; }
            public bool UseAgeBasedMatchmaking { get; set; }
            public bool UseRecRoyaleMatchmaking { get; set; }
            public int ReleaseStatus { get; set; }
            public bool SupportsJoinInProgress { get; set; }
        }

        public class Root
        {
            public Room Room { get; set; }
            public List<Scene> Scenes { get; set; }
            public List<ulong> CoOwners { get; set; }
            public List<ulong> InvitedCoOwners { get; set; }
            public List<ulong> Hosts { get; set; }
            public List<ulong> InvitedHosts { get; set; }
            public int CheerCount { get; set; }
            public int FavoriteCount { get; set; }
            public int VisitCount { get; set; }
            public List<aTag> Tags { get; set; }
        }
        public class aTag
        {
            public string Tag { get; set; }
            public int Type { get; set; }
        }
    }
    public class ModernRooms
    {
        public class Stats
        {
            public int CheerCount { get; set; }
            public int FavoriteCount { get; set; }
            public int VisitorCount { get; set; }
            public int VisitCount { get; set; }
        }

        public class SubRoom
        {
            public int SubRoomId { get; set; }
            public ulong RoomId { get; set; }
            public string UnitySceneId { get; set; }
            public string Name { get; set; }
            public string DataBlob { get; set; }
            public DateTime DataSavedAt { get; set; }
            public bool IsSandbox { get; set; }
            public int MaxPlayers { get; set; }
            public int Accessibility { get; set; }
        }

        public class Root
        {
            public ulong RoomId { get; set; }
            public bool IsDorm { get; set; }
            public int MaxPlayerCalculationMode { get; set; }
            public int MaxPlayers { get; set; }
            public bool CloningAllowed { get; set; }
            public bool DisableMicAutoMute { get; set; }
            public bool DisableRoomComments { get; set; }
            public bool EncryptVoiceChat { get; set; }
            public bool LoadScreenLocked { get; set; }
            public int Version { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string ImageName { get; set; }
            public int WarningMask { get; set; }
            public object CustomWarning { get; set; }
            public int CreatorAccountId { get; set; }
            public int State { get; set; }
            public int Accessibility { get; set; }
            public bool SupportsLevelVoting { get; set; }
            public bool IsRRO { get; set; }
            public bool SupportsScreens { get; set; }
            public bool SupportsWalkVR { get; set; }
            public bool SupportsTeleportVR { get; set; }
            public bool SupportsVRLow { get; set; }
            public bool SupportsQuest2 { get; set; }
            public bool SupportsMobile { get; set; }
            public bool SupportsJuniors { get; set; }
            public int MinLevel { get; set; }
            public DateTime CreatedAt { get; set; }
            public Stats Stats { get; set; }
            public List<SubRoom> SubRooms { get; set; }
            public List<object> Tags { get; set; }
            public List<object> PromoImages { get; set; }
            public List<object> PromoExternalContent { get; set; }
            public List<object> LoadScreens { get; set; }
        }


    }
}
