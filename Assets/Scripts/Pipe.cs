using UnityEngine;
using UnityEngine.VFX;

public class Pipe : MonoBehaviour
{

    [SerializeField] private float speed;
    private float gameTime;
    private float dynamicSpeed;
    private float speedMultiplier=4f;

    private float deadZone = -15f;
    private void Update()
    {
        gameTime = GameManager.Instance.GetGameTime();
        
        dynamicSpeed =speed+ ((gameTime / 100) * speedMultiplier);
        transform.position += Vector3.left * Time.deltaTime * (dynamicSpeed);
            
        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
        Debug.Log(dynamicSpeed);
    }

}
