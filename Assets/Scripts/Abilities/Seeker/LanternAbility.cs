using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternAbility : Ability
{
    public GameObject lanternPrefab;
    private GameObject[] activeLanterns = new GameObject[2];
    private int activeLanternCount;
    private int lastLanternIndex;

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
        activeLanternCount = 0;
        lastLanternIndex = 0;
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
            PlaceLantern();
        }
    }

    private void PlaceLantern()
    {
        // placing new lantern
        if (activeLanternCount < activeLanterns.Length)
        {
            activeLanterns[lastLanternIndex] = Instantiate(lanternPrefab, transform.position, Quaternion.identity);
            activeLanternCount++;
            lastLanternIndex++;
        }
        else // moving oldest lantern
        {
            lastLanternIndex++;
            if (lastLanternIndex > 1)
                lastLanternIndex = 0;

            activeLanterns[lastLanternIndex].transform.position = transform.position;
        }

    }
    
    public override void Deactivate()
    {
        // ability timer stuff
        active = false;
    
        // ability effects
    }

    private void OnDestroy()
    {
        // destroy lanterns
        if (activeLanterns[0] != null)
            Destroy(activeLanterns[0]);
        if (activeLanterns[1] != null)
            Destroy(activeLanterns[1]);
    }
}
