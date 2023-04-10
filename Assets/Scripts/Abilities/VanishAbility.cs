using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishAbility : Ability
{
    public Material invisibilityMat;
    public Material defaultMat;
    public float visibilityFadeSpeed = 5.0f;
    private float visibilityLerp;

    // Start is called before the first frame update
    void Start()
    {
        // general timer setup
        active = false;
        activeTime = 1f;
        timeSinceActivation = activeTime;
        coolDown = 0.7f;
        lastUseTimeStamp = 0f;

        // assign invisibility mat to all sprites
        SpriteRenderer[] renderers = transform.parent.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
            renderer.material = invisibilityMat;

        visibilityLerp = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            timeSinceActivation -= Time.deltaTime;
            if (timeSinceActivation <= 0)
            {
                // lerp to visible
                visibilityLerp += Time.deltaTime * 5f;
                invisibilityMat.SetFloat("_Step", visibilityLerp);
                if (visibilityLerp >= 1)
                    Deactivate();
            }
            else if (visibilityLerp > 0.0f)
            {
                // lerp to invisible
                visibilityLerp -= Time.deltaTime * visibilityFadeSpeed;
                invisibilityMat.SetFloat("_Step", visibilityLerp);
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
            visibilityLerp = 1.0f;
        }
    }
    
    public override void Deactivate()
    {
        // ability timer stuff
        active = false;
    }

    //// changes to spriterenderer material are saved in play mode, so reset!
    //private void OnDestroy()
    //{
    //    invisibilityMat.SetFloat("_Step", 1f);
    //    transform.parent.Find("charGraphics").GetComponent<SpriteRenderer>().material = defaultMat;
    //    transform.parent.Find("charGraphics").transform.Find("charMid").GetComponent<SpriteRenderer>().material = defaultMat;
    //    transform.parent.Find("charGraphics").transform.Find("charMid").transform.GetChild(0).GetComponent<SpriteRenderer>().material = defaultMat;
    //}
}
