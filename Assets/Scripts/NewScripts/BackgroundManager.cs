using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager instance;

    [SerializeField]
    private GameObject image1;
    [SerializeField]
    private GameObject image2;
    [SerializeField]
    private GameObject image3;
    [SerializeField]
    private GameObject image4;

    public GameObject Image1 { get => image1; set => image1 = value; }
    public GameObject Image2 { get => image2; set => image2 = value; }
    public GameObject Image3 { get => image3; set => image3 = value; }
    public GameObject Image4 { get => image4; set => image4 = value; }

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

    public void SetBackground(bool _image1, bool _image2, bool _image3, bool _image4)
    {
        Image1.SetActive(_image1);
        Image2.SetActive(_image2);
        Image3.SetActive(_image3);
        Image4.SetActive(_image4);
    }
}