using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class QuizDatabase : MonoBehaviour
{
	private static QuizDatabase _instance;
	public static QuizDatabase Instance
	{
		get
		{
			return _instance;
		}
	}

	[SerializeField] private QuizPack[] _quizPackList;

	public void InitObject()
	{
		if (_instance != null && _instance != this) Destroy(gameObject);
		else
		{
			DontDestroyOnLoad(gameObject);
			_instance = this;

			foreach(string item in SaveData.Instance.PacksUnlockList())
            {
				LoadDataUnlock(item);
            }
		}
	}

	private void LoadDataUnlock(string code)
	{
		foreach (QuizPack item in _quizPackList)
		{
			if (item.QuizCode == code)
			{
				item.IsUnlock = true;

				foreach(QuizLevel quizLevel in item.QuizLevelList)
                {
					LoadLevelPassed(item.QuizCode+"_", quizLevel);
                }

				break;
			}
		}
	}

	private void LoadLevelPassed(string code, QuizLevel quiz)
    {
		foreach (string item in SaveData.Instance.LevelPassed())
        {
			if (item == code + quiz.Level) quiz.IsPassed = true;
        }
	}

	public bool UnlockQuiz(QuizPack quiz)
	{
		if (Currency.Instance.GetGold() >= quiz.Price)
		{
			return true;
		}
		
		return false;
	}

	public QuizPack[] GetQuizPackList() => _quizPackList;

	public QuizPack GetQuizPack(string code)
	{

		foreach (QuizPack item in _quizPackList)
		{
			if (item.QuizCode == code) return item;
		}

		return null;
	}
}

[Serializable]
public class QuizPack
{
	public string QuizCode;
	public int Price;
	public bool IsUnlock;
	public QuizLevel[] QuizLevelList;

	public QuizLevel GetQuizLevel(int level) => QuizLevelList[level-1];
}

[Serializable]
public class QuizLevel
{
	public int Level;
	public string Question;
	public string[] Answer;
	public string AnswerCorrect;
	public Sprite ImageHint;
	public bool IsPassed;
}