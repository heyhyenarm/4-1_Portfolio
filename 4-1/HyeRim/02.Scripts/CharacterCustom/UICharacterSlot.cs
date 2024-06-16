using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NHR
{
    public class UICharacterSlot : MonoBehaviour
    {
        public Button buttonCharacterSlot;
        public TMP_Text textCharacterName;
        public Image imageCharacter;
        public Image imageFrame;
        public int characterNum;

        public void Init()
        {
            this.buttonCharacterSlot = this.GetComponent<Button>();
            //this.textCharacterName = this.GetComponentInChildren<TMP_Text>();
            Image[] images = this.GetComponentsInChildren<Image>();
            this.imageCharacter = images[0];
            this.imageFrame = images[1];
            this.imageFrame.color = new Color(0.7f, 0f, 0f, 0.5f);
            this.OnUnselected();
        }

        public void OnSelected()
        {
            this.imageCharacter.color = Color.white;
            this.imageFrame.gameObject.SetActive(true);
        }
        public void OnUnselected()
        {
            this.imageCharacter.color = new Color(0.5f, 0.5f, 0.5f);
            this.imageFrame.gameObject.SetActive(false);
        }
    }

}
