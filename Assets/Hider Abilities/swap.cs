using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swap : ability
{
    private Vector2 tempPosition;
    private float timer; // for when you can use abilit
    public GameObject particlesPrefab;
    private List<SpriteRenderer> whites = new List<SpriteRenderer>();
    // Start is called before the first frame update
    void Awake()
    {
        timer = coolDown;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("White"))
            whites.Add(obj.GetComponent<SpriteRenderer>());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.1f)
        {
            foreach (SpriteRenderer renderer in whites)
                renderer.enabled = false;
        }
    }

    public override void Use()
    {
        if (timer >= coolDown)
        {
            transform.parent.GetComponent<CircleCollider2D>().enabled = false;
            tempPosition = transform.parent.position;
            transform.parent.position = GameObject.FindGameObjectWithTag("Saw").transform.position;
            GameObject.FindGameObjectWithTag("Saw").transform.position = tempPosition;
            transform.parent.GetComponent<CircleCollider2D>().enabled = true;
            foreach (SpriteRenderer renderer in whites)
                renderer.enabled = true;
            timer = 0f;
        }
    }
}
