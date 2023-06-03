using UnityEngine;

public class SphereTrap : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.GetDamage(Damage);
        }
    }
}
