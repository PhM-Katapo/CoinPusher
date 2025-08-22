using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin Settings")]
    public int value = 1;
    public float lifetime = 30f;

    private Rigidbody rb;

    void Start()
    {
        // Add slight random rotation for realism
        rb.angularVelocity = new Vector3(
            Random.Range(-2f, 2f),
            Random.Range(-2f, 2f),
            Random.Range(-2f, 2f)
        );

        // Self-destruct after lifetime
        Destroy(gameObject, lifetime);
    }

    public void Launch(Vector3 force)
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Impulse);
    }
}