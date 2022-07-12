using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackground : MonoBehaviour
{
    private static AudioBackground instance = null;
    public static AudioBackground Instance 
    {
        get {return instance;}
    }

    private void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    
    }
}
