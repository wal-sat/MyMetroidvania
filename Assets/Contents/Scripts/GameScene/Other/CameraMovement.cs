using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(_playerTransform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
