using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSellectedLevel : MonoBehaviour
{
    private static CurrentSellectedLevel _instance;
    public static CurrentSellectedLevel Instance { 
		get { 
			return _instance;
		}
	}

    private string code;
	private int lvl;

    public void InitObject()
    {
		if (_instance != null && _instance != this) Destroy(gameObject);
		else
		{
			DontDestroyOnLoad(gameObject);
			_instance = this;
		}
	}


	public void SetPackCode(string code) => this.code = code;

	public void SetLevel(int lvl) => this.lvl = lvl;

	public string GetPackCode() => code;
	public int GetLevel() => lvl;
}