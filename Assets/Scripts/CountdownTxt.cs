using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTxt : MonoBehaviour
{
    [SerializeField]
    private GameObject puzzleHolder;
    [SerializeField]
    private GameObject puzzlePieces;
    [SerializeField]
    private TextMeshProUGUI countdownTxt;
    private float currentTime = 0;
    [SerializeField]
    private float startTime = 90;
    [SerializeField]
    private GameObject replayBtn;

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownTxt.text = "Timer: " + currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            puzzleHolder.SetActive(false);
            puzzlePieces.SetActive(false);
            replayBtn.SetActive(true);
        }
    }
}
