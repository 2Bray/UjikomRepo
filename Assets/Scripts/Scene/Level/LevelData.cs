using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{
    public void SellectLevel(int level)
    {
        CurrentSellectedLevel.Instance.SetLevel(level);
        SceneManager.LoadScene("Gameplay");
    }
}
