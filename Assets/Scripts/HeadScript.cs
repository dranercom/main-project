using UnityEngine;
using System.Collections;

public class HeadScript : MonoBehaviour {

    private GameObject cam;
    private int val;

	// Use this for initialization
	void Start ()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        if (gameObject.name.Equals("Helmet"))
            val = 1;
        else if (gameObject.name.Equals("Body"))
            val = 0;

    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        
            transform.rotation = new Quaternion(cam.transform.rotation.x*val, cam.transform.rotation.y, cam.transform.rotation.z*val, 1);
    }
}
