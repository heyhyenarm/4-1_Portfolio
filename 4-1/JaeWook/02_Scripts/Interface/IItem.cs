using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jaewook
{
    /// <summary>
    /// 사용 Item, Interface 상속 연결
    /// </summary>
    public interface IItem
    {
        // Item 상호작용 순간 
        public void OnGrab();

        // item 트리거버튼 작동
        public void OnUse();

        // item 놓을 때
        public void OnRelease();

        // 추가 상호작용
        // public void On??();

    }
}
