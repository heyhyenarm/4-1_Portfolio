using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Jaewook
{
    /// <summary>
    /// 전등 item들 
    /// </summary>
    public class LightManager : MonoBehaviour
    {
        public static LightManager instance;
        public static LightManager Instance { get; private set; }

        public void Awake()
        {
            if (instance != null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else // null -> 삭제
            {
                Destroy(gameObject);
            }
        }
    }
}