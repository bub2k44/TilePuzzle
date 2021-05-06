using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;

    [SerializeField]
    private float startTimeLvl1 = 20.5f;
    [SerializeField]
    private float startTimeLvl2 = 30.5f;
    [SerializeField]
    private float startTimeLvl3 = 40.5f;
    [SerializeField]
    private float startTimeLvl4 = 50.5f;
    [SerializeField]
    private float startTimeLvl5 = 60.5f;

    private float currentTime;

    public float StartTimeLvl1 { get => startTimeLvl1; set => startTimeLvl1 = value; }
    public float StartTimeLvl2 { get => startTimeLvl2; set => startTimeLvl2 = value; }
    public float StartTimeLvl3 { get => startTimeLvl3; set => startTimeLvl3 = value; }
    public float StartTimeLvl4 { get => startTimeLvl4; set => startTimeLvl4 = value; }
    public float StartTimeLvl5 { get => startTimeLvl5; set => startTimeLvl5 = value; }
    public float CurrentTime { get => currentTime; set => currentTime = value; }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Timer();
    }

    public void Timer()
    {
        CurrentTime -= 1 * Time.deltaTime;
        UIManager.instance.CountdownTxt.text = CurrentTime.ToString("0");

        if (CurrentTime <= 0)
        {
            CurrentTime = 0;

            UIManager.instance.DeactivatePuzzle();
            LevelLoaderManager.instance.LoadNextEndLevel();
        }
    }

    public void SelectStartTime()
    {
        switch (UIManager.instance.Level1)
        {
            case 1:
                CurrentTime = StartTimeLvl1;
                break;
            case 2:
                CurrentTime = StartTimeLvl2;
                break;
            case 3:
                CurrentTime = StartTimeLvl3;
                break;
            case 4:
                CurrentTime = StartTimeLvl4;
                break;
            case 5:
                CurrentTime = StartTimeLvl5;
                break;
        }
    }
}
