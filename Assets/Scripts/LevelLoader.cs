using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private GameMaster _gm;

    private void Start() => _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

    public void LoadNextLevel() => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    public void LoadLevel2()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        _gm.LastCheckPointPos = new Vector2(0, 1.5f);
    }

    public void ReloadLevel() => StartCoroutine(RestartLevel(SceneManager.GetActiveScene().buildIndex));

    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
    }

    private IEnumerator RestartLevel(int levelIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
