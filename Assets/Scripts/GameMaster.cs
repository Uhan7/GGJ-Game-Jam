using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public GameObject timer;
    private Timer timerScript;

    public GameObject[] ask;
    public GameObject dos;

    private GameObject currentAsk;

    private int randomNum;

    private bool redOn;
    private bool blueOn;

    private bool greenOn;
    private bool purpleOn;
    private bool yellowOn;

    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject timeoutScreen;

    private bool servePressed;

    private void Awake()
    {
        timerScript = timer.GetComponent<Timer>();
    }

    void Start()
    {
        servePressed = false;
        StartCoroutine(Ask());
    }

    /*
     * 0  = red
     * 1  = red green
     * 2  = red purple
     * 3  = red yellow
     * 4  = red green purple
     * 5  = red green yellow
     * 6  = red purple yellow
     * 7  = blue
     * 8  = blue green
     * 9  = blue purple
     * 10 = blue yellow
     * 11 = blue green purple
     * 12 = blue green yellow
     * 13 = blue purple yellow
     */

    IEnumerator Ask()
    {
        randomNum = Random.Range(0, ask.Length);
        currentAsk = ask[randomNum];
        currentAsk.SetActive(true);
        yield return new WaitForSeconds(timerScript.time);
        if (!servePressed) EvalServe(2);
    }

    IEnumerator AfterServe()
    {
        dos.SetActive(false);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        ResetValues();
        StartCoroutine(Ask());
    }

    public void ResetValues()
    {
        foreach (var q in ask)
        {
            q.SetActive(false);
        }
        redOn = false;
        blueOn = false;
        greenOn = false;
        purpleOn = false;
        yellowOn = false;

        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        timerScript.timerFill.fillAmount = 1f;

        servePressed = false;

        dos.SetActive(true);
    }


    public void Serve()
    {

        servePressed = true;

        if (randomNum == 0)
        {
            if (redOn && !blueOn && !greenOn && !purpleOn && !yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 1)
        {
            if (redOn && !blueOn && greenOn && !purpleOn && !yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 2)
        {
            if (redOn && !blueOn && !greenOn && purpleOn && !yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 3)
        {
            if (redOn && !blueOn && !greenOn && !purpleOn && yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 4)
        {
            if (redOn && !blueOn && greenOn && purpleOn && !yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 5)
        {
            if (redOn && !blueOn && greenOn && !purpleOn && yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 6)
        {
            if (redOn && !blueOn && !greenOn && purpleOn && yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 7)
        {
            if (!redOn && blueOn && !greenOn && !purpleOn && !yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 8)
        {
            if (!redOn && blueOn && greenOn && !purpleOn && !yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 9)
        {
            if (!redOn && blueOn && !greenOn && purpleOn && !yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 10)
        {
            if (!redOn && blueOn && !greenOn && !purpleOn && yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 11)
        {
            if (!redOn && blueOn && greenOn && purpleOn && !yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 12)
        {
            if (!redOn && blueOn && greenOn && !purpleOn && yellowOn) EvalServe(1);
            else EvalServe(0);
        }
        if (randomNum == 13)
        {
            if (!redOn && blueOn && !greenOn && purpleOn && yellowOn) EvalServe(1);
            else EvalServe(0);
        }

    }

    public void Activate(int num)
    {
        switch (num)
        {
            case 0:
                redOn = true;
                break;

            case 1:
                blueOn = true;
                break;

            case 2:
                greenOn = true;
                break;

            case 3:
                purpleOn = true;
                break;

            case 4:
                yellowOn = true;
                break;

            default:
                break;
        }
    }

    public void EvalServe(int result)
    {
        if (result == 0)
        {
            winScreen.SetActive(false);
            loseScreen.SetActive(true);
            timeoutScreen.SetActive(false);
        }
        else if (result == 1)
        {
            winScreen.SetActive(true);
            loseScreen.SetActive(false);
            timeoutScreen.SetActive(false);
        }
        else
        {
            winScreen.SetActive(false);
            loseScreen.SetActive(false);
            timeoutScreen.SetActive(true);
        }
        StartCoroutine(AfterServe());
    }

}
