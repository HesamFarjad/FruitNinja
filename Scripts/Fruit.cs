using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public GameObject slicedFruitPrefab;

    public void CreateSlicedFruit()
    {
        // Log the original fruit's position and rotation
        Debug.Log("Original Fruit Position: " + transform.position);
        Debug.Log("Original Fruit Rotation: " + transform.rotation);

        GameObject inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        // Log the instantiated sliced fruit's position and rotation
        Debug.Log("Sliced Fruit Position: " + inst.transform.position);
        Debug.Log("Sliced Fruit Rotation: " + inst.transform.rotation);



        //Play Cutting Fruits Sound
        GameManager.instance.PlayRandomSliceSound();

        Rigidbody[] rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in rbsOnSliced)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(200, 500), transform.position, 5f);
        }

        GameManager.instance.IncreaseScore(3); // ⦿ Using Singleton Instance ⦿ //



        Destroy(inst.gameObject, 5);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (!b)
        {
            return;
        }

        CreateSlicedFruit();
    }

}
