using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PackData : MonoBehaviour
{
    public Action<string> UnlockPack;

    [SerializeField] private PackUnlock _unlock;
    [SerializeField] private GameObject _popUpPanel;

    private void OnEnable()
    {
        Analytic.Instance.AddEventToListen(this);
    }

    private void OnDisable()
    {
        Analytic.Instance.RemoveEvent(this);
    }

    public void SellectPack(string code)
    {
        QuizPack quiz = QuizDatabase.Instance.GetQuizPack(code);

        if (quiz.IsUnlock)
        {
            Continue(code);
        }
        else if (_unlock.UnlockPack(quiz))
        {
            quiz.IsUnlock = true;
            Currency.Instance.UpdateGold(-quiz.Price);
            SaveData.Instance.UpdatePacksUnlockList(quiz.QuizCode);

            UnlockPack(code);
            Continue(code);
        }
        else _popUpPanel.SetActive(true);
    }

    private void Continue(string code)
    {
        CurrentSellectedLevel.Instance.SetPackCode(code);
        SceneManager.LoadScene("Level");
    }
}
