using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    [SerializeField] private float _speed = 0;
  
    void Update()
    {
        transform.Rotate(0, 0, _speed * Time.deltaTime);
    }
}
