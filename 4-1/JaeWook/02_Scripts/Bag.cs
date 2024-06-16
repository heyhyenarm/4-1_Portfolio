using NHR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 그냥 오브젝트로 제작하기로 결정 
/// </summary>
public class Bag : MonoBehaviour, Jaewook.IItem
{
    [Header("가방 프리펩")]
    public GameObject inventoryObjectPrefab;

    private void Start()
    {
        // 인벤토리 UI ( 설정 )
        if (inventoryObjectPrefab != null)
        {
            // pos, rot 추가설정 필요 -> 성민님 피드백 : 아이템매니저 제작 ( pos,rot 설정 )
            GameObject inventoryObjectInstance = Instantiate(inventoryObjectPrefab, transform.position, transform.rotation);
        }
    }

    public void OnGrab()
    {
        /*
        // Bag 오브젝트를 비활성화하고 인벤토리 UI를 활성화합니다.
        if (this.gameObject != null)
        {
            // enableInventoryObject.gameObject.SetActive(true);  // UI 활성화 ( 현재 없으므로 오류 뜸 )

            
        }
        */
    }

    public void OnRelease()
    {
        // 필요한 경우 OnRelease 구현
    }

    public void OnUse()
    {
       // 
    }
}
