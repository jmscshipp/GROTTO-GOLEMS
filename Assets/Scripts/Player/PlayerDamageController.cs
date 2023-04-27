using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // this object is seeker
        if (collision.gameObject.tag == "Hider")
        {

        }
        // this object is hider
        else if (collision.gameObject.tag == "Seeker")
        {

        }
    }
}
