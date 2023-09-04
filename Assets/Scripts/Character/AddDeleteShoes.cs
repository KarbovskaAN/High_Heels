using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDeleteShoes : MonoBehaviour
{
    [SerializeField] private GameObject _pointSpawn;
    //[SerializeField] private GameObject _pointSpawnRightLeg;
    [SerializeField] private GameObject _shoes;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shoes"))
        {
            InstantiateShoes();
        }
    }

    private void AddShoes()
    {
        
    }

    private void InstantiateShoes()
    {
        Vector3 spawnShoes = _pointSpawn.transform.position;
       GameObject shoes = Instantiate(_shoes,spawnShoes, Quaternion.identity);
       shoes.transform.parent = _pointSpawn.transform;
    }
}
