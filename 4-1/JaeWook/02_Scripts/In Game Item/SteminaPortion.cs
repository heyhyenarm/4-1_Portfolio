using System.Collections;
using System.Collections.Generic;
using Jaewook;
using UnityEngine;
//using UnityEngine.SocialPlatforms.Impl;

namespace Jaewook
{
    /// <summary>
    /// 스테미너 포션 -> 랜덤 배치 or 주기적으로 리스폰 ( singleton )
    /// </summary>
    public class SteminaPortion : MonoBehaviour, IItem
    {
        public GameObject pickupEffect;
        public GameObject useEffect;

        public void OnGrab()
        {
            // 스테미너 물약의 효과
            Instantiate(pickupEffect, this.transform.position, Quaternion.identity);

           
        }

        public void OnUse()
        {
            // 스테미너 회복 효과
            Instantiate(useEffect, this.transform.position, Quaternion.identity);
            Debug.Log("Health Potion Used");

            // stemina 회복 로직
            
        }

        public void OnRelease()
        {
            throw new System.NotImplementedException();
        }
    }

}
