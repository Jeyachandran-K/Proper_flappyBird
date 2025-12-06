using UnityEngine;
using UnityEngine.VFX;

public class Pipe : MonoBehaviour
{

    [SerializeField] private float speed;
    private void Update()
    {
        transform.position += Vector3.left*Time.deltaTime*speed;
    }
}
