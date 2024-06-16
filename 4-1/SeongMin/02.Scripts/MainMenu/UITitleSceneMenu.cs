using NHR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static NHR.App;

namespace SeongMin
{
    public class UITitleSceneMenu : MonoBehaviour
    {
        public Button startButton;
        public Button tutorialButton;
        public Button characterSettingButton;
        public Button gameSettingButton;

        public UIKeyboard keyboard;

        private void Awake()
        {
            UIManager.Instance.titleSceneMenu = this;
            startButton = transform.Find("StartButton").GetComponent<Button>();
            tutorialButton = transform.Find("TutorialButton").GetComponent<Button>();

            characterSettingButton = transform.Find("CharacterSettingButton").GetComponent<Button>();
            gameSettingButton = transform.Find("GameSettingButton").GetComponent<Button>();

            keyboard = FindObjectOfType<UIKeyboard>();

            startButton.onClick.AddListener(() => 
            EventDispatcher.instance.SendEvent<eSceneType>((int)NHR.EventType.eEventType.Change_Scene, eSceneType.Lobby));
            tutorialButton.onClick.AddListener(() => 
            EventDispatcher.instance.SendEvent<eSceneType>((int)NHR.EventType.eEventType.Change_Scene, eSceneType.Tutorial));
            characterSettingButton.onClick.AddListener(() => 
            EventDispatcher.instance.SendEvent<eSceneType>((int)NHR.EventType.eEventType.Change_Scene, eSceneType.CharacterCustom));
        }

    }

}
