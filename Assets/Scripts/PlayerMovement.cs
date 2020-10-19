using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float breakForce = 2500f;
    public float turnForce = 15f;
    public float sidewaysForce = 500f;
    
    public static bool startGame = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(startGame){
            
            forwardForce = forwardForce + 0.0000001f;

            rb.AddForce(0,0,forwardForce * Time.deltaTime);

            if ( Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) )
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                transform.rotation = Quaternion.Euler(0, Input.GetAxis("Horizontal") * turnForce,0);
            }

            if ( Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                transform.rotation = Quaternion.Euler(0,-Input.GetAxis("Horizontal") * -turnForce,0);
            }

            if ( Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(0,0,-breakForce * Time.deltaTime);
            }

            if(!Input.anyKey){
    
                transform.rotation = Quaternion.Euler(0,0,0);
            
            }
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
