using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    [SerializeField]
    Animator anim;
    [SerializeField]
    PlayerBehavior player;


    public void animate()
    {
        if (player.checkSpd == 1)
        {
             anim.SetTrigger("Walk");
        }
        else if (player.checkSpd == 0)
        {
            anim.SetTrigger("Back");
        }
    }

}
