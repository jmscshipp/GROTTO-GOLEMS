using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAbility : Ability
{
    public Color ghostColor;
    private SpriteRenderer[] playerSprites;
    private TrailRenderer[] trails;
    private CircleCollider2D[] colliders;
    private ParticleSystem[] particles;

    // Start is called before the first frame update
    void Start()
    {
        // general timer setup
        active = false;
        activeTime = 0.7f;
        timeSinceActivation = activeTime;
        coolDown = 0.7f;
        lastUseTimeStamp = 0f;

        // specific to this ability
        playerSprites = transform.parent.GetComponentsInChildren<SpriteRenderer>();
        trails = transform.parent.GetComponentsInChildren<TrailRenderer>();
        colliders = transform.parent.GetComponentsInChildren<CircleCollider2D>();
        particles = GetComponentsInChildren<ParticleSystem>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            timeSinceActivation -= Time.deltaTime;
            if (timeSinceActivation <= 0)
            {
                Deactivate();
            }
        }
    }
    
    public override void Activate()
    {
        if (Time.time - lastUseTimeStamp > coolDown)
        {
            // ability timer stuff
            active = true;
            timeSinceActivation = activeTime;
            lastUseTimeStamp = Time.time;

            // ability effects
            foreach (ParticleSystem particleSystem in particles)
                particleSystem.Play();
            foreach (TrailRenderer trail in trails)
                trail.emitting = false;
            foreach (SpriteRenderer renderer in playerSprites)
                renderer.color = ghostColor;
            foreach (CircleCollider2D collider in colliders) // won't be able to collide with player either..
                collider.enabled = false;
        }
    }
    
    public override void Deactivate()
    {
        // ability timer stuff
        active = false;

        // ability effects
        foreach (ParticleSystem particleSystem in particles)
            particleSystem.Stop();
        foreach (TrailRenderer trail in trails)
            trail.emitting = true;
        foreach (SpriteRenderer renderer in playerSprites) 
            renderer.color = Color.white;
        foreach (CircleCollider2D collider in colliders) // won't be able to collide with player either..
            collider.enabled = true;
    }
}
