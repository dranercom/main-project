using UnityEngine;
using System.Collections;

public class NetworkManagerScript : Photon.MonoBehaviour {


    public bool offline = true;

    private void Awake()
    {
        //PhotonNetwork.autoJoinLobby = false;
    }

    private void Start()
    {

        PhotonNetwork.offlineMode = offline;
        //if (offline)
        //    PhotonNetwork.ConnectUsingSettings("v0.2");
        //else
        //    SpawnAstronaut();

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), PhotonNetwork.connectionState.ToString());
        Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master :D");
        if(!offline)
            PhotonNetwork.JoinLobby();
        else
            PhotonNetwork.JoinOrCreateRoom("common", null, null);
    }

    void OnConnectionFail()
    {
        PhotonNetwork.Reconnect();
    }

    void OnJoinedLobby()
    {
        Debug.Log("Connected to Lobby :D");
        PhotonNetwork.JoinOrCreateRoom("common", null, null);
    }

    void OnJoinedRoom()
    {
        SpawnAstronaut();
    }

    void SpawnAstronaut()
    {
        GameObject astro = PhotonNetwork.Instantiate("Astronaut", Vector3.zero, Quaternion.identity, 0);
        astro.name = "Astronaut";
        astro.transform.GetChild(0).gameObject.SetActive(true);
        astro.transform.GetChild(1).gameObject.SetActive(true);
        astro.transform.GetChild(2).GetChild(1).GetChild(1).gameObject.SetActive(true);
        astro.transform.GetChild(2).GetChild(0).GetComponent<HeadScript>().enabled = true;
        astro.transform.GetChild(2).GetChild(1).GetComponent<HeadScript>().enabled = true;

        //astro.transform.GetChild(2).transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        astro.GetComponent<AstronautScript>().enabled = true;
    }

}
