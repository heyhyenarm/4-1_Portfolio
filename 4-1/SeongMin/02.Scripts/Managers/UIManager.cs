using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeongMin
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager instance;
        public static UIManager Instance { get { return instance; } }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        public UITitleSceneMenu titleSceneMenu;
        public UILobbySceneMenu robbySceneMenu;
        public UIInGameSceneMenu inGameSceneMenu;
    }
}
