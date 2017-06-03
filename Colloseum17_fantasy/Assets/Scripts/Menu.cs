using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
       //LevelManager.LoadScene(name, LoadSceneMode.Single);
    }
	
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

	// Update is called once per frame
	void Update ()
    {
	
	}
}
