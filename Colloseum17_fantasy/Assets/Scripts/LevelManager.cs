using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    int currentSceneIndex;
    Scene currentScene;

    new string name = "ross_prototype";
    public static void LoadScene(string v, LoadSceneMode single)
    {
        SceneManager.LoadScene(v, single);
    }

    public static Scene GetSceneByName(string name)
    {
        Scene scene = SceneManager.GetSceneByName(name);
        return scene;
    }

    public static bool SetActiveScene(Scene scene)
    {
        return false;
    }
    
}
 