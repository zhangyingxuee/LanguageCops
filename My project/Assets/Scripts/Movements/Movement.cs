
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
 public Transform player;
 public Vector3 offset;

 public GameObject textBox;

    // Update is called once per frame
    void Update()
    {
        if (textBox.activeSelf==false)
        {
            if (Input.GetKey("d"))
            {
                player.position += offset; 
            }
            if (Input.GetKey("a"))
            {
                player.position -= offset; 
            }
        }
        
    }
}
