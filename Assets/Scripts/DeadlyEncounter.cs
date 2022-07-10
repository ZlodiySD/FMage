using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DeadlyEncounter : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeathEncounterTriggered(collision.collider.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeathEncounterTriggered(collision.gameObject);
    }

    public void DeathEncounterTriggered(GameObject go)
    {
        if (!go.TryGetComponent(out PlayerController playerController))
            return;

        TriggerDeath(playerController);
    }

    public virtual void TriggerDeath(PlayerController playerController)
    {
        playerController.Die();
    }
}
