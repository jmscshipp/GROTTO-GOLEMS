using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decoy : ability
{
    public GameObject decoyPrefab;
    private GameObject thisDecoy;
    private movement playerMovement;
    private float timer; // for when you can use ability
    private bool active = false;

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
            if (thisDecoy == null)
                active = false;
        }
        else
            timer += Time.deltaTime;
    }

    public override void Use()
    {
        if (timer >= coolDown)
        {
            thisDecoy = Instantiate(decoyPrefab, transform.position, Quaternion.identity);
            thisDecoy.GetComponent<decoyObj>().SetDirection(playerMovement.inputVector);
            active = true;
            timer = 0f;
        }
    }
}
