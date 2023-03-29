using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    [HideInInspector]
    public Vector2 inputVector = Vector2.zero;
    //[HideInInspector]
    public float speed = 9.95f; // default speed of enem, because char is set to 10 when spawned in in roles script

    // Update is called once per frame
    void Update()
    {
        if (abilityManager.onMenu == false)
            GetComponent<Rigidbody2D>().AddForce(inputVector * Time.deltaTime * speed * 300);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (abilityManager.onMenu == false)
            inputVector = context.ReadValue<Vector2>();
    }
}
