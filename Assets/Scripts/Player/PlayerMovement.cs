using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [HideInInspector]
    public Vector2 inputVector = Vector2.zero;
    //[HideInInspector]
    public float speed = 9.95f; // default speed of enem, because char is set to 10 when spawned in in roles script
    public bool canMove = false;

    private void Awake()
    {

    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
            GetComponent<Rigidbody2D>().AddForce(inputVector * Time.deltaTime * speed * 300);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("current control scheme: " + GetComponent<PlayerInput>().currentControlScheme);
        inputVector = context.ReadValue<Vector2>().normalized;
    }
}
