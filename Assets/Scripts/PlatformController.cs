using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformController : MonoBehaviour {

    [SerializeField] private GameObject platform;
    private float distance;
    public Text distanceText;
    public static bool moving = false;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private GameObject exhaust;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        distance = Vector3.Distance(transform.position, platform.transform.position);
        UpdateDistance();
        if (moving) {
            platform.transform.Translate(new Vector3(0f, moveSpeed * Time.deltaTime, 0f));
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && distance > 0.5f)
        {
            moving = true;
        }
        else if (distance < 0.5f) {
            exhaust.SetActive(false);
            moving = false;
        }
        else
        {
            moving = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            moving = false;
        }
    }

    void UpdateDistance()
    {
        distanceText.text = "Distance to platform: " + distance.ToString("F2");
    }
}
