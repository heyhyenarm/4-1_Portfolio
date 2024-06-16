using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NHR
{
    public class Character : MonoBehaviour
    {
        public GameObject clothes;
        public Material material;

        private void Awake()
        {
            this.material = this.clothes.GetComponent<SkinnedMeshRenderer>().material;
        }
    }

}
