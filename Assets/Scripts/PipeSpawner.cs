using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Pipe pipe;
    


    private float minHeight=3f;
    private float timer;
    private bool isPlay;
    

    private void Start()
    {
        Bird.Instance.OnPlayState += Instance_OnPlayState;
          
    }

    private void Instance_OnPlayState(object sender, System.EventArgs e)
    {
        isPlay=true;
    }

    private void Update()
    {
        if (isPlay)
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
}
