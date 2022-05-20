
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
 public Transform player;
 public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d")){
            player.position += offset; 
        }
        if (Input.GetKey("a")){
            player.position -= offset; 
        }
    }
}
