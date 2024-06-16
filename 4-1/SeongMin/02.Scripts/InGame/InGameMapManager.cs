using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SeongMin
{
    public class InGameMapManager : MonoBehaviour
    {
        public PhotonView photonView;
        [Header("플레이어 스폰 위치 리스트")]
        public List<Transform> playerSpawnPositionList;
        [Header("일반 아이템 스폰 위치 리스트")]
        public List<Transform> inGameItemPositionList;
        [Header("일반 아이템 리스트")]
        public List<GameObject> inGameRunnerItemList;
        [Header("일반 아이템 넘버링 관리 배열")]
        public int[] inGameRunnerItemNumberArray;
        [Header("복수자 아이템 리스트")]
        public List<GameObject> inGameChaserItemList;
        [Header("협동미션 아이템 리스트")]
        public List<GameObject> inGameTeamPlayItemList;

        private void Awake()
        {
            GameManager.Instance.inGameMapManager = this;
            photonView = GetComponent<PhotonView>();

            //임시
            DataManager.Instance.LoadEventDialogData();
        }
        //inGameRunnerItemList의 길이만큼 숫자를 리스트에 넣기
        //각 플레이어가 inGameRunnerItemList 를 자동으로 넣으면 편하지만
        //아무래도 각 클라이언트가 리스트가 바뀔 수 있어서 에디터 상에서 넣는게 좋아보임
        //미션 세팅시에 직렬화 대신 쓰일 예정.
        public void ItemNumberListSetting()
        {
            inGameRunnerItemNumberArray = new int[inGameRunnerItemList.Count];
            for (int i = 0; i<inGameRunnerItemList.Count; i++)
            {
                inGameRunnerItemNumberArray[i] = i;
            }
        }
        public void ItemPositionSetting()
        {
            if (inGameRunnerItemList.Count < inGameItemPositionList.Count)
            {
                for (int i = 0; i < inGameRunnerItemList.Count; i++)
                {
                    var _object = inGameRunnerItemList[i];
                    _object.transform.position = inGameItemPositionList[i].position;
                }
            }
            else
            {
                print("생성해야할 오브젝트 수가 생성 가능한 위치보다 많습니다. 생성위치를 추가해주세요.");
            }
        }
        public void PlayerPositionSetting()
        {
            GameDB.Instance.Shuffle(GameManager.Instance.inGameMapManager.playerSpawnPositionList);
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {
                Vector3 _playerPosition = GameManager.Instance.inGameMapManager.playerSpawnPositionList[i].position;
                photonView.RPC("GetPlayerPosition", PhotonNetwork.PlayerList[i], _playerPosition); ;
            }
        }

        [PunRPC]
        public void GetPlayerPosition(Vector3 _playerPosition)
        {
            GameDB.Instance.myPlayer.transform.position = _playerPosition;
        }
    }
}

