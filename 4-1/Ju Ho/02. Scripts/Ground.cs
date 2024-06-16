using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    PlayerMovement pm;

    private void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            //pm.isGround = true;
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            //pm.isGround = false;
        }
    }
}
