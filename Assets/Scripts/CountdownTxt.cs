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
    private TextMeshProUGUI countdownTxt = default;
    private float currentTime = 0;
    [SerializeField]
    private float startTime = 90;
    [SerializeField]
    private GameObject replayBtn = default;

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownTxt.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
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
