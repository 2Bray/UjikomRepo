using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldUI;

    private void OnEnable()
    {
        Currency.Instance.OnGoldUpdate += ShowGold;

        ShowGold(Currency.Instance.GetGold());
    }

    private void OnDisable()
    {
        Currency.Instance.OnGoldUpdate -= ShowGold;
    }

    private void ShowGold(int value)
    {
        _goldUI.text = "Coin :" + value;
    }
}
