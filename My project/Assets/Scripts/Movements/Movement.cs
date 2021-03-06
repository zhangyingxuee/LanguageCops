
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
 public Transform player;
 public Vector3 offset;
    public Animator walking;

 public GameObject textBox;
    private bool AllowMovement = true;

    void Start()
    {
        GameEvents.current.onCloseCafe += toggleAllowance;
    }
    private void toggleAllowance()
    {
        AllowMovement = !AllowMovement;
        //Debug.Log(AllowMovement);
    }

    // Update is called once per frame
    void Update()
    {
        if (textBox.activeSelf==false & AllowMovement == true)
        {
            
            if (Input.GetKey("d"))
            {
                walking.SetBool("IsWalking", true);
                player.position += offset; 
            }
            if (Input.GetKey("a"))
            {
                walking.SetBool("IsWalking", true);
                player.position -= offset; 
            }
        }
        walking.SetBool("IsWalking", false);

    }
}
