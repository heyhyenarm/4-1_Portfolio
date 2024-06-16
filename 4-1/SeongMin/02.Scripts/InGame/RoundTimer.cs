using SeongMin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SeongMin
{
    public class RoundTimer : MonoBehaviour
    {
        [Header("라운드 타이머 시간 조절")]
        public int timer = 190;
        [Header("괴물 변신 타이머 시간 조절")]
        public float monsterTimer = 10;

        WaitForSecondsRealtime waitOneSecond = new WaitForSecondsRealtime(1f);
        private void Awake()
        {
            GameManager.Instance.roundTimer = this;
        }
        public void TimerStart()
        {
            StartCoroutine(Timer());
        }
        private IEnumerator Timer()
        {
            int _timer = timer;
            while (_timer>0)
            {
                print("타이머가 돌고 있습니다.");
                yield return waitOneSecond;
                _timer--;
                UIManager.Instance.inGameSceneMenu.timer.text = _timer.ToString();
                EventDispatcher.instance.SendEvent<int>((int)NHR.EventType.eEventType.Update_Timer, _timer);
            }
            GameManager.Instance.inGameSceneManager.Lose();
            //테스트 끝나면 활성화
            //GameManager.Instance.roundManager.RoundChange(RoundManager.Round.Three);
            yield break;
        }
        public void MonsterTimerStart()
        {
            StartCoroutine(this.MonsterTimer());
        }
        private IEnumerator MonsterTimer()
        {
            float _monsterTimer = this.monsterTimer;
            while (_monsterTimer > 0)
            {
                Debug.Log("괴물 변신 중");
                yield return waitOneSecond;
                _monsterTimer--;
                EventDispatcher.instance.SendEvent<float>((int)NHR.EventType.eEventType.Update_MonsterTimer, _monsterTimer);
            }
            //괴물 변신 풀림
            EventDispatcher.instance.SendEvent<string>((int)NHR.EventType.eEventType.Notice_EventUI, "chaserChangeOff");
        }
    }

}