using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public GameObject[] ask;

    private GameObject currentAsk;

    private int randomNum;

    private bool redOn;
    private bool blueOn;

    private bool greenOn;
    private bool purpleOn;
    private bool yellowOn;

    public GameObject winScreen;
    public GameObject loseScreen;

    void Start()
    {
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
        yield return new WaitForSeconds(5f);
        Serve();
        yield return new WaitForSeconds(1f);
        Ask();
    }

    public void Serve()
    {
        if (randomNum == 0)
        {
            if (redOn && !blueOn && !greenOn && !purpleOn && !yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 1)
        {
            if (redOn && !blueOn && greenOn && !purpleOn && !yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 2)
        {
            if (redOn && !blueOn && !greenOn && purpleOn && !yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 3)
        {
            if (redOn && !blueOn && !greenOn && !purpleOn && yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 4)
        {
            if (redOn && !blueOn && greenOn && purpleOn && !yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 5)
        {
            if (redOn && !blueOn && greenOn && !purpleOn && yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 6)
        {
            if (redOn && !blueOn && !greenOn && purpleOn && yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 7)
        {
            if (!redOn && blueOn && !greenOn && !purpleOn && !yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 8)
        {
            if (!redOn && blueOn && greenOn && !purpleOn && !yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 9)
        {
            if (!redOn && blueOn && !greenOn && purpleOn && !yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 10)
        {
            if (!redOn && blueOn && !greenOn && !purpleOn && yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 11)
        {
            if (!redOn && blueOn && greenOn && purpleOn && !yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 12)
        {
            if (!redOn && blueOn && greenOn && !purpleOn && yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
        }
        if (randomNum == 13)
        {
            if (!redOn && blueOn && !greenOn && purpleOn && yellowOn) winScreen.SetActive(true);
            else loseScreen.SetActive(true);
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

    public void EvalServe(bool win)
    {
        if (win)
        {
            winScreen.SetActive(true);
            loseScreen.SetActive(false);
        }
        else
        {
            winScreen.SetActive(false);
            loseScreen.SetActive(true);
        }
    }

}
