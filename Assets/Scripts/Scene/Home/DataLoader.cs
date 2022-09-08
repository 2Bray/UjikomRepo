using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    [SerializeField] private Analytic _analytic;
    [SerializeField] private CurrentSellectedLevel _currentSellectedLevel;
    [SerializeField] private SaveData _saveData;
    [SerializeField] private Currency _currency;
    [SerializeField] private QuizDatabase _QuizDatabase;

    private void Awake()
    {
        _analytic.InitObject();
        _currentSellectedLevel.InitObject();
        _saveData.InitObject(_currency);
        _QuizDatabase.InitObject();
    }
}
