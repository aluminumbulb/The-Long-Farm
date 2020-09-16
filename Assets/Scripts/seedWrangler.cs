using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class seedWrangler : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindObjectsOfType<LifeCycle>().Length > 200)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
