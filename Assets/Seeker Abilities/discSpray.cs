using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class discSpray : ability
{
    public GameObject miniSeeker;
    //private float coolDown = 2f; // might wanna delete later
    private float timer;
    private Vector2[] spawnLocations = { new Vector2(0, 1), new Vector2(0.7071f, 0.7071f), new Vector2(1, 0), new Vector2(0.7071f, -0.7071f), new Vector2(0, -1), new Vector2(-0.7071f, -0.7071f), new Vector2(-1, 0), new Vector2(-0.7071f, 0.7071f) };
    // 8 spawn locations around the player
    /*
     x  x  x
    x   p   x
     x  x  x
    */
    // Start is called before the first frame update
    void Start()
    {
        timer = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public override void Use()
    {
        if (timer >= coolDown)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject newSeeker = Instantiate(miniSeeker, gameObject.transform);
                newSeeker.transform.localPosition = spawnLocations[i];
            }
            timer = 0f;
        }
    }
}
