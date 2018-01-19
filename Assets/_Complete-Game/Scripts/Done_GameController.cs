using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
    public GameObject player;
	
	public Text fuelText;
    [SerializeField] private GameObject exhaust;
	private float fuelLevel;

    void Start ()
	{
		fuelLevel = 15f;
		StartCoroutine (SpawnWaves ());
	}
	
	void FixedUpdate ()
	{
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || 
            Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || 
            Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            fuelLevel -= (Time.deltaTime / 2);
            UpdateFuel();
        }
        if (fuelLevel <= 0f)
        {
            exhaust.SetActive(false);
            fuelText.text = "Fuel Left: 0.0";
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnWait -= 0.025f;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            player.SetActive(false);

        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            player.SetActive(true);
        }
	}

    void LoadLevel()
    {
        SceneManager.LoadScene(3);
    }

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (-spawnValues.x,Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
	
	
	
	void UpdateFuel ()
	{
		fuelText.text = "Fuel Left: " + fuelLevel.ToString("F2");
	}
	
	public void GameOver ()
	{
        Invoke("LoadLevel", 2.0f);
	}
}