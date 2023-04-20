using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierAbiity : Ability
{
    public GameObject barrierPrefab;
    private GameObject barrierInstance;

    // Start is called before the first frame update
    void Start()
    {
        // general timer setup
        active = false;
        activeTime = 1.25f;
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
            else if (timeSinceActivation <= 0.25f)
            {
                barrierInstance.GetComponent<Animator>().SetBool("platformUp", false);
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
            barrierInstance = Instantiate(barrierPrefab, transform.position + (Vector3)transform.parent.GetComponent<PlayerMovement>().inputVector * 2.5f, Quaternion.identity);

        }
    }
    
    public override void Deactivate()
    {
        // ability timer stuff
        active = false;

        // ability effects
        Destroy(barrierInstance);
    }
}
