using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NHR
{
    public class UIFlashlight : MonoBehaviour
    {
        //배터리들
        public GameObject[] batteries;

        public bool hasBattery = true;
        public int nowBatteryTime = 3;
        public int nowBattery = 3;
        //max 값
        public int maxBatteryTime = 3;
        public int maxBattery = 3;

        private void Awake()
        {
            this.nowBattery = this.maxBattery;
            this.nowBatteryTime = this.maxBatteryTime;
        }
        public void ChargeFlashlight()
        {
            this.nowBattery = this.maxBattery;
            this.nowBatteryTime = this.maxBatteryTime;
            this.hasBattery = true;
            foreach (var battery in batteries)
            {
                battery.SetActive(true);
            }
        }
    }
}
