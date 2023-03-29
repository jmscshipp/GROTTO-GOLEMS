using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : ability
{
    private float timer; // for when you can use ability
    private bool active = false;
    private float activeTimer = 1f; // for how long ability lasts once active

    // Start is called before the first frame update
    void Start()
    {
        timer = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            activeTimer -= Time.deltaTime;
            if (activeTimer <= 0f)
            {
                foreach (GameObject platform in GameObject.FindGameObjectsWithTag("Platform"))
                    platform.GetComponent<Animator>().SetBool("platformUp", true);
                active = false;
            }
        }
        else
            timer += Time.deltaTime;
    }

    public override void Use()
    {
        if (timer >= coolDown)
        {
            activeTimer = 2f;
            active = true;
            foreach (GameObject platform in GameObject.FindGameObjectsWithTag("Platform"))
                platform.GetComponent<Animator>().SetBool("platformUp", false);
            timer = 0f;
        }
    }
}
