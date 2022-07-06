using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    float horizontalmove = 0f;
    public float offset;
    private Vector3 position;
    private bool m_FacingRight = true;
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;
    public Animator walking;
    public GameObject textBox;
    private bool AllowMovement = true;
    public bool isInCutScene;

    // Start is called before the first frame update
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        GameEvents.current.onCloseCafe += toggleAllowance;
    }

    // Update is called once per frame
    void Update()
    {
        if (textBox.activeSelf == false & AllowMovement == true & isInCutScene == false)
        {
            horizontalmove = Input.GetAxisRaw("Horizontal") * offset;
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                walking.SetBool("IsWalking", true);
            } else
            {
                walking.SetBool("IsWalking", false);
            }
        }
        else
        {
            horizontalmove = 0;
            walking.SetBool("IsWalking", false);
        }

        
    }
    private void toggleAllowance()
    {
        if (!isInCutScene)
        {
            AllowMovement = !AllowMovement;
        } 
        //Debug.Log(AllowMovement);
    }
    private void FixedUpdate()
    {
        //Move character here
        move();



    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void move()
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(horizontalmove * 10f, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        // If the input is moving the player right and the player is facing left...
        if (horizontalmove > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalmove < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }
}
