using System.Collections.Generic;
using UnityEngine;

public class CollectShoes : MonoBehaviour
{
    [SerializeField] private GameObject _pointSpawnLeftLeg;
    [SerializeField] private GameObject _pointSpawnRightLeg;
    [SerializeField] private GameObject _shoes;
    private List<GameObject> _leftShoesList = new List<GameObject>(); 
    private List<GameObject> _rightShoesList = new List<GameObject>(); 
    private void OnTriggerEnter(Collider other)
    {
        Vector3 spawnShoesLL = _pointSpawnLeftLeg.transform.position;
        Vector3 spawnShoesRL = _pointSpawnRightLeg.transform.position;
        
        if (other.gameObject.CompareTag("Shoes"))
        {
            _leftShoesList.Add(InstantiateShoes(spawnShoesLL,_pointSpawnLeftLeg));
            _rightShoesList.Add(InstantiateShoes(spawnShoesRL,_pointSpawnRightLeg));
            
            gameObject.transform.position += new Vector3(0,0.5f,0);
            gameObject.GetComponent<BoxCollider>().center -= new Vector3(0,0.5f,0);

            ShoesPositionAdd(_leftShoesList);
            ShoesPositionAdd(_rightShoesList);

        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameObject f = _leftShoesList[_leftShoesList.Count - 1];
            Destroy(f);
            GameObject ff = _rightShoesList[_rightShoesList.Count - 1];
            Destroy(ff);
            _leftShoesList.RemoveAt(_leftShoesList.Count-1);
            _rightShoesList.RemoveAt(_rightShoesList.Count-1);
            
            gameObject.transform.position -= new Vector3(0,0.5f,0);
            gameObject.GetComponent<BoxCollider>().center += new Vector3(0,0.5f,0);

            ShoesPositionDelete(_leftShoesList);
            ShoesPositionDelete(_rightShoesList);
        }
    }
    private GameObject InstantiateShoes(Vector3 spawnPointPosition,GameObject spawnPoint)
    {
       
       GameObject shoes = Instantiate(_shoes,spawnPointPosition, Quaternion.identity);
       shoes.transform.SetParent( spawnPoint.transform);
       return shoes;
    }

    private void ShoesPositionAdd(List<GameObject> shooes)
    {
        foreach (var shoes in shooes)
        {
            shoes.transform.localPosition -= new Vector3(0, 0,0.5f);
        }
    }
    private void ShoesPositionDelete(List<GameObject> shooes)
    {
        foreach (var shoes in shooes)
        {
            shoes.transform.localPosition += new Vector3(0, 0, 0.5f);
        }
    }
}
