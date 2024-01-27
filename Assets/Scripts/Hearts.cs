using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{

    private Image img;

    public int health;

    public Sprite heart3;
    public Sprite heart2;
    public Sprite heart1;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        switch (health)
        {
            case 3:
                img.sprite = heart3;
                break;

            case 2:
                img.sprite = heart2;
                break;

            case 1:
                img.sprite = heart1;
                break;

            default:
                break;
        }
    }

}
