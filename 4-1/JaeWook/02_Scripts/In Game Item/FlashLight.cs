using System.Collections;
using System.Collections.Generic;
using SeongMin;
using UnityEngine;

namespace Jaewook
{
    public class FlashLight : ItemObject, IItem
    {
        public bool isOn = false;
        public Light flashlight;

        protected void Start()
        {
            base.Start(); // ItemObject의 Start 메서드를 호출하여 씬과 캐릭터에 따라 등록
            flashlight = GetComponentInChildren<Light>();
            if (flashlight != null)
            {
                flashlight.enabled = isOn;
            }
        }

        public void OnGrab()
        {
            
            
        }

        public void OnUse()
        {
            // 트리거 버튼을 눌렀을 때 플래시라이트 켜기/끄기
            isOn = !isOn;
            flashlight.enabled = isOn;

            //Debug.Log("Flashlight Used: " + (isOn ? "On" : "Off"));
        }

        public void OnRelease()
        {
            
            //Debug.Log("Flashlight Released");
        }
    }
}
