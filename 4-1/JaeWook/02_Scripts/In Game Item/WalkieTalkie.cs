using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jaewook
{
    public class WalkieTalkie : MonoBehaviour, Jaewook.IItem
    {
        public void OnGrab()
        {
            // particle
        }

        public void OnUse()
        {
            // 무전 기능 x -> Photon Voice
        }

        public void OnRelease()
        {
            throw new System.NotImplementedException();
        }
    }

}
