using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AnswerButton : MonoBehaviour
{
    public void SetInitButton(string answer, Action<string> OnClickAction)
    {
        GetComponent<Button>().onClick.AddListener(() => OnClickAction(answer));
        transform.GetComponentInChildren<TextMeshProUGUI>().text = answer;
    }
}
