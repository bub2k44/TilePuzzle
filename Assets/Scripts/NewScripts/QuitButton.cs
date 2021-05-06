using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonPress);
    }

    public void ButtonPress()
    {
        Application.ExternalEval("window.location=\"http://www.flywithbutchohare.com\"");//.editorconfig
        Application.Quit();
    }
}