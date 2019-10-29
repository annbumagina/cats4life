using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public float speed = 10.0f;
    float maxDistance = 1f;
    public Text cucumerText;
    int cucumberCounter = 0;
    AudioSource walkAudio;

    // Start is called before the first frame update
    void Start()
    {
        walkAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(moveX, 0, moveZ);
        if ((Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) && Time.timeScale > 0)
        {
            walkAudio.Play();
        } else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && walkAudio.isPlaying)
        { 
            walkAudio.Pause();
        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject[] cucumbers = GameObject.FindGameObjectsWithTag("cucumber");
            Vector3 position = transform.position;
            foreach (GameObject cucumber in cucumbers)
            {
                if ((cucumber.transform.position - position).sqrMagnitude < maxDistance)
                {
                    Destroy(cucumber);
                    cucumberCounter += 3;
                    cucumerText.text = "" + cucumberCounter;
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && cucumberCounter > 0)
        {
            GameObject[] cats = GameObject.FindGameObjectsWithTag("cat");
            Vector3 position = transform.position;
            foreach (GameObject cat in cats)
            {
                if ((cat.transform.position - position).sqrMagnitude < maxDistance)
                {
                    CatScript catScript = cat.GetComponent<CatScript>();
                    if (catScript.health < catScript.maxHealth)
                    {
                        catScript.health += 1;
                        catScript.slider.value = catScript.health / catScript.maxHealth;
                        cucumberCounter--;
                        cucumerText.text = "" + cucumberCounter;
                        break;
                    }
                }
            }
        }
    }
}
