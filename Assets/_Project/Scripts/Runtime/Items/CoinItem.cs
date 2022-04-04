using Rogue.Managers;
using UnityEngine;

namespace Rogue.Items
{
    public class CoinItem : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required ScriptableObjects")]
        public PlayerDataSo PlayerData;

        [Header("Coin Properties")]
        public int Amount = 10;

        #endregion

        #region UNITY METHODS

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            // ToDo - Update Gold Text in HUD UI
            PlayerData.Gold += Amount;
            EventsManager.Instance.OnUpdateGoldText($"{PlayerData.Gold:0000000000}");
            Destroy(gameObject);
        }

        #endregion

        #region METHODS

        #endregion
    }
}