using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour {

	public GameObject[] winObjects;
    public GameObject[] loseObjects;

    // Use this for initialization
    void Start () {
		Time.timeScale = 1;
		winObjects = GameObject.FindGameObjectsWithTag("ShowOnWin");
        loseObjects = GameObject.FindGameObjectsWithTag("ShowOnLose");
        hideWin();
        hideLose();

    }

	// Update is called once per frame
	void Update () {
		

	}


	//Reloads the Level
	public void Reload(){
		//Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


	//shows objects with ShowOnWin tag
	public void showWin(){
		foreach(GameObject g in winObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnWin tag
	public void hideWin(){
		foreach(GameObject g in winObjects){
			g.SetActive(false);
		}
	}

    //shows objects with ShowOnLose tag
    public void showLose() {
        foreach (GameObject g in loseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnLose tag
    public void hideLose() {
        foreach (GameObject g in loseObjects)
        {
            g.SetActive(false);
        }
    }

    //Pauses the game
    public void Pause(){
		Time.timeScale = 0;
	}
	//Unpauses the game
	public void Unpause(){
		Time.timeScale = 1;
	}

    public void Win(){
        //Add Win condition here
        Pause();
        showWin();
    }

    public void Lose() {
        //Add Lose condition here
        Pause();
        showLose();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Win();
    }
}
