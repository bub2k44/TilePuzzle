using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager instance;

    [SerializeField]
    private CanvasGroup[] imagesLevel1;
    [SerializeField]
    private CanvasGroup[] imagesLevel2;
    [SerializeField]
    private CanvasGroup[] imagesLevel3;
    [SerializeField]
    private CanvasGroup[] imagesLevel4;
    [SerializeField]
    private CanvasGroup[] imagesLevel5;

    public CanvasGroup[] ImagesLevel1 { get => imagesLevel1; set => imagesLevel1 = value; }
    public CanvasGroup[] ImagesLevel2 { get => imagesLevel2; set => imagesLevel2 = value; }
    public CanvasGroup[] ImagesLevel3 { get => imagesLevel3; set => imagesLevel3 = value; }
    public CanvasGroup[] ImagesLevel4 { get => imagesLevel4; set => imagesLevel4 = value; }
    public CanvasGroup[] ImagesLevel5 { get => imagesLevel5; set => imagesLevel5 = value; }

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

    public void FullImage(CanvasGroup[] _current)
    {
        for (int j = 0; j < _current.Length; j++)
        {
            _current[j].alpha = 1.0f;
        }
    }

    public void TransparentImage(CanvasGroup[] _current)
    {
        for (int j = 0; j < _current.Length; j++)
        {
            _current[j].alpha = 0.2f;
        }
    }

    public void HideImage(CanvasGroup[] _current)
    {
        for (int j = 0; j < _current.Length; j++)
        {
            _current[j].alpha = 0.0f;
        }
    }

    public void HideAllImages()
    {
        HideImage(ImagesLevel1);
        HideImage(ImagesLevel2);
        HideImage(ImagesLevel3);
        HideImage(ImagesLevel4);
        HideImage(ImagesLevel5);
    }
}
