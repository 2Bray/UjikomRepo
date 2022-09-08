using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public Action<int> OnGoldUpdate;

    private static Currency _instance;
    public static Currency Instance
    {
        get
        {
            return _instance;
        }
    }


    private DataPlayer _data;

    public void InitObject(DataPlayer data)
    {
        _data = data;
        _instance = this;
    }

    public int GetGold() => _data.Gold;

    public void UpdateGold(int value)
    {
        _data.Gold += value;
        SaveData.Instance.SavingData();

        OnGoldUpdate?.Invoke(_data.Gold);
    }

    private void AddCurrency(int i) => UpdateGold(20);

    public void AddEventToListen(GameFlow gameFlow) => gameFlow.FinishLevel += AddCurrency;

    public void RemoveEvent(GameFlow gameFlow) => gameFlow.FinishLevel -= AddCurrency;
}
