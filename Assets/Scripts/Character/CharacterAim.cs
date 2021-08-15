using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAim : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputManager m_InputManager;
    private StandardControls m_Inputs;

    [Header("Aim")]
    [SerializeField] private Camera m_camera;

    private Vector2 m_mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        m_Inputs = m_InputManager.Inputs;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_InputManager.ControllerConnected)
        {
            AimController();
        }
        else
        {
            Aim();
        }
    }

    private void Aim()
    {
        m_mousePosition = m_Inputs.Normal.Aim.ReadValue<Vector2>();
        Vector3 mousePos = m_camera.ScreenToWorldPoint(new Vector3(m_mousePosition.x, m_mousePosition.y, m_camera.transform.position.z - transform.position.z));
        transform.LookAt(mousePos);
        transform.rotation = new Quaternion(0f, transform.rotation.y, 0f, transform.rotation.w);
    }

    private void AimController()
    {
        Vector2 controllerTest = m_Inputs.Normal.AimController.ReadValue<Vector2>();

        if (controllerTest == Vector2.zero)
        {
            return;
        }

        float testAngle = Mathf.Atan2(controllerTest.y, controllerTest.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, (testAngle - 90f) * -1f, 0f);
    }
}
