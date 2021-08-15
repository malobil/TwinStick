using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Renderer m_skin;
    
    private Rigidbody m_rbComp ;
    private bool m_cast;

    private void Awake()
    {
        m_rbComp = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_cast)
        {
            if(!m_skin.isVisible)
            {
                HideBullet();
            }
        }
    }

    public void SetVelocity(float bulletSpeed)
    {
        m_rbComp.velocity = transform.forward * bulletSpeed;
        m_cast = true;
    }

    private void HideBullet()
    {
        gameObject.SetActive(false);
        m_cast = false;
    }
}
