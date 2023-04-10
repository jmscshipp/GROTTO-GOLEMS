using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : Ability
{
    private PlayerMovement playerMovement;

    // settings
    float speedIncreaseMultiplier = 2f;
    public GameObject afterImagePrefab;

    // Start is called before the first frame update
    void Start()
    {
        // general timer set up
        active = false;
        activeTime = 0.2f;
        timeSinceActivation = activeTime;
        coolDown = 0.7f;
        lastUseTimeStamp = 0f;

        // specific to this ability
        playerMovement = transform.parent.GetComponent<PlayerMovement>();
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
            playerMovement.speed *= speedIncreaseMultiplier;
            StartCoroutine(SpeedEffect(timeSinceActivation));
        }
    }

    public override void Deactivate()
    {
        // ability timer stuff
        active = false;

        // ability effects
        playerMovement.speed /= speedIncreaseMultiplier;
    }

    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // this effect would look better if the afterimages faded out!
    // come back and do that

    private IEnumerator SpeedEffect(float timerLength)
    {
        List<GameObject> duplicates = new List<GameObject>();
        float counter = timerLength / 4f;
        for (float i = 0; i < 4; i++)
        {
            GameObject afterImage = Instantiate(afterImagePrefab, transform.parent.position, Quaternion.identity);

            // correcting rotation
            float angle = Mathf.Atan2(playerMovement.inputVector.y, playerMovement.inputVector.x) * Mathf.Rad2Deg;
            Quaternion lookRot = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            afterImage.transform.rotation = Quaternion.RotateTowards(afterImage.transform.rotation, lookRot, 360f);

            // setting transparency of afterimage
            Color temp = Color.white;
            temp.a = counter / timerLength;
            afterImage.GetComponent<SpriteRenderer>().color = temp;

            duplicates.Add(afterImage);
            counter += timerLength / 4f;
            yield return new WaitForSeconds(timerLength / 4f);
        }

        // cleanup
        foreach (GameObject obj in duplicates)
        {
            Destroy(obj);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
