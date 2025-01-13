using System.Collections;
using UnityEngine;

public class ToxicBehavior : MonoBehaviour
{
    public float size = 0;
    public float speed = 0.1f;
    [Tooltip("This variable sets the time until it starts shrinking.")]
    public float timeUntilShrinkingStarts = 2f;
    [Tooltip("This variable sets the time between each coroutine iteration")]
    public float coroutineTime = 0.05f;

    private Coroutine goShortyCoroutine;

    void GoShorty()
    {
        size += 0.1f;
        transform.localScale = new Vector3(size, size, size);
        transform.localPosition += Vector3.forward * speed;
    }

    IEnumerator GoShortyRepeating()
    {
        while (true)
        {
            yield return new WaitForSeconds(coroutineTime);
            GoShorty();
        }
    }

    /// <summary>
    /// KillIt() makes the target smaller until its scale's magnitude is smaller than 0.866 (Vector3.one * 0.5f)
    /// E.g.: (0.45, 0.5, 0.55) > (0.5, 0.5, 0.5) -> The target would get smaller again
    /// </summary>
    IEnumerator KillIt()
    {
        if (transform.localScale.magnitude > new Vector3(0.5f, 0.5f, 0.5f).magnitude)
        {
            if (goShortyCoroutine != null)
            {
                StopCoroutine(goShortyCoroutine);
            }

            while (size > 0.5f)
            {
                size -= 0.1f;
                transform.localScale = new Vector3(size, size, size);
                transform.localPosition += Vector3.forward * speed;
                yield return new WaitForSeconds(coroutineTime);
            }
        }

        Destroy(gameObject);
    }

    void StartKillIt()
    {
        StartCoroutine(KillIt());
    }

    void Start()
    {
        goShortyCoroutine = StartCoroutine(GoShortyRepeating());
        Invoke("StartKillIt", timeUntilShrinkingStarts);
    }
}
