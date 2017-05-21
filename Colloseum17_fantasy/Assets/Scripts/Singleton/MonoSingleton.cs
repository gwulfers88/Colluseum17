using UnityEngine;
using System.Collections;

public class MonoSingleton<T> : MonoBehaviour where T : Component
{
    private static bool isQuitting = false;
    private static T instance = null;

    public static T Instance
    {
        get
        {
            if(instance == null && !isQuitting)
            {
                GameObject obj = new GameObject("");
                instance = obj.AddComponent<T>();
                DontDestroyOnLoad(instance);
            }
            
            return instance;
        }
    }
    
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }
}
