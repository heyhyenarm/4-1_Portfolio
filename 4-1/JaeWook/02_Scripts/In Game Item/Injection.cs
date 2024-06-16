using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jaewook
{
    public class Injection : MonoBehaviour, Jaewook.IItem
    {
        public AudioSource audioSourceInjection;
        
        void Start()
        {
            audioSourceInjection = gameObject.AddComponent<AudioSource>();
            audioSourceInjection.clip = Resources.Load<AudioClip>("InjectionSound");
        }

        public void OnGrab()
        {
            // Particle
        }

        public void OnUse()
        {
            // 주사하는 사운드 효과
            if (audioSourceInjection != null && audioSourceInjection.clip != null)
            {
                audioSourceInjection.Play();
                Debug.Log("주사 효과음!");
            }

        }

        public void OnRelease()
        {
            throw new System.NotImplementedException();
        }
    }

}
