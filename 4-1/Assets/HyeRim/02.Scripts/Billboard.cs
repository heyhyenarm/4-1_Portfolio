using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
    public enum Axis
    {
        X,
        Y,
        Z
    }

    public Axis lookAxis = Axis.Y;

    public Transform targetTf;
    public bool isTargetCamera = true;

    void Start()
    {
        if (isTargetCamera)
        {
            targetTf = Camera.main.transform;
        }
    }

    void Update()
    {
        transform.LookAt(this.transform.position + targetTf.transform.rotation * Vector3.forward, targetTf.transform.rotation * Vector3.up);

        var currRot = this.transform.localEulerAngles;

        if (lookAxis == Axis.X)
        {
            currRot.y = 0f;
            currRot.z = 0f;
        }
        else if (lookAxis == Axis.Y)
        {
            currRot.x = 0f;
            currRot.z = 0f;
        }
        else if (lookAxis == Axis.Z)
        {
            currRot.x = 0f;
            currRot.y = 0f;
        }

        this.transform.localEulerAngles = currRot;
    }
}