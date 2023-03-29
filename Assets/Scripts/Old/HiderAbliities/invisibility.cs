using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibility : ability
{
    private float timer; // for when you can use ability
    private bool active = false;
    private float activeTimer = 1f; // for how long invisibility lasts once active
    private float visibilityLerp = 1f;
    private bool end = false;
    public Material invisibilityMat;
    public Material defaultMat;
    private SpriteRenderer charBase;
    private SpriteRenderer charMid;
    private SpriteRenderer charHead;
    // Start is called before the first frame update
    void Start()
    {
        timer = coolDown;
        transform.parent.Find("charGraphics").GetComponent<SpriteRenderer>().material = invisibilityMat;
        transform.parent.Find("charGraphics").transform.Find("charMid").GetComponent<SpriteRenderer>().material = invisibilityMat;
        transform.parent.Find("charGraphics").transform.Find("charMid").transform.GetChild(0).GetComponent<SpriteRenderer>().material = invisibilityMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            if (visibilityLerp >= 0f && end == false)
            {
                visibilityLerp -= Time.deltaTime * 5f;
                invisibilityMat.SetFloat("_Step", visibilityLerp);
            }
            activeTimer -= Time.deltaTime;
            if (activeTimer <= 0f)
            {
                end = true;
                visibilityLerp += Time.deltaTime * 5f;
                invisibilityMat.SetFloat("_Step", visibilityLerp);
                if (visibilityLerp >= 1f)
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
            visibilityLerp = 1f;
            activeTimer = 1f;
            end = false;
            active = true;
            timer = 0f;
        }
    }

    private void OnDestroy()
    {
        invisibilityMat.SetFloat("_Step", 1f);
        transform.parent.Find("charGraphics").GetComponent<SpriteRenderer>().material = defaultMat;
        transform.parent.Find("charGraphics").transform.Find("charMid").GetComponent<SpriteRenderer>().material = defaultMat;
        transform.parent.Find("charGraphics").transform.Find("charMid").transform.GetChild(0).GetComponent<SpriteRenderer>().material = defaultMat;
    }
}
