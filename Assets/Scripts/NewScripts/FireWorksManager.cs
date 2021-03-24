using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksManager : MonoBehaviour
{
    public static FireWorksManager fireWorksManager;

    public ParticleSystem[] fireWorks;

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
        for (int i = 0; i < fireWorks.Length; i++)
        {
            fireWorks[i].Play();
        }
    }
}