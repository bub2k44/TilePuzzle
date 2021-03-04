using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public LevelLoader ll;

    private void Start()
    {
        PermanentUI.perm.timer.SetActive(false);
    }


    public void PlayGame()
    {       
        ll.LoadNextLevel();
    }

    public void QuitGame() => Application.Quit();
}

