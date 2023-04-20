using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternInstance : MonoBehaviour
{
    public Sprite[] lanternSprites;     // should be 2 sprites
    private static bool firstLanternSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!firstLanternSpawned)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = lanternSprites[0];
            firstLanternSpawned = true;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().sprite = lanternSprites[1];
            firstLanternSpawned = false; // reset var for next room
        }

        // turn off collider when spawned to avoid displacing the player accidentally
        GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(DelayCollision());
    }

    private IEnumerator DelayCollision()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<CircleCollider2D>().enabled = true;
    }
    
    // will want to add hooks for animations later probably
}
