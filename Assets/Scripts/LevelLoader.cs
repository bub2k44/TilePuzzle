using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TilePuzzles.Scoreboards;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1.0f;

    public Scoreboard scoreboard;

    public Transform keyboard;

    private void Start()
    {
        //keyboard = GameObject.FindGameObjectWithTag("Keyboard");
    }

    public void LoadNextLevel() => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    public void ReloadLevel() => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));

    public void LoadStartMenu()
    {
        //transition.SetTrigger("start");

        SceneManager.LoadScene("MainMenu");
        PermanentUI.perm.gameLogo.SetActive(true);
        PermanentUI.perm.dashBoard.SetActive(true);
        PermanentUI.perm.timerUi.SetActive(true);
        //PermanentUI.perm.timer.SetActive(true);
        PermanentUI.perm.startMenuButtons.SetActive(true);
        PermanentUI.perm.pieceCounter = 0;
        PermanentUI.perm.level = 1;
        PermanentUI.perm.score = 0;
        PermanentUI.perm.displayScore = 0;
        PermanentUI.perm.scoreTxt.text = PermanentUI.perm.displayScore.ToString("0");

        Level(PermanentUI.perm.imagesLevel1);
        //Level(PermanentUI.perm.imagesLevel2);
        //Level(PermanentUI.perm.imagesLevel3);
        //Level(PermanentUI.perm.imagesLevel4);
        //Level(PermanentUI.perm.imagesLevel5);
    }

    public void LoadFinalScreen()
    {
        transition.SetTrigger("start");

        SceneManager.LoadScene("EndScene");
        PermanentUI.perm.timer.SetActive(false);
        Debug.Log("LoadFinal");
        //ScoreboardSaveData savedScores = scoreboard.GetSavedScores();

        //for (int i = 0; i < savedScores.highscores.Count; i++)
        //{
        //    if (PermanentUI.perm.score > savedScores.highscores[i].entryScore)
        //    {
        //        Instantiate(keyboard);
        //        //keyboard.SetActive(true);
        //    }
        //}
    }

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

    private void Level(CanvasGroup[] _current)
    {
        for (int j = 0; j < _current.Length; j++)
        {
            _current[j].alpha = 0.2f;
        }
    }
}