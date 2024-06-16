using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : PlayerMovement
{
    private void Update()
    {
        PlayerMove();
    }
    public override void PlayerMove() // 걷기 
    {
        if (pv.IsMine)
        {
            base.PlayerMove();
            moveProvider.moveSpeed = 10f;
            animator.SetFloat("Walk", dir.magnitude); // 블렌트 트리 임계값을 0 ~ 1로 설정
        }
    }
}


    //private void FixedUpdate()
    //{
    //    Jump();
    //}
    //public override void Jump()
    //{
    //    base.Jump();
    //}
