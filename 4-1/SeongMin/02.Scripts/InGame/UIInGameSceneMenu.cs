using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SeongMin
{
    public class UIInGameSceneMenu : MonoBehaviour
    {
        [Header("(임시) 라운드 교체 버튼들")]
        public Button roundTwoButton;
        public Button roundThreeButton;
        public Button endingButton;
        [Header("임시 로딩 이미지")]
        public Image loadingImage;
        public TMP_Text roundChangeText;
        [Header("타이머")]
        public TMP_Text timer;
        private void Awake()
        {
            UIManager.Instance.inGameSceneMenu = this;
            roundTwoButton = transform.Find("RoundTwoButton").GetComponent<Button>();
            roundThreeButton = transform.Find("RoundThreeButton").GetComponent<Button>();
            endingButton = transform.Find("GameEndingButton").GetComponent<Button>();
            timer = transform.Find("Timer").GetComponent<TMP_Text>();


            roundTwoButton.onClick.AddListener(() => GameManager.Instance.roundManager.RoundChange(RoundManager.Round.One));
            roundThreeButton.onClick.AddListener(() => GameManager.Instance.roundManager.RoundChange(RoundManager.Round.Two));
            endingButton.onClick.AddListener(() => GameManager.Instance.roundManager.RoundChange(RoundManager.Round.Three));
            //loadingImage = transform.Find("RoundLoadingImage").GetComponent<Image>();
            //roundChangeText = transform.Find("RoundChangeText").GetComponent <TMP_Text>();
        }
    }
}