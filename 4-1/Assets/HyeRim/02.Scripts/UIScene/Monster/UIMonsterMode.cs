using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using SeongMin;

namespace NHR
{
    public class UIMonsterMode : MonoBehaviour
    {
        public Image imageMonsterTime;

        private float maxTime;

        private void Awake()
        {
            //this.imageMonsterTime = GetComponentInChildren<Image>();
        }
        private void Start()
        {
            this.maxTime = GameManager.Instance.roundTimer.monsterTimer;
        }
        public void UpdateTimer(float sec)
        {
            this.imageMonsterTime.fillAmount = sec/this.maxTime;
        }
    }

}
