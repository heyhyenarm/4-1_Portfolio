using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NHR
{
    public class UIHeart : MonoBehaviour
    {
        public GameObject imageDeath;

        private void Awake()
        {
            this.imageDeath.SetActive(false);
        }
    }

}
