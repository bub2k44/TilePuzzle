using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public LevelLoader ll;

    public void PlayGame () => ll.LoadNextLevel();

    public void QuitGame() => Application.Quit();
}

