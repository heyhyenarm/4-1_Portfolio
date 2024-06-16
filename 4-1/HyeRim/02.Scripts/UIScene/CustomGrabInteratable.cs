using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace NHR
{
    public class CustomGrabInteratable : XRGrabInteractable
    {
        public bool isSelectEntered = false;

        //임시
        private GameObject uiItem;

        private void Start()
        {
            this.selectEntered.AddListener(SelectEntered);
            this.selectExited.AddListener(SelectExited);

            //임시
            this.uiItem = this.gameObject.GetComponent<EnableInventoryObject>().uiGo;
        }
        private void SelectEntered(SelectEnterEventArgs args)
        {
            //Debug.Log("SelectEntered");
            //이벤트 나중에 바꾸기
            this.uiItem.SetActive(false);
            this.isSelectEntered = true;
        }
        private void SelectExited(SelectExitEventArgs args)
        {
            this.uiItem.SetActive(true);
        }
    }

}
