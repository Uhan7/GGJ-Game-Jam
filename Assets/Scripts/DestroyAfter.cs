using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{

    public float time;
    public bool unscaledTime;

    private void Start()
    {
        StartCoroutine(Destroy(gameObject, time));
    }

    IEnumerator Destroy(GameObject obj, float time)
    {
        if (unscaledTime) yield return new WaitForSecondsRealtime(time);
        else yield return new WaitForSeconds(time);
        Destroy(obj);
    }
}
