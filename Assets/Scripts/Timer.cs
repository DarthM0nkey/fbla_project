using System;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TMP_Text _timerText;
    enum TimerType {Countdown, Stopwatch}
    [SerializeField] private TimerType _timerType;
    [SerializeField] private float timeToDisplay = 60.0f;
    private bool _isRunning;

    private void Awake()
    {
        _timerText = GetComponent<TMP_Text>();
        _isRunning = true;
        
    }
    private void OnEnable ()
    {
        EventManager.TimerStart += EventManagerOnTimerStart;
        EventManager.TimerStop += EventManagerOnTimerStop;
        EventManager.TimerUpdate += EventManagerOnTimerUpdate;
    }
    private void OnDisable()
    {
        EventManager.TimerStart -= EventManagerOnTimerStart;
        EventManager.TimerStop -= EventManagerOnTimerStop;
        EventManager.TimerUpdate -= EventManagerOnTimerUpdate;
    }
    private void EventManagerOnTimerStart() => _isRunning = true;
   
    private void EventManagerOnTimerStop() => _isRunning = false;

    private void EventManagerOnTimerUpdate(float value) => timeToDisplay += value;
  
   
    private void Update()
    {
        Debug.Log("Hey dude" + _isRunning);
        if (!_isRunning) return;
        if (_timerType == TimerType.Countdown && timeToDisplay < 0.0f)
        {
            EventManager.OnTimerStop();
            return;
        }
        timeToDisplay += _timerType == TimerType.Countdown ? -Time.deltaTime : Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        _timerText.text = timeSpan.ToString (format: @"mm\:ss\:ff");
    }
}
