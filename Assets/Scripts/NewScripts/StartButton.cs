using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerDownHandler
{
    public Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void UseButton()
    {
        Screen.fullScreen = !Screen.fullScreen;
        SceneManager.LoadScene("1 StartGame");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ((IPointerDownHandler)button).OnPointerDown(eventData);
    }
}