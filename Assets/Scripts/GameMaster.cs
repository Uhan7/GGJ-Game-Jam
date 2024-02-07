using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMaster : MonoBehaviour
{

    private AudioSource aSource;

    public GameObject smolTimer;
    private SmolTimer smolTimerScript;

    public GameObject dayTimer;
    private DayTimer dayTimerScript;

    public GameObject scoreTracker;
    private ScoreTracker scoreTrackerScript;

    public GameObject hearts;
    private Hearts heartsScript;

    public GameObject speechBubble;
    public GameObject[] ask;
    public GameObject dos;

    public Button pauseButton;
    public Button[] doButtons;

    public Sprite image1;
    public Sprite image2;

    public AudioClip sfx1;
    public AudioClip sfx2;
    public AudioClip sfx3;

    public AudioClip dingBellSFX;

    public GameObject currentFunny;
    public bool currentFunnySwitched;

    private int randomNum;
    private int randomNum1;
    private int randomNum2;

    private GameObject currentAsk;
    private GameObject currentPerson;

    public AudioClip[] laughs;

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

    public GameObject loadingScreenIn;

    private bool timeouted;

    public static bool dayDone;

    public static bool gameIsPaused;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
        smolTimerScript = smolTimer.GetComponent<SmolTimer>();
        dayTimerScript = dayTimer.GetComponent<DayTimer>();
        scoreTrackerScript = scoreTracker.GetComponent<ScoreTracker>();
        heartsScript = hearts.GetComponent<Hearts>();
    }

    void Start()
    {
        redOn = false;
        blueOn = false;
        greenOn = false;
        purpleOn = false;
        yellowOn = false;

        orderSatisfied = 2;

        dayDone = false;

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

        Ask(false);
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
            if (scoreTrackerScript.peopleServedToday >= scoreTrackerScript.oneStarMin) StartCoroutine(DayDone());
            else StartCoroutine(DayLose());
            dayDone = true;
        }

        if (dayDone)
        {
            pauseButton.interactable = false;
            pauseScreen.SetActive(false);
        }
    }

    public void Ask(bool sameChara)
    {
        randomNum = Random.Range(0, ask.Length-1);
        randomNum1 = Random.Range(0, people.Length);
        randomNum2 = Random.Range(0, 10);

        if (randomNum2 == 0)
        {
            StartCoroutine("ChangeAsk");
        }

        speechBubble.SetActive(true);

        currentAsk = ask[randomNum];
        currentAsk.SetActive(true);

        if (!sameChara) currentPerson = people[randomNum1];
        if (!sameChara) currentPerson.SetActive(true);
    }

    IEnumerator ChangeAsk()
    {
        print("Changing Quyestion");
        yield return new WaitForSeconds(Random.Range(2f, 3f));
        foreach (var button in doButtons)
        {
            button.interactable = false;
        }
        currentAsk.SetActive(false);
        currentAsk = ask[ask.Length - 1];
        currentAsk.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        speechBubble.SetActive(false);
        Time.timeScale = 1;
        ResetValues(true);
        Ask(true);
    }


    public void ResetValues(bool sameChara)
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

        if (!sameChara) orderSatisfied = 2;


        if (!sameChara) currentPerson.SetActive(false);

        timeouted = false;

        foreach (var button in doButtons)
        {
            button.interactable = true;
        }
        Time.timeScale = 1;
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

        aSource.PlayOneShot(dingBellSFX);
        StopCoroutine("ChangeAsk");

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
        if (orderSatisfied == 1) ShowFunny();
        speechBubble.SetActive(false);
        StartCoroutine(AfterServe());
    }

    public void ShowFunny()
    {
        if (!currentFunnySwitched) currentFunnySwitched = true;
        else currentFunnySwitched = false;

        currentFunny.GetComponent<Animator>().SetBool("Switched", currentFunnySwitched);

        if (redOn && !blueOn) currentFunny.GetComponent<Image>().sprite = image1;
        else if (blueOn && !redOn) currentFunny.GetComponent<Image>().sprite = image2;

        if (greenOn) aSource.PlayOneShot(sfx1);
        if (purpleOn) aSource.PlayOneShot(sfx2);
        if (yellowOn) aSource.PlayOneShot(sfx3);
    }

    IEnumerator AfterServe()
    {

        switch (orderSatisfied)
        {
            case 0:

            case 2:
                aSource.PlayOneShot(laughs[0]);
                break;

            case 1:
                switch (currentPerson.name)
                {
                    case "Female Child":
                        aSource.PlayOneShot(laughs[1]);
                        break;

                    case "Female Teen":
                        aSource.PlayOneShot(laughs[2]);
                        break;

                    case "Female Adult":
                        aSource.PlayOneShot(laughs[3]);
                        break;

                    case "Male Child":
                        aSource.PlayOneShot(laughs[4]);
                        break;

                    case "Male Teen":
                        aSource.PlayOneShot(laughs[5]);
                        break;

                    case "Male Adult":
                        aSource.PlayOneShot(laughs[6]);
                        break;

                    default:
                        break;
                }
                break;

            default:
                break;
        }

        foreach (var button in doButtons)
        {
            button.interactable = false;
        }

        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2f);

        if (heartsScript.health <= 0)
        {
            StartCoroutine(DayLose());
        }
        if (!dayDone)
        {
            ResetValues(false);
            Ask(false);
        }
    }

    IEnumerator DayDone()
    {
        dayDone = true;
        scoreTrackerScript.canGetHighscore = true;
        Time.timeScale = 0;
        foreach (var thing in dayDoneScreen)
        {
            yield return new WaitForSecondsRealtime(1f);
            thing.SetActive(true);
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

    IEnumerator RestartScene()
    {
        loadingScreenIn.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator GoHome()
    {
        loadingScreenIn.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Start Screen");
    }

}
