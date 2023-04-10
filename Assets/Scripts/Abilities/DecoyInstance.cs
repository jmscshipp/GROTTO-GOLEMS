using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyInstance : MonoBehaviour
{
    public Vector2 dir;
    private SpriteRenderer[] graphics;
    private GameObject collisionExemption; // player that spawned the decoy
    private Color spriteColor;
    private float fadeCounter;
    public float fadeSpeed = 2.0f;
    public float moveSpeed = 120.0f; // will need to update to match player speed!
    private bool death;

    // Start is called before the first frame update
    void Start()
    {
        graphics = GetComponentsInChildren<SpriteRenderer>();
        spriteColor = Color.white;
        fadeCounter = 0.0f;
        death = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (death)
        {
            fadeCounter -= Time.deltaTime * fadeSpeed;
            spriteColor.a = fadeCounter;
            foreach (SpriteRenderer sprite in graphics)
                sprite.color = spriteColor;
            if (fadeCounter <= 0f)
                Destroy(gameObject);
        }
        else
            GetComponent<Rigidbody2D>().AddForce(dir * Time.deltaTime * moveSpeed * 300);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject != collisionExemption)
    //        death = true;
    //}

    public void SetDirectionAndExemption(Vector2 newDirection, GameObject exemption)
    {
        // make sure decoy can't collide with player that created it
        collisionExemption = exemption;

        if (newDirection.x != 0f || newDirection.y != 0f) // interpret player movement if they're moving
        {
            float x = newDirection.x;
            float y = newDirection.y;
            if (newDirection.x > 0f)
                x = 1;
            else if (newDirection.x < 0f)
                x = -1;
            if (newDirection.y > 0f)
                y = 1;
            else if (newDirection.y < 0f)
                y = -1;
            dir = new Vector2(-x, -y);
        }
        else // if player not moving go in random direction
        {
            do
            {
                dir = new Vector2(Mathf.Round(Random.Range(-1f, 1f)), Mathf.Round(Random.Range(-1f, 1f)));
            }
            while (dir.x == 0f && dir.y == 0f);
        }
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion lookRot = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, 360f);
    }
}
