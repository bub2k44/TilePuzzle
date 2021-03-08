using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static AudioSource audioSource;

    #region Static Audio Clips
    public static AudioClip coinPickUp;
    public static AudioClip powerUp;
    public static AudioClip knockBack;
    public static AudioClip looseLife;
    public static AudioClip jump;
    public static AudioClip land;
    public static AudioClip sprint;
    public static AudioClip climb;
    public static AudioClip teleport;
    public static AudioClip squashed;
    public static AudioClip death;
    #endregion

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        coinPickUp = Resources.Load<AudioClip>("CoinPickUp");
        powerUp = Resources.Load<AudioClip>("PowerUp");//
        knockBack = Resources.Load<AudioClip>("KnockBack");
        looseLife = Resources.Load<AudioClip>("LooseLife");
        jump = Resources.Load<AudioClip>("Jump");
        land = Resources.Load<AudioClip>("Land");
        sprint = Resources.Load<AudioClip>("Sprint");
        climb = Resources.Load<AudioClip>("Climb");
        teleport = Resources.Load<AudioClip>("Teleport");//
        squashed = Resources.Load<AudioClip>("Squashed");
        death = Resources.Load<AudioClip>("Death");
    }

    public static void PlaySound(string _clip)
    {
        switch (_clip)
        {
            case "CoinPickUp":
                audioSource.PlayOneShot(coinPickUp);
                break;

            case "PowerUp":
                audioSource.PlayOneShot(powerUp);
                break;

            case "KnockBack":
                audioSource.PlayOneShot(knockBack);
                break;

            case "LooseLife":
                audioSource.PlayOneShot(looseLife);
                break;

            case "Jump":
                audioSource.PlayOneShot(jump);
                break;

            case "Land":
                audioSource.PlayOneShot(land);
                break;

            case "Sprint":
                audioSource.PlayOneShot(sprint);
                break;

            case "Climb":
                audioSource.PlayOneShot(climb);
                break;

            case "Teleport":
                audioSource.PlayOneShot(teleport);
                break;

            case "Squashed":
                audioSource.PlayOneShot(squashed);
                break;

            case "Death":
                audioSource.PlayOneShot(death);
                break;

            default:
                break;
        }
    }
}