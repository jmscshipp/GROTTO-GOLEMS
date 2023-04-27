using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //[HideInInspector]
    //public Vector2 inputVector = Vector2.zero;
    //
    //public float speed = 9.95f; // default speed of enem, because char is set to 10 when spawned in in roles script
    //
    //// Update is called once per frame
    ////void FixedUpdate()
    ////{
    ////    GetComponent<Rigidbody2D>().AddForce(inputVector * Time.fixedDeltaTime * speed * 300.0f);
    ////}
    //
    //void Update()
    //{
    //    GetComponent<Rigidbody2D>().AddForce(inputVector * Time.deltaTime * speed * 300);
    //}
    //
    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    Debug.Log("callback getting called");
    //    //if (abilityManager.onMenu == false)
    //    inputVector = context.ReadValue<Vector2>();
    //}

    [HideInInspector]
    public Vector2 inputVector = Vector2.zero;
    //[HideInInspector]
    public float speed = 9.95f; // default speed of enem, because char is set to 10 when spawned in in roles script

    private void Awake()
    {

    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(inputVector * Time.deltaTime * speed * 300);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("current control scheme: " + GetComponent<PlayerInput>().currentControlScheme);
        inputVector = context.ReadValue<Vector2>().normalized;
    }
}
