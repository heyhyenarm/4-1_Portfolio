using SeongMin;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NHR
{
    public class UIGameEvent : MonoBehaviour
    {
        [Header("안내 팝업 이벤트")]
        public UINotice uiNotice;

        [Header("역할 배정 이벤트")]
        public UIRole uiRole;

        //생존자
        [Header("생존자 공격 받음 이벤트")]
        public UIAttacked uiAttacked;

        //괴물
        [Header("괴물 변신 중 이벤트")]
        public UIMonsterMode uiMonsterMode;

        //관전UI
        [Header("관전 이벤트")]
        public UIWatching uiWatching;

        //Timer UI
        [Header("Round Timer")]
        public UITimer uiTimer;

        //게임 현황
        [Header("현재 플레이어들 현황")]
        public UINowPlayers uiNowPlayers;

        private GameObject nowPopUI;

        private void Awake()
        {
            //임시
            DataManager.Instance.LoadEventDialogData();

            this.uiNotice = FindObjectOfType<UINotice>();
            this.uiRole = FindObjectOfType<UIRole>();
            this.uiAttacked = FindObjectOfType<UIAttacked>();
            this.uiMonsterMode = FindObjectOfType<UIMonsterMode>();
            this.uiWatching = FindObjectOfType<UIWatching>();
            this.uiTimer = FindObjectOfType<UITimer>();
            this.uiNowPlayers = FindObjectOfType<UINowPlayers>();

            this.Init();
        }
        private void Init()
        {
            this.uiNotice.Init();
            this.uiNotice.gameObject.SetActive(false);

            this.uiRole.Init();
            this.uiRole.gameObject.SetActive(false);

            this.uiAttacked.Init();

            this.uiMonsterMode.gameObject.SetActive(false);
            this.uiWatching.gameObject.SetActive(false);
        }
        private void Start()
        {
            //이벤트 string 전달
            EventDispatcher.instance.AddEventHandler<string>((int)NHR.EventType.eEventType.Notice_EventUI, new EventHandler<string>((type, str) =>
            {
                if (str == "chaserChangeOff") this.uiMonsterMode.gameObject.SetActive(false);
                this.uiNotice.Init();
                Debug.Log("<color=yellow>notice</color>");
                var dialog = DataManager.Instance.GetEventDialog(str);
                Debug.LogFormat("<color=yellow>{0}</color>", dialog);
                this.uiNotice.gameObject.SetActive(true);
                this.nowPopUI = this.uiNotice.gameObject;
                StartCoroutine(CTypingDialog(dialog, this.uiNotice.textNotice));
                //this.uiNotice.textNotice.text = dialog;
            }));
            //역할 전달
            EventDispatcher.instance.AddEventHandler<string>((int)NHR.EventType.eEventType.Notice_Role, new EventHandler<string>((type, role) =>
            {
                this.uiRole.Init();
                Debug.Log("<color=yellow>역할 배정 완료</color>");
                //role은 Runner와 Chaser
                var roleDialog = DataManager.Instance.GetEventDialog("role" + role);
                var questDialog = DataManager.Instance.GetEventDialog("quest" + role);

                this.uiRole.gameObject.SetActive(true);
                this.nowPopUI = this.uiRole.gameObject;
                Debug.LogFormat("<color=yellow>{0}</color>", role);
                this.uiRole.textRole.text = roleDialog;
                StartCoroutine(CTypingDialog("주 목표 : " + questDialog, this.uiRole.textQuest));
            }));

            //공격받음 1, 2, 3단계
            EventDispatcher.instance.AddEventHandler<int>((int)NHR.EventType.eEventType.Notice_Attacked, new EventHandler<int>((type, heart) =>
            {
                //복수자가 아니면
                if (!GameDB.Instance.playerMission.isChaser)
                {
                    Debug.Log("<color=red>공격 받음</color>");

                    //UI열기
                    this.uiAttacked.OpenUI(heart);

                    //목숨 줄어드는 UI
                    this.uiAttacked.hearts[3 - heart].imageDeath.SetActive(true);

                    //기절 혹은 죽음 UI text
                    if (heart != 1)
                    {
                        this.uiAttacked.textState.text = DataManager.Instance.GetEventDialog("attacked");
                        //부활
                        this.ReviveUI();
                    }
                    else
                    {
                        this.uiAttacked.textState.text = DataManager.Instance.GetEventDialog("death");
                        Invoke("PopWatching", 2f);
                    }
                    this.uiAttacked.Close();
                }
            }));

            //부활
            EventDispatcher.instance.AddEventHandler((int)NHR.EventType.eEventType.Notice_Respawn, new EventHandler((type) =>
            {
                //
            }));

            //관전(죽은 후, 승리 후 다른 플레이어 기다림)
            EventDispatcher.instance.AddEventHandler((int)NHR.EventType.eEventType.Watching_Game, new EventHandler((type) =>
            {
                Debug.Log("<color=blue>관전모드</color>");
                this.uiWatching.gameObject.SetActive(true);
            }));

            //괴물 변신
            EventDispatcher.instance.AddEventHandler((int)NHR.EventType.eEventType.Change_Monster, new EventHandler((type) =>
            {
                Debug.Log("<color=red>괴물 변신</color>");
                if (GameDB.Instance.playerMission.isChaser)
                {
                    //괴물 전용 UI 띄우기
                    this.uiMonsterMode.gameObject.SetActive(true);
                }
                else
                {
                    //괴물 변신 알림
                    EventDispatcher.instance.SendEvent<string>((int)NHR.EventType.eEventType.Notice_EventUI, "chaserChangeOn");
                }
            }));

            //타이머 갱신
            EventDispatcher.instance.AddEventHandler<int>((int)NHR.EventType.eEventType.Update_Timer, new EventHandler<int>((type, time) =>
            {
                Debug.LogFormat("<color=yellow>남은 시간 : {0}</color>", time);
                this.uiTimer.UpdateTimer(time);
            }));
            //괴물 변신 타이머 갱신
            EventDispatcher.instance.AddEventHandler<float>((int)NHR.EventType.eEventType.Update_MonsterTimer, new EventHandler<float>((type, time) =>
            {
                if (GameDB.Instance.playerMission.isChaser)
                {
                    Debug.LogFormat("<color=yellow>변신 남은 시간 : {0}</color>", time);
                    this.uiMonsterMode.UpdateTimer(time);
                }
            }));
        }

        /// <summary>
        /// 부활 UI
        /// </summary>
        private void ReviveUI()
        {
            Debug.Log("<color=red>부활</color>");
            //기절 UI 없애기
            this.uiAttacked.imageDeath.gameObject.SetActive(false);

        }
        private void PopWatching()
        {
            this.uiWatching.gameObject.SetActive(true);
        }

        //dialog 출력
        IEnumerator CTypingDialog(string dialog, TMP_Text tmp)
        {
            foreach (var c in dialog)
            {
                tmp.text += c;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(2f);
            this.nowPopUI.gameObject.SetActive(false);
        }
    }
}
