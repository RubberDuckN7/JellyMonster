using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.IsolatedStorage;

namespace Jelly_Monster
{
    public class PlayerData
    {
        public byte current_id;
        public byte world_id;
        public bool trial;

        public PlayerData()
        {
            current_id = 0;
            world_id = 0;
            trial = true;
        }
    }

    public class PlayerSaveData
    {
        public byte version;
        public List<byte> scores = new List<byte>();
        public byte music_off;
        public byte sound_off;
    }

    public static class Save
    {
        public static bool FileExist(string file)
        {
            using (IsolatedStorageFile fs = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (fs.FileExists(file))
                {
                    return true;
                }
            }

            return false;
        }

        public static void SaveFile(PlayerSaveData data, string file)
        {
            IsolatedStorageFile savegameStorage = IsolatedStorageFile.GetUserStoreForApplication();

            IsolatedStorageFileStream fs = null;
            using (fs = savegameStorage.CreateFile(file))
            {
                if (fs != null)
                {
                    fs.WriteByte(data.version);
                    fs.WriteByte((byte)data.scores.Count);
                    fs.Write(data.scores.ToArray(), 0, data.scores.Count);
                    fs.WriteByte(data.music_off);
                    fs.WriteByte(data.sound_off);
                }
            }
        }

        public static PlayerSaveData LoadFile(string file)
        {
            PlayerSaveData data = new PlayerSaveData();

            using (IsolatedStorageFile savegameStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream fs = savegameStorage.OpenFile(file, System.IO.FileMode.Open))
                {
                    if (fs != null)
                    {
                        byte version;
                        byte count;
                        byte[] bw;
                        version = (byte)fs.ReadByte();
                        count = (byte)fs.ReadByte();
                        bw = new byte[count];
                        fs.Read(bw, 0, count);

                        data.version = version;
                        data.scores = new List<byte>(bw);

                        data.music_off = (byte)fs.ReadByte();
                        data.sound_off = (byte)fs.ReadByte();

                        return data;
                    }
                }
            }

            return null;
        }
    }

    public class GameData
    {
        public int score;
        public byte life_count;
        public byte deaths;
        public MinuteCounter time;
        public bool won;

        public GameData()
        {
            score = 0;
            life_count = 0;
            deaths = 0;
            time = new MinuteCounter();
            won = false;
        }
    }
}
