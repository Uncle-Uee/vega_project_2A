using System;
using LU3;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int Score = 10;

    public void OnMouseDown()
    {
        print("Clicking Object");
        GameManager.Instance.UpdateScore(Score);
    }
}