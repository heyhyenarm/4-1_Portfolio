using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NHR
{
    //월드에 위치한 UI
    public class UIWorld : MonoBehaviour
    {
        //임시 손전등 전원 버튼
        public Button buttonFlashOnOff;
        private TMP_Text txtOnOff;
        //임시 손전등 충전 버튼
        public Button buttonFlashCharge;
        //임시 확인
        public bool isFlashlightOn = false;

        //손전등
        public UIFlashlight uiFlashlight;

        //코루틴
        private IEnumerator flashCoroutine;

        private void Awake()
        {
            this.txtOnOff = this.buttonFlashOnOff.GetComponentInChildren<TMP_Text>();
            this.flashCoroutine = this.CLightOn();
        }

        private void Start()
        {
            this.buttonFlashOnOff.onClick.AddListener(() =>
            {
                Debug.Log("btn flash OnOff clicked");
                if(this.uiFlashlight.hasBattery)
                {
                    this.isFlashlightOn = !this.isFlashlightOn;
                    if (this.isFlashlightOn)
                    {
                        this.txtOnOff.text = "On";
                        StartCoroutine(this.flashCoroutine);
                        Debug.Log("Start CLightOn int UIWorld");
                    }
                    else
                    {
                        this.txtOnOff.text = "Off";
                        StopCoroutine(flashCoroutine);
                    }

                }
            });
            this.buttonFlashCharge.onClick.AddListener(() =>
            {
                this.uiFlashlight.ChargeFlashlight();
            });
        }

        //손전등 배터리
        public IEnumerator CLightOn()
        {
            while (true)
            {
                Debug.LogFormat("nowBattery time : {0}", this.uiFlashlight.nowBatteryTime);
                this.uiFlashlight.nowBatteryTime--;

                //배터리 한 칸 시간이 다 되었을 경우
                if (this.uiFlashlight.nowBatteryTime < 0)
                {
                    this.uiFlashlight.batteries[3 - this.uiFlashlight.nowBattery].SetActive(false);
                    Debug.Log(3 - this.uiFlashlight.nowBattery);
                    this.uiFlashlight.nowBatteryTime = 3;
                    this.uiFlashlight.nowBattery--;

                    //배터리가 다 닳았을 경우 손전등 강제 종료
                    if (this.uiFlashlight.nowBattery <= 0)
                    {
                        StopCoroutine(this.flashCoroutine);
                        this.txtOnOff.text = "Off";
                        this.isFlashlightOn = false;
                        this.uiFlashlight.hasBattery = false;
                    }
                    Debug.LogFormat("<color=yellow>nowBatery{0}</color>", this.uiFlashlight.nowBattery);
                    this.uiFlashlight.nowBatteryTime = this.uiFlashlight.maxBatteryTime;
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }

}
