using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour {

    public GameObject player, gameController, fireworks, platformController;
    public Text distanceText;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Done_PlayerController>().enabled = false;
            gameController.SetActive(false);
            platformController.GetComponent<PlatformController>().enabled = false;
            fireworks.SetActive(true);
            distanceText.text = "Landed Safely";
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Invoke("LevelLoader", 5.0f);
        }
    }

    void LevelLoader()
    {
        SceneManager.LoadScene(2);
    }
}
