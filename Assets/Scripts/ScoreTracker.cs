using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTracker : MonoBehaviour
{

    public int peopleServedToday;
    private string dayRating;

    public TextMeshProUGUI peopleServedTodayText;
    public TextMeshProUGUI dayRatingText;

    public int threeStarMin;
    public int twoStarMin;
    public int oneStarMin;

    public void Start()
    {
        peopleServedToday = 0;
    }

    public void Update()
    {
        peopleServedTodayText.text = "You made " + peopleServedToday.ToString() + " people laugh today!";
        dayRatingText.text = dayRating;
        if (peopleServedToday >= threeStarMin) dayRating = "YOU'RE SO FUNNY !!!\n3/3";
        else if (peopleServedToday >= twoStarMin) dayRating = "Not too bad, you're pretty funny!\n2/3";
        else if (peopleServedToday >= oneStarMin) dayRating = "Funny, but could use some work!\n1/3";
        else dayRating = "Okay.. Let's take some comedy classes.";
    }

}
