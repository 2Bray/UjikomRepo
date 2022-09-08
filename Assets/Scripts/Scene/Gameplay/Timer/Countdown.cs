using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Action OnTimesUp;

    [SerializeField] private float _timer;
    [SerializeField] private Slider _timerUI;
    [SerializeField] private Image _timerUIFill;

    private bool _isGameOver = false;

    private void Start()
    {
        _timerUI.maxValue = _timer;
        _timerUI.minValue = 0;

        _timerUI.value = _timerUI.maxValue;
        _timerUIFill.color = Color.green;
    }

    private void Update()
    {
        if (_isGameOver) return;

        _timer -= Time.deltaTime;
        _timerUI.value = _timer;

        if (_timer < 5) _timerUIFill.color = Color.red;

        if (_timer <= 0)
        {
            StopTime();
        }
    }

    public void StopTime()
    {
        _isGameOver = true;
        OnTimesUp();
    }

    public float GetTime() => _timer;
}
