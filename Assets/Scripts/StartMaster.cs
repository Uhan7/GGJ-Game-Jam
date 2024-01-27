using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMaster : MonoBehaviour
{

    public GameObject creditsScreen;

    public GameObject loadingScreen;

    public void Wrapper(string coroutineName)
    {
        StartCoroutine(coroutineName);
    }

    IEnumerator StartGame()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }

    public void Credits()
    {
        if (!creditsScreen.activeInHierarchy) creditsScreen.SetActive(true);
        else creditsScreen.SetActive(false);
    }

}