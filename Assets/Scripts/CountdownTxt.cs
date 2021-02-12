using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTxt : MonoBehaviour
{
    [SerializeField]
    private GameObject puzzleHolder = default;

    [SerializeField]
    private GameObject holderBackground = default;

    [SerializeField]
    private GameObject timer = default;

    [SerializeField]
    private TextMeshProUGUI countdownTxt = default;

    [SerializeField]
    public float startTime = 90;

    [SerializeField]
    private GameObject replayBtn = default;

    public float currentTime = 0;

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        timer = GameObject.FindGameObjectWithTag("Timer");
        puzzleHolder = GameObject.FindGameObjectWithTag("PuzzleHolder");
        holderBackground = GameObject.FindGameObjectWithTag("HolderBackground");

        Timer();
    }

    public void Timer()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownTxt.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;

            timer.SetActive(false);
            puzzleHolder.SetActive(false);
            holderBackground.SetActive(false);
            replayBtn.SetActive(true);
        }
        else
        {
            replayBtn.SetActive(false);
        }
    }
}
