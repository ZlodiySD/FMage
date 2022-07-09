using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class DeathEncounterTest : MonoBehaviour
{
    void Start()
    {
        Debug.LogWarning("Hey, I'm test script");
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
