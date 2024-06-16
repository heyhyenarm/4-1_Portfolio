using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jaewook
{
    public abstract class ScoreItem : MonoBehaviour
    {
        // 사용하면 없어지는 1회성 아이템들 추상화 구현
        public abstract void UseAndDisappearedItem();


    }

}