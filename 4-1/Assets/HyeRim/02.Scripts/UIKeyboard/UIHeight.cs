using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NHR
{
    public class UIHeight : MonoBehaviour
    {
        public TMP_Text textHeight;
        public UIKeyboard uiKeyboard;

        private void Awake()
        {
            this.uiKeyboard = GetComponentInParent<UIKeyboard>();
        }
        private void Start()
        {
            EventDispatcher.instance.AddEventHandler<string>((int)NHR.EventType.eEventType.Input_Key, new EventHandler<string>((type, inputText) =>
            {
                //Debug.LogFormat("key {0} input", inputText);

                //키 Reset, Enter, 숫자 키들 기능 나눔
                if (inputText == "Reset") this.textHeight.text = "";
                else if (inputText == "Enter")
                {
                    InfoManager.Instance.HeightInfo.height = int.Parse(this.textHeight.text);
                    this.uiKeyboard.gameObject.SetActive(false);
                }
                else this.textHeight.text += inputText;
            }));

        }
    }

}
