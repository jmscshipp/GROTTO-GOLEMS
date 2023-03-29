using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{
    public Transform leftSpawn, rightSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //ResetRoom();
    }

    public IEnumerator ResetRoom(bool forMove) // forMove should be set to true when resetting because of room switch, not char death
    {
        GameObject saw, character;

        if (forMove == false)
        {
            saw = GameObject.FindWithTag("Saw");
            character = GameObject.FindWithTag("Character");
        }
        else
        {
            character = GameObject.FindWithTag("Saw");
            saw = GameObject.FindWithTag("Character");
        }
        

        if (saw.GetComponent<roles>().direction) // new character trying to go right
        {
            saw.transform.position = leftSpawn.position;
            character.transform.position = rightSpawn.position;
        }
        else // character trying to go left
        {
            saw.transform.position = rightSpawn.position;
            character.transform.position = leftSpawn.position;
        }

        yield return new WaitForSeconds(0.01f);
        if (forMove == false)
        {
            saw.GetComponent<roles>().roleSwitch();
            character.GetComponent<roles>().roleSwitch();
        } 
    }
}
