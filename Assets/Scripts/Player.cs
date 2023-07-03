using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;

    int score = 0;

    // Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        // Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Spawned")
        {
            score += 10;
            scoreText.text = $"Score: {score.ToString("D5")}";
        }
    }
}
