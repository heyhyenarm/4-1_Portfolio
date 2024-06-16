using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NHR
{
    public class TutorialQuestObject : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player in");
                EventDispatcher.instance.SendEvent((int)NHR.EventType.eEventType.Clear_TutorialQuest);
                this.gameObject.SetActive(false);
            }
        }
    }

}
