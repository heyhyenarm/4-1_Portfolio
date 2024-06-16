
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace NHR
{
    public class CustomDirectInteractor : XRDirectInteractor
    {
        private void Start()
        {
            base.Start();
            this.selectEntered.AddListener(SelectEntered);
            this.selectExited.AddListener(SelectExited);
        }
        private void SelectEntered(SelectEnterEventArgs args)
        {
            Debug.Log("Select Enter");
            if(args.interactableObject.transform.GetComponent<IItem>() != null)
            {
                IItem item = args.interactableObject.transform.GetComponent<IItem>();
                item.Grab();
            }
        }
        
        private void SelectExited(SelectExitEventArgs args)
        {
            Debug.Log("Select Exit");
            if (args.interactableObject.transform.GetComponent<IItem>() != null)
            {
                IItem item = args.interactableObject.transform.GetComponent<IItem>();
                item.Release();
            }

        }
    }

}
