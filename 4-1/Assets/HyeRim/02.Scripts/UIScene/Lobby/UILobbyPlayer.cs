using SeongMin;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NHR
{
    public class UILobbyPlayer : MonoBehaviour
    {
        public UIGameResult uiGameResult;

        private void Awake()
        {
            this.uiGameResult = FindObjectOfType<UIGameResult>();
            this.Init();
        }
        private void Init()
        {
            this.uiGameResult.gameObject.SetActive(false);
        }

        private void Start()
        {
            //게임이 끝나고 돌아왔다면
            if (GameDB.Instance.hasGameData)
            {
                Debug.Log("game result");
                this.ShowGameResult();
                GameDB.Instance.hasGameData = false;
            }

            this.uiGameResult.buttonStay.onClick.AddListener(() => this.uiGameResult.gameObject.SetActive(false));
            this.uiGameResult.buttonTitle.onClick.AddListener(() =>
            {
                //타이틀로 돌아가기
                EventDispatcher.instance.SendEvent<App.eSceneType>((int)NHR.EventType.eEventType.Change_Scene, App.eSceneType.Title);
            });
        }

        private void ShowGameResult()
        {
            this.uiGameResult.gameObject.SetActive(true);

            var text = this.uiGameResult.textResult.text;
            if (GameDB.Instance.isWin) text = DataManager.Instance.GetEventDialog("gameWin");
            else text = DataManager.Instance.GetEventDialog("gameLose");
        }
    }

}
