using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NHR
{
    public class PlayerManager : MonoBehaviour
    {
        [Header("플레이어 제어")]
        public PlayerController playerController;
        [Header("플레이어 UI")]
        public UIPlayer uiPlayer;

        [Header("남은 생명 수")]
        public int heart = 3;

        private void Awake()
        {
            SeongMin.GameManager.Instance.playerManager = this;
            this.heart = 3;
        }
        private void Start()
        {
            this.playerController.watch.hoverEntered.AddListener((args) =>
            {
                Debug.Log("hoverEntered");
                this.uiPlayer.uiWatch.uiInventory.handMenu.gameObject.SetActive(true);
            });
            this.playerController.watch.hoverExited.AddListener((args) =>
            {
                Debug.Log("hoverExited");
                this.uiPlayer.uiWatch.uiInventory.handMenu.gameObject.SetActive(false);
            });
        }
    }
}
