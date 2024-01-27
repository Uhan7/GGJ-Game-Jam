using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioSource aSource;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(PlayBGM());
    }

    IEnumerator PlayBGM()
    {
        yield return new WaitForSecondsRealtime(1f);
        aSource.Play();
    }

    void Update()
    {
        if (GameMaster.gameIsPaused) aSource.Pause();
        else aSource.UnPause();
    }
}
