using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    Animator anim;
    bool isSwinging = false;
    scoreText scoreTracker;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        scoreTracker = FindObjectOfType<scoreText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swingingToTrue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Plant" && isSwinging)
        {
            LifeCycle plant = (LifeCycle)other.gameObject.GetComponent<LifeCycle>();
            int flowerValue = plant.getPlantScore();
            Destroy(plant.gameObject);
            scoreTracker.updateScore(flowerValue);
        }
    }

    void swingingToTrue()
    {
        anim.SetBool("swinging", true);
        isSwinging = true;
    }

    void swingingToFalse()
    {
        anim.SetBool("swinging", false);
        isSwinging = false;
    }
}
