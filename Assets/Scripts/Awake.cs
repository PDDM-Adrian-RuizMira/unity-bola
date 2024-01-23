using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Awake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Click(){
        SceneManager.LoadScene("Bola");
    }
}
