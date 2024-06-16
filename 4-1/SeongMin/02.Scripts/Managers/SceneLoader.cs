using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SeongMin
{
    public class SceneLoader : MonoBehaviour
    {
        private static SceneLoader instance;
        public static SceneLoader Instance { get { return instance; } }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        public void SceneLoad(string _value)
        {
            if (_value == "TitleScene" && PhotonNetwork.IsConnected)
            {
                PhotonNetwork.Disconnect();
            }
            SceneManager.LoadScene(_value);
        }
    }

}