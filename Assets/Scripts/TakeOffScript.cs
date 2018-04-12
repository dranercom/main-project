using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TakeOffScript : MonoBehaviour {

    public Text countdown;
    public float timer = 10;

    public AudioClip[] clips;

    public bool takingOff = false;
    public bool called = false;
    public GameObject lunarMod;
    public Transform child1, child2;
    private AudioScript audScript;

	// Use this for initialization
	void Start ()
    {
        audScript = lunarMod.GetComponent<AudioScript>();
        audScript.PlayClip(clips[0]);
	}
	
	// Update is called once per frame
	void Update ()
    {
        countdown.text = "Launching";
        if (!audScript.audioSource.isPlaying)
        {
            takingOff = true;
            if(!called)
            {
                called = true;
                audScript.PlayClip(clips[1]);
            }
        }

        if (takingOff)
        {
            lunarMod.transform.position += Vector3.up;
            countdown.text = "Altitude: " + Mathf.Round(lunarMod.transform.position.y);
            //if(lunarMod.transform.rotation.x>270)
            lunarMod.transform.Rotate(-11.5f* Time.deltaTime, 0, 0);
            child1.localPosition = new Vector3(-child1.transform.localPosition.x, child1.transform.localPosition.y, child1.transform.localPosition.z);
            child2.localPosition = child1.localPosition;
        }

        if (lunarMod.transform.position.y > 100)
            SceneManager.LoadScene("MoonSelect");
	}


}
