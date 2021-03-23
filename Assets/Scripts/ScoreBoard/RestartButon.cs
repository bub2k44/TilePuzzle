using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButon : MonoBehaviour
{
    private GameObject timer;
    private GameObject puzzleHolder;
    private GameObject holderBackground;

    private void Update()
    {
        timer = GameObject.FindGameObjectWithTag("Timer");
        puzzleHolder = GameObject.FindGameObjectWithTag("PuzzleHolder");
        holderBackground = GameObject.FindGameObjectWithTag("HolderBackground");

        //Timer();
    }

    public void ReplayButton()
    {
        //currentTime = 0;

        timer.SetActive(false);
        puzzleHolder.SetActive(false);
        holderBackground.SetActive(false);
    }

    //public void Timer()
    //{
    //    currentTime -= 1 * Time.deltaTime;

    //    countdownTxt.text = currentTime.ToString("0");

    //    if (currentTime <= 0)
    //    {
    //        currentTime = 0;

    //        timer.SetActive(false);
    //        puzzleHolder.SetActive(false);
    //        holderBackground.SetActive(false);
    //        replayBtn.SetActive(true);
    //    }
    //    else
    //    {
    //        replayBtn.SetActive(false);
    //    }
    //}
}
