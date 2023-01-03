using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : ability
{
    public GameObject duplicatePrefab;
    private movement playerMovement;
    private float timer; // for when you can use ability
    private bool active = false;
    private float activeTimer = .2f; // for how long dash effect happens once active
    // Start is called before the first frame update
    void Start()
    {
        timer = coolDown;
        playerMovement = transform.parent.GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (active == true)
        {
            activeTimer -= Time.deltaTime;
            playerMovement.speed = 100f; // going to have to tweak when player speed gets updated in movement
            if (activeTimer <= 0f)
            {
                playerMovement.speed = 50f; // going to have to tweak when player speed gets updated in movement
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
            activeTimer = .2f;
            StartCoroutine(spawnDuplicates(activeTimer));
            active = true;
            timer = 0f;
        }
    }

    private IEnumerator spawnDuplicates(float timerLength)
    {
        List<GameObject> duplicates = new List<GameObject>();
        float counter = timerLength / 4f;
        for (float i = 0; i < 4; i ++)
        {
            GameObject newDupe = Instantiate(duplicatePrefab, transform.parent.position, Quaternion.identity);
            float angle = Mathf.Atan2(playerMovement.inputVector.y, playerMovement.inputVector.x) * Mathf.Rad2Deg;
            Quaternion lookRot = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            newDupe.transform.rotation = Quaternion.RotateTowards(newDupe.transform.rotation, lookRot, 360f);
            //for setting transparency of afterimage
            Color temp = Color.white;
            temp.a = counter / timerLength;
            newDupe.GetComponent<SpriteRenderer>().color = temp;

            duplicates.Add(newDupe);
            counter += timerLength / 4f;
            yield return new WaitForSeconds(timerLength / 4f);
        }
        foreach (GameObject obj in duplicates)
        {
            Destroy(obj);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
