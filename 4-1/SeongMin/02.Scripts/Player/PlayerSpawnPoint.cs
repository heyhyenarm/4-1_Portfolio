using SeongMin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public enum SceneValue
    {
        tutorial,
        lobby,
        inGame
    }

    [Header("각 씬에 맞게 선택하기")]
    public SceneValue sceneValue;
    private void Start()
    {
        // 로비매니저의 리스트에 이 오브젝트 추가 
        if (sceneValue == SceneValue.lobby)
            GameManager.Instance.lobbySceneManager.playerSpawnPointList.Add(this.transform);
        else if (sceneValue == SceneValue.inGame)
            GameManager.Instance.inGameMapManager.playerSpawnPositionList.Add(this.transform);

    }
}
