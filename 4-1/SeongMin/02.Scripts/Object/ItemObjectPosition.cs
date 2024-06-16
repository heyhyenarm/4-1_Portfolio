using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SeongMin
{
    public class ItemObjectPosition : MonoBehaviour
    {
        public enum SceneValue
        {
            tutorial,
            lobby,
            inGame
        }
        [Header("씬에 맞게 설정")]
        public SceneValue sceneValue;
        public enum CharacterValeu
        {
            human,
            monster
        }
        [Header("복수자 전용인지 선택하기 ")]
        public CharacterValeu characterValeu = CharacterValeu.human;
        private void Start()
        {
            // 각 방의 매니저에게 자신의 objectPosition을 알리기
            if (sceneValue == SceneValue.tutorial)
                GameManager.Instance.tutorialSceneManager.tutorialObjectPositionList.Add(this.transform);
            else if (sceneValue == SceneValue.lobby)
                GameManager.Instance.lobbySceneManager.lobbyItemPositionList.Add(this.transform);
            else if (sceneValue == SceneValue.inGame)
            {
                GameManager.Instance.inGameMapManager.inGameItemPositionList.Add(this.transform);
            }
        }

    }
}