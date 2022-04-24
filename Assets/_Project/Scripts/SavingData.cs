using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

namespace Rogue
{
    public class SavingData : MonoBehaviour
    {
        #region VARIABLES

        public GameData GameData;

        public List<TMP_Text> Leaderboard = new List<TMP_Text>();

        #endregion

        #region METHODS

        public void SaveData()
        {
            string json = JsonUtility.ToJson(GameData);
            File.WriteAllText(Application.dataPath + "/gamedata.json", json);
        }

        public void LoadData()
        {
            string json = File.ReadAllText(Application.dataPath + "/gamedata.json");
            JsonUtility.FromJsonOverwrite(json, GameData);
        }

        #endregion

        #region MyRegion

        public void PopulateLeaderboard()
        {
            int count = Leaderboard.Count;
            for (int i = 0; i < count; i += 1)
            {
                string leaderboardString = $"{GameData.Players[i].PlayerName}\t{GameData.Players[i].Score}";
                Leaderboard[i].SetText(leaderboardString);
            }
        }

        #endregion
    }
}