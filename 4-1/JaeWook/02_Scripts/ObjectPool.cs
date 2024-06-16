using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Singleton - ObjectPool
/// 지속적으로 생성이 필요한 경우 -> singleton Pool 사용
/// </summary>
public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance; // 원본 데이터
    public static ObjectPool Instance
    {
        get
        {
            if(instance == null) // 원본데이터가 없으면 ObjectPool타입의 오브젝트 생성
            {
                var obj = FindObjectOfType<ObjectPool>(); // * Find- 함수 -> Update()에서 사용 X
                
                if (obj != null) // 생성한 오브젝트를 원본데이터로 정의
                {
                    instance = obj; 
                }
                else // null이라면 새로운 오브젝트 생성 -> ObjectPool타입 적용 -> 원본으로 정의
                {
                    var newObj = new ObjectPool();
                    newObj.AddComponent<ObjectPool>();

                    instance = newObj.GetComponent<ObjectPool>();
                }
            }

            return instance;
        }
    }

    void Awake()
    {
        if(instance != null )
        {
            instance = this; // 적용된 오브젝트를 원본으로 넣고
            DontDestroyOnLoad( this.gameObject ); // 삭제 불가능하게 적용

        }
        else
        {
            Destroy( this.gameObject ); // null이면 삭제
        }
    }

    public Queue<GameObject> _queues = new Queue<GameObject>();
    public Queue<GameObject> queues
    {
        get => _queues;
        set => _queues = value;
    }

    public GameObject prefabs;
    public int amount = 15;
    public Transform parentTF;

    void Start()
    {
        CreatePool();
    }

    //void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        OnDequeue();
    //    }  
    //}

    private void CreatePool()
    {
        Debug.Log($"Create Pool ");
        for(int i = 0; i < amount; i++)
        {
            var newObj = Instantiate(prefabs);
            OnInit(newObj);
            
        }
    }

    /// <summary>
    /// 생성된 obj 초기화
    /// 1. 큐에 넣기
    /// 2. 위치, 방향 0으로 설정
    /// 3. 상위 GameObject를 생성 ( 그룹화 )
    /// 4. Active false 설정
    /// </summary>
    /// <param name="obj"></param>
    public void OnInit(GameObject obj)
    {
        queues.Enqueue(obj);

        obj.transform.SetParent(parentTF);
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;

        obj.SetActive(false);
    }

    public GameObject OnDequeue()
    {
        if(queues.Count <= 10)
        {
            CreatePool();
        }

        GameObject obj = queues.Dequeue();
        obj.SetActive(true);

        return obj;
    }

}
