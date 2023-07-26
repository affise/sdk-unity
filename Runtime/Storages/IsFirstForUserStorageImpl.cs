using System.Collections.Generic;
using System.IO;
using AffiseAttributionLib.Events;
using UnityEngine;

namespace AffiseAttributionLib.Storages
{
    /**
     * Storage of already send events
     *
     * @property context to retrieve app dir
     * @property logsManager for error logging
     */
    public class IsFirstForUserStorageImpl : IIsFirstForUserStorage
    {
        public void Add(string eventClass)
        {
            FileAppendText($"{eventClass}\n");
        }

        public List<string> GetEventNames()
        {
            return FileReadLines();
        }

        private string GetEventsFile()
        {
            var eventDir = Path.Join(Application.persistentDataPath, EventsParams.EVENTS_DIR_NAME);
            var filePath = Path.Join(eventDir, EventsParams.FIRST_FOR_USER_NAME);

            if (!Directory.Exists(eventDir))
            {
                Directory.CreateDirectory(eventDir);
            }

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "");
            }

            return filePath;
        }

        private List<string> FileReadLines()
        {
            var data = File.ReadAllText(GetEventsFile());
            return new List<string>(data.Split('\n'));
        }

        private void FileAppendText(string data)
        {
            File.AppendAllText(GetEventsFile(), data);
        }
    }
}