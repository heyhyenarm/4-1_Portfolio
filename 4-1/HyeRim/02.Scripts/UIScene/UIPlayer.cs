using Photon.Pun.Demo.PunBasics;
using SeongMin;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NHR
{
    //플레이어 카메라에 부착된 UI
    public class UIPlayer : MonoBehaviour
    {
        //시계 UI
        [Header("시계 UI")]
        public UIWatch uiWatch;

        //에너지
        public TMP_Text txtEnergy;

        //코루틴
        public IEnumerator runningCoroutine;
        public IEnumerator energyChargingCoroutine;

        //나중에 플레이어로 옮길 것
        //max 값
        private int maxEnergy = 10;
        public int nowEnergy = 10;

        //달리는 상태인가?
        public bool isRunning = false;
        //에너지 다운 상태인가?
        public bool isEnergyDown = false;

        private void Awake()
        {
            if (this.uiWatch == null) this.uiWatch = GetComponentInChildren<UIWatch>();
            //코루틴 할당
            this.runningCoroutine = this.CRunning();
            this.energyChargingCoroutine = this.CEnergyCharging();
        }
        private void Start()
        {
            SeongMin.GameManager.Instance.playerManager.uiPlayer = this;
        }
        private void LateUpdate()
        {
            //LeftShift를 누르고 있을 경우 달리기
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //에너지 다운 상태가 아니고, 달리는 상태가 아니라면 달리기
                if(!this.isRunning && !this.isEnergyDown)
                {
                    this.isRunning = !this.isRunning;
                    StartCoroutine(this.runningCoroutine);
                    StopCoroutine(this.energyChargingCoroutine);
                }
                Debug.Log("GetKeyDown LeftShift");
            }
            if(Input.GetKeyUp(KeyCode.LeftShift)) 
            {
                Debug.Log("GetKeyUp LeftShift");
                //달리던 상태이고 에너지 다운 상태가 아니고 최대 에너지가 아니라면 달리는 상태 멈추고 충전 시작
                if (this.isRunning && !this.isEnergyDown && this.nowEnergy < this.maxEnergy)
                {
                    this.isRunning = !this.isRunning;
                    StopCoroutine(this.runningCoroutine);
                    StartCoroutine(this.energyChargingCoroutine);
                }

            }
        }
        //달리는 중
        public IEnumerator CRunning()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);

                //에너지 소모
                this.nowEnergy--;
                this.txtEnergy.text = $"달리기 On, 에너지 {this.nowEnergy}";
                
                //에너지를 다 사용했다면 달리는 중 코루틴 멈추기
                if (this.nowEnergy <= 0)
                {
                    this.txtEnergy.text = $"다운 상태, 에너지 {this.nowEnergy}";
                    this.isRunning = false;
                    this.isEnergyDown = true;
                    StopCoroutine(this.runningCoroutine);
                    StartCoroutine(this.energyChargingCoroutine);
                }
            }
        }

        //에너지 충전 중
        public IEnumerator CEnergyCharging()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                //에너지 충전
                this.nowEnergy++;

                //에너지 다 충전되었다면 충전 코루틴 멈추기
                if (this.nowEnergy >= maxEnergy)
                {
                    this.isEnergyDown = false;
                    Debug.Log("충전 끝");
                    StopCoroutine(this.energyChargingCoroutine);
                }
                if (this.isEnergyDown)
                {
                    this.txtEnergy.text = $"다운 상태, 에너지 {this.nowEnergy}";
                }
                else
                {
                    this.txtEnergy.text = $"달리기 Off, 에너지 {this.nowEnergy}";
                }
            }
        }
    }
}
