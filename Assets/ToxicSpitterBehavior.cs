using UnityEngine;

public class ToxicSpitterBehavior : MonoBehaviour
{
    public float minimumTime = 3;
    public float maximumTime = 15;

    float randomTime = 0;

    public GameObject projectilePrefab;

    void Shoot()
    {
        randomTime = Random.Range(minimumTime, maximumTime);
        Instantiate(projectilePrefab, transform.parent);
        Invoke("Shoot", randomTime);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomTime = Random.Range(minimumTime, maximumTime);
        Invoke("Shoot", randomTime);
    }
}
