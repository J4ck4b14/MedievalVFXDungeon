using System.Collections;
using UnityEngine;

public class ToxicBehavior : MonoBehaviour
{
    public float size = 0;
    public float speed = 1;
    public float timeToDecrease = 5f;
    public float decreaseTime = 0.5f;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("GoShorty", 1f, 0.5f);
        Invoke("KillIt", timeToDecrease);
    }

    IEnumerator GoShorty()
    {
        size++;
        gameObject.transform.localScale = new Vector3(size*0.1f, size*0.1f);
        gameObject.transform.position = Vector3.forward * speed;
        Debug.Log("Funciono");
        yield return null;
    }

    IEnumerator KillIt()
    {
        if (size > 1)
        {
            StopCoroutine("GoShorty");
            size -= .1f;
            gameObject.transform.position = Vector3.forward * speed;
            Invoke("KillIt", decreaseTime);
            yield return null;
        }
        else
        {
            StopAllCoroutines();
            Object.DestroyImmediate(gameObject);
            yield return null;
        }
    }
}
