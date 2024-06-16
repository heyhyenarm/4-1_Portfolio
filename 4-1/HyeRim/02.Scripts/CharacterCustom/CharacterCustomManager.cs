using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static NHR.App;

namespace NHR
{
    public class CharacterCustomManager : MonoBehaviour
    {
        [SerializeField]
        private UICharacterCustomManager subjectUI;

        [SerializeField]
        private CustomPlayer observerCharacter;

        private void Start()
        {
            //주체에 옵저버 등록
            this.subjectUI.ResisterObserver(this.observerCharacter);
            this.subjectUI.UpdateObservers();

            //버튼 이벤트
            this.subjectUI.buttonExit.onClick.AddListener(() =>
            {
                Debug.Log("buttonExit clicked");

                //선택된 캐릭터 인포 저장
                InfoManager.Instance.EditPlayerInfo(this.subjectUI.selectedCharacter.characterNum, this.subjectUI.selectedClothesColor.index);

                //Exit 누르면 타이틀씬으로
                EventDispatcher.instance.SendEvent<eSceneType>((int)NHR.EventType.eEventType.Change_Scene, eSceneType.Title);
                //SceneManager.LoadScene("TitleScene");
            });

        }
    }

}
