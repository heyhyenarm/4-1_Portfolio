//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HandGun : MonoBehaviour, Jaewook.IItem
//{
//    public Transform fireTF;
//    public float shootSpeed = 10f;

//    public void OnGrab()
//    {
//        //
//    }

//    public void OnUse()
//    {
//        Debug.Log("핸드건을 사용했다");
//        GameObject bullet = ObjectPool.Instance.OnDequeue();

//        // Gun의 fire transfrom 위치로 초기화
//        bullet.transform.SetPositionAndRotation(fireTF.position, fireTF.rotation);

//        // 총알 생성, 발사
//        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
//        bulletRb.AddForce(fireTF.forward * shootSpeed, ForceMode.Impulse);
        
//    }
//}
