using UnityEngine;

public class RestartButon : MonoBehaviour
{
    public void Restart()
    {
        FindObjectOfType<LevelLoaderManager>().LoadNextMainMenu();
    }
}
