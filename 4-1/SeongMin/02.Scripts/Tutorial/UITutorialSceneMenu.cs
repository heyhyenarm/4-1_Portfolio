using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static NHR.App;
namespace SeongMin
{
    public class UITutorialSceneMenu : MonoBehaviour
    {
        public Button quitButton;

        private void Awake()
        {
            quitButton = transform.Find("QuitButton").GetComponent<Button>();

            quitButton.onClick.AddListener(() =>
            EventDispatcher.instance.SendEvent<eSceneType>((int)NHR.EventType.eEventType.Change_Scene, eSceneType.Title));

        }
    }

}