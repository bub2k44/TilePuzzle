using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyVideoPlayer : MonoBehaviour
{
    [SerializeField] private int _time = 8;

    private void Update() => StartCoroutine(StartNextScene());

    public IEnumerator StartNextScene()
    {
        yield return new WaitForSeconds(_time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
