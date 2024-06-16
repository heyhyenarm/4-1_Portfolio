using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jaewook
{
    public class PlayerActiveSkill : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            IItem item = other.GetComponent<IItem>();
            IOpenable openable = other.GetComponent<IOpenable>(); 
            
            if (item != null)
            {
                // item.OnUse();
                // Destroy(other.gameObject);
            }
            if(openable != null)
            {
                openable.Open();
            }

        }
        public void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<IItem>() != null)
            {
                IItem item = other.GetComponent<IItem>();

                if (Input.GetMouseButton(0))
                {
                    item.OnUse();
                }
            }
        }
        /*
        public void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<IItem>() != null)
            {
                IItem item = other.GetComponent<IItem>();
                item.Release();
            }
        }
        */
    }
}
