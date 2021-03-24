using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager backGroundManger;

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    public bool isImage1 = false;
    public bool is6thru10 = false;
    public bool is11thru15 = false;
    public bool is16thru20 = false;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!backGroundManger)
        {
            backGroundManger = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}