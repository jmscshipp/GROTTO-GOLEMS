using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanternObj : MonoBehaviour
{
    public Sprite lanternSprite1;
    public Sprite lanternSprite2;
    private static bool firstLanternSpawned = false;
    private Vector2 newDest = Vector2.zero;
    private Vector2 oldDest;
    private float lerpCounter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (!firstLanternSpawned)
        {
            GetComponent<SpriteRenderer>().sprite = lanternSprite1;
            firstLanternSpawned = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = lanternSprite2;
            firstLanternSpawned = false; // for next room
        }
        SetNewDest();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 100f);
        lerpCounter += Time.deltaTime/2f;
        transform.localPosition = Vector2.Lerp(oldDest, newDest, lerpCounter);
        if (transform.localPosition == new Vector3(newDest.x, newDest.y, 0f))
            SetNewDest();
    }

    private void SetNewDest()
    {
        oldDest = newDest;
        newDest = Random.insideUnitCircle / 5f;
        lerpCounter = 0f;
    }
}
