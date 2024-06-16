using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NHR
{
    public interface ILookCamera
    {
        private IEnumerator CLookCamera(GameObject go, GameObject player)
        {
            while (true)
            {
                //Debug.Log("Look Camera");
                //Quaternion newRot = Quaternion.LookRotation(Camera.main.transform.forward);
                //newRot.y = go.transform.rotation.y;
                //newRot.z = go.transform.rotation.z;
                //go.transform.rotation = newRot;
                Vector3 dir = (go.transform.position - player.transform.position).normalized;
                go.transform.rotation = Quaternion.LookRotation(dir);
                Debug.LogFormat("ui pos{0}, player pos{1}, dir{2}", go.transform.position, player.transform.position, dir);
                Debug.Log(dir);
                yield return null;
            }
        }

    }

}
