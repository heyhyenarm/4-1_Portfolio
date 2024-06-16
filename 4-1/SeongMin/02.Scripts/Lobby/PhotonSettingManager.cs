using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeongMin
{
    public class PhotonSettingManager : MonoBehaviourPunCallbacks
    {
        private void Awake()
        {
            GameManager.Instance.photonSettingManager = this;
            Screen.SetResolution(1080, 720, false);
            PhotonNetwork.SendRate = 60;
            PhotonNetwork.SerializationRate = 60;
            PhotonNetwork.GameVersion = "1";
            Connect();

        }

        public void Connect()
        {
            PhotonNetwork.ConnectUsingSettings();
            print("포톤 서버 접속");
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 4 }, null);
            print("포톤 서버 접속 완료");
        }

        public override void OnJoinedRoom()
        {
            print("방에 입장했습니다.");
            PhotonNetwork.Instantiate("Player", Vector3.up, Quaternion.identity);

            if(PhotonNetwork.IsMasterClient)
            GameManager.Instance.lobbySceneManager.isLobbySetting = true; // 로비 세팅 가능함을 알리기
        }
    }

}
