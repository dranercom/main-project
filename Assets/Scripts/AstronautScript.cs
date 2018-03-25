﻿using UnityEngine;
using System.Collections;

public class AstronautScript : Photon.MonoBehaviour {

    public float speed = 3f;
    public bool moving;
    public Animator anim;
    public bool gazing;
    private CharacterController controller;
    private Transform vrHead;

	// Use this for initialization
	void Start ()
    {
        
        transform.FindChild("Main Camera").GetComponent<PopupUIController>().popupUI = GameObject.Find("PopupUI").GetComponent<Canvas>();

        controller = GetComponent<CharacterController>();
        vrHead = Camera.main.transform;
        
        transform.GetChild(1).transform.GetChild(2).gameObject.AddComponent<FlareLayer>();
        transform.GetChild(1).transform.GetChild(3).gameObject.AddComponent<FlareLayer>();
        anim = transform.FindChild("AstroAvatar").FindChild("Body").GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!photonView.isMine)
            return;*/
        if (Input.GetButtonDown("Fire1") && !gazing)
        {
            moving = !moving;
        }

        if(moving)
        {
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            controller.SimpleMove(speed*forward);
        }
        
	}
    /*
    private void Update()
    {
        float horizontal = Input.GetAxis("Vertical");
        if (horizontal != 0)
        {
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            controller.SimpleMove(speed * forward * horizontal);
            moving = true;
        }
        else
            moving = false;
    }*/

    private void LateUpdate()
    {
        if(anim!= null)
        {
            anim.SetBool("walking", moving);
        }
    }
}
