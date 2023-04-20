using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyAbility : Ability
{
    public GameObject decoyPrefab;
    private GameObject decoyInstance;
    private PlayerMovement playerMovement;

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
        playerMovement = transform.parent.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            timeSinceActivation -= Time.deltaTime;
            // triggered when decoy is destroyed
            if (decoyInstance == null)
                Deactivate();
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
            decoyInstance = Instantiate(decoyPrefab, transform.position, Quaternion.identity);
            decoyInstance.GetComponent<DecoyInstance>().SetDirectionAndExemption(playerMovement.inputVector, transform.parent.gameObject);
        }
    }
    
    public override void Deactivate()
    {
        // ability timer stuff
        active = false;
    }
}
