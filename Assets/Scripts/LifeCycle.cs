using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    private bool matured = false;
    private Genotype _genes;
    Color finalColor;
    //private List<float> rValList, gValList, bValList;
    // Start is called before the first frame update
    void Start()
    {
        _genes = GetComponent<Genotype>();
        int ranNum = Random.Range(0, _genes.plantColor.Length);
        finalColor = _genes.plantColor[ranNum];
        gameObject.GetComponent<Renderer>().material.color = finalColor;

        StartCoroutine(lifeCycle());
    }

    IEnumerator lifeCycle()
    {
        //Debug.Log("Growing");
        yield return null;

        yield return new WaitForSeconds(_genes.lifespan / 2);
        pollinate();
        for (int i = 0; i< _genes.reproductivePotential; i++) {
            seed();
        }
        matured = true;

        yield return new WaitForSeconds(_genes.lifespan);
        Debug.Log("I die");
        StartCoroutine(whither());

    }

    void seed()
    {
        float randAngle = Random.Range(0, 360);
        Vector3 pos = new Vector3(transform.position.x + Mathf.Cos(randAngle) * _genes.seedingRadius, transform.position.y, transform.position.z +Mathf.Sin(randAngle) * _genes.seedingRadius);
        Instantiate(this,pos,Quaternion.identity);
    }

    void pollinate()
    {
       // Debug.Log("Pollinate");
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _genes.polinatingRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Plant")
            {
                LifeCycle seedInfo = hitCollider.gameObject.GetComponent<LifeCycle>();
                int randomPick = Random.Range(0, _genes.plantColor.Length); 
               _genes.plantColor[randomPick] = (seedInfo._genes.plantColor[randomPick]);
            }
        }
    }

    IEnumerator whither()
    {
        //Debug.Log("whithering");
        while (transform.localScale.x > .05)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(.01f, .01f, .01f), _genes.whitherRate * Time.deltaTime);
            yield return null;
        }
        Destroy(this.gameObject);
    }

    public int getPlantScore()
    {
        float maturityModifier = 1;
        if (matured)
        {
            maturityModifier = 1.5f;
        }
        return (int)Mathf.Ceil(maturityModifier*(finalColor.r+finalColor.g+finalColor.b));
    }
}
