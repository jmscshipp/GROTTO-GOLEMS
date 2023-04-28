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
            StartCoroutine(SeekerDamaged());
        }
        // this object is hider, both called when players collide
        else if (collision.gameObject.tag == "Seeker")
        {
            StartCoroutine(HiderDamaged());
        }
    }

    private IEnumerator HiderDamaged()
    {
        GameManager.Instance().SwitchRoles();
        yield return new WaitForSeconds(0);
    }

    private IEnumerator SeekerDamaged()
    {
        yield return new WaitForSeconds(0);
    }
}
