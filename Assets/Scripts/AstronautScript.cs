using UnityEngine;
using System.Collections;

public class AstronautScript : MonoBehaviour {

    public float speed = 3f;
    public bool moving;
    public bool gazing;
    private CharacterController controller;
    private Transform vrHead;

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
        vrHead = Camera.main.transform;
        transform.GetChild(1).transform.GetChild(2).gameObject.AddComponent<FlareLayer>();
        transform.GetChild(1).transform.GetChild(3).gameObject.AddComponent<FlareLayer>();
    }

    // Update is called once per frame
    void Update()
    {
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
}
