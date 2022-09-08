using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PackListButton : MonoBehaviour
{
    public void SetButton(string packCode, bool isUnlock, Action<string> OnClickAction)
    {
        GetComponent<Button>().onClick.AddListener(() => OnClickAction(packCode));
        transform.GetComponentInChildren<TextMeshProUGUI>().text = "Pack Level " + packCode;
        GetComponent<Image>().color = isUnlock ? Color.white : Color.grey;
    }
}
