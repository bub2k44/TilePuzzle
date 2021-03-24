using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountDownManager : MonoBehaviour
{
    public static CountDownManager cdm;

    public float startTimeLvl1;
    public float startTimeLvl2;
    public float startTimeLvl3;
    public float startTimeLvl4;
    public float startTimeLvl5;

    public float currentTime;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!cdm)
        {
            cdm = this;
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
        currentTime -= 1 * Time.deltaTime;

        UIManager.uim.countDownTxt.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;

            LevelLoaderManager.llm.LoadFinalScreen();
        }
    }
}
