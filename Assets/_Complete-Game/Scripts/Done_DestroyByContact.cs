using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	private void OnCollisionEnter (Collision other)
	{
		if (explosion != null && other.gameObject.tag == "Player")
		{
			Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

		if (other.gameObject.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            gameController.GameOver();
            Destroy(gameObject);
        }
		
	}

    void LoadLevel()
    {
        SceneManager.LoadScene(3);         
    }
}