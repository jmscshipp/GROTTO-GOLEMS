using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailAbility : Ability
{
    public GameObject trailPrefab;
    private Vector2 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        // general timer setup
        active = false;
        activeTime = 0.2f;
        timeSinceActivation = activeTime;
        coolDown = 0.2f;
        lastUseTimeStamp = 0f;

        // specific to this ability
        lastPos = transform.position;
        Activate();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceActivation -= Time.deltaTime;

        if (timeSinceActivation <= 0f && Vector2.Distance(transform.position, lastPos) >= .8f)
        {
            Instantiate(trailPrefab, transform.position, Quaternion.identity);
            lastPos = transform.position;
            timeSinceActivation = activeTime;
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
        }
    }
    
    public override void Deactivate()
    {
        // ability timer stuff
        active = false;
    
        // ability effects
    }
}
