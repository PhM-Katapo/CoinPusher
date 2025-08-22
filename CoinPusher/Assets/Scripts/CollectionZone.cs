using UnityEngine;

public class CollectionZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.Instance.CollectCoin(other.gameObject);
        }
    }
}