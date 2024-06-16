using SeongMin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace SeongMin
{
    public class PlayerAction : XRGrabInteractable
    {
        private void Start()
        {
            this.activated.AddListener(ActivedEvent);
        }
        // 플레이어가 아이템을 잡았을 때,
        private void ActivedEvent(ActivateEventArgs args)
        {
            if (args.interactableObject.transform.TryGetComponent(out ItemObject _item))
            {
                // 플레이어의 미션 배열에 _item 오브젝트와 일치하는 게 있으면 if문 안에 코드를 실행
                if(GameDB.Instance.playerMission.MissionCheck(_item.gameObject, GameDB.Instance.playerMission.playerMissionArray))
                {
                    //TODO 즉발성 아이템이면, PunRPC로 게임 시스템에 영향 미치기 
                }
            }
        }
    }

}