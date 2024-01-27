using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    private Image img;

    public Sprite normalSprite;
    public Sprite changedSprite;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        string name = gameObject.name;

        switch (name)
        {
            case "Red":
                if (GameMaster.redOn) img.sprite = changedSprite;
                else img.sprite = normalSprite;
                break;

            case "Blue":
                if (GameMaster.blueOn) img.sprite = changedSprite;
                else img.sprite = normalSprite;
                break;

            case "Green":
                if (GameMaster.greenOn) img.sprite = changedSprite;
                else img.sprite = normalSprite;
                break;

            case "Purple":
                if (GameMaster.purpleOn) img.sprite = changedSprite;
                else img.sprite = normalSprite;
                break;

            case "Yellow":
                if (GameMaster.yellowOn) img.sprite = changedSprite;
                else img.sprite = normalSprite;
                break;

            default:
                break;
        }
    }
}
