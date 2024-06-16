using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NHR
{
    public class UIClothesColor : MonoBehaviour
    {
        public int index;
        public Button btnColor;
        public GameObject selectedGo;
        //나중에 동적으로 바꿀 것
        public string textureName;
        private void Awake()
        {
            this.btnColor = this.GetComponent<Button>();
            Image[] gos = this.GetComponentsInChildren<Image>();
            this.selectedGo = gos[1].gameObject;
            this.selectedGo.SetActive(false);
        }
    }

}
