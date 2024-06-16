using System.Collections;
using System.Collections.Generic;
using Jaewook;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jaewook
{
    public class Letter : MonoBehaviour, IItem
    {
        public bool isOnMap = false;
        public TMP_Text letterUI;
        public Image image;

        private void Start()
        {
            letterUI = GetComponentInChildren<TMP_Text>();
            image = GetComponentInChildren<Image>();

            letterUI.text = " ㅇㅅㅇ ";

            // LetterUI가 비활성화 상태인지 확인합니다.
            if (letterUI != null)
            {
                image.enabled = isOnMap;
                letterUI.enabled = isOnMap;
            }
            // letterUI가 Inspector할당 확인
            else if (letterUI == null)
            {
                Debug.LogError("LetterUI가 없어");
            }
        }

        public void OnGrab()
        {
            // 현재 그랩에 문제가 있다 -> 그랩함수가 작동안함 -> custom interactable 문제?
            /*
            if (letterUI != null)
            {
                isOnMap = !isOnMap;
                image.enabled = isOnMap;
                letterUI.enabled = isOnMap;
                Debug.Log("로그확인용 (LetterUI 활성화 - 비활성화 성공)");
            }
            */
        }

        public void OnUse()
        {
           
            if (letterUI != null)
            {
                isOnMap = !isOnMap;
                image.enabled = isOnMap;
                letterUI.enabled = isOnMap;
                Debug.Log("로그확인용 (LetterUI 활성화 - 비활성화 성공)");
            }
        }

        public void OnRelease()
        {
            // 편지지를 놓았을 때 UI를 비활성화

            letterUI.enabled = false;


            // 편지지 자체 삭제 ?
            // this.transform.SetActive(false);
        }

    }
}
