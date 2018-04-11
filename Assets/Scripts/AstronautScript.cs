using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AstronautScript : Photon.MonoBehaviour {

    public float speed = 3f;
    public bool moving;
    public Animator anim;
    public bool gazing;
    private CharacterController controller;
    public Transform vrHead;
    public Slider timeSlider;
    public float timeGazing;
    public float maxScale = 0.08f;
    public Image picImage;
    public magneticClick magClick = new magneticClick();
    public bool movementEnabled = true;

    // Use this for initialization
    void Start ()
    {
        
        //transform.FindChild("Main Camera").GetComponent<PopupUIController>().popupUI = GameObject.Find("PopupUI").GetComponent<Canvas>();

        controller = GetComponent<CharacterController>();
        vrHead = Camera.main.transform;
        
        transform.GetChild(1).transform.GetChild(3).gameObject.AddComponent<FlareLayer>();
        transform.GetChild(1).transform.GetChild(4).gameObject.AddComponent<FlareLayer>();
        anim = transform.FindChild("AstroAvatar").FindChild("Body").GetComponent<Animator>();
        timeSlider = transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Slider>();
        picImage = transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<Image>();
        timeSlider.value = 0;
        timeGazing = 0;

        magClick.init();

    }

    // Update is called once per frame
    void Update()
    {
        magClick.magUpdate(Input.acceleration, Input.compass.rawVector);
        /*
        if (!photonView.isMine)
            return;*/

        timeSlider.value = timeGazing / 1;

        if (gazing && timeGazing <= 1)
        {
            
            if(!timeSlider.gameObject.activeInHierarchy)
            {
                timeSlider.gameObject.SetActive(true);
            }
            timeGazing += Time.deltaTime;

            timeSlider.gameObject.transform.localScale = new Vector3(timeGazing * maxScale, timeGazing * maxScale, timeGazing * maxScale);
        }

        if(!gazing)
        {
            timeGazing = 0;
            timeSlider.gameObject.transform.localScale *= 0;
            if (timeSlider.gameObject.activeInHierarchy)
                timeSlider.gameObject.SetActive(false);
        }

        if (!gazing && (Input.GetButtonDown("Fire1") || magClick.clicked()) && movementEnabled)
        {
            moving = !moving;
            Debug.Log(picImage.rectTransform.localPosition.x);
            if(picImage.rectTransform.localPosition.x<=240)
                picImage.gameObject.GetComponent<Animator>().Play("image scale left");
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

    public void OnCardboardTrigger()
    {
        if (!gazing)
            moving = !moving;
    }
}
