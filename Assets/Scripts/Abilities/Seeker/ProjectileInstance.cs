using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInstance : MonoBehaviour
{
    public float lifeTime = 3.0f;
    private Vector2 moveDir;
    private float lifeTimer;
    private float shrinkTimer;

    // Start is called before the first frame update
    void Start()
    {
        moveDir = transform.parent.transform.position - transform.position;
        transform.parent = null; // unparented
        moveDir = -moveDir.normalized;

        lifeTimer = 0f;
        shrinkTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir * Time.deltaTime * 7f);
        lifeTimer += Time.deltaTime;

        if (lifeTimer >= lifeTime)
            Destroy(gameObject);
        else if (lifeTimer >= lifeTime - 0.1f)
        {
            shrinkTimer += Time.deltaTime;
            transform.localScale -= Vector3.one * shrinkTimer;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Character")
        {
            moveDir = collision.GetContact(0).point - (Vector2)transform.position;
            moveDir = -moveDir.normalized;
        }
    }
}
