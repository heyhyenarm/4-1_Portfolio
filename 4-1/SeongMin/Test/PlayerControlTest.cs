using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class PlayerControlTest : MonoBehaviour
{
    private PhotonView photonView;
    //Player²¨
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    //XR Origin ²¨
    public Transform headRig;
    public Transform rightHandRig;
    public Transform leftHandRig;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        XROrigin origin = FindObjectOfType<XROrigin>();

        headRig = origin.transform.GetChild(0).GetChild(0);
        rightHandRig = origin.transform.GetChild(0).GetChild(1);
        leftHandRig = origin.transform.GetChild(0).GetChild(2);
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            SyncTransform(head, XRNode.Head);
            SyncTransform(leftHand, XRNode.LeftHand);
            SyncTransform(rightHand, XRNode.RightHand);
        }
    }

    private void SyncTransform(Transform _targetTf, XRNode node)
    {
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 pos);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rot);

        _targetTf.position = pos;
        _targetTf.rotation = rot;
    }
}
