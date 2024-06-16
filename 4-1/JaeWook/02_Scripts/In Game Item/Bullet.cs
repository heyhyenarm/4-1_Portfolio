//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///// <summary>
///// 1. prefabs
///// </summary>
//namespace Jaewook
//{
//    public class Bullet : MonoBehaviour
//    {

//        public float damage = 10f;

//        void OnEnable() // setActive - true 상태면 계속 실행
//        {
//            Invoke("ReturnQueue", 2f); // 특정 행위 이후 실행 -> 함수 지연 실행
//        }

//        void OnDisable() // false할 때마다 실행
//        {
//            if (this.GetComponent<Rigidbody>() != null)
//            {
//                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
//                this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
//            }

//            CancelInvoke("ReturnQueue");
//        }

//        private void ReturnQueue()
//        {
//            ObjectPool.Instance.OnInit(this.gameObject);
//        }

//        /*
//        public void OnTriggerEnter(Collider other)
//        {
//            if (other.transform.root.GetComponent<CharacterHp>() != null)
//            {
//                CharacterHp hp = other.transform.root.GetComponent<CharacterHp>();
//                if (other.CompareTag("Head"))
//                {
//                    // 헤드샷 데미지
//                    hp.OnHit(damage * 3f);
//                }
//                else if (other.CompareTag("Body"))
//                {
//                    // 일반 데미지
//                    hp.OnHit(damage);
//                }
//            }
//        }
//        */
//    }
//}
