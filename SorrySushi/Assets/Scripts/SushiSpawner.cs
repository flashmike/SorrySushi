using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiSpawner : MonoBehaviour
{
    public GameObject sushi;
    public GameObject bomb;
    public float maxX;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartSpawning", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnSushiGroup", 1, 6f);
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnSushiGroup");
        StopCoroutine("SpawnSushi");
    }

    public void SpawnSushiGroup()
    {
        StartCoroutine("SpawnSushi");

        /*spawn bomb*/
        if (Random.Range (0, 6) > 3)
        {
            SpawnBomb();
        }
    }

    IEnumerator SpawnSushi()
    {
        for (int i = 0; i < 5; i++)
        {
            float Rand = Random.Range(-maxX, maxX);
            Vector3 pos = new Vector3(Rand, transform.position.y, 0);
            GameObject f = Instantiate(sushi, pos, Quaternion.identity) as GameObject;
            /*add force on sushi object; so it goes up before coming down*/
            f.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15f), ForceMode2D.Impulse);

            /*then add rotation on sushi*/
            /*f.GetComponent<Rigidbody2D>().AddTorque(20f);*/

            /*randomize rotation*/
            f.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-20f,20f));


            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnBomb()
    {
        float Rand = Random.Range(-maxX, maxX);
        Vector3 pos = new Vector3(Rand, transform.position.y, 0);
        GameObject b = Instantiate(bomb, pos, Quaternion.identity) as GameObject;
        b.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15f), ForceMode2D.Impulse);
        b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-50f, 50f));
    }
}
