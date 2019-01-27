using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMaster : MonoBehaviour
{
    public void LoadLevel(int nr)
    {
        SceneManager.LoadSceneAsync(2);
        SceneManager.LoadSceneAsync(3+nr, LoadSceneMode.Additive);
    }
}
