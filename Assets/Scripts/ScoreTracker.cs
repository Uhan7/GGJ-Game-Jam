using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreTracker : MonoBehaviour
{

    public int peopleServedToday;
    private string dayRating;

    public TextMeshProUGUI peopleServedTodayText;
    public TextMeshProUGUI peopleServedTodayText1;
    public TextMeshProUGUI dayRatingText;

    public GameObject dayDoneScreen;

    public Sprite[] dayDoneStars;

    public int threeStarMin;
    public int twoStarMin;
    public int oneStarMin;

    public bool canGetHighscore;

    public void Start()
    {
        peopleServedToday = 0;
        canGetHighscore = false;
    }

    public void Update()
    {
        peopleServedTodayText1.text = peopleServedToday.ToString();

        peopleServedTodayText.text = "You made " + peopleServedToday.ToString() + " people laugh today!";
        dayRatingText.text = dayRating;
        if (peopleServedToday >= threeStarMin)
        {
            dayRating = "YOU'RE SO FUNNY !!!\n3/3";
            dayDoneScreen.GetComponent<Image>().sprite = dayDoneStars[2];
        }
        else if (peopleServedToday >= twoStarMin) {
            dayRating = "Not too bad, you're pretty funny!\n2/3";
            dayDoneScreen.GetComponent<Image>().sprite = dayDoneStars[1];
        }
        else if (peopleServedToday >= oneStarMin) {
            dayRating = "Funny, but could use some work!\n1/3";
            dayDoneScreen.GetComponent<Image>().sprite = dayDoneStars[0];
        }
        else dayRating = "Okay.. Let's take some comedy classes.";

        switch (SceneManager.GetActiveScene().name)
        {
            case "Game Day 1":
                if (peopleServedToday > PlayerPrefs.GetInt("HighscoreDay1", 0))
                {
                    PlayerPrefs.SetInt("HighscoreDay1", peopleServedToday);
                }
                break;

            case "Game Day 2":
                if (peopleServedToday > PlayerPrefs.GetInt("HighscoreDay2", 0))
                {
                    PlayerPrefs.SetInt("HighscoreDay2", peopleServedToday);
                }
                break;

            case "Game Day 3":

                if (peopleServedToday > PlayerPrefs.GetInt("HighscoreDay3", 0))
                {
                    PlayerPrefs.SetInt("HighscoreDay3", peopleServedToday);
                }
                break;

            default:
                break;
        }
        print(peopleServedToday);
        print("Highscore: " + PlayerPrefs.GetInt("HighscoreDay1", 0).ToString());
        canGetHighscore = false;
    }

}
