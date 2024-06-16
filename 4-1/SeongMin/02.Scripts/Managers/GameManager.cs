using NHR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeongMin
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance { get { return instance; } }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
        [Header("튜토리얼 씬 매니저")]
        public TutorialSceneManager tutorialSceneManager;
        [Header("로비 씬 매니저")]
        public LobbySceneManager lobbySceneManager;
        public PhotonSettingManager photonSettingManager;
        [Header("인 게임 매니저")]
        public InGameSceneManager inGameSceneManager;
        public InGameMapManager inGameMapManager;
        public RoundManager roundManager;
        public MissionManager missionManager;
        public RoundTimer roundTimer;
        public PlayerManager playerManager;
    }

}