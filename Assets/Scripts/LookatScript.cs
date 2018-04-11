using UnityEngine;
using System.Collections;

public class LookatScript : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}