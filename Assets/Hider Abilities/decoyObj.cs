using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decoyObj : MonoBehaviour
{
    private Vector2 direction;
    public GameObject sprites;
    private bool fade = false;
    private float lerpNum = 1f;
    private Color spriteColor = Color.white;
    private List<SpriteRenderer> graphics = new List<SpriteRenderer>();

    private void Start()
    {
        graphics.Add(sprites.GetComponent<SpriteRenderer>());
        foreach (SpriteRenderer sprite in sprites.GetComponentsInChildren<SpriteRenderer>())
            graphics.Add(sprite);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (fade)
        {
            lerpNum -= Time.deltaTime * 2;
            spriteColor.a = lerpNum;
            foreach (SpriteRenderer sprite in graphics)
                sprite.color = spriteColor;
            if (lerpNum <= 0f)
                Destroy(gameObject);
        }
        else
            GetComponent<Rigidbody2D>().AddForce(direction * Time.deltaTime * 40f * 300); // may need to change 10f to match player speed if its changed
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Character")
            fade = true;
    }

    public void SetDirection(Vector2 direction)
    {
        if (direction.x != 0f || direction.y != 0f) // interpret player movement if they're moving
        {
            float x = direction.x;
            float y = direction.y;
            if (direction.x > 0f)
                x = 1;
            else if (direction.x < 0f)
                x = -1;
            if (direction.y > 0f)
                y = 1;
            else if (direction.y < 0f)
                y = -1;
            this.direction = new Vector2(-x, -y);
        }
        else // if player not moving go in random direction
        {
            do
            {
                this.direction = new Vector2(Mathf.Round(Random.Range(-1f, 1f)), Mathf.Round(Random.Range(-1f, 1f)));
            }
            while (this.direction.x == 0f && this.direction.y == 0f);
        }
        float angle = Mathf.Atan2(this.direction.y, this.direction.x) * Mathf.Rad2Deg;
        Quaternion lookRot = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        sprites.transform.rotation = Quaternion.RotateTowards(sprites.transform.rotation, lookRot, 360f);
    }
}
