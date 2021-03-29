using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreManager : MonoBehaviour
{
    public static FinalScoreManager instance;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    public TextMeshProUGUI ScoreText { get => scoreText; set => scoreText = value; }

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

    private void Update()
    {
        ScoreText.text = UIManager.instance.Score.ToString("0");
    }
}