using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NHR
{
    public class UISettings : MonoBehaviour
    {
        public Button buttonClose;

        private void Awake()
        {
            this.gameObject.SetActive(false);
        }
        private void Start()
        {
            this.buttonClose.onClick.AddListener(() =>
            {
                Debug.Log("setting close");
                this.gameObject.SetActive(false);
            });
        }

    }

}
