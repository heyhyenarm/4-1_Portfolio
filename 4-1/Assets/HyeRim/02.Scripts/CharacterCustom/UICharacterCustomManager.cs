using Oculus.Interaction.UnityCanvas;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static NHR.App;
using static NHR.Enums;

namespace NHR
{
    public interface ICharacterUISubject
    {
        //옵저버 등록하기
        void ResisterObserver(ICharacterObserver observer);
        //옵저버 제거하기
        void RemoveObserver(ICharacterObserver observer);
        //모든 옵저버 업데이트하기
        void UpdateObservers();
    }

    public class UICharacterCustomManager : MonoBehaviour, ICharacterUISubject
    {
        //선택된 캐릭터, 컬러
        public UICharacterSlot selectedCharacter;
        public UIClothesColor selectedClothesColor;

        //옵저버 관리열
        private List<ICharacterObserver> observers = new List<ICharacterObserver>();
        public ICharacterObserver observer;

        //캐릭터 슬롯들
        //public UICharacterSlot[] slots;
        //임시 only Jake
        public UICharacterSlot slot;

        //옷 컬러 슬롯들
        public UIClothesColor[] colors;

        //타이틀로 가는 버튼
        public Button buttonExit;

        //curvedUI
        public CanvasRenderTexture canvasRender;
        public CanvasMeshRenderer canvasMeshRenderer;

        private void Awake()
        {
            //예비
            DataManager.Instance.LoadCharacterData();
            InfoManager.Instance.LoadPlayerInfo();

            this.Init();
        }
        private void Init()
        {
            //캐릭터 슬롯들 받아오기
            //this.slots = this.GetComponentsInChildren<UICharacterSlot>();

            //임시 only Jake
            this.OnlyJake();

            //캐릭터 슬롯들
            //for (int i = 0; i < this.slots.Length; i++)
            //{
            //    this.slots[i].Init();
            //    //캐릭터 번호
            //    this.slots[i].characterNum = i;
            //    //캐릭터 이름 받아오기
            //    Debug.Log($"id : {1000 + i}");

            //    var data = DataManager.Instance.GetCharacterData(1000 + i);
            //    this.slots[i].textCharacterName.text = data.name;
            //    this.slots[i].imageCharacter.sprite = Resources.Load<Sprite>(data.texturePath);
            //}
            //옷 컬러들
            for (int i = 0; i < this.colors.Length; i++) this.colors[i].index = i;

            //인포에 저장된 캐릭터 불러오기
            this.selectedCharacter = this.slot;
            this.selectedClothesColor = this.colors[InfoManager.Instance.PlayerInfo.nowCharacterId];
        }

        //임시
        private void OnlyJake()
        {
            this.slot = this.GetComponentInChildren<UICharacterSlot>();
            this.slot.Init();
            this.slot.characterNum = 1;

            var data = DataManager.Instance.GetCharacterData(1001);
            this.slot.textCharacterName.text = data.name;
            this.slot.imageCharacter.sprite = Resources.Load<Sprite>(data.texturePath);
        }
        private void Start()
        {
            Debug.Log("UICharacterCustomManager start");

            //디폴트로 선택된 캐릭터/색 활성화
            this.selectedCharacter.OnSelected();
            this.selectedClothesColor.selectedGo.SetActive(true);

            //버튼들 관리, 클릭 시 OnBtnClick 함수 호출
            //foreach (UICharacterSlot slot in this.slots)
            //{
            //    slot.buttonCharacterSlot.onClick.AddListener(() => OnBtnClick(slot));
            //}
            //임시
            this.slot.buttonCharacterSlot.onClick.AddListener(() => this.OnBtnClick(slot));

            foreach(UIClothesColor color in this.colors)
            {
                color.btnColor.onClick.AddListener(() => OnBtnColorClick(color));
            }

        }

        private void OnBtnClick(UICharacterSlot slot)
        {
            //버튼 클릭 시 옵저버들 업데이트, 캐릭터
            Debug.LogFormat("{0} clicked", slot);
            //이전 선택된 캐릭터 컬러 회색으로, 새로 선택한 캐릭터 컬러 흰색으로
            //이전 선택한 것과 같지 않다면
            //if (this.selectedCharacter != slot)
            //{
            //    this.selectedCharacter.OnUnselected();
            //    this.selectedCharacter = slot;
            //    this.selectedCharacter.OnSelected();
            //    this.UpdateObservers();
            //}
        }
        private void OnBtnColorClick(UIClothesColor color)
        {
            //버튼 클릭 시 옵저버들 업데이트, 옷 컬러
            Debug.LogFormat("{0} clicked", color);
            //이전 선택한 것과 같지 않다면
            if (this.selectedClothesColor != color)
            {
                this.selectedClothesColor.selectedGo.SetActive(false);
                this.selectedClothesColor = color;
                this.selectedClothesColor.selectedGo.SetActive(true);
                this.UpdateObservers();
            }
        }
        public void UpdateObservers()
        {
            Debug.Log("Update Observers");
            Debug.LogFormat("num : {0}, color name : {1}", this.selectedCharacter, this.selectedClothesColor);
            //모든 옵저버 업데이트하기
            foreach (ICharacterObserver observer in observers)
            {
                observer.ObserverUpdate(this.selectedCharacter.characterNum, this.selectedClothesColor.textureName);
            }
            //curvedUI 업데이트
            //EventDispatcher.instance.SendEvent((int)NHR.EventType.eEventType.Update_CurvedUI);
            //canvasRender.UpdateCamera();
            //canvasMeshRenderer.UpdateUI();
            //this.canvasRender.UpdateCurved();
        }

        public void RemoveObserver(ICharacterObserver observer)
        {
            //옵저버 제거하기
            this.observers.Remove(observer);
        }

        public void ResisterObserver(ICharacterObserver observer)
        {
            //옵저버 등록하기
            this.observers.Add(observer);
        }
    }

}

