using UnityEngine;
using TMPro;

public class CountdownTxt : MonoBehaviour
{
    public static CountdownTxt cdt;

    [SerializeField]
    private GameObject puzzleHolder = default;

    [SerializeField]
    private GameObject holderBackground = default;

    [SerializeField]
    private GameObject timer = default;

    [SerializeField]
    private TextMeshProUGUI countdownTxt = default;

    public float startTimeLvl1 = 20f;
    public float startTimeLvl2 = 40f;
    public float startTimeLvl3 = 60f;
    public float startTimeLvl4 = 80f;
    public float startTimeLvl5 = 100f;

    [SerializeField]
    private GameObject replayBtn = default;

    public float currentTime;

    private void Awake()
    {
        //PermanentUI.perm.level = 1;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!cdt)
        {
            cdt = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //currentTime = startTimeLvl1;

        //if (PermanentUI.perm.level == 1)
        //{
        //    currentTime = startTimeLvl1;
        //}
        //if (PermanentUI.perm.level == 2)
        //{
        //    currentTime = startTimeLvl2;
        //}
        //if (PermanentUI.perm.level == 3)
        //{
        //    currentTime = startTimeLvl3;
        //}
        //if (PermanentUI.perm.level == 4)
        //{
        //    currentTime = startTimeLvl4;
        //}
        //if (PermanentUI.perm.level == 5)
        //{
        //    currentTime = startTimeLvl5;
        //}
    }

    private void OnEnable()
    {
        //if (PermanentUI.perm.level == 1)
        //{
        //    currentTime = startTimeLvl1;
        //}
        //if (PermanentUI.perm.level == 2)
        //{
        //    currentTime = startTimeLvl2;
        //}
        //if (PermanentUI.perm.level == 3)
        //{
        //    currentTime = startTimeLvl3;
        //}
        //if (PermanentUI.perm.level == 4)
        //{
        //    currentTime = startTimeLvl4;
        //}
        //if (PermanentUI.perm.level == 5)
        //{
        //    currentTime = startTimeLvl5;
        //}
    }

    private void Update()
    {
        timer = GameObject.FindGameObjectWithTag("Timer");
        puzzleHolder = GameObject.FindGameObjectWithTag("PuzzleHolder");
        holderBackground = GameObject.FindGameObjectWithTag("HolderBackground");

        //if (PermanentUI.perm.level == 1)
        //{
        //    currentTime = startTimeLvl1;
        //}
        //if (PermanentUI.perm.level == 2)
        //{
        //    currentTime = startTimeLvl2;
        //}
        //if (PermanentUI.perm.level == 3)
        //{
        //    currentTime = startTimeLvl3;
        //}
        //if (PermanentUI.perm.level == 4)
        //{
        //    currentTime = startTimeLvl4;
        //}
        //if (PermanentUI.perm.level == 5)
        //{
        //    currentTime = startTimeLvl5;
        //}

        Timer();
    }

    public void Timer()
    {
        currentTime -= 1 * Time.deltaTime;

        countdownTxt.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;

            timer.SetActive(false);
            puzzleHolder.SetActive(false);
            holderBackground.SetActive(false);
            replayBtn.SetActive(true);

            //if (PermanentUI.perm.level == 1)
            //{
            //    currentTime = startTimeLvl1;
            //}
            //if (PermanentUI.perm.level == 2)
            //{
            //    currentTime = startTimeLvl2;
            //}
            //if (PermanentUI.perm.level == 3)
            //{
            //    currentTime = startTimeLvl3;
            //}
            //if (PermanentUI.perm.level == 4)
            //{
            //    currentTime = startTimeLvl4;
            //}
            //if (PermanentUI.perm.level == 5)
            //{
            //    currentTime = startTimeLvl5;
            //}
        }
        else
        {          
            replayBtn.SetActive(false);
        }
    }
}