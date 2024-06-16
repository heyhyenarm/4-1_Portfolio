using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NHR
{
    public class TitleSceneManager : MonoBehaviour
    {
        public UIKeyboard uiKeyboard;
        private void Awake()
        {
            this.uiKeyboard = FindObjectOfType<UIKeyboard>();
            this.Init();
        }
        public void Init()
        {
            //키 측정 유무
            this.uiKeyboard.gameObject.SetActive(false);
            if (InfoManager.Instance.HeightInfo.height==0)
            {
                this.uiKeyboard.gameObject.SetActive(true);
            }
        }
    }

}
