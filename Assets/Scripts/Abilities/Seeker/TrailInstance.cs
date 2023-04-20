using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailInstance : MonoBehaviour
{
    public float lifeTime = 1f;
    private float lifeTimer;
    private float shrinkTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeTime;
        shrinkTimer = 0f;

        GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(DelayCollision());
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            shrinkTimer += Time.deltaTime;
            transform.localScale = transform.localScale * (1 - shrinkTimer);
            if (shrinkTimer >= 1)
                Destroy(gameObject);
        }

    }

    private IEnumerator DelayCollision()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
