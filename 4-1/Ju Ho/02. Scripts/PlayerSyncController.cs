using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class PlayerSyncController : MonoBehaviour
{
    PhotonView pv;
    RiggingManager riggingManager;
    PlayerMovement playerMovement;
    HumanMovement humanMovement;
    MonsterMovement monsterMovement;

    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    // xr origin의 헤드, 왼손, 오른손
    Transform headRig;
    Transform leftHandRig;
    Transform rightHandRig;

    Transform lefttHandIK_hint;
    Transform rightHandIK_hint;


    RaycastHit hitInfo;

    void Start()
    {
        pv = this.GetComponent<PhotonView>();

        ChangeLayer(this.gameObject, 7); // 플레이어 레이어 설정
        if(pv.IsMine)
        {
            XROrigin origin = FindObjectOfType<XROrigin>();
            headRig = origin.transform.GetChild(0).GetChild(0);      // xr origin / camera offset / main camera
            leftHandRig = origin.transform.GetChild(0).GetChild(1);  // xr origin / camera offset / left controller
            rightHandRig = origin.transform.GetChild(0).GetChild(2); // xr origin / camera offset / right controller
            riggingManager = this.GetComponentInChildren<RiggingManager>();

            if (this.transform.GetComponentInChildren<HumanMovement>() != null)
            {
                humanMovement = this.GetComponentInChildren<HumanMovement>();
            }
            else
            {
                monsterMovement = this.GetComponentInChildren<MonsterMovement>();
            }
        }

        //if (this.transform.name == "Player")
        //{
        //    riggingManager = GameObject.Find("Banana Man").GetComponent<RiggingManager>();
        //}
        //else
        //{
        //    riggingManager = GameObject.Find("skinless zombie").GetComponent<RiggingManager>();
        //}
    }

    void Update()
    {
        //Debug.DrawRay(head.transform.position, - head.transform.up * 5f, Color.red);

        if (pv.IsMine)
        {
            if (headRig.transform.position.y > riggingManager.modelHeight)
            {
                float floor = headRig.transform.position.y > 5f ? 5.3f : 0f;

                headRig.transform.position = new Vector3(headRig.transform.position.x, riggingManager.modelHeight + floor, headRig.transform.position.z);
                //Debug.Log(headRig.transform.position); 
                head.transform.position = new Vector3(head.transform.position.x, riggingManager.modelHeight + floor, head.transform.position.z);
            }

            SyncTransform(head, headRig);
            SyncTransform(leftHand, leftHandRig);
            SyncTransform(rightHand, rightHandRig);
       
        }
    }

    void SyncTransform(Transform targetTf, Transform rigTf)
    {
        targetTf.position = rigTf.position;
        targetTf.rotation = rigTf.rotation;
    }

    void ChangeLayer(GameObject obj, int layer) // 플레이어 레이어 설정
    {
        if(pv.IsMine)
        {
            obj.layer = layer;

            foreach (Transform child in obj.transform)
            {
                ChangeLayer(child.gameObject, layer);
            }
        }
    }
}
