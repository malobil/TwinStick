using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance { get; private set; }

    [SerializeField] private List<PoolObject> m_poolObjectList;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        PoolAllObjects();    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PoolAllObjects()
    {
        for(int i = 0; i < m_poolObjectList.Count; i++)
        {
            GameObject parent = new GameObject();
            parent.name = m_poolObjectList[i].m_poolObjectName;
            parent.transform.SetParent(transform);

            for(int y = 0; y < m_poolObjectList[i].m_poolQuantity; y++)
            {
                GameObject temp = Instantiate(m_poolObjectList[i].m_poolObject);
                temp.SetActive(false);
                temp.transform.SetParent(parent.transform);
                m_poolObjectList[i].m_spawnedObject.Add(temp);
            }
        }
    }

    public GameObject GetPoolObject(GameObject obj)
    {
        for (int i = 0; i < m_poolObjectList.Count; i++)
        {
            if(m_poolObjectList[i].m_poolObject == obj)
            {
                for(int y = 0; y < m_poolObjectList[i].m_spawnedObject.Count; y++ )
                {
                    if (!m_poolObjectList[i].m_spawnedObject[y].activeInHierarchy)
                    {
                        return m_poolObjectList[i].m_spawnedObject[y];
                    }
                }
            }
        }

        return null;
    }
}

[System.Serializable]
public class PoolObject
{
    public string m_poolObjectName;
    public GameObject m_poolObject;
    public int m_poolQuantity;
    [HideInInspector]
    public List<GameObject> m_spawnedObject = new List<GameObject>();
}
