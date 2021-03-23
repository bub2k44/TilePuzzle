using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager cm;

    public CanvasGroup[] imagesLevel1;
    public CanvasGroup[] imagesLevel2;
    public CanvasGroup[] imagesLevel3;
    public CanvasGroup[] imagesLevel4;
    public CanvasGroup[] imagesLevel5;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!cm)
        {
            cm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
