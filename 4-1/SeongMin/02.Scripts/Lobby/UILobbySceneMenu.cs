using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static NHR.App;
using HashTable = ExitGames.Client.Photon.Hashtable;

namespace SeongMin
{
    public class UILobbySceneMenu : MonoBehaviourPunCallbacks
    {
        [Header("버튼들")]
        public Button readyButton;
        public Button quitButton;
        public Button roundStartButton;
        [Header("최대 플레이어 설정 하기")]
        public int maxPlayer = 4;
        [Header("준비된 플레이어 표시되는 곳")]
        public int readyPlayer = 0;
        public bool isReady = false;

        private void Awake()
        {
            UIManager.Instance.robbySceneMenu = this;
            readyButton = transform.Find("ReadyButton").GetComponent<Button>();
            quitButton = transform.Find("QuitButton").GetComponent<Button>();
            roundStartButton = transform.Find("RoundStartButton").GetComponent<Button>();

            readyButton.onClick.AddListener(() => PlayerReady());
            quitButton.onClick.AddListener(() =>
            {
                PhotonNetwork.Disconnect();  //네트워크 연결 해제
                EventDispatcher.instance.SendEvent<eSceneType>((int)NHR.EventType.eEventType.Change_Scene, eSceneType.Title);
            });
            roundStartButton.onClick.AddListener(() => GameStart());

            roundStartButton.gameObject.SetActive(false);

            PhotonNetwork.AutomaticallySyncScene = true; // 같은 씬에 있는 플레이어들 자동 동기화
        }

        private void PlayerReady() // 플레이어가 버튼을 눌러 커스텀 프로퍼티 변경시 준비완료한 플레이어 숫자 동기화 
        {
            isReady = !isReady;
            HashTable props = new HashTable
            {
                {"isReady", isReady}
            };

            PhotonNetwork.LocalPlayer.SetCustomProperties(props); // 커스텀 프로퍼티 변경하는 함수
        }

        public override void OnPlayerPropertiesUpdate(Player _player, HashTable _changedProps) // 커스텀 프로퍼티 변경시 콜백 받는 함수
        {
            if (_changedProps.ContainsKey("isReady"))
            {
                bool reddystate = (bool)_changedProps["isReady"];

                if (_player == PhotonNetwork.LocalPlayer)
                {
                    readyButton.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = reddystate ? "Not Ready" : "Ready"; // Ready 누르면 Not Ready로 바뀜
                }
                // Update the number of ready players
                UpdateReadyPlayerCount();
                PlayersReadyCheck();
            }
        }

        private void UpdateReadyPlayerCount() // 단순 레디인원 체크용 함수 (지워도 상관없음)
        {
            readyPlayer = 0;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.CustomProperties.TryGetValue("isReady", out object isReady))
                {
                    if ((bool)isReady)
                        readyPlayer++;
                    else
                        readyPlayer--;
                }
            }
        }

        public void PlayersReadyCheck()
        {
            bool allReady = true;
            // 현재 접속한 플레이어들이 한명이라도 레디 상태가 아니면 allReady를 false로 변경
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (!player.CustomProperties.TryGetValue("isReady", out object isReddy) || !(bool)isReddy)
                {
                    allReady = false;
                    break;
                }
            }

            if (allReady && PhotonNetwork.IsMasterClient)
            {
                roundStartButton.gameObject.SetActive(true);
                print("모든 플레이어가 준비 완료입니다.");
            }
            else
            {
                roundStartButton.gameObject.SetActive(false);
                print("아직 레디하지 않은 플레이어가 있습니다");
            }
        }

        private void GameStart()
        {
            if (PhotonNetwork.IsMasterClient)
            {

                GameDB.Instance.playerCount = PhotonNetwork.PlayerList.Length;
                PhotonNetwork.LoadLevel("InGameScene 1"); // 모든 플레이어들 인게임 씬으로 이동
            }
        }
    }
}