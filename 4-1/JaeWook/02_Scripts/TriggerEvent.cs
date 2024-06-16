using System.Collections;
using System.Collections.Generic;
using Jaewook;
using UnityEngine;

namespace Jaewook
{
    public class TriggerEvent : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IItem>() != null)
            {
                IItem it = other.GetComponent<IItem>();

                it.OnGrab();
            }
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<IItem>() != null)
            {
                IItem it = other.GetComponent<IItem>();

                if (Input.GetMouseButton(0))
                {
                    it.OnUse();
                }
            }


        }
        /*
        public void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<IItem>() != null)
            {
                IItem it = other.GetComponent<IItem>();
                it.Release();

            }
        }
        */
    }

}
