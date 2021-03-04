using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject replayButton;
    public GameObject timer;
    public CountdownTxt countdownTxt;

    public void OnButtonPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PermanentUI.perm.pieceCounter = 0;
        replayButton.SetActive(false);
        timer.SetActive(true);
        countdownTxt.currentTime = countdownTxt.startTime;
        Debug.Log("Found the Game Object");
    }
}
