using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAbility : Ability
{
    // Start is called before the first frame update
    void Start()
    {
        // general timer setup
        active = false;
        activeTime = 1.0f;
        timeSinceActivation = activeTime;
        coolDown = 0.7f;
        lastUseTimeStamp = 0f;
        // specific to this ability
    }
    
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            timeSinceActivation -= Time.deltaTime;
            if (timeSinceActivation <= 0)
            {
                Deactivate();
            }
        }
    }
    
    public override void Activate()
    {
        if (Time.time - lastUseTimeStamp > coolDown)
        {
            // ability timer stuff
            active = true;
            timeSinceActivation = activeTime;
            lastUseTimeStamp = Time.time;

            // ability effects
            foreach (GameObject platform in GameObject.FindGameObjectsWithTag("Platform"))
                platform.GetComponent<Animator>().SetBool("platformUp", false);
            // doing this every time in case player spawned new platform from barrier ability
        }
    }
    
    public override void Deactivate()
    {
        // ability timer stuff
        active = false;

        // ability effects
        foreach (GameObject platform in GameObject.FindGameObjectsWithTag("Platform"))
            platform.GetComponent<Animator>().SetBool("platformUp", true);
    }
}
