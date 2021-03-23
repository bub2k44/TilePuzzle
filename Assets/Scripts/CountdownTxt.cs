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

    public LevelLoader ll;

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
    }

    private void Update()
    {
        timer = GameObject.FindGameObjectWithTag("Timer");
        puzzleHolder = GameObject.FindGameObjectWithTag("PuzzleHolder");
        holderBackground = GameObject.FindGameObjectWithTag("HolderBackground");

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

            ll.LoadFinalScreen();
            replayBtn.SetActive(true);
        }
        else
        {          
            replayBtn.SetActive(false);
        }
    }
}