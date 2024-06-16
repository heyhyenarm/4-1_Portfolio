using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeongMin 
{
    /// <summary>
    /// 이 스크립트는 테스트 용 현재 사용 안함
    /// </summary>
    public class PlayerData : MonoBehaviour
    {
        private void Awake()
        {
            GameDB.Instance.myPlayer = this.gameObject;
        }
    }
}
