using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{

    private Image img;

    public int health;

    public Sprite heartis3;
    public Sprite heartis2;
    public Sprite heartis1;
    public Sprite heartis0;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        switch (health)
        {
            case 3:
                img.sprite = heartis3;
                break;

            case 2:
                img.sprite = heartis2;
                break;

            case 1:
                img.sprite = heartis1;
                break;

            case 0:
                img.sprite = heartis0;
                break;

            default:
                break;
        }
    }

}
