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

    public CameraShake cameraShake;

    public int score = 0;
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
        scoreTxt.text = score.ToString();
        levelTxt.text = level.ToString();
        stageTxt.text = stage.ToString();

        if (level == 1 && stage == 1 && pieceCounter == 6)
        {
            EndStage();
            imagesLevel1[0].alpha = 1f;
        }

        if (level == 1 && stage == 2 && pieceCounter == 6)
        {
            EndStage();
            imagesLevel1[1].alpha = 1f;
        }

        if (level == 1 && stage == 3 && pieceCounter == 6)
        {
            EndStage();
            imagesLevel1[2].alpha = 1f;

            for (int i = 0; i < imagesLevel1.Length; i++)
            {
                imagesLevel1[i].alpha = 0f;
            }
        }

        if (level == 2 && stage == 1 && pieceCounter == 9)
        {      
            EndStage();
            imagesLevel2[0].alpha = 1f;
        }

        if (level == 2 && stage == 2 && pieceCounter == 9)
        {
            EndStage();
            imagesLevel2[1].alpha = 1f;
        }

        if (level == 2 && stage == 3 && pieceCounter == 9)
        {
            EndStage();
            imagesLevel1[0].alpha = 1f;

            for (int i = 0; i < imagesLevel2.Length; i++)
            {
                imagesLevel2[i].alpha = 0f;
            }
        }
         
        /*if (level == 2 && pieceCounter == 8)
        {
            EndLevel();
            images[1].alpha = 1f;
        }
        if (level == 3 && pieceCounter == 12)
        {
            EndLevel();
            images[2].alpha = 1f;
        }
        if (level == 4 && pieceCounter == 18)
        {
            EndLevel();
            images[3].alpha = 1f;
        }
        if (level == 5 && pieceCounter == 24)
        {
            EndLevel();
            images[4].alpha = 1f;
        }
        if (level == 6)
        {
            EndLevel();
            levelTxt.text = "";
        }*/
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

    private void EndLevel()
    {
        StartCoroutine(NewLevel());
        SoundManager.PlaySound("PowerUp");

        level++;
        stage = 1;
        
        pieceCounter = 0;
        cameraShake.ShakeCamera();
        PlayFireWorks();
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
        countdownTxt.currentTime = 20;

        if (stage > 3)
        {
            for (int j = 0; j < imagesLevel2.Length; j++)
            {
                imagesLevel2[j].alpha = 0.2f;
            }

            level++;
            stage = 1;
        }
    }
}
