using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : ability
{
    public GameObject platformPrefab;
    private GameObject thisPlatform;
    private float timer;
    private bool active = false;
    private float activeTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        timer = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            activeTimer -= Time.deltaTime;
            if (activeTimer <= 0.25f)
            {
                thisPlatform.GetComponent<Animator>().SetBool("platformUp", false);
                if (activeTimer <= 0f)
                {
                    Destroy(thisPlatform);
                    active = false;
                }
            }
        }
        else
            timer += Time.deltaTime;
    }

    public override void Use()
    {
        if (timer >= coolDown)
        {
            RaisePlatform();
            timer = 0f;
        }
    }

    private void RaisePlatform()
    {
        active = true;
        activeTimer = 1.25f;
        thisPlatform = Instantiate(platformPrefab, transform.position + (Vector3)transform.parent.GetComponent<movement>().inputVector * 2.5f, Quaternion.identity);
    }
}
