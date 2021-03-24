using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManagger : MonoBehaviour
{
    public static TimerManagger myTM;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!myTM)
        {
            myTM = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Timer();
    }

    public void Timer()
    {

    }
}
