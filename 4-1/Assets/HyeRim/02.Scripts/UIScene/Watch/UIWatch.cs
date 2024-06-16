using NHR;
using SeongMin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWatch : MonoBehaviour
{
    public UIInventory uiInventory;
    public UIHeartWatch uiHeart;
    public int nowHeart;

    private void Awake()
    {
        this.uiInventory = GetComponentInChildren<UIInventory>();
        this.uiHeart = GetComponentInChildren<UIHeartWatch>();
        this.nowHeart = 3;
    }
    private void Start()
    {
        EventDispatcher.instance.AddEventHandler<int>((int)NHR.EventType.eEventType.Notice_Attacked, new EventHandler<int>((type, heart) =>
        {
            //복수자가 아니면
            if (!GameDB.Instance.playerMission.isChaser)
            {
                Debug.Log("<color=red>하트 갱신</color>");
            }
        }));

    }
}
