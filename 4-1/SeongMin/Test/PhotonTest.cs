using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeongMin
{
    public class PhotonTest : MonoBehaviourPunCallbacks
    {
        private void Awake()
        {
            Screen.SetResolution(1080, 720, false);
            PhotonNetwork.SendRate = 60;
            PhotonNetwork.SerializationRate = 30;
            PhotonNetwork.GameVersion = "1";



        }
        private void Start()
        {
            OnConnect();
        }
        public void OnConnect()
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        public override void OnConnectedToMaster() // 마스터에게 연결될때 호출함수 없으면 내가 마스터
        {
            PhotonNetwork.JoinOrCreateRoom("Room",new RoomOptions {MaxPlayers = 20 },null);
            Debug.Log("방 생성");
        }
        public override void OnJoinedRoom() // 방에 참가할때
        {
            print("방참가");
        }
    }

}
