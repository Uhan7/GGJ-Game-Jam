using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMaster : MonoBehaviour
{

    public GameObject smolTimer;
    private SmolTimer smolTimerScript;

    public GameObject dayTimer;
    private DayTimer dayTimerScript;

    public GameObject scoreTracker;
    private ScoreTracker scoreTrackerScript;

    public GameObject hearts;
    private Hearts heartsScript;

    public GameObject[] ask;
    public GameObject dos;

    public Button pauseButton;
    public Button[] doButtons;

    private int randomNum;
    private int randomNum1;

    private GameObject currentAsk;
    private GameObject currentPerson;

    public static bool redOn;
    public static bool blueOn;

    public static bool greenOn;
    public static bool purpleOn;
    public static bool yellowOn;

    public GameObject[] people;

    public static int orderSatisfied;

    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject timeoutScreen;
    public GameObject pauseScreen;

    public GameObject[] dayDoneScreen;
    public GameObject[] dayLoseScreen;

    public GameObject startScreen;
    public TextMeshProUGUI startScreenText;

    private bool timeouted;

    public static bool dayDone;

    public static bool gameIsPaused;

    private void Awake()
    {
        smolTimerScript = smolTimer.GetComponent<SmolTimer>();
        dayTimerScript = dayTimer.GetComponent<DayTimer>();
        scoreTrackerScript = scoreTracker.GetComponent<ScoreTracker>();
        heartsScript = hearts.GetComponent<Hearts>();
    }

    void Start()
    {
        gameIsPaused = true;
        Time.timeScale = 0;
        StartCoroutine(StartScene());

        orderSatisfied = 2;
    }

    IEnumerator StartScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        startScreenText.text = "Funny Store is Ready for Orders!";
        yield return new WaitForSecondsRealtime(2f);
        startScreenText.text = "Ready";
        yield return new WaitForSecondsRealtime(.5f);
        startScreenText.text = "Set";
        yield return new WaitForSecondsRealtime(.5f);
        startScreenText.text = "SERVE!";
        yield return new WaitForSecondsRealtime(.5f);

        startScreen.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1;

        Ask();
    }

    public void Update()
    {
        if (smolTimerScript.timerFill.fillAmount <= 0 && !timeouted)
        {
            EvalServe(2);
            timeouted = true;
        }

        if (dayTimerScript.timerFill.fillAmount <= 0 && !dayDone)
        {
            StopAllCoroutines();
            StartCoroutine(DayDone());
            dayDone = true;
        }

        if (dayDone)
        {
            pauseButton.interactable = false;
            pauseScreen.SetActive(false);
        }
    }

    public void Ask()
    {
        randomNum = Random.Range(0, ask.Length);
        randomNum1 = Random.Range(0, people.Length);

        currentAsk = ask[randomNum];
        currentAsk.SetActive(true);

        currentPerson = people[randomNum1];
        currentPerson.SetActive(true);
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
        timeoutScreen.SetActive(false);
        smolTimerScript.timerFill.fillAmount = 1f;

        orderSatisfied = 2;

        currentPerson.SetActive(false);

        timeouted = false;

        foreach (var button in doButtons)
        {
            button.interactable = true;
        }
    }

 /* Serve guide
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

    public void Serve()
    {
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
                if (!redOn) redOn = true;
                else redOn = false;
                break;

            case 1:
                if (!blueOn) blueOn = true;
                else blueOn = false;
                break;

            case 2:
                if (!greenOn) greenOn = true;
                else greenOn = false;
                break;

            case 3:
                if (!purpleOn) purpleOn = true;
                else purpleOn = false;
                break;

            case 4:
                if (!yellowOn) yellowOn = true;
                else yellowOn = false;
                break;

            default:
                break;
        }
    }

    public void EvalServe(int result)
    {
        if (result == 0)
        {
            orderSatisfied = 0;

            winScreen.SetActive(false);
            loseScreen.SetActive(true);
            timeoutScreen.SetActive(false);

            heartsScript.health--;
        }
        else if (result == 1)
        {
            orderSatisfied = 1;

            winScreen.SetActive(true);
            loseScreen.SetActive(false);
            timeoutScreen.SetActive(false);

            scoreTrackerScript.peopleServedToday++;
        }
        else
        {
            orderSatisfied = 0;

            winScreen.SetActive(false);
            loseScreen.SetActive(false);
            timeoutScreen.SetActive(true);

            heartsScript.health--;
        }
        StartCoroutine(AfterServe());
    }

    IEnumerator AfterServe()
    {
        foreach (var button in doButtons)
        {
            button.interactable = false;
        }

        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);

        if (heartsScript.health <= 0)
        {
            StartCoroutine(DayLose());
        }
        if (!dayDone)
        {
            if (!gameIsPaused) Time.timeScale = 1;
            ResetValues();
            Ask();
        }
    }

    IEnumerator DayDone()
    {
        dayDone = true;
        Time.timeScale = 0;
        foreach (var thing in dayDoneScreen)
        {
            thing.SetActive(true);
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    IEnumerator DayLose()
    {
        dayDone = true;
        Debug.Log("printed");
        Time.timeScale = 0;
        foreach (var thing in dayLoseScreen)
        {
            thing.SetActive(true);
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    public void Wrapper(string coroutineName)
    {
        StartCoroutine(coroutineName);
    }

    IEnumerator PauseGame()
    {
        if (!gameIsPaused)
        {
            gameIsPaused = true;

            pauseScreen.SetActive(true);

            yield return null;

            foreach (var button in doButtons)
            {
                button.interactable = false;
            }

            currentAsk.SetActive(false);

            Time.timeScale = 0;
        }
        else
        {

            pauseScreen.SetActive(false);

            pauseButton.interactable = false;
            yield return new WaitForSecondsRealtime(1);
            pauseButton.interactable = true;

            foreach (var button in doButtons)
            {
                button.interactable = true;
            }

            currentAsk.SetActive(true);

            Time.timeScale = 1;

            gameIsPaused = false;
        }
    }

}
