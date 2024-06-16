using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected InputActionAsset inputActionAsset;
    [SerializeField] protected ActionBasedContinuousMoveProvider moveProvider;
    [SerializeField] protected Animator animator;
    [SerializeField] protected PhotonView pv;

    protected Vector2 dir;

    public virtual void Start()
    {
        animator = this.GetComponent<Animator>();
        pv = this.transform.GetComponentInParent<PhotonView>();
        moveProvider = FindObjectOfType<ActionBasedContinuousMoveProvider>();
        inputActionAsset = Resources.Load<InputActionAsset>("XRI Default Input Actions");
    }


    public virtual void PlayerMove() // 걷기 입력 이벤트
    {
        Vector2 _movePosition = inputActionAsset.actionMaps[3].actions[5].ReadValue<Vector2>();

        dir = new Vector2(_movePosition.x, _movePosition.y).normalized;
    }
}
