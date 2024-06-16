using Jaewook;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomGrabInteractor : XRGrabInteractable
{
    void Start()
    {
        this.activated.AddListener(ActivatedEvent);
    }

    private void ActivatedEvent(ActivateEventArgs args)
    {
        if (args.interactableObject.transform.GetComponent<IItem>() != null)
        {
            IItem item = args.interactableObject.transform.GetComponent<IItem>();

            item.OnUse();
        }
    }

}
