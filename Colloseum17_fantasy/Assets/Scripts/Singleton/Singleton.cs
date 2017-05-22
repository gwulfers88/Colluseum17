using UnityEngine;
using System.Collections;

// TODO: Fix this class. Does not work properly when trying to access functions from the templated class
public class Singleton<T>
{
    private static Singleton<T> instance = null;
    public static Singleton<T> Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Singleton<T>();
            }
            return instance;
        }
    }
}
