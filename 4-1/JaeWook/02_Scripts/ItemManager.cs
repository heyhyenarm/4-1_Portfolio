using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jaewook
{
    /// <summary>
    /// ItemManager Singleton
    /// </summary>
    public class ItemManager : MonoBehaviour
    {
        public static ItemManager instance;
        public static ItemManager Instance { get; private set; }

        public void Awake()
        {
            if (instance != null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else // null -> ªË¡¶
            {
                Destroy(gameObject);
            }
        }

    }

}
