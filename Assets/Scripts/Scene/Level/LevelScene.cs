using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScene : MonoBehaviour
{
    [SerializeField] private LevelListButton _buttonLevelList;
    [SerializeField] private Transform _buttonParent;

    [SerializeField] private LevelData _levelData;
    [SerializeField] private Button _backButton;

    private void Start()
    {
        QuizPack currentPack = QuizDatabase.Instance.GetQuizPack(CurrentSellectedLevel.Instance.GetPackCode());
        foreach (QuizLevel item in currentPack.QuizLevelList)
        {
            Instantiate(_buttonLevelList, _buttonParent).SetButton(
                item.Level,
                item.IsPassed,
                _levelData.SellectLevel
                );
        }

        _backButton.onClick.AddListener(()=>SceneManager.LoadScene("Pack"));
    }
}
