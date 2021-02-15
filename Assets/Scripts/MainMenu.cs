using System.Collections;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public LevelLoader ll;
    public GameObject PlayerUI;
    public CanvasGroup StartText;

    public void PlayGame()
    {
        StartText.alpha = 0;
        StartText.interactable = false;
        ll.LoadNextLevel();
        StartCoroutine(StartGame());
        //PlayerUI.SetActive(true);
    }
    public void QuitGame() => Application.Quit();

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);
        PlayerUI.SetActive(true);
    }
    
}

