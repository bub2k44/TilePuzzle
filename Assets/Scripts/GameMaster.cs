using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster _instance;

    private Vector2 _lastCheckPointPos;
    private Vector2 _lastDarknessPos;

    public Vector2 LastCheckPointPos { get => _lastCheckPointPos; set => _lastCheckPointPos = value; }

    public Vector2 LastDarknessPos { get => _lastDarknessPos; set => _lastDarknessPos = value; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
