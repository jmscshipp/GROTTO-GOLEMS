using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public Vector2 inputVector = Vector2.zero;

    public float speed = 9.95f; // default speed of enem, because char is set to 10 when spawned in in roles script

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GetComponent<Rigidbody2D>().AddForce(inputVector * Time.deltaTime * speed * 300.0f);
    }

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    if (abilityManager.onMenu == false)
    //        inputVector = context.ReadValue<Vector2>();
    //}
}
