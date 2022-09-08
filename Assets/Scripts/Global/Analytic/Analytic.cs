using System;
using System.Collections.Generic;
using UnityEngine;

public class Analytic : MonoBehaviour
{
    private static Analytic _instance;
    public static Analytic Instance
    {
        get
        {
            return _instance;
        }
    }

    public void InitObject()
    {
        if (_instance != null && _instance != this) Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void TrackUnlockPack(string packCode)
    {
        Debug.Log("Mengirim Ke Server\n"+"Player Membeli Pack : "+packCode);
    }

    private void TrackFinishLevel(int packLvl)
    {
        Debug.Log("Mengirim Ke Server\n" + "Player Melewati Level : " + packLvl);
    }

    public void AddEventToListen(PackData packData) => packData.UnlockPack += TrackUnlockPack;

    public void AddEventToListen(GameFlow gameFlow) => gameFlow.FinishLevel += TrackFinishLevel;

    public void RemoveEvent(PackData packData) => packData.UnlockPack -= TrackUnlockPack;

    public void RemoveEvent(GameFlow gameFlow) => gameFlow.FinishLevel -= TrackFinishLevel;
}
