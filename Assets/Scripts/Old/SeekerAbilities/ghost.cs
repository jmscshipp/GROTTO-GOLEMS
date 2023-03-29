using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : ability
{
    public CircleCollider2D playerCollider;
    public CircleCollider2D playerArmsCollider;
    public List<SpriteRenderer> playerSprites = new List<SpriteRenderer>();
    public List<TrailRenderer> trailRenderers = new List<TrailRenderer>();
    public Color ghostColor;
    private float timer; // for when you can use ability
    private bool active = false;
    private float activeTimer = .2f; // for how long dash effect happens once active

    // Start is called before the first frame update
    void Start()
    {
        timer = coolDown;
        playerCollider = transform.parent.GetComponent<CircleCollider2D>();
        playerArmsCollider = transform.parent.Find("sawGraphics").Find("arms").GetComponent<CircleCollider2D>();
        foreach (TrailRenderer trail in playerArmsCollider.gameObject.GetComponentsInChildren<TrailRenderer>())
            trailRenderers.Add(trail);
        foreach (SpriteRenderer renderer in transform.parent.Find("sawGraphics").GetComponentsInChildren<SpriteRenderer>())
        {
            if (renderer.gameObject.tag != "RevealerSprite" && renderer.gameObject.tag != "White")
                playerSprites.Add(renderer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (active == true)
        {
            activeTimer -= Time.deltaTime;
            if (activeTimer <= 0f)
            {
                GetComponent<ParticleSystem>().Stop();
                foreach (TrailRenderer trail in trailRenderers)
                    trail.emitting = true;
                foreach (SpriteRenderer renderer in playerSprites)
                    renderer.color = Color.white;
                playerCollider.enabled = true; // going to have to tweak when player speed gets updated in movement
                playerArmsCollider.enabled = true;
                active = false;
            }
        }
        else
            timer += Time.deltaTime;
    }

    public override void Use()
    {
        if (timer >= coolDown)
        {
            activeTimer = .75f;
            GetComponent<ParticleSystem>().Play();
            //Color halfOpacity = Color.white; // partly transparent
            //.a = 0.5f;
            //playerSprite.color = halfOpacity;
            foreach (TrailRenderer trail in trailRenderers)
                trail.emitting = false;
            foreach (SpriteRenderer renderer in playerSprites)
                renderer.color = ghostColor;
            playerCollider.enabled = false; // collider off
            playerArmsCollider.enabled = false;
            active = true;
            timer = 0f;
        }
    }
}
