using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;

    int score = 0;


    /// <summary>
    /// Upon collision with another game object, increase the score.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Spawned")
        {
            score += 10;
            scoreText.text = $"Score: {score.ToString("D5")}";
            StartConsumeItemSequence(other.gameObject);
        }
    }

    private void StartConsumeItemSequence(GameObject go)
    {
        go.SetActive(false);
    }
}
