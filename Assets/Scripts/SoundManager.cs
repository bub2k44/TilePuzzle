using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sm;

    static AudioSource audioSource;

    #region Static Audio Clips
    public static AudioClip powerUp;
    public static AudioClip teleport;
    #endregion

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!sm)
        {
            sm = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();

        powerUp = Resources.Load<AudioClip>("PowerUp");
        teleport = Resources.Load<AudioClip>("Teleport");
    }

    public static void PlaySound(string _clip)
    {
        switch (_clip)
        {
            case "PowerUp":
                audioSource.PlayOneShot(powerUp);
                break;

            case "Teleport":
                audioSource.PlayOneShot(teleport);
                break;

            default:
                break;
        }
    }
}