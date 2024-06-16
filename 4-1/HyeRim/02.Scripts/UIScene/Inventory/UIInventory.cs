using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NHR
{
    public class UIInventory : MonoBehaviour
    {
        public HandMenu handMenu;
        public GameObject inventory;
        public bool isOpened = false;

        private void Awake()
        {
            this.isOpened = false;
            this.inventory.SetActive(false);
            this.handMenu.gameObject.SetActive(false);
        }
        private void Start()
        {
            this.handMenu.buttonOpenInventory.onClick.AddListener(() =>
            {
                Debug.Log("Open Inventory");
                this.inventory.SetActive(!this.isOpened);
                this.isOpened = !this.isOpened;
            });
        }
    }

}
