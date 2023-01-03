using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail : ability
{
    private float trailSpawnCountDown = .2f; // how often new trail piece is spawned
    private Vector2 lastPos;
    public GameObject trailPrefab;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update() // passively makes trail
    {
        trailSpawnCountDown -= Time.deltaTime;
        if (trailSpawnCountDown <= 0)
        {
            if (Vector2.Distance(transform.position, lastPos) >= .8f)
            {
                Instantiate(trailPrefab, transform.position, Quaternion.identity);
                lastPos = transform.position;
            }
            trailSpawnCountDown = .2f;
        }
    }

    public override void Use()
    {
        // might want to put something here if passive trail isn't strong enough
    }
}
