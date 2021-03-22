﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    public float jumpHeight;
    public bool isGrounded;
    public Transform groundCheck;
    public float radius;
    public LayerMask groundLayer;

    Ray ray;
    RaycastHit hitInfo;
    public bool toggle;
  public  GameObject interactText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        movement();
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,  out hitInfo,3f))
        {
            if (hitInfo.collider.CompareTag("Door"))
            {
                // if the object is static UI should not pop up
                if (!hitInfo.transform.GetComponent<Door>().staticObjects)
                {

                interactText.SetActive(true);
                hitInfo.transform.GetComponent<Renderer>().material.color = Color.yellow;       
                } 
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    toggle = !toggle;
                    
                    // taking Every opendoor and changing them to close door 
                    foreach (var openDoor in OpenAndCloseList.instance.openDoors)
                    {
                        openDoor.GetComponent<Door>().isOpened = !toggle;
                        
                        
                    }
                    // taking Every closed door and changing them to opened door 
                    foreach (var closeDoor in OpenAndCloseList.instance.closedDoors)
                    {
                        closeDoor.GetComponent<Door>().isOpened = toggle;
                       
                       
                    }


                }
           
            }
            
        }
        else
        {
            interactText.SetActive(false);
        }
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 3f);
    }

    private void movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, radius, groundLayer);

        Vector3 movement = transform.right * horizontal + transform.forward * vertical;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // jumping
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
        transform.localPosition += (movement * moveSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);

    }
   
}
