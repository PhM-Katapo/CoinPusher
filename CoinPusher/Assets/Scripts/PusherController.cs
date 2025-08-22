using UnityEngine;

public class PusherController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float pushDistance = 2f;
    public float pushSpeed = 2f;
    public float pushInterval = 3f;

    private Vector3 startPosition;
    private Vector3 pushPosition;
    private bool isPushing = false;
    private float timer;

    void Start()
    {
        startPosition = transform.position;
        pushPosition = startPosition + Vector3.forward * pushDistance;
        timer = pushInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !isPushing)
        {
            StartCoroutine(PushSequence());
            timer = pushInterval;
        }
    }

    System.Collections.IEnumerator PushSequence()
    {
        isPushing = true;

        // Push forward
        yield return StartCoroutine(MoveTo(pushPosition));

        // Wait briefly
        yield return new WaitForSeconds(0.1f);

        // Pull back
        yield return StartCoroutine(MoveTo(startPosition));

        isPushing = false;
    }

    System.Collections.IEnumerator MoveTo(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, pushSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
