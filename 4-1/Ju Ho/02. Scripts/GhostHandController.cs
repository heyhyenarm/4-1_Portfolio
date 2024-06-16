using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhostHandController : MonoBehaviour
{
    PhotonView pv;
    HumanMovement humanMovement;
    Animator animator;
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            humanMovement = this.transform.root.GetChild(i).GetComponent<HumanMovement>();
            if (humanMovement != null)
                break;
        }

        animator = this.GetComponent<Animator>();
        pv = this.transform.root.GetComponent<PhotonView>();
        //inputActionAsset = Resources.Load<InputActionAsset>("XRI Default Input Actions");
    }

    // Update is called once per frame
    void Update()
    {
        humanMovement.FingerMove(animator);
    }
}
