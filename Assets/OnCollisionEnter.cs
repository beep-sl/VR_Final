using UnityEngine;
public class OnCollisionEnter : MonoBehaviour
{
    public float damage;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            //Debug.Log(playerHealth.health);
            if (playerHealth)
            {
                playerHealth.health -= damage;
            }
        }
    }
}
