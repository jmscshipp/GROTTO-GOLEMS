using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lantern : ability
{
    public GameObject lanternPrefab;
    private GameObject[] lanterns = new GameObject[2];
    private int activeLanternNum = 0; // first lantern is 0, second is 1
    private int lastLanternIndex = 0;
    private float useTimer = 0.5f;

    private void Update()
    {
        useTimer += Time.deltaTime;
    }
    public override void Use()
    {
        if (useTimer >= 0.5f)
        {
            if (activeLanternNum < 2)
            {
                lanterns[activeLanternNum] = Instantiate(lanternPrefab, transform.position, Quaternion.identity);
                lastLanternIndex = activeLanternNum;
                activeLanternNum++;
            }
            else
            {
                int index;
                if (lastLanternIndex == 0)
                    index = 1;
                else
                    index = 0;
                lanterns[index].transform.position = transform.position;
                lastLanternIndex = index;
            }
            useTimer = 0f;
        }
    }

    private void OnDestroy()
    {
        Destroy(lanterns[0]);
        Destroy(lanterns[1]);
    }
}
