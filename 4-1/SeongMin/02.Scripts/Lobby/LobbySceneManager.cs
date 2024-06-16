using Photon.Pun;
using SeongMin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeongMin
{
    public class LobbySceneManager : MonoBehaviour
    {
        [Header("로비 아이템 위치 리스트")]
        public List<Transform> lobbyItemPositionList;
        [Header("로비 아이템 리스트")]
        public List<GameObject> lobbyItemList;
        [Header("플레이어 스폰 위치 리스트")]
        public List<Transform> playerSpawnPointList;
        private PhotonView photonView;
        public bool isLobbySetting = false;
        private void Awake()
        {
            photonView = GetComponent<PhotonView>();
            GameManager.Instance.lobbySceneManager = this;
        }
        private IEnumerator Start()
        {
            yield return new WaitUntil(() => isLobbySetting);
            if (PhotonNetwork.IsMasterClient)
                ObjectSetting();
        }

        private void ObjectSetting()
        {
            if (lobbyItemList.Count <= lobbyItemPositionList.Count)
            {
                GameDB.Instance.Shuffle(lobbyItemPositionList);
                for (int i = 0; i < lobbyItemList.Count; i++)
                {
                    lobbyItemList[i].transform.position = lobbyItemPositionList[i].position;
                }
            }
            else
            {
                print("생성해야할 오브젝트 수가 생성 가능한 위치보다 많습니다. 생성위치를 추가해주세요.");
            }
        }
    }

}