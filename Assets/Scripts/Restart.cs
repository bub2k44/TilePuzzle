using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject replayButton;
    public GameObject timer;

    public CountdownTxt countdownTxt;

    public void OnButtonPress()
        ///NEEDS TESTING
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        PermanentUI.perm.pieceCounter = 0;

        replayButton.SetActive(false);
        timer.SetActive(true);

        if (PermanentUI.perm.level == 1)
        {
            countdownTxt. currentTime = countdownTxt. startTimeLvl1;
        }
        if (PermanentUI.perm.level == 2)
        {
            countdownTxt. currentTime = countdownTxt.startTimeLvl2;
        }
        if (PermanentUI.perm.level == 3)
        {
            countdownTxt. currentTime = countdownTxt.startTimeLvl3;
        }
        if (PermanentUI.perm.level == 4)
        {
            countdownTxt. currentTime = countdownTxt.startTimeLvl4;
        }
        if (PermanentUI.perm.level == 5)
        {
            countdownTxt. currentTime = countdownTxt.startTimeLvl5;
        }
    }
}