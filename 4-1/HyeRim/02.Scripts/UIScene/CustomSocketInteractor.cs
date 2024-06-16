using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

namespace NHR
{
    public class CustomSocketInteractor : XRSocketInteractor
    {
        public Image imgSocket;
        private Color color;

        private void Start()
        {
            this.selectEntered.AddListener(SelectEntered);
            this.selectExited.AddListener(SelectExited);
            this.hoverEntered.AddListener(HoverEnterd);
            this.hoverExited.AddListener(HoverExited);
            this.color = this.imgSocket.color;
        }
        private void SelectEntered(SelectEnterEventArgs args)
        {
            //잡혀있는 물체 투명화
            args.interactableObject.transform.GetComponent<MeshRenderer>().enabled = false;
        }
        private void SelectExited(SelectExitEventArgs args)
        {
            args.interactableObject.transform.GetComponent<MeshRenderer>().enabled = true;
        }
        private void HoverEnterd(HoverEnterEventArgs args)
        {
            this.imgSocket.color = Color.yellow;
        }
        private void HoverExited(HoverExitEventArgs args)
        {
            this.imgSocket.color = this.color;
        }
    }

}
