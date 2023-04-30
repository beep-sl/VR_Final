using UnityEngine;
public class OnCollisionEnter : MonoBehaviour
{
    public int damage = 1;
    public float totalLifeTime = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth)
            {
                GameManager.Instance.currentHealth -= damage;
            }
            Destroy(this.gameObject);
        }
    }

    void Start() {
        Destroy(this.gameObject, totalLifeTime);
    }
}
