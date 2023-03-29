using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability : MonoBehaviour
{
    public float coolDown;

    public ability()
    {
        coolDown = 0.7f;
    }

    public virtual void Use()
    {

    }
}