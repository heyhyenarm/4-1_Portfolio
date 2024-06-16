using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NHR
{
    public class EnableInventoryObject : InteractiveObject
    {
        public CustomGrabInteratable customGrab;

        private void Start()
        {
            //CustomGrabInteratable 추가 후 DynamicAttach 활성화
            this.customGrab = this.gameObject.AddComponent<CustomGrabInteratable>();
            this.gameObject.GetComponent<CustomGrabInteratable>().useDynamicAttach = true;

            //텍스트
            this.txtGo.GetComponent<TMP_Text>().text = "줍기";
            this.txtGo.SetActive(false);
        }
        private void OnBecameVisible()
        {
            if (this.customGrab.isSelectEntered) this.uiGo.SetActive(false);
        }
    }

}
