using UnityEngine;

public class NetworkCharacterScript : Photon.MonoBehaviour {

    private Vector3 correctAstroPos;
    private Quaternion correctAstroRot;
    private Animator anim;
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
        if(!photonView.isMine)
        {
            if (name[0] == 'A')
                transform.position = Vector3.Lerp(transform.position, correctAstroPos, 0.1f);
            else
                transform.rotation = Quaternion.Lerp(transform.rotation, correctAstroRot, 0.1f);
        }

	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.isWriting)
        {
            if(name[0]=='A')
                stream.SendNext(transform.position);
            else
                stream.SendNext(transform.rotation);
            if (anim != null)
                stream.SendNext(anim.GetBool("walking"));
        }

        else
        {
            if (name[0] == 'A')
                correctAstroPos = (Vector3)stream.ReceiveNext();
            else
                correctAstroRot = (Quaternion)stream.ReceiveNext();
            if (anim != null)
                anim.SetBool("walking", (bool)stream.ReceiveNext());
        }
    }
}
