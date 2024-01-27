using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{

    private Animator anim;
    private bool gotAnimComponent;

    void Update()
    {
        if (gameObject.activeInHierarchy && !gotAnimComponent)
        {
            anim = GetComponent<Animator>();
            gotAnimComponent = true;
        }
        anim.SetInteger("Order Outcome", GameMaster.orderSatisfied);
    }
}
