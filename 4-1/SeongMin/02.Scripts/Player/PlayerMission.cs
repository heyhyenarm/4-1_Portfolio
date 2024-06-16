using Photon.Pun;
using SeongMin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeongMin
{
    public class PlayerMission : MonoBehaviour
    {
        PhotonView photonView;
        [Header("복수자 배정 받았는지 여부")]
        public bool isChaser = false;
        [Header("협동 미션 배정 받았는지 여부")]
        public bool isTeamMission = false;
        [Header("현재 배정받은 플레이어의 미션 리스트 ")]
        public GameObject[] playerMissionArray;
        [Header("현재 배정받은 플레이어의 협동 미션 리스트 ")]
        public GameObject[] playerTeamPlayMissionArray;
        [Header("현재 배정받은 복수자의의 미션 리스트 ")]
        public GameObject[] chaserMissionArray;

        //[Header("")]
        private void Awake()
        {
            
            photonView = GetComponent<PhotonView>();
            GameDB.Instance.playerMission = this;

            if (GameManager.Instance.missionManager != null)
            {
                playerMissionArray = new GameObject[GameManager.Instance.missionManager.runnerMissionCount];

                playerTeamPlayMissionArray = new GameObject[GameManager.Instance.missionManager.teamPlayMissionCount];

                chaserMissionArray = new GameObject[GameManager.Instance.missionManager.chaserMissionCount];
            }
        }
        private void Start()
        {
            //괴물 변신
            EventDispatcher.instance.AddEventHandler((int)NHR.EventType.eEventType.Change_Monster, new EventHandler((type) =>
            {
                //복수자 배정된 경우에만 괴물 변신
                if(this.isChaser)
                {
                    Debug.Log("<color=red>괴물 변신 완료</color>");
                    //괴물 On 모델
                }
                GameManager.Instance.roundTimer.MonsterTimerStart();
            }));
        }
        public bool MissionCheck(GameObject _item, GameObject[] _array)
        {
            bool _value = false;

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == _item)
                    _value = true;
            }
            return _value;
        }

        [PunRPC]
        public void WinCheck()
        {

            if (PhotonNetwork.IsMasterClient)
            {

               
            }
        }
    }
}