using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{

    public Image timerFill;
    public float dayTime;

    void Update()
    {
        timerFill.fillAmount -= Time.unscaledDeltaTime / dayTime;
    }
}
