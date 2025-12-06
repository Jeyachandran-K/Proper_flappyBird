using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Pipe pipe;
    


    private float minHeight=3f;
    private float timer;
    

    private void Start()
    {
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(-minHeight, minHeight), 0), Quaternion.identity);
    }

    private void Update()
    {

        if (timer > 2f)
        {
            timer = 0;
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(-minHeight, minHeight), 0), Quaternion.identity);
        }
        else
        {
            timer += Time.deltaTime;
        }
        
    }
}
