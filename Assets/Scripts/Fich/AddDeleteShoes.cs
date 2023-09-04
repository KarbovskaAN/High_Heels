using System;
using UnityEngine;

public class AddDeleteShoes : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            _character.transform.position += new Vector3(0,-0.25f,0);
        }
        
        if (other.gameObject.CompareTag("Shoes"))
        {
            _character.transform.position += new Vector3(0,0.25f,0);
        }
    }
}
