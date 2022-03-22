using TMPro;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    #region VARIABLES

    public static InGameUIController Instance;
    public TMP_Text ScoreText;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        // Ensure we only Have 1 Singleton Instance of InGameUIController
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Refer Instance to itself
        Instance = this;

        // Do not destroy when we load different scenes
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    #region METHODS

    public void UpdateScoreText(string value)
    {
        ScoreText.SetText($"Score : {value}");
    }

    #endregion
}