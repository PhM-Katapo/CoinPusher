using UnityEngine;

public class CoinDropper : MonoBehaviour
{
    [Header("Drop Settings")]
    public GameObject coinPrefab;
    public Transform dropPoint;
    public float dropForce = 5f;
    public LayerMask coinLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DropCoin();
        }
    }

    void DropCoin()
    {
        if (GameManager.Instance.CanDropCoin())
        {
            GameObject coin = Instantiate(coinPrefab, dropPoint.position, Quaternion.identity);

            // Add downward force with slight randomization
            Vector3 force = Vector3.down * dropForce;
            force += new Vector3(
                Random.Range(-0.5f, 0.5f),
                0,
                Random.Range(-0.5f, 0.5f)
            );

            Coin coinScript = coin.GetComponent<Coin>();
            coinScript.Launch(force);
            GameManager.Instance.OnCoinDropped();
        }
    }
}