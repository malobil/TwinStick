using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{

    [Header("Input")]
    [SerializeField] private InputManager m_InputManager ;
    private StandardControls m_Inputs;

    [Header("Movement")]
    [SerializeField] private float m_horizontalMoveSpeed = 1f ;
    [SerializeField] private float m_verticalMoveSpeed = 1f ;

    
    private Rigidbody m_rbComp;
    private Vector3 m_inputValue;
    private Vector3 m_currentVelocity ;



    // Start is called before the first frame update
    void Start()
    {
        m_rbComp = GetComponent<Rigidbody>();
        m_Inputs = m_InputManager.Inputs;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        m_inputValue = new Vector3(m_Inputs.Normal.Movement.ReadValue<Vector2>().x, 0f, m_Inputs.Normal.Movement.ReadValue<Vector2>().y) ;
        m_currentVelocity = new Vector3(m_inputValue.x * m_horizontalMoveSpeed, m_inputValue.y, m_inputValue.z * m_verticalMoveSpeed);
        m_rbComp.velocity = m_currentVelocity;
    }
}
