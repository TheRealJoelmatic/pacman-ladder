using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAnimation : MonoBehaviour
{
    private bool TimerOn = true;
    private bool Turn;

    public float Timer;
    private float targetTime;

    private void Start()
    {
        targetTime = Timer;
    }
    private void Update()
    {

        if (TimerOn == true)
        {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                if (Turn == true)
                {
                    this.GetComponent<Image>().enabled = false;
                    targetTime = Timer;
                    Turn = false;
                }
                else
                {
                    this.GetComponent<Image>().enabled = true;
                    targetTime = Timer;
                    Turn = true;
                }
            }
        }
        else
        {
            targetTime = Timer;
        }
    }
}
