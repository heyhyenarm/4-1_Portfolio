using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NHR
{
    public class PlayerController : MonoBehaviour
    {
        public SmartWatchCustomInteractable watch;

        private void Awake()
        {
            if (this.watch == null) this.watch = GetComponentInChildren<SmartWatchCustomInteractable>();
        }
    }

}
