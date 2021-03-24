using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderManager : MonoBehaviour
{
    public static LevelLoaderManager llm;

    public Animator transition;

    public float transitionTime = 1.0f;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!llm)
        {
            llm = this;
        }
        else
        {
            Destroy(gameObject);
        }

        BackgroundManager.backGroundManger.image1.SetActive(true);
        BackgroundManager.backGroundManger.isImage1 = true;
    }

    public void LoadNextLevel() => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    //public void LoadNextLevel()
    //{
        
    //}

    //public void ReloadLevel() => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));

    public void LoadStartMenu()
    {
        transition.SetTrigger("start");

        SceneManager.LoadScene("2 MainMenu");

        BackgroundManager.backGroundManger.image1.SetActive(true);
        BackgroundManager.backGroundManger.image2.SetActive(false);
        BackgroundManager.backGroundManger.image3.SetActive(false);

        UIManager.uim.gameLogo.SetActive(true);
        UIManager.uim.dashBoard.SetActive(true);
        UIManager.uim.timerUi.SetActive(true);
        UIManager.uim.startMenuButtons.SetActive(true);

        UIManager.uim.pieceCounter = 0;
        UIManager.uim.level = 0;
        UIManager.uim.score = 0;
        UIManager.uim.displayScore = 0;
        UIManager.uim.scoreTxt.text = UIManager.uim.displayScore.ToString("0");

        Level(CollectableManager.colectableManager.imagesLevel1);
    }

    public void LoadFinalScreen()
    {
        transition.SetTrigger("start");

        SceneManager.LoadScene("EndScene");

        BackgroundManager.backGroundManger.image1.SetActive(false);
        BackgroundManager.backGroundManger.image2.SetActive(false);
        BackgroundManager.backGroundManger.image3.SetActive(true);

        UIManager.uim.gameLogo.SetActive(true);
        UIManager.uim.dashBoard.SetActive(true);
        UIManager.uim.timerUi.SetActive(true);
        UIManager.uim.startMenuButtons.SetActive(true);

        UIManager.uim.pieceCounter = 0;
        UIManager.uim.level = 0;
        UIManager.uim.score = 0;
        UIManager.uim.displayScore = 0;
        UIManager.uim.scoreTxt.text = UIManager.uim.displayScore.ToString("0");

        Level(CollectableManager.colectableManager.imagesLevel1);
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");

        if (PermanentUI.perm.level == 1)
        {
            TimerManager.cdt.currentTime = TimerManager.cdt.startTimeLvl1;
        }
        if (PermanentUI.perm.level == 2)
        {
            TimerManager.cdt.currentTime = TimerManager.cdt.startTimeLvl2;
        }
        if (PermanentUI.perm.level == 3)
        {
            TimerManager.cdt.currentTime = TimerManager.cdt.startTimeLvl3;
        }
        if (PermanentUI.perm.level == 4)
        {
            TimerManager.cdt.currentTime = TimerManager.cdt.startTimeLvl4;
        }
        if (PermanentUI.perm.level == 5)
        {
            TimerManager.cdt.currentTime = TimerManager.cdt.startTimeLvl5;
        }

        yield return new WaitForSeconds(transitionTime);

        PermanentUI.perm.timer.SetActive(true);
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
    }

    private void Level(CanvasGroup[] _current)
    {
        for (int j = 0; j < _current.Length; j++)
        {
            _current[j].alpha = 0.2f;
        }
    }
}