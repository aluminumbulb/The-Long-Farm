using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    public float finalMovespeed = 5f,mouseLookSpeed = 5f;
    public Camera eyes;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        eyes = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        transform.position = (transform.position) + (finalMovespeed * transform.forward * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.position =  (transform.position) + (finalMovespeed * transform.right * Input.GetAxis("Horizontal") * Time.deltaTime);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, (transform.eulerAngles.y + mouseLookSpeed * Input.GetAxis("Mouse X")), transform.eulerAngles.z);
    }
}