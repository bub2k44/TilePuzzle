using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButon : MonoBehaviour
{
    public void Restart()
    {
        GameObject.FindObjectOfType<LevelLoaderManager>().LoadNextMainMenu();
    }
}
