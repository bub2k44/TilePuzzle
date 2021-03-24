using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager uim;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI levelTxt;
    public TextMeshProUGUI stageTxt;
    public TextMeshProUGUI countDownTxt;

    public float score = 0;
    public float displayScore = 0;

    public int level = 1;
    public int stage = 1;

    public int pieceCounter = 0;
    public int imageCount = 0;

    public bool canTime = false;

    public GameObject timer;
    public GameObject gameLogo;
    public GameObject timerUi;
    public GameObject dashBoard;
    public GameObject puzzleHolder;
    public GameObject holderBackground;
    public GameObject startMenuButtons;

    public CameraShake cameraShake;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!uim)
        {
            uim = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update() => SetLevelUI();

    public void SetLevelUI()
    {
        levelTxt.text = level.ToString();
        stageTxt.text = stage.ToString();

        LevelUI(1, 6, CollectableManager.colectableManager.imagesLevel1);
        LevelUI(2, 9, CollectableManager.colectableManager.imagesLevel2);
        LevelUI(3, 12, CollectableManager.colectableManager.imagesLevel3);
        LevelUI(4, 15, CollectableManager.colectableManager.imagesLevel4);
        LevelUI(5, 18, CollectableManager.colectableManager.imagesLevel5);
    }

    private void LevelUI(int _level, int _pieceCounter, CanvasGroup[] _imageLevel)
    {
        if (level == _level && stage == 1 && pieceCounter == _pieceCounter)
        {
            EndStage();
            _imageLevel[0].alpha = 1f;
        }

        if (level == _level && stage == 2 && pieceCounter == _pieceCounter)
        {
            EndStage();
            _imageLevel[1].alpha = 1f;
        }

        if (level == _level && stage == 3 && pieceCounter == _pieceCounter)
        {
            EndStage();
            _imageLevel[2].alpha = 1f;
        }
    }

    public void EndStage()
    {
        StartCoroutine(NewLevel());

        SoundManager.PlaySound("PowerUp");

        pieceCounter = 0;
        cameraShake.ShakeCamera();
        FireWorksManager.fireWorksManager.PlayFireWorks();

        score = score + (5 * TimerManager.cdt.currentTime);
        StartCoroutine(ScoreUpdated());

        timer.SetActive(false);
    }

    private IEnumerator ScoreUpdated()
    {
        while (true)
        {
            if (displayScore < score)
            {
                displayScore++;

                scoreTxt.text = displayScore.ToString("0");
            }

            yield return new WaitForSeconds(0.02f);// make var
        }
    }

    private IEnumerator NewLevel()
    {
        yield return new WaitForSeconds(2);

        if (level > 1)
        {
            timer.SetActive(false);
            gameLogo.SetActive(false);
            timerUi.SetActive(false);
            dashBoard.SetActive(false);

            UnLevel(1, 3, CollectableManager.colectableManager.imagesLevel1, null);
            UnLevel(2, 3, CollectableManager.colectableManager.imagesLevel2, null);
            UnLevel(3, 3, CollectableManager.colectableManager.imagesLevel3, null);
            UnLevel(4, 3, CollectableManager.colectableManager.imagesLevel4, null);
            UnLevel(5, 3, CollectableManager.colectableManager.imagesLevel5, null);

            LevelLoaderManager.llm.LoadFinalScreen();
        }
        else
        {
            LevelLoaderManager.llm.LoadNextLevel();

            yield return new WaitForSeconds(1);

            stage++;
            timer.SetActive(true);

            gameLogo.SetActive(true);
            timerUi.SetActive(true);
            dashBoard.SetActive(true);

            Level(1, 3, CollectableManager.colectableManager.imagesLevel1, CollectableManager.colectableManager.imagesLevel2);
            Level(2, 3, CollectableManager.colectableManager.imagesLevel2, CollectableManager.colectableManager.imagesLevel3);
            Level(3, 3, CollectableManager.colectableManager.imagesLevel3, CollectableManager.colectableManager.imagesLevel4);
            Level(4, 3, CollectableManager.colectableManager.imagesLevel4, CollectableManager.colectableManager.imagesLevel5);
            Level(5, 3, CollectableManager.colectableManager.imagesLevel5, null);
        }
    }

    private void UnLevel(int _level, int _stage, CanvasGroup[] _current, CanvasGroup[] _next)
    {
        for (int j = 0; j < _current.Length; j++)
        {
            _current[j].alpha = 0.0f;
        }

        PermanentUI.perm.timer.SetActive(false);
    }

    private void Level(int _level, int _stage, CanvasGroup[] _current, CanvasGroup[] _next)
    {
        if (level == _level && stage > _stage)
        {

            for (int j = 0; j < _current.Length; j++)
            {
                _current[j].alpha = 0.0f;
            }

            for (int j = 0; j < _next.Length; j++)
            {
                _next[j].alpha = 0.2f;
            }

            level++;
            stage = 1;

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

            if (PermanentUI.perm.level > 5)
            {

            }
        }
    }
}