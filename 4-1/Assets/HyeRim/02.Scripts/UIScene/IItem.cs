using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NHR
{
    public interface IItem
    {
        public void Grab(); //물건을 잡았을 때
        public void Use();  //물건을 잡고 상호작용 할 때
        public void Release();  //물건을 놓았을 때
    }

}
