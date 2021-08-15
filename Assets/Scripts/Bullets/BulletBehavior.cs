using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBehavior : MonoBehaviour
{
    [SerializeField] private Renderer m_skin;
    [SerializeField] private BulletData m_datas;
    
    private Rigidbody m_rbComp ;
    private bool m_cast;

    private void Awake()
    {
        Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBehavior();
    }

    protected virtual void Initialize()
    {
        m_rbComp = GetComponent<Rigidbody>();
    }

    protected virtual void UpdateBehavior()
    {
        if (m_cast)
        {
            if (!m_skin.isVisible)
            {
                HideBullet();
            }
        }
    }

    public virtual void SetVelocity()
    {
        m_rbComp.velocity = transform.forward * m_datas.m_bulletSpeed;
        m_cast = true;
    }

    protected virtual void HideBullet()
    {
        gameObject.SetActive(false);
        m_cast = false;
    }

    protected virtual void TouchSomething(Collider touchedThing)
    {
        HideBullet();
    }

    protected virtual void DoDamage()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        TouchSomething(other);
    }
}
