using Photon.Pun;
using Photon.Realtime;
using SeongMin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SeongMin
{
    public class MissionManager : MonoBehaviour
    {
        public PhotonView photonView;
        [Header("도망자 미션 갯수 설정")]
        public int runnerMissionCount = 3;
        [Header("협력 미션 갯수 설정")]
        public int teamPlayMissionCount = 1;
        [Header("복수자 미션 갯수 설정")]
        public int chaserMissionCount = 3;
        private void Awake()
        {
            GameManager.Instance.missionManager = this;
            photonView = GetComponent<PhotonView>();
        }
        public void MissionSetting()
        {
            GameDB.Instance.Shuffle(GameManager.Instance.inGameMapManager.inGameRunnerItemNumberArray);
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {
                int _minValue = i*runnerMissionCount;
                int _maxValue = _minValue + runnerMissionCount;
                int[] _intArray = GameManager.Instance.inGameMapManager.inGameRunnerItemNumberArray;
                photonView.RPC("MissionSend", PhotonNetwork.PlayerList[i], _minValue, _maxValue, _intArray);
            }
            //EventDispatcher.instance.SendEvent((int)NHR.EventType.eEventType.Get_Mission);
        }
        [PunRPC]
        public void MissionSend(int _minValue, int _maxValue, int[] _intArray)
        {
            // 내 클라이언트에 다른 클라이언트와 안겹치게 미션 배정 받기
            int j = 0;
            for (int i =_minValue; i < _maxValue; i++)
            {
                GameDB.Instance.playerMission.playerMissionArray[j] = 
                    GameManager.Instance.inGameMapManager.inGameRunnerItemList[_intArray[i]];
                j++;
            }
            EventDispatcher.instance.SendEvent((int)NHR.EventType.eEventType.Get_Mission);

            // 복수자이면 복수자 미션 주기
            if (GameDB.Instance.playerMission.isChaser == true)
            {
                GameDB.Instance.Shuffle(GameManager.Instance.inGameMapManager.inGameChaserItemList);
                for (int i = 0; i < chaserMissionCount; i++)
                {
                    GameDB.Instance.playerMission.chaserMissionArray[i] =
                        GameManager.Instance.inGameMapManager.inGameChaserItemList[i];
                }
            }
            // 협업미션을 수행해야하면 주기
            if (GameDB.Instance.playerMission.isTeamMission == true)
            {
                GameDB.Instance.Shuffle(GameManager.Instance.inGameMapManager.inGameTeamPlayItemList);

                for (int i = 0; i < teamPlayMissionCount; i++)
                {
                    GameDB.Instance.playerMission.playerTeamPlayMissionArray[i] =
                        GameManager.Instance.inGameMapManager.inGameTeamPlayItemList[i];
                }
            }
        }
    }

}