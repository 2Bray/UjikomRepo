using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
	private static SaveData _instance;
	public static SaveData Instance
	{
		get
		{
			return _instance;
		}
	}

	private DataPlayer _data;


	private const string DATACODE = "DataPlayer";

    public void InitObject(Currency currency)
    {
		if (_instance != null && _instance != this) Destroy(gameObject);
		else
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
			LoadData();

			currency.InitObject(_data);
		}
    }

    public void SavingData()
	{
		PlayerPrefs.SetString(DATACODE, JsonUtility.ToJson(new DataPlayer(_data)));
	}

	public void LoadData()
	{
		string json = PlayerPrefs.GetString(DATACODE);

		if (string.IsNullOrWhiteSpace(json))
		{
			_data = new DataPlayer();
		}
		else _data = JsonUtility.FromJson<DataPlayer>(json);
	}

	public string[] PacksUnlockList() => _data.PacksUnlockList;
	public string[] LevelPassed() => _data.LevelPassed;

	public void UpdatePacksUnlockList(string code)
	{
		string[] dataTemp = new string[_data.PacksUnlockList.Length + 1];
		for (int i = 0; i < _data.PacksUnlockList.Length; i++)
		{
			dataTemp[i] = _data.PacksUnlockList[i];
		}

		dataTemp[_data.PacksUnlockList.Length] = code;
		_data.PacksUnlockList = dataTemp;
		SavingData();
	}

	public void UpdateLevelPassed(string code, int lvl)
	{
		string[] dataTemp = new string[_data.LevelPassed.Length + 1];
		for (int i = 0; i < _data.LevelPassed.Length; i++)
		{
			dataTemp[i] = _data.LevelPassed[i];
		}

		dataTemp[_data.LevelPassed.Length] = code + "_" + lvl;
		_data.LevelPassed = dataTemp;
		SavingData();
	}

	private void SaveLevelPassed(int level)
	{
		UpdateLevelPassed(CurrentSellectedLevel.Instance.GetPackCode(), level);
	}

	public void AddEventToListen(GameFlow gameFlow) => gameFlow.FinishLevel += SaveLevelPassed;

	public void RemoveEvent(GameFlow gameFlow) => gameFlow.FinishLevel -= SaveLevelPassed;
}

public class DataPlayer
{
	public int Gold = 0;
	public string[] PacksUnlockList = new string[1] { "A" };
	public string[] LevelPassed = new string[0];

	public bool IsLoaded = false;
	public DataPlayer(DataPlayer data)
	{
		Gold = data.Gold;
		PacksUnlockList = data.PacksUnlockList;
		LevelPassed = data.LevelPassed;

		IsLoaded = false;
	}

	public DataPlayer() { }
}