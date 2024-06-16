using SeongMin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestGame : MonoBehaviour
{
    [Header("공격 받음 - 생존자")]
    public Button btnAttacked;  //공격 받음

    [Header("탈출 성공")]
    public Button btnEnd;   //탈출 성공, 관전 모드

    [Header("괴물 변신 - 복수자")]
    public Button btnChangeMonster; //괴물 변신, 복수자라면

    public int heart = 3;
    private void Start()
    {
        this.heart = 3;
        this.btnAttacked.onClick.AddListener(() =>
        {
            EventDispatcher.instance.SendEvent<int>((int)NHR.EventType.eEventType.Notice_Attacked, this.heart);
            this.heart--;
        });
        this.btnEnd.onClick.AddListener(() =>
        {
            Debug.Log("탈출 성공");
            GameDB.Instance.isWin = true;
            EventDispatcher.instance.SendEvent((int)NHR.EventType.eEventType.Watching_Game);
        });
        this.btnChangeMonster.onClick.AddListener(() =>
        {
            Debug.Log("괴물 변신");
            EventDispatcher.instance.SendEvent((int)NHR.EventType.eEventType.Change_Monster);
        });
    }
}
