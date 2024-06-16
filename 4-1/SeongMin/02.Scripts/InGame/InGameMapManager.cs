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
        [Header("�÷��̾� ���� ��ġ ����Ʈ")]
        public List<Transform> playerSpawnPositionList;
        [Header("�Ϲ� ������ ���� ��ġ ����Ʈ")]
        public List<Transform> inGameItemPositionList;
        [Header("�Ϲ� ������ ����Ʈ")]
        public List<GameObject> inGameRunnerItemList;
        [Header("�Ϲ� ������ �ѹ��� ���� �迭")]
        public int[] inGameRunnerItemNumberArray;
        [Header("������ ������ ����Ʈ")]
        public List<GameObject> inGameChaserItemList;
        [Header("�����̼� ������ ����Ʈ")]
        public List<GameObject> inGameTeamPlayItemList;

        private void Awake()
        {
            GameManager.Instance.inGameMapManager = this;
            photonView = GetComponent<PhotonView>();

            //�ӽ�
            DataManager.Instance.LoadEventDialogData();
        }
        //inGameRunnerItemList�� ���̸�ŭ ���ڸ� ����Ʈ�� �ֱ�
        //�� �÷��̾ inGameRunnerItemList �� �ڵ����� ������ ��������
        //�ƹ����� �� Ŭ���̾�Ʈ�� ����Ʈ�� �ٲ� �� �־ ������ �󿡼� �ִ°� ���ƺ���
        //�̼� ���ýÿ� ����ȭ ��� ���� ����.
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
                print("�����ؾ��� ������Ʈ ���� ���� ������ ��ġ���� �����ϴ�. ������ġ�� �߰����ּ���.");
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
