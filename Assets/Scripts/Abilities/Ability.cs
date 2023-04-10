using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    protected bool active; // only used with dash ...
    protected float activeTime; // (SET FOR EACH) how long ability is active. only used with dash ...
    protected float timeSinceActivation; // keeps track from moment to moment
    protected float coolDown; // (SET FOR EACH) wait time between activations
    protected float lastUseTimeStamp; // used to compare with cooldown to see if ability can be used

    public virtual void Activate()
    {
    }

    public virtual void Deactivate()
    {
    }

    // D E R I V E D  A B I L I I T Y  B O I L E R  P L A T E
    //
    // Start is called before the first frame update
    //void Start()
    //{
    //    // general timer setup
    //    active = false;
    //    activeTime = 0.2f;
    //    timeSinceActivation = activeTime;
    //    coolDown = 0.7f;
    //    lastUseTimeStamp = 0f;
    //    // specific to this ability
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    if (active)
    //    {
    //        timeSinceActivation -= Time.deltaTime;
    //        if (timeSinceActivation <= 0)
    //        {
    //            Deactivate();
    //        }
    //    }
    //}
    //
    //public override void Activate()
    //{
    //    if (Time.time - lastUseTimeStamp > coolDown)
    //    {
    //        // ability timer stuff
    //        active = true;
    //        timeSinceActivation = activeTime;
    //        lastUseTimeStamp = Time.time;
    //
    //        // ability effects
    //    }
    //}
    //
    //public override void Deactivate()
    //{
    //    // ability timer stuff
    //    active = false;
    //
    //    // ability effects
    //}
}
