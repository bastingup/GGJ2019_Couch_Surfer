using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ToMenu", 5);
    }

    // Update is called once per frame
    void ToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
