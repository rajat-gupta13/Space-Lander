using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour {

    [SerializeField] private GameObject title, subtitle, move, arrows, platform, next, prev, returnToMenu;
    
    // Use this for initialization
	void Start () {
        title.SetActive(true);
        subtitle.SetActive(true);
        next.SetActive(true);
        move.SetActive(false);
        arrows.SetActive(false);
        platform.SetActive(false);
        prev.SetActive(false);
        returnToMenu.SetActive(false);
    }

    public void NextPage()
    {
        title.SetActive(false);
        subtitle.SetActive(false);
        next.SetActive(false);
        move.SetActive(true);
        arrows.SetActive(true);
        platform.SetActive(true);
        prev.SetActive(true);
        returnToMenu.SetActive(true);
    }

    public void PrevPage()
    {
        title.SetActive(true);
        subtitle.SetActive(true);
        next.SetActive(true);
        move.SetActive(false);
        arrows.SetActive(false);
        platform.SetActive(false);
        prev.SetActive(false);
        returnToMenu.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
