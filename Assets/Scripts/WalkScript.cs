﻿using UnityEngine;
using System.Collections;

public class WalkScript : MonoBehaviour {

    public float speed = 3f;
    public bool moving;
    private CharacterController controller;
    private GvrViewer gvrViewer;
    private Transform vrHead;

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
        gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
        vrHead = Camera.main.transform;
        //GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
        transform.GetChild(1).transform.GetChild(2).gameObject.AddComponent<FlareLayer>();
        transform.GetChild(1).transform.GetChild(3).gameObject.AddComponent<FlareLayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            moving = !moving;
        }

        if(moving)
        {
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            controller.SimpleMove(speed*forward);
        }
        
	}
}
