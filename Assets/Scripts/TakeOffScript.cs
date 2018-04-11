using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TakeOffScript : MonoBehaviour {

    public Text countdown;
    public float timer = 5;

    public bool takingOff = false;
    public GameObject lunarMod;
    public Transform child1, child2;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        countdown.text = "Launching in " + Mathf.Round(timer);
        if (timer > 0.5)
            timer -= Time.deltaTime;
        else
            takingOff = true;

        if (takingOff)
        {
            lunarMod.transform.position += Vector3.up;
            countdown.text = "Altitude: " + Mathf.Round(lunarMod.transform.position.y);
            //if(lunarMod.transform.rotation.x>270)
            //lunarMod.transform.Rotate(-5f* Time.deltaTime, 0, 0);
            child1.localPosition = new Vector3(-child1.transform.localPosition.x, child1.transform.localPosition.y, child1.transform.localPosition.z);
            child2.localPosition = child1.localPosition;
        }

        if (lunarMod.transform.position.y > 500)
            SceneManager.LoadScene("MoonSelect");
	}


}
