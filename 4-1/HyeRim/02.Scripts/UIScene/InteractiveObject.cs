using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace NHR
{
    public class InteractiveObject : MonoBehaviour
    {
        public GameObject uiGo;
        public GameObject txtGo;
        //public GameObject playerGo;

        private void Start()
        {
            this.txtGo.SetActive(false);
            this.uiGo.SetActive(false);
            this.txtGo.GetComponent<TMP_Text>().text = this.name;


        }

        private void OnBecameVisible()
        {
            //시야각에 들어왔을 때 상호작용 가능 UI 보여줌
            Debug.Log("OnBecameVisible");
            this.uiGo.SetActive(true);
            StartCoroutine(CLookCamera(this.uiGo));
        }
        private void OnBecameInvisible()
        {
            //시야각에서 빠져나왔을 때 상호작용 가능 UI 없어짐
            Debug.Log("OnBecameInvisible");
            this.uiGo.SetActive(true);
            StopAllCoroutines();
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player");
                this.txtGo.SetActive(true);
            }
        }
        public void OnTriggerExit(Collider other)
        {
            this.txtGo.SetActive(false);
        }
        private IEnumerator CLookCamera(GameObject go)
        {
            while (true)
            {
                Vector3 dir = (go.transform.position -  Camera.main.transform.position).normalized;
                this.uiGo.transform.rotation = Quaternion.LookRotation(dir);
                yield return null;
            }
        }
    }

}
