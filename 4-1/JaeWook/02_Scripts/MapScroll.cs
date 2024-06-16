using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jaewook
{
    public class MapScroll : MonoBehaviour, IItem
    {
        public RawImage mapUI;

        private void Start()
        {
            mapUI = GetComponentInChildren<RawImage>();

            if (mapUI != null)
            {
                mapUI.enabled = false;
            }
            else
            {
                Debug.LogError("Map UI 없음");
            }
        }

        public void OnGrab()
        {
            if (mapUI != null)
            {
                mapUI.enabled = true;
                Debug.Log("지도 잡음, UI 활성화");
            }
        }

        public void OnUse()
        {
            // 필요시 추가 기능 구현
        }

        public void OnRelease()
        {
            if (mapUI != null)
            {
                mapUI.enabled = false;
            }
        }
    }
}
