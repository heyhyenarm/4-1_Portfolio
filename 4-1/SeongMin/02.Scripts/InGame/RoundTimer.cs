using SeongMin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SeongMin
{
    public class RoundTimer : MonoBehaviour
    {
        [Header("���� Ÿ�̸� �ð� ����")]
        public int timer = 190;
        [Header("���� ���� Ÿ�̸� �ð� ����")]
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
                print("Ÿ�̸Ӱ� ���� �ֽ��ϴ�.");
                yield return waitOneSecond;
                _timer--;
                UIManager.Instance.inGameSceneMenu.timer.text = _timer.ToString();
                EventDispatcher.instance.SendEvent<int>((int)NHR.EventType.eEventType.Update_Timer, _timer);
            }
            GameManager.Instance.inGameSceneManager.Lose();
            //�׽�Ʈ ������ Ȱ��ȭ
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
                Debug.Log("���� ���� ��");
                yield return waitOneSecond;
                _monsterTimer--;
                EventDispatcher.instance.SendEvent<float>((int)NHR.EventType.eEventType.Update_MonsterTimer, _monsterTimer);
            }
            //���� ���� Ǯ��
            EventDispatcher.instance.SendEvent<string>((int)NHR.EventType.eEventType.Notice_EventUI, "chaserChangeOff");
        }
    }

}