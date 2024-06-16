using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace NHR
{
    public class UIKeyboard : MonoBehaviour
    {
        public Key[] keys;

        private void Start()
        {
            this.keys = GetComponentsInChildren<Key>();

            //버튼 이벤트
            for (int i = 0; i < keys.Length; i++)
            {
                var key = this.keys[i];
                key.buttonKey.onClick.AddListener(() =>
                {
                    var text = key.textKey.text;
                    //Debug.LogFormat("<color=yellow>button {0} clicked</color>", key.textKey.text);
                    EventDispatcher.instance.SendEvent<string>((int)NHR.EventType.eEventType.Input_Key, text);
                });
            }
        }
    }

}
