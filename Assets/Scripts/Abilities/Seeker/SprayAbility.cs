using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayAbility : Ability
{
    // 8 spawn locations around the player
    /*
     x  x  x
    x   p   x
     x  x  x
    */
    private Vector2[] spawnLocations = { new Vector2(0, 1), new Vector2(0.7071f, 0.7071f), new Vector2(1, 0), new Vector2(0.7071f, -0.7071f), new Vector2(0, -1), new Vector2(-0.7071f, -0.7071f), new Vector2(-1, 0), new Vector2(-0.7071f, 0.7071f) };
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        // general timer setup
        active = false;
        activeTime = 0.2f;
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
            for (int i = 0; i < 8; i++)
            {
                GameObject projectile = Instantiate(projectilePrefab, gameObject.transform); // initially parented to seeker
                projectile.transform.localPosition = spawnLocations[i];
            }
        }
    }
    
    public override void Deactivate()
    {
        // ability timer stuff
        active = false;
    
        // ability effects
    }
}
