using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectScript : MonoBehaviour 
{

    public Text objectText;
    public string objType;
    public Animator anim;
    public AudioClip clip;
    public AudioScript audio_script;
    public AstronautScript astro_script;
    public GameObject gvrObject;
    public GameObject contextMenu;
    public Sprite image;

    // Use this for initialization
    void Start ()
    {
        //Canvas element that displays the object type
        gvrObject = GameObject.Find("GvrObject");
        objectText = gvrObject.GetComponent<Text>();
        anim = gvrObject.GetComponent<Animator>();

        //Movement script for the VR head
        astro_script = GameObject.FindGameObjectWithTag("Player").GetComponent<AstronautScript>();
        audio_script = GameObject.Find("Main Camera").GetComponent<AudioScript>();
		objType = gameObject.name;

        //Contextual Menu Object
        contextMenu = GameObject.Find("Contextual Menu");
	}
	
	// Update is called once per frame
	void Update()
    {
        if (SceneManager.GetActiveScene().name == "MoonSelect")
            astro_script.movementEnabled = false;

        if (gvrObject == null)
            Start();


        if (astro_script.timeGazing >= 1)
        {
            DisplayInfo();
        }

        if (astro_script.moving && contextMenu.activeInHierarchy)
            contextMenu.transform.position = new Vector3(0, -500, 0);
    }

    public void Gazing()
    {
        astro_script.gazing = true;
        objectText.text = objType;
        anim.Play("fade in");
    }

    public void NotGazing()
    {
        astro_script.gazing = false;
        objectText.text = "";
    }

    public void DisplayInfo()
    {
        if (objType != objectText.text)
            return;

        if (objectText.text[0] == 'L')
        {
            AudioSetter();
        }
  
        if(objectText.text[0] == 'P')
        {
            Vector3 forward = astro_script.vrHead.TransformDirection(Vector3.forward);
            contextMenu.transform.position = astro_script.vrHead.transform.position + forward + new Vector3(0, forward.y, 0) / 5;
            contextMenu.transform.LookAt(astro_script.vrHead.transform);

            for (int i = 0; i < contextMenu.transform.childCount; i++)
            {
                GameObject child = contextMenu.transform.GetChild(i).gameObject;
                child.GetComponent<Animator>().Play("scale in");
                child.transform.LookAt(astro_script.vrHead.transform);
                child.GetComponent<ObjectScript>().clip = clip;
                child.GetComponent<ObjectScript>().image = image;
            }
        }

        switch (objectText.text)
        {
            case "Cube":
                break;
            case "Earth":
                audio_script.PlayClip(clip);
                break;
            case "Door":
                SceneManager.LoadSceneAsync(1);
                break;
            case "Audio":
                audio_script.PlayClip(clip);
                contextMenu.transform.position = new Vector3(0, -500, 0);
                break;
            case "Images":
                astro_script.picImage.sprite = image;
                astro_script.picImage.gameObject.GetComponent<Animator>().Play("image scale up");
                contextMenu.transform.position = new Vector3(0, -500, 0);
                break;
            case "Apollo11":
            case "Apollo15":
            case "Apollo12":
                SceneManager.LoadSceneAsync("Apollo 12");
                break;

        }

        astro_script.timeGazing = 0;
        NotGazing();
    }

    public void AudioSetter()
    {
        Debug.Log(objectText.text);
        if (!audio_script.audioSource.isPlaying)
            audio_script.PlayClip(clip);
        else
            return;
        if (objectText.text.Split(' ')[0].Equals("Light"))
        {
            StartCoroutine(DimLights(GetComponent<Light>()));
        }
    }

    IEnumerator DimLights(Light light)
    {
        Debug.Log(objectText.text);
        while (light.intensity>0.1f)
        {
            light.intensity -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        NotGazing();
        Destroy(gameObject);
    }


}
