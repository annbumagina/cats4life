using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatScript : MonoBehaviour
{
    const int DECREASE_HEALTH_TIME = 15;
    const int CHANGE_DIRECTION_TIME = 5;
    int MEOW_TIME;
    int BIRTH_TIME;
    int MEOW_NUMBER;

    static int catNumber = -1;
    public Image gameover;
    public float speed = 0.01f;
    public Slider slider;
    public float maxHealth = 5;
    public float health;
    int direction = 0;
    Material material;
    float radius = 4.9f;
    GameObject rip;
    AudioSource[] meows;


    // Start is called before the first frame update
    void Start()
    {
        gameover.enabled = false;
        catNumber++;
        rip = GameObject.Find("rip");
        meows = GetComponents<AudioSource>();
        slider.value = 1;
        health = 5;
        BIRTH_TIME = Random.Range(60, 120);
        MEOW_TIME = Random.Range(20, 50);
        MEOW_NUMBER = Random.Range(0, 3);

        InvokeRepeating("ChangeDirection", 0, CHANGE_DIRECTION_TIME);
        InvokeRepeating("NewCat", BIRTH_TIME, BIRTH_TIME);
        InvokeRepeating("DecreaseHealth", DECREASE_HEALTH_TIME, DECREASE_HEALTH_TIME);
        InvokeRepeating("Meow", MEOW_TIME, MEOW_TIME);

        GameObject mesh = transform.Find("CatMesh").gameObject;
        material = new Material(mesh.GetComponent<Renderer>().material);
        
        int color = Random.Range(0, 4);
        if (color == 0)
        {
            material.color = Color.black;
        } else if (color == 1)
        {
            material.color = Color.white;
        } else if (color == 2)
        {
            material.color = Color.grey;
        }
        mesh.GetComponent<Renderer>().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.LookAt(Camera.main.gameObject.transform);
    }

    private void FixedUpdate()
    {
        transform.localRotation = Quaternion.AngleAxis(90 * direction, transform.up);
        transform.Translate(-speed, 0, 0);
    }

    void ChangeDirection()
    {
        direction = Random.Range(0, 4);
    }

    void NewCat()
    {
        Instantiate(this.gameObject, new Vector3(Random.Range(-radius, radius), 0.3f, Random.Range(-radius, radius)), Quaternion.identity);
    }

    void DecreaseHealth()
    {
        if (health > 1)
            health -= 1;
        else
        {
            Vector3 pos = transform.position;
            pos.y = 0.152f;
            Instantiate(rip, pos, transform.localRotation);
            catNumber--;
            if (catNumber == 0)
            {
                gameover.enabled = true;
                Time.timeScale = 0;
            }
            Destroy(this.gameObject);
        }
        slider.value = health / maxHealth;
    }

    void Meow()
    {
        meows[MEOW_NUMBER].Play();
    }

    private void OnDestroy()
    {
        Destroy(material);
    }
}
