using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PackScene : MonoBehaviour
{
    [SerializeField] private PackListButton _buttonPackList;
    [SerializeField] private Transform _buttonParent;

    [SerializeField] private PackData _data;
    [SerializeField] private Button _backButton;

    private void Start()
    {
        foreach(QuizPack item in QuizDatabase.Instance.GetQuizPackList())
        {
            Instantiate(_buttonPackList, _buttonParent).SetButton(
                item.QuizCode,
                item.IsUnlock,
                _data.SellectPack
                );
        }

        _backButton.onClick.AddListener(() => SceneManager.LoadScene("Home"));
    }
}
