using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{

    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }

}
