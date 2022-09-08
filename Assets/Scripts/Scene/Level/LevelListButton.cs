using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelListButton : MonoBehaviour
{
    public void SetButton(int level, bool isPassed, Action<int> OnClickAction)
    {
        GetComponent<Button>().onClick.AddListener(() => OnClickAction(level));
        transform.GetComponentInChildren<TextMeshProUGUI>().text = "Level " + level;

        transform.GetChild(transform.childCount - 1).gameObject.SetActive(isPassed);
    }
}
