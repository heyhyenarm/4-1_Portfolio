using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SeongMin
{
    public class TutorialSceneManager : MonoBehaviour
    {
        public List<Transform> tutorialObjectPositionList;
        public List<GameObject> tutorialObjectList;
        private void Awake()
        {
            GameManager.Instance.tutorialSceneManager = this;
        }

        private void Start()
        {
            TutorialSetting();
        }

        private void TutorialSetting()
        {
            // 튜토리얼 오브젝트 초기화 
            // ps. 튜토리얼 오브젝트는 최소한 한개씩은 있어야 하기에
            // 생성 포인트를 항상 
            // 튜토리얼 오브젝트 갯수보다 여유롭게 가지고 있게 해야한다.
            // 그리고 튜토리얼 오브젝트 갯수만큼만 for문을 돌렸다.
            if (tutorialObjectList.Count <= tutorialObjectPositionList.Count)
            {
                for (int i = 0; i < tutorialObjectList.Count; i++)
                {
                    var tutorialObject = Instantiate(tutorialObjectList[i]);
                    tutorialObjectList[i].transform.position = tutorialObjectPositionList[i].position;
                }
            }
            else
            {
                print("생성해야할 오브젝트 수가 생성 가능한 위치보다 많습니다. 생성위치를 추가해주세요.");
            }
        }
    }

}