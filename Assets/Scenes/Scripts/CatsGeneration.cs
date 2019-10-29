using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsGeneration : MonoBehaviour
{
    const int CAT_NUMBER = 3;

    float radius = 4.9f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject cat = GameObject.Find("CatOriginal");
        for (int i = 0; i < CAT_NUMBER; i++)
        {
            Instantiate(cat, new Vector3(Random.Range(-radius, radius), 0.3f, Random.Range(-radius, radius)), Quaternion.identity);
        }
        Destroy(cat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
