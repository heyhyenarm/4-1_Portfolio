using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jaewook;
using UnityEngine.XR.Interaction.Toolkit;

namespace Jaewook
{
    /// <summary>
    /// Player -> Custom Direct Grab
    /// </summary>
    public class CustomXRDirectInteractor : XRDirectInteractor
    {
        protected override void Start()
        {
            base.Start();
            this.selectEntered.AddListener(SelectSomething);
        }

        private void SelectSomething(SelectEnterEventArgs args)
        {
            if (args.interactableObject.transform.GetComponent<Jaewook.IItem>() != null)
            {
                IItem item = args.interactableObject.transform.GetComponent<IItem>();
                item.OnGrab();

            }
        }

        
        private void ActivateSomething(ActivateEventArgs args)
        {
            if (args.interactorObject.transform.GetComponent<Jaewook.IItem>() != null)
            {
                IItem item = args.interactorObject.transform.GetComponent<Jaewook.IItem>();

                item.OnUse();
            }
        }
        
        
        private void DeselectSomething(SelectExitEventArgs args)
        {
            if (args.interactableObject.transform.GetComponent<Jaewook.IItem>() != null)
            {
                IItem item = args.interactableObject.transform.GetComponent<Jaewook.IItem>();
                item.OnRelease();
            }
        }
    }
}
