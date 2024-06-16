using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NHR
{
    public class TutorialQuestObjectManager : MonoBehaviour
    {
        public TutorialQuestObject[] questObjects;

        private void Awake()
        {
            this.questObjects = GetComponentsInChildren<TutorialQuestObject>();
            //모든 오브젝트 비활성화
            foreach (var obj in questObjects)
            {
                obj.gameObject.SetActive(false);
            }
        }
    }

}
