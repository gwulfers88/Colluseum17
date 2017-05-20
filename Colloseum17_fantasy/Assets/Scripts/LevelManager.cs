using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        LoadScene("", LoadSceneMode.Additive);
	}

    private static void LoadScene(string v, object additive)
    {
        throw new NotImplementedException();
    }

    public static SceneManagement.Scene GetSceneByName(string name)
    {
        
    }

    public static bool SetActiveScene(SceneManagement.Scene scene)
    {

    }

 