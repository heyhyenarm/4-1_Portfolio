using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NHR
{
    public class UIRole : MonoBehaviour
    {
        public TMP_Text textRole;
        public TMP_Text textQuest;

        public void Init()
        {
            this.textRole.text = "";
            this.textQuest.text = "";
        }
    }

}
