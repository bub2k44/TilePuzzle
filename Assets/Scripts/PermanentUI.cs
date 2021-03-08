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

    public int score = 0;
    public int level = 1;
    public int stage = 1;

    public int pieceCounter = 0;
    public int imageCount = 0;

    public bool canTime = false;

    public GameObject timer;

    public CountdownTxt countdownTxt;

    private void Awake()
    {
        //level = 1;
    }

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
        scoreTxt.text = score.ToString();
        levelTxt.text = level.ToString();
        stageTxt.text = stage.ToString();

        LevelUI(1, 6, imagesLevel1, countdownTxt.startTimeLvl1);
        LevelUI(2, 9, imagesLevel2, countdownTxt.startTimeLvl2);
        LevelUI(3, 12, imagesLevel3, countdownTxt.startTimeLvl3);
        LevelUI(4, 15, imagesLevel4, countdownTxt.startTimeLvl4);
        LevelUI(5, 18, imagesLevel5, countdownTxt.startTimeLvl5);
    }

    private void LevelUI(int _level, int _pieceCounter, CanvasGroup[] _imageLevel, float _countdownTxt)
    {
        if (level == _level && stage == 1 && pieceCounter == _pieceCounter)
        {
            EndStage();
            _imageLevel[0].alpha = 1f;


            countdownTxt.currentTime = _countdownTxt;
        }

        if (level == _level && stage == 2 && pieceCounter == _pieceCounter)
        {
            EndStage();
            _imageLevel[1].alpha = 1f;


            countdownTxt.currentTime = _countdownTxt;
        }

        if (level == _level && stage == 3 && pieceCounter == _pieceCounter)
        {
            EndStage();
            _imageLevel[2].alpha = 1f;


            countdownTxt.currentTime = _countdownTxt;
        }
    }

    public void EndStage()
    {
        StartCoroutine(NewLevel());

        SoundManager.PlaySound("PowerUp");

        pieceCounter = 0;
        cameraShake.ShakeCamera();
        PlayFireWorks();
        timer.SetActive(false);
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

        //countdownTxt.currentTime = 100;//////////////////////

        Level(1, 3, imagesLevel1, imagesLevel2, countdownTxt.startTimeLvl1);
        Level(2, 3 ,imagesLevel2, imagesLevel3, countdownTxt.startTimeLvl2);
        Level(3, 3, imagesLevel3, imagesLevel4, countdownTxt.startTimeLvl3);
        Level(4, 3, imagesLevel4, imagesLevel5, countdownTxt.startTimeLvl4);
        Level(5, 3, imagesLevel5, null, countdownTxt.startTimeLvl5);
    }

    private void Level(int _level, int _stage, CanvasGroup[] _current, CanvasGroup[] _next, float _currentTime)
    {
        if (level == _level && stage > _stage)
        {
            //countdownTxt.currentTime = _currentTime;//////////////////////////////

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


            countdownTxt.currentTime = _currentTime;///////////////////////
        }
    }
}