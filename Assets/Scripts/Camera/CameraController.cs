using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _player;
    

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = _player.position.x - 9.5f;
        temp.y = _player.position.y +5;

        transform.position = temp;
    }
}
