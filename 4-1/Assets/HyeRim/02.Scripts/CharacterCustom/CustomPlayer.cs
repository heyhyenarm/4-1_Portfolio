using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NHR
{
    public interface ICharacterObserver
    {
        //옵저버 업데이트 캐릭터번호, 텍스쳐 이름
        void ObserverUpdate(int characterNum, string textureName);
    }

    public class CustomPlayer : MonoBehaviour, ICharacterObserver
    {
        //현재 캐릭터번호, 텍스쳐 이름
        public int nowCharacterNum;
        public string nowTextureName;

        public TMP_Text characterName;

        public Character[] characters;

        private void Awake()
        {
            this.Init();
        }
        private void Init()
        {
            this.characters = this.GetComponentsInChildren<Character>();
            //foreach (var character in this.characters)
            //{
            //    character.gameObject.SetActive(false);
            //}
            //this.characters[this.nowCharacterNum].gameObject.SetActive(true);
            this.characterName.text = this.characters[this.nowCharacterNum].name;
        }
        public void ObserverUpdate(int characterNum, string textureName)
        {
            Debug.LogFormat("in CustomPlayer num : {0}, texture : {1}", characterNum, textureName);
            //전달된 정보 업데이트
            //이전 선택과 다를 경우
            //if (this.nowCharacterNum != characterNum)
            //{
            //    //캐릭터 변신
            //    this.characters[this.nowCharacterNum].gameObject.SetActive(false);
            //    this.nowCharacterNum = characterNum;
            //    this.characters[this.nowCharacterNum].gameObject.SetActive(true);
            //    this.characterName.text = this.characters[this.nowCharacterNum].name;
            //}
            //텍스쳐 바꿈
            var mat = this.characters[this.nowCharacterNum].material;
            Debug.LogFormat("<color=yellow>material : {0}</color>", mat.name);
            //Debug.LogFormat("<color=yellow>main texture : {0}</color>", mat.mainTexture.name);
            mat.mainTexture = Resources.Load<Texture>("ClothesTexture/" + this.nowCharacterNum + textureName);

            this.nowTextureName = textureName;
        }
    }
}
