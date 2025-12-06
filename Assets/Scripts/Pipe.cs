using UnityEngine;
using UnityEngine.VFX;

public class Pipe : MonoBehaviour
{

    [SerializeField] private float speed;

    private float deadZone = -15f;
    private void Update()
    {
        transform.position += Vector3.left*Time.deltaTime*speed;
        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

}
