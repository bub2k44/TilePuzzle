using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.0f;

    public void LoadNextLevel() => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    //public void LoadLevel2()
    //{
    //    StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    //}

    public void ReloadLevel() => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));

    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        PermanentUI.perm.timer.SetActive(true);
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
    }
}
