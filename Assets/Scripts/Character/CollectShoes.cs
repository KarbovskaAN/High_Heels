using System.Collections.Generic;
using UnityEngine;

public class CollectShoes : MonoBehaviour
{
    [SerializeField] private GameObject _pointSpawnLeftLeg;
    [SerializeField] private GameObject _pointSpawnRightLeg;
    [SerializeField] private GameObject _pointSpawnCollider;
    [SerializeField] private GameObject _shoesPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _colliderShoesPrefab;
    [SerializeField] private Transform _shoesCollectCollider;
    
    
    private List<GameObject> _leftShoesList = new List<GameObject>(); 
    private List<GameObject> _rightShoesList = new List<GameObject>(); 
    public List<GameObject> _colliderShoesList = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        Vector3 spawnShoesLL = _pointSpawnLeftLeg.transform.position;
        Vector3 spawnShoesRL = _pointSpawnRightLeg.transform.position;
        Vector3 spawnCollider = _pointSpawnCollider.transform.position;
        
        if (other.gameObject.CompareTag("Shoes"))
        { 
            Destroy(other.gameObject); 
            
            GameObject leftShoesList =InstantiateShoes(spawnShoesLL, _shoesPrefab, _pointSpawnLeftLeg);
            _leftShoesList.Add(leftShoesList);
            GameObject rightShoesList = InstantiateShoes(spawnShoesRL,_shoesPrefab, _pointSpawnRightLeg);
            _rightShoesList.Add(rightShoesList);
            GameObject collider = InstantiateShoes(spawnCollider, _colliderShoesPrefab, _pointSpawnCollider);
            _colliderShoesList.Add(collider);

            _parent.position += new Vector3(0, 0.5f, 0);
            _shoesCollectCollider.position -= new Vector3(0, 0.5f, 0);

            PositionCollider(collider,_colliderShoesList);
            PositionShoes(leftShoesList,_leftShoesList);
            PositionShoes(rightShoesList,_rightShoesList);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") )
        {
            NewMethod(); 
            _parent.position -= new Vector3(0,0.50f,0);
            _shoesCollectCollider.position += new Vector3(0, 0.5f, 0);
        }
    }

    public void NewMethod()
    {
        GameObject leftShoes = _leftShoesList[_leftShoesList.Count - 1];
        Destroy(leftShoes);
        GameObject rightShoes = _rightShoesList[_rightShoesList.Count - 1];
        Destroy(rightShoes);

        GameObject collider = _colliderShoesList[_colliderShoesList.Count - 1];
        Destroy(collider);
        
        _leftShoesList.RemoveAt(_leftShoesList.Count - 1);
        _rightShoesList.RemoveAt(_rightShoesList.Count - 1);
        
        if (_colliderShoesList.Count != 0 )
        {
            _colliderShoesList.RemoveAt(_colliderShoesList.Count - 1);
        }
    }

    private GameObject InstantiateShoes(Vector3 spawnPointPosition,GameObject prefab, GameObject spawnPoint)
    {
       
       GameObject shoes = Instantiate(prefab,spawnPointPosition, Quaternion.identity);
       shoes.transform.SetParent( spawnPoint.transform);
       return shoes;
    }
    private void PositionShoes(GameObject go , List<GameObject> gameObjectsList)
    {
        go.transform.localEulerAngles = new Vector3(90,0,0);
        
        if (gameObjectsList.Count == 1)
        {
            go.transform.localPosition -= new Vector3(0, 0, +0.5f);
        }
        else
        {
            go.transform.localPosition = new Vector3(0, 0, gameObjectsList[gameObjectsList.Count - 2].transform.localPosition.z - 0.5f);
        }
    } 
    private void PositionCollider(GameObject go,List<GameObject> gameObjectsList)
    {
        if (gameObjectsList.Count == 1)
        {
            go.transform.localPosition -= new Vector3(0, +0.5f, 0);
        }
        else
        {
            go.transform.localPosition = new Vector3(0, gameObjectsList[gameObjectsList.Count - 2].transform.localPosition.y - 0.5f, 0);
        }
    }
}
