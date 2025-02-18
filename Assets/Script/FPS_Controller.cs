using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controller : MonoBehaviour
{
    [Header("Settings")]
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

    public float hitDistance = 10f;
    public LayerMask hitLayers;

    public Animator anim;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        //Frappe
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Punch");
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, hitDistance, hitLayers))
            {
                if (hit.collider.GetComponent<Ennemy>())
                {
                    hit.collider.GetComponent<Ennemy>().TakeDamage();
                    print("hit");
                }
            }
        }
    }
}
