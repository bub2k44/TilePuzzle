using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager um;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI levelTxt;
    public TextMeshProUGUI stageTxt;

    public float score = 0;
    public float displayScore = 0;
    public int level = 1;
    public int stage = 1;

    public int pieceCounter = 0;
    public int imageCount = 0;

    public bool canTime = false;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!um)
        {
            um = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}