using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumbersGeneration : MonoBehaviour
{
    const int GROW_TIME = 7;

    GameObject cucumber;
    float radius = 4.9f;

    // Start is called before the first frame update
    void Start()
    {
        cucumber = GameObject.Find("CucumberOriginal");
        InvokeRepeating("NewCucumber", 0, GROW_TIME);
    }

    void NewCucumber()
    {
        Instantiate(cucumber, new Vector3(Random.Range(-radius, radius), 0.23f, Random.Range(-radius, radius)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
