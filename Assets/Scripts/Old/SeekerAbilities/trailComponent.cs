using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailComponent : MonoBehaviour
{
    private bool count = true;
    private float countDown = 1f;
    private bool shrink = false;
    private float shrinkTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0 && count)
        {
            shrink = true;
            count = false;
        }
        if (shrink == true)
        {
            shrinkTimer += Time.deltaTime;
            transform.localScale = transform.localScale * (1 - shrinkTimer);
            if (shrinkTimer >= 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
