using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private TextMeshProUGUI scoreTxt;
    [SerializeField]
    private TextMeshProUGUI levelTxt;
    [SerializeField]
    private TextMeshProUGUI stageTxt;
    [SerializeField]
    private TextMeshProUGUI countdownTxt;

    [SerializeField]
    private float score = 0;
    [SerializeField]
    private float displayScore = 0;
    [SerializeField]
    private float scoreUpdateTime = 0.02f;

    [SerializeField]
    private int scoreRounded = 0;
    [SerializeField]
    private int level1 = 1;
    [SerializeField]
    private int stage = 1;
    [SerializeField]
    private int pieceCounter = 0;
    [SerializeField]
    private int imageCount = 0;

    [SerializeField]
    private CameraShake cameraShake;

    [SerializeField]
    private GameObject timerManager;
    [SerializeField]
    private GameObject puzzleHolder;
    [SerializeField]
    private GameObject holderBackground;
    [SerializeField]
    private GameObject finalScoreManager;

    public TextMeshProUGUI ScoreTxt { get => scoreTxt; set => scoreTxt = value; }
    public TextMeshProUGUI LevelTxt { get => levelTxt; set => levelTxt = value; }
    public TextMeshProUGUI StageTxt { get => stageTxt; set => stageTxt = value; }
    public TextMeshProUGUI CountdownTxt { get => countdownTxt; set => countdownTxt = value; }

    public float Score { get => score; set => score = value; }
    public float DisplayScore { get => displayScore; set => displayScore = value; }
    public float ScoreUpdateTime { get => scoreUpdateTime; set => scoreUpdateTime = value; }

    public int ScoreRounded { get => scoreRounded; set => scoreRounded = value; }
    public int Level1 { get => level1; set => level1 = value; }
    public int Stage { get => stage; set => stage = value; }
    public int PieceCounter { get => pieceCounter; set => pieceCounter = value; }
    public int ImageCount { get => imageCount; set => imageCount = value; }

    public CameraShake CameraShake { get => cameraShake; set => cameraShake = value; }

    public GameObject TimerManager { get => timerManager; set => timerManager = value; }
    public GameObject PuzzleHolder { get => puzzleHolder; set => puzzleHolder = value; }
    public GameObject HolderBackground { get => holderBackground; set => holderBackground = value; }
    public GameObject FinalScoreManager { get => finalScoreManager; set => finalScoreManager = value; }

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
    }

    private void Update() => SetLevelUI();

    public void SetLevelUI()
    {
        PuzzleHolder = GameObject.FindGameObjectWithTag("PuzzleHolder");
        HolderBackground = GameObject.FindGameObjectWithTag("HolderBackground");
        LevelTxt.text = Level1.ToString();
        StageTxt.text = Stage.ToString();
        LevelUI(1, 6, CollectableManager.instance.ImagesLevel1);
        LevelUI(2, 9, CollectableManager.instance.ImagesLevel2);
        LevelUI(3, 12, CollectableManager.instance.ImagesLevel3);
        LevelUI(4, 15, CollectableManager.instance.ImagesLevel4);
        LevelUI(5, 18, CollectableManager.instance.ImagesLevel5);
    }

    private void LevelUI(int _level, int _pieceCounter, CanvasGroup[] _imageLevel)
    {
        if (Level1 == _level && Stage == 1 && PieceCounter == _pieceCounter)
        {
            EndStage();
            _imageLevel[0].alpha = 1f;
        }

        else if (Level1 == _level && Stage == 2 && PieceCounter == _pieceCounter)
        {
            EndStage();
            _imageLevel[1].alpha = 1f;
        }

        else if (Level1 == _level && Stage == 3 && PieceCounter == _pieceCounter)
        {
            EndStage();
            _imageLevel[2].alpha = 1f;
        }
    }

    public void EndStage()
    {
        PieceCounter = 0;
        CameraShake.ShakeCamera();
        FireWorksManager.fireWorksManager.PlayFireWorks();
        Score = Score + (5 * global::TimerManager.instance.CurrentTime); 
        SoundManager.PlaySound("PowerUp");
        StartCoroutine(ScoreUpdated());

        if (Level1 == 5 && Stage == 3)
        {
            LevelLoaderManager.instance.LoadNextEndLevel();
        }
        else
        {
            StartCoroutine(NewLevel());            
        } 
    }

    private IEnumerator ScoreUpdated()
    {
        while (true)
        {
            if (DisplayScore < Score)
            {
                DisplayScore++;

                ScoreRounded = (int)Math.Floor(DisplayScore);
                ScoreTxt.text = ScoreRounded.ToString("0");
            }

            yield return new WaitForSeconds(ScoreUpdateTime);
        }
    }

    private IEnumerator NewLevel()
    {
        if (Level1 > 5)
        {
            BackgroundManager.instance.SetBackground(false, false, false, true);
            DeactivatePuzzle();
            CollectableManager.instance.HideAllImages();
            LevelLoaderManager.instance.LoadNextEndLevel();
        }
        else
        {
            LevelLoaderManager.instance.LoadNextLevel();
            yield return new WaitForSeconds(1);
            Stage++;
            ReactivatePuzzle();
            Level(1, 3, CollectableManager.instance.ImagesLevel1, CollectableManager.instance.ImagesLevel2);
            Level(2, 3, CollectableManager.instance.ImagesLevel2, CollectableManager.instance.ImagesLevel3);
            Level(3, 3, CollectableManager.instance.ImagesLevel3, CollectableManager.instance.ImagesLevel4);
            Level(4, 3, CollectableManager.instance.ImagesLevel4, CollectableManager.instance.ImagesLevel5);
            Level(5, 3, CollectableManager.instance.ImagesLevel5, null);
        }
    }

    private void Level(int _level, int _stage, CanvasGroup[] _current, CanvasGroup[] _next)
    {
        if (Level1 == _level && Stage > _stage)
        {
            CollectableManager.instance.HideImage(_current);
            CollectableManager.instance.TransparentImage(_next);
            Level1++;
            Stage = 1;
            global::TimerManager.instance.SelectStartTime();
        }
    }

    public void RestGamePlay()
    {
        PieceCounter = 0;
        Level1 = 1;
        Stage = 1;
        DisplayScore = 0;
        ScoreTxt.text = DisplayScore.ToString("0");
    }

    public void DeactivatePuzzle()
    {
        if (PuzzleHolder != null)
        {
            PuzzleHolder.SetActive(false);
        }
        if (HolderBackground != null)
        {
            HolderBackground.SetActive(false);
        }
            
        TimerManager.SetActive(false);
    }

    public void ReactivatePuzzle()
    {
        PuzzleHolder.SetActive(true);
        HolderBackground.SetActive(true);
        TimerManager.SetActive(true);
    }
}