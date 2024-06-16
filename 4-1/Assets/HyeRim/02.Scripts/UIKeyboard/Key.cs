using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NHR
{
    public class Key : MonoBehaviour
    {
        public Button buttonKey;
        public TMP_Text textKey;

        private void Awake()
        {
            this.buttonKey = GetComponentInChildren<Button>();
            this.textKey = GetComponentInChildren<TMP_Text>();
        }
    }

}
