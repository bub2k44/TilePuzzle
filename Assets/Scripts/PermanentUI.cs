using System.Collections;
using TMPro;
using UnityEngine;

public class PermanentUI : MonoBehaviour
{
    public static PermanentUI perm;

    public LevelLoader ll;

    public TextMeshProUGUI scoreTxt = default;
    public TextMeshProUGUI levelTxt = default;
    public TextMeshProUGUI stageTxt = default;

    public ParticleSystem[] fireWorks;

    public CanvasGroup[] imagesLevel1;
    public CanvasGroup[] imagesLevel2;
    public CanvasGroup[] imagesLevel3;
    public CanvasGroup[] imagesLevel4;
    public CanvasGroup[] imagesLevel5;

    public CameraShake cameraShake;

    public float score = 0;
    public float displayScore = 0;
    public int level = 1;
    public int stage = 1;

    public int pieceCounter = 0;
    public int imageCount = 0;

    public bool canTime = false;

    public GameObject timer;

    public CountdownTxt countdownTxt;

    private void Start()
    {
        canTime = true;
        DontDestroyOnLoad(gameObject);

        if (!perm)
        {
            perm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update() => SetLevelUI();

    private void SetLevelUI()
    {
        levelTxt.text = level.ToString();
        stageTxt.text = stage.ToString();

        LevelUI(1, 6, imagesLevel1);
        LevelUI(2, 9, imagesLevel2);
        LevelUI(3, 12, imagesLevel3);
        LevelUI(4, 15, imagesLevel4);
        LevelUI(5, 18, imagesLevel5);
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
        PlayFireWorks();

        score = score + (5 * CountdownTxt.cdt.currentTime);
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

            Debug.Log("ScoreCount");
        }        
    }

    private void PlayFireWorks()
    {
        for (int i = 0; i < fireWorks.Length; i++)
        {
            fireWorks[i].Play();
        }
    }

    private IEnumerator NewLevel()
    {
        yield return new WaitForSeconds(2);

        ll.LoadNextLevel();
        
        yield return new WaitForSeconds(1);

        stage++;
        timer.SetActive(true);

        Level(1, 3, imagesLevel1, imagesLevel2);
        Level(2, 3 ,imagesLevel2, imagesLevel3);
        Level(3, 3, imagesLevel3, imagesLevel4);
        Level(4, 3, imagesLevel4, imagesLevel5);
        Level(5, 3, imagesLevel5, null);
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
        }
    }
}