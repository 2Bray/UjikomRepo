using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    public Action<int> FinishLevel;

    [SerializeField] private Countdown _countDown;
    private string _correctAnswer;

    private bool _isGameOver = false;

    private void OnEnable()
    {
        _countDown.OnTimesUp += TimesUp;
        Analytic.Instance.AddEventToListen(this);
        Currency.Instance.AddEventToListen(this);
        SaveData.Instance.AddEventToListen(this);
    }

    private void OnDisable()
    {
        _countDown.OnTimesUp -= TimesUp;
        Analytic.Instance.RemoveEvent(this);
        Currency.Instance.RemoveEvent(this);
        SaveData.Instance.RemoveEvent(this);
    }

    private void TimesUp()
    {
        PlayerAnswer("");
    }

    public void SetCorrectAnswer(string correct) => _correctAnswer = correct;
    public void PlayerAnswer(string playerAnswer)
    {
        if (_isGameOver) return;

        _isGameOver = true;
        _countDown.StopTime();

        if (_correctAnswer == playerAnswer)
            PlayerCorrect();
        else 
            PlayerWrong();
    }

    private void PlayerCorrect()
    {
        string codePack = CurrentSellectedLevel.Instance.GetPackCode();
        int level = CurrentSellectedLevel.Instance.GetLevel();

        bool isLevelAlreadyPassed = false;
        string currentCode = codePack + "_" + level;
        foreach (string item in SaveData.Instance.LevelPassed())
        {
            if (currentCode == item)
            {
                isLevelAlreadyPassed = true;
                break;
            }
        }

        if (!isLevelAlreadyPassed) LevelPassed(level);

        QuizDatabase.Instance.GetQuizPack(codePack).GetQuizLevel(level).IsPassed = true;

        if (QuizDatabase.Instance.GetQuizPack(codePack).QuizLevelList.Length == level)
            SceneManager.LoadScene("Pack");
        else
        {
            CurrentSellectedLevel.Instance.SetLevel(level + 1);
            SceneManager.LoadScene("Gameplay");
        }
    }

    private void LevelPassed(int packLvl) => FinishLevel?.Invoke(packLvl);

    private void PlayerWrong()
    {
        SceneManager.LoadScene("Level");
    }
}
