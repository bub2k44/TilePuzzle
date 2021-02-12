using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject replayButton;
    public GameObject timer;

    public CountdownTxt countdownTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //replayButton = GameObject.FindGameObjectWithTag("ReplayButton");
    }
    public void OnButtonPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        replayButton.SetActive(false);
        timer.SetActive(true);
        countdownTxt.currentTime = countdownTxt.startTime;
    }
}
