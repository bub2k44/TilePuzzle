using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1.0f;

    public void LoadNextLevel() => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    public void ReloadLevel() => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));

    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");

        if (PermanentUI.perm.level == 1)
        {
            CountdownTxt.cdt.currentTime = CountdownTxt.cdt.startTimeLvl1;
        }
        if (PermanentUI.perm.level == 2)
        {
            CountdownTxt.cdt.currentTime = CountdownTxt.cdt.startTimeLvl2;
        }
        if (PermanentUI.perm.level == 3)
        {
            CountdownTxt.cdt.currentTime = CountdownTxt.cdt.startTimeLvl3;
        }
        if (PermanentUI.perm.level == 4)
        {
            CountdownTxt.cdt.currentTime = CountdownTxt.cdt.startTimeLvl4;
        }
        if (PermanentUI.perm.level == 5)
        {
            CountdownTxt.cdt.currentTime = CountdownTxt.cdt.startTimeLvl5;
        }

        yield return new WaitForSeconds(transitionTime);

        PermanentUI.perm.timer.SetActive(true);
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
    }
}