using Photon.Pun;
using Photon.Realtime;
using SeongMin;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


namespace NHR
{
    public class App : MonoBehaviour
    {
        //씬 enum
        public enum eSceneType
        {
            App, Title, Lobby, InGame, Loading, Tutorial, CharacterCustom
        }
        //현재 씬
        private eSceneType nowScene = eSceneType.Title;
        //이전 씬
        private eSceneType preScene = eSceneType.Title;


        //뉴비인가?
        public bool isNewbie;

        private void Awake()
        {
            DontDestroyOnLoad(this);

            //초기셋팅들
            this.Init();
        }

        //초기화
        private void Init()
        {
        }
        private void Start()
        {
            //데이터 받아오기
            DataManager.Instance.LoadCharacterData();
            DataManager.Instance.LoadTutorialData();
            DataManager.Instance.LoadEventDialogData();

            //플레이어 인포로 뉴비 판별하기
            this.isNewbie = InfoManager.Instance.IsNewbie();

            //기존 유저이면 인포 받아오기
            //신규 유저이면 인포 생성
            if (isNewbie)
            {
                //신규 유저
                Debug.Log("<color=yellow>신규유저</color>");

                //인포 초기화
                InfoManager.Instance.PlayerInfoInit();
                InfoManager.Instance.HeightInfoInit();
            }
            else
            {
                //기존 유저
                Debug.Log("<color=yellow>기존유저</color>");
            
                //인포 로드
                InfoManager.Instance.LoadPlayerInfo();
                //임시 매 플레이 초기화
                InfoManager.Instance.HeightInfoInit();
            }


            //EventDispatcher
            //매개변수가 없는 이벤트 초기화
            //EventDispatcher.instance.AddEventHandler((int)NHR.EventType.eEventType.Change_Scene, new EventHandler((type) =>
            //{
            //    Debug.Log("<color=yellow>Event_Test</color>");
            //}));


            //eSceneType 매개변수가 있는 이벤트 초기화
            EventDispatcher.instance.AddEventHandler<eSceneType>((int)NHR.EventType.eEventType.Change_Scene, new EventHandler<eSceneType>((type, scene) =>
            {
                Debug.Log("change Scene");
                this.preScene = this.nowScene;
                //this.nowScene = scene;
                this.ChangeScene(scene);
            }));

            //게임 시작 시 이전의 PlayerPref 셋팅 불러오기

            //메인 씬 로드
            EventDispatcher.instance.SendEvent<eSceneType>((int)NHR.EventType.eEventType.Change_Scene, eSceneType.Title);
        }


        //씬 전환
        public void ChangeScene(eSceneType sceneType)
        {
            //로딩씬
            //현재 sceneType에 따라 씬 전환 switch
            //메모리를 받아오는 중 로딩씬 로드
            //var oper = SceneManager.LoadSceneAsync("Loading");
            //oper.completed += (obj) =>
            //{
            //    var loadinMain = GameDB.FindFirstObjectByType<LoadingMain>();
            //};

            //씬타입이 Main이면
            if(sceneType == eSceneType.Title)
            {
                //씬로드 (메모리)
                var mainOper = SceneManager.LoadSceneAsync(sceneType.ToString() + "Scene 1");
                mainOper.completed += (obj) =>
                {
                    //씬로드 완료
                    //인스턴스 접근 가능
                    //var main = GameObject.FindObjectOfType<Title>();
                    //main.Init();
                };
                SceneManager.LoadScene(sceneType.ToString() + "Scene 1");
                this.nowScene = sceneType;
            }
            else
            {
                SceneManager.LoadScene(sceneType.ToString() + "Scene 1");
                Debug.LogFormat("<color=yellow>nowScene : {0}, preScene : {1}</color>", this.nowScene, this.preScene);
                if (sceneType == eSceneType.Lobby )//&&플레이어에게 게임 결과 있으면
                {
                    Debug.Log("게임 결과");
                    //EventDispatcher.instance.SendEvent((int)NHR.EventType.eEventType.Notice_GameResult);
                }

                this.nowScene = sceneType;
            }

        }

        //필요한 것들..
    }

}