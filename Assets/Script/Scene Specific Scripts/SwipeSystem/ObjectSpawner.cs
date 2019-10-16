using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Rigidbody2D spawnedObjects;
    public GameObject spawnPoint;
    public GameObject particle1;

    public void OnSpin()
    {
        particle1.SetActive(true);
        StartCoroutine(SpawnSequence(1));
    }

    public IEnumerator SpawnSequence(int duration){
        InvokeRepeating("SpawnObjects", 0.0f, 0.1f);
        yield return new WaitForSeconds(duration);
        CancelInvoke("SpawnObjects");

        yield return new WaitForSeconds(duration*3);
        particle1.SetActive(false);
    }

    public void SpawnObjects() {
        Instantiate(spawnedObjects, spawnPoint.transform.position, Quaternion.identity);

        //Rigidbody2D instance = Instantiate(spawnedObjects, spawnPoint);
        //instance.velocity = Random.insideUnitSphere * 5;
        //instance.AddForce(transform.up * 5);
    }

}
