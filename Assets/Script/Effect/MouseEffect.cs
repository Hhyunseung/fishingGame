using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEffect : MonoBehaviour
{
    public static MouseEffect Instance;

    public GameObject MousePrefab;

    Queue<GameObject> ObjectPool = new Queue<GameObject>();
    float spawnsTime;
    float defaultTime = 0.1f;

    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            for (int i = 0; i < 10; i++)
            {
                ObjectPool.Enqueue(StarCreat());
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && spawnsTime >= defaultTime)
        {
            GetObject();
            AudioManager.Instance.clSource.Play();

            spawnsTime = 0;
        }
        spawnsTime += Time.deltaTime;
    }

    GameObject StarCreat()
    {
        GameObject newObj = Instantiate(MousePrefab, Instance.transform);
        newObj.gameObject.SetActive(false);

        return newObj;
    }

    public GameObject GetObject()
    {
        if (ObjectPool.Count > 0)
        {
            GameObject objectinPool = ObjectPool.Dequeue();
            objectinPool.gameObject.SetActive(true);

            Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mPosition.z = 0;
            objectinPool.transform.position = mPosition;
            objectinPool.transform.SetParent(null);
            return objectinPool;
        }
        else
        {
            GameObject objectinPool = StarCreat();
            objectinPool.gameObject.SetActive(true);

            Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mPosition.z = 0;
            objectinPool.transform.position = mPosition;
            objectinPool.transform.SetParent(null);
            return objectinPool;
        }
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        ObjectPool.Enqueue(obj);
    }
}
