using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] prefabs;

    int maxObjects = 10;

    float xMin = -6.0f;
    float xMax = 6.0f;

    float yStart = 3.0f;

    GameObject[] objects;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();    
    }

    // Update is called once per frame
    void Update()
    {
        GameObject currentObject = objects[index];

        
    }

    void SpawnObjects()
    {
        objects = new GameObject[maxObjects];

        // randomize
        for(int i = 0; i < maxObjects; i++)
        {
            float xPos = Random.Range(-3.0f, 3.0f);
            Vector3 position = new Vector3(xPos, 10.0f, 0);

            int type = Random.Range(0, prefabs.Length);
            objects[i] = Instantiate(prefabs[type], position, Quaternion.identity);
        }

        // animate the first object
        // when the animation completes, another object is animated this keep repeating.
        objects[index].transform.DOMove(new Vector3(objects[index].transform.position.x, -10, 0), 3)
            .onComplete = NextObject;
 
    }

    void NextObject()
    {
        if (index < maxObjects - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }

        // animate the first object
        float xPos = Random.Range(-3.0f, 3.0f);
        Vector3 position = new Vector3(xPos, 10.0f, 0);
        objects[index].transform.position = position;
        objects[index].transform.DOMove(new Vector3(objects[index].transform.position.x, -10, 0), 3)
            .onComplete = NextObject;
    }

}
