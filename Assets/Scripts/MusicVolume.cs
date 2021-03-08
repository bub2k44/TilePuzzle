using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider Volume;

    public AudioSource myMusic;

    void Update() => myMusic.volume = Volume.value;
}