using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class DeathEncounterTest : MonoBehaviour
{
    void Start()
    {
        Debug.LogWarning("Hey, I'm test script");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerController player))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
