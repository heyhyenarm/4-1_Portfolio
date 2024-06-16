using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NHR
{
    public class OtherPlayer : MonoBehaviour
    {
        public GameObject uiPlayerGo;
        public GameObject xrPlayerGo;

        private void Start()
        {
            //Debug.Log("start");
            StartCoroutine(CLookCamera(this.uiPlayerGo));
        }
        IEnumerator CLookCamera(GameObject go)
        {
            while (true)
            {
                //Debug.Log("name");
                Vector3 dir = (go.transform.position - this.xrPlayerGo.transform.position).normalized;
                uiPlayerGo.transform.rotation = Quaternion.LookRotation(dir);
                yield return null;
            }

        }

    }

}
