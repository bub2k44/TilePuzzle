using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksManager : MonoBehaviour
{
    public static FireWorksManager fireWorksManager;

    [SerializeField]
    private ParticleSystem[] fireWorks;

    public ParticleSystem[] FireWorks { get => fireWorks; set => fireWorks = value; }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!fireWorksManager)
        {
            fireWorksManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayFireWorks()
    {
        for (int i = 0; i < FireWorks.Length; i++)
        {
            FireWorks[i].Play();
        }
    }
}