using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartMaster : MonoBehaviour
{

    public GameObject creditsScreen;
    public GameObject levelMenuScreen;

    public GameObject loadingScreen;

    public TextMeshProUGUI day1Highscore;
    public TextMeshProUGUI day2Highscore;
    public TextMeshProUGUI day3Highscore;

    public GameObject tutorialParent;
    public GameObject[] tutorialSlides;

    private int i;

    public void Wrapper(string coroutineName)
    {
        StartCoroutine(coroutineName);
    }

    private void Start()
    {
        day1Highscore.text = "Highscore: " + PlayerPrefs.GetInt("HighscoreDay1", 0).ToString();
        day2Highscore.text = "Highscore: " + PlayerPrefs.GetInt("HighscoreDay2", 0).ToString();
        day3Highscore.text = "Highscore: " + PlayerPrefs.GetInt("HighscoreDay3", 0).ToString();

        i = 0;
    }

    IEnumerator StartDay1()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Game Day 1");
    }

    IEnumerator StartDay2()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Game Day 2");
    }

    IEnumerator StartDay3()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Game Day 3");
    }

    public void Credits()
    {
        if (!creditsScreen.activeInHierarchy) creditsScreen.SetActive(true);
        else creditsScreen.SetActive(false);
    }

    public void LevelMenu()
    {
        if (!levelMenuScreen.activeInHierarchy) levelMenuScreen.SetActive(true);
        else levelMenuScreen.SetActive(false);
    }

    public void NextTutorial()
    {
        tutorialSlides[i].SetActive(true);
        i++;
        if (i >= tutorialSlides.Length)
        {
            tutorialParent.SetActive(false);
        }
    }

    public void CloseTutorial()
    {
        tutorialParent.SetActive(false);
    }

}
