using UnityEngine;

public class CharacterShot : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputManager m_InputManager;
    private StandardControls m_Inputs;

    [Header("Shot")]
    [SerializeField] private Weapon m_CurrentWeapon;
    [SerializeField] private GameObject m_CurrentBullet;
    [SerializeField] private Transform m_BulletStartPoint;
    private float m_currentShotCooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        m_Inputs = m_InputManager.Inputs;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseShotCoolDown();

        if (m_Inputs.Normal.Shot.ReadValue<float>() > 0 && m_currentShotCooldown <= 0f)
        {
            Shot();
        }
    }

    void DecreaseShotCoolDown()
    {
        if (m_currentShotCooldown > 0)
        {
            m_currentShotCooldown -= Time.deltaTime;
        }
    }

    void Shot()
    {
        GameObject selectedBullet = ObjectPoolManager.Instance.GetPoolObject(m_CurrentBullet);

        if (selectedBullet != null)
        {
            BulletBehavior bulletComp = selectedBullet.GetComponent<BulletBehavior>();

            selectedBullet.transform.position = m_BulletStartPoint.position;
            selectedBullet.transform.rotation = m_BulletStartPoint.rotation;
            selectedBullet.SetActive(true);
            bulletComp.SetVelocity();
            m_currentShotCooldown = m_CurrentWeapon.m_ShotSpeed;
        }
    }
}
