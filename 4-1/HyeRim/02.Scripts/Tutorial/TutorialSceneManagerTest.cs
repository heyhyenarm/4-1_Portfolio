using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NHR
{
    public class TutorialSceneManagerTest : MonoBehaviour
    {
        public UITutorialPlayer uiTutorialPlayer;

        //index 0번 : 달성 dialog
        public int totalIndex; //0번을 제외한 총 인덱스 수
        private int currentIndex;   //현재 인덱스

        //퀘스트 오브젝트 인덱스
        public TutorialQuestObjectManager questObjectManager;
        private int nowQuestIndex = 0;

        //현재 dialog 출력을 완료했는가?
        private bool isDone;
        //현재 퀘스트를 클리어했는가?
        private bool isClearQuest;

        private void Awake()
        {
            //임시
            DataManager.Instance.LoadTutorialData();

            this.Init();
        }

        //초기화
        public void Init()
        {
            this.uiTutorialPlayer.textDialog.text = "";
            this.isDone = true;
            this.isClearQuest = true;
            //인덱스 수 가져오기
            this.totalIndex = DataManager.Instance.totalTutorialIndex;
            this.currentIndex = 1;

            this.nowQuestIndex = 0;
        }

        private IEnumerator Start()
        {
            //튜토리얼 퀘스트 클리어 이벤트 정의
            EventDispatcher.instance.AddEventHandler((int)NHR.EventType.eEventType.Clear_TutorialQuest, new EventHandler((type) =>
            {
                Debug.Log("Clear_TutorialQuest");
                this.isClearQuest = true;
                this.uiTutorialPlayer.textDialog.text = "";
                this.nowQuestIndex++;
            }));

            while (true)
            {
                yield return null;
                if (this.isDone && this.isClearQuest) 
                {
                    //튜토리얼 클리어 조건
                    if(this.currentIndex == this.totalIndex)
                    {
                        Debug.Log("튜토리얼 클리어");
                        break;
                    }
                    //dialog 출력
                    var data = DataManager.Instance.GetTutorialData(this.currentIndex);

                    //데이터 타입 -1이면 그냥 출력, 0, 1이면 퀘스트 완수해야 다음 출력
                    if (data.type != -1)
                    {
                        //퀘스트 조건 설정
                        this.isClearQuest = false;
                        this.questObjectManager.questObjects[this.nowQuestIndex].gameObject.SetActive(true);
                        yield return null;
                    }
                    if (this.currentIndex == 2)
                    {
                        //스타트
                        this.uiTutorialPlayer.textDialog.text = "";
                    }
                    this.isDone = false;
                    StartCoroutine(CTypingDialog(data.dialog));
                }
            }
        }

        //dialog 출력
        IEnumerator CTypingDialog(string dialog)
        {
            foreach (var c in dialog)
            {
                this.uiTutorialPlayer.textDialog.text += c;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(1.5f);
            Debug.Log("end");
            this.currentIndex++;
            this.isDone = true;
        }
    }

}
