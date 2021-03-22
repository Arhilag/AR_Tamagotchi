using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public Animator shopController;
    //public Text testScore;

    private bool checkShop = false;
    private bool checkThink = false;
    //private int score = 0;
    //private int flag = 0;
    void Start()
    {
        
    }

    
    //void FixedUpdate()
    //{
    //    if (flag < 5) flag++;
    //    else
    //    {
    //        score++;
    //        flag = 0;
    //    }
        
    //    testScore.text = score + "";
    //}

    

    public void ShopButton()
    {
        if (checkShop == false && checkThink == true)
        {
            shopController.SetTrigger("switchTS");
            checkThink = false;
            checkShop = true;
        }
        else
        {
            shopController.SetTrigger("shop");
            checkShop = !checkShop;
        }
    }

    public void ThinkButton()
    {
        if (checkThink == false && checkShop == true)
        {
            shopController.SetTrigger("switchST");
            checkShop = false;
            checkThink = true;
        }
        else
        {
            shopController.SetTrigger("think");
            checkThink = !checkThink;
        }
    }

    public void ButtonMove()
    {
        //Debug.Log("2");
        animator.SetTrigger("active");
        
    }
}
