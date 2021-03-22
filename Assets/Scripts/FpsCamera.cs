using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCamera : MonoBehaviour
{
    [SerializeField] float mouseSensitivity;
    public Transform player;
    public float xRotation;
    public float cameraClamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXaxis = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseYaxis = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseYaxis;
        xRotation = Mathf.Clamp(xRotation, -cameraClamp, cameraClamp);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        player.Rotate(Vector3.up * mouseXaxis);

    }
}
