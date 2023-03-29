using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundUIAnims : MonoBehaviour
{
    private bool imageSwitch = false;
    private Animator thisAnimator;
    // Start is called before the first frame update
    void Start()
    {
        thisAnimator = GetComponent<Animator>();
        thisAnimator.keepAnimatorStateOnDisable = true;
    }

    public void Switch()
    {
        StartCoroutine(DelayedSwitch());
    }

    IEnumerator DelayedSwitch() // makes better visual if there's a slight delay before switch
    {
        yield return new WaitForSeconds(0.3f);
        if (!imageSwitch)
        {
            thisAnimator.SetBool("switch", true);
            imageSwitch = true;
        }
        else
        {
            thisAnimator.SetBool("switch", false);
            imageSwitch = false;
        }
    }
}
