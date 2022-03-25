using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Rogue.Data
{
    [Serializable]
    public class Item
    {
        public string ItemName = "";
        public int Amount = 0;
    }

    [Serializable]
    public class GameData
    {
        #region VARIABLES

        [Header("Currency")]
        public int Gold = 0;

        [Header("Items")]
        public List<Item> Items = new List<Item>();

        #endregion

        #region METHODS

        /// <summary>
        /// Serialization or Saving Data
        /// </summary>
        public void Save(string filename)
        {
            string persistentPath = Application.persistentDataPath;
            Debug.Log(persistentPath);

            string json = JsonUtility.ToJson(this, true);
            Debug.Log(json);

            File.WriteAllText(Path.Combine(persistentPath, $"{filename}.json"), json);
        }

        /// <summary>
        /// Deserialization or Loading Data
        /// </summary>
        public void Load(string filename)
        {
            string persistentPath = Application.persistentDataPath;
            string json = File.ReadAllText(Path.Combine(persistentPath, $"{filename}.json"));
            Debug.Log(json);
            JsonUtility.FromJsonOverwrite(json, this);
        }

        #endregion
    }
}