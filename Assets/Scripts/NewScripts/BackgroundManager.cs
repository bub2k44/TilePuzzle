using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager bgm;

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!bgm)
        {
            bgm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}