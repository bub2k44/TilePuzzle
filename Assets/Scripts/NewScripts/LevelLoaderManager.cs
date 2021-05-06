using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderManager : MonoBehaviour
{
    public static LevelLoaderManager instance;

    [SerializeField]
    private Animator transition;
    [SerializeField]
    private float transitionTime = 1.0f;

    public Animator Transition { get => transition; set => transition = value; }
    public float TransitionTime { get => transitionTime; set => transitionTime = value; }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        UIManager.instance.TimerManager.SetActive(false);
        UIManager.instance.FinalScoreManager.SetActive(false);
    }

    public void LoadNextLevel() => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    public void LoadNextEndLevel() => StartCoroutine(LoadFinalScreen());
    public void LoadNextMainMenu() => StartCoroutine(LoadStartMenu());

    private IEnumerator LoadStartMenu()
    {
        UIManager.instance.FinalScoreManager.SetActive(false);
        Transition.SetTrigger("start");
        SceneManager.LoadScene("2 MainMenu");
        yield return new WaitForSeconds(TransitionTime);
        BackgroundManager.instance.SetBackground(false, true, false, false);
        UIManager.instance.Score = 0;
        UIManager.instance.RestGamePlay();
        CollectableManager.instance.TransparentImage(CollectableManager.instance.ImagesLevel1);
    }

    private IEnumerator LoadFinalScreen()
    {
        Transition.SetTrigger("start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene("18 EndScene");
        UIManager.instance.FinalScoreManager.SetActive(true);
        BackgroundManager.instance.SetBackground(false, false, false, true);
        UIManager.instance.RestGamePlay();
        UIManager.instance.DeactivatePuzzle();
        CollectableManager.instance.HideAllImages();
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        Transition.SetTrigger("start");
        yield return new WaitForSeconds(TransitionTime);
        TimerManager.instance.SelectStartTime();
        BackgroundManager.instance.SetBackground(false, false, true, false);
        UIManager.instance.TimerManager.SetActive(true);
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
    }
}