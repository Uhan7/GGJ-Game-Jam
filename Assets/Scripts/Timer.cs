using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Image timerFill;
    public float time;

    void Update()
    {
        timerFill.fillAmount -= Time.deltaTime/time;
    }
}
