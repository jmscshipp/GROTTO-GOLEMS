using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapAbility : Ability
{
    private Vector2 tempPosition;
    private GameObject[] whiteOuts; // white version of sprites for visual effect

    void Start()
    {
        // general timer setup
        active = false;
        activeTime = 0.2f;
        timeSinceActivation = activeTime;
        coolDown = 0.7f;
        lastUseTimeStamp = 0f;

        // specific to this ability
        whiteOuts = GameObject.FindGameObjectsWithTag("White");

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
            transform.parent.GetComponent<CircleCollider2D>().enabled = false;
            tempPosition = transform.parent.position;
            GameObject chaser = GameObject.FindGameObjectWithTag("Seeker");
            transform.parent.position = chaser.transform.position;
            chaser.transform.position = tempPosition;
            transform.parent.GetComponent<CircleCollider2D>().enabled = true;

            foreach (GameObject whiteOut in whiteOuts)
                whiteOut.GetComponent<SpriteRenderer>().enabled = true; // turning on whiteouts
        }
    }
    
    public override void Deactivate()
    {
        // ability timer stuff
        active = false;

        // ability effects
        foreach (GameObject whiteOut in whiteOuts)
            whiteOut.GetComponent<SpriteRenderer>().enabled = false; // turning off whiteouts
    }
}
