using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLookTowards : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float rotationSpeed;

    private Vector3 dir;
    private float angle;
    private Quaternion lookRot;

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.inputVector != Vector2.zero)
        {
            dir = new Vector3(transform.position.x + playerMovement.inputVector.x, transform.position.y + playerMovement.inputVector.y, 0f) - transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            lookRot = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, 360f * rotationSpeed * Time.deltaTime);
        }
    }
}
