using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniseeker : MonoBehaviour
{
    private Vector3 dir;
    private float timer = 0f;
    private float shrinker = 0f;
    // Start is called before the first frame update
    void Start()
    {
        dir = transform.parent.transform.position - transform.position;
        transform.parent = null;
        dir = -dir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * 7f);
        timer += Time.deltaTime;
        if (timer >= 2.9f)
        {
            shrinker += Time.deltaTime;
            transform.localScale -= Vector3.one * shrinker;
        }
        if (timer >= 3f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Character")
        {
            dir = collision.GetContact(0).point - (Vector2)transform.position;
            dir = -dir.normalized;
            //GetComponent<Rigidbody2D>().AddForce(dir * 30f);
        }
    }
}
