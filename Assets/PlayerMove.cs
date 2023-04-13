using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public enum PLAYER_STATE { IDLE, MOVE, STOP, COLLIDE_WALL,}

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    [SerializeField] 
    private float JumpPower;

    [SerializeField]
    private int GroundJumpCount;

    [SerializeField]
    private int WallJumpCount;

    private bool isWallCheck;

    private int currentGroundJumpCount;


    public bool isWallJump = false;

    void Start()
    {
        isWallCheck = false;
        currentGroundJumpCount = 0;
    }

    public void Jump()
    {
        if ((isWallCheck || currentGroundJumpCount < GroundJumpCount) && Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("Jump");
            currentGroundJumpCount++;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (isWallCheck)
            {
                Vector3 currentPosition = this.transform.position.normalized * -1;
                //currentPosition.x *= 2f;
                currentPosition.y = 1f;
                GetComponent<Rigidbody>().AddForce(currentPosition * JumpPower);
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().AddForce(Vector3.up * JumpPower);
            }
            

            isWallCheck = false;
        }
    }


    
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        GetComponent<Rigidbody>().AddForce( new Vector3(h, 0, v) * Time.deltaTime * Speed , ForceMode.Impulse);

        Jump();
        

       
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        RaycastHit hit;
        
        if (Physics.Raycast(this.transform.position, Vector3.right, out hit, 0.6f) ||
            Physics.Raycast(this.transform.position, Vector3.left, out hit, 0.6f) ||
            Physics.Raycast(this.transform.position, Vector3.forward, out hit, 0.6f) ||
            Physics.Raycast(this.transform.position, Vector3.back, out hit, 0.6f)   )
        {
            if (hit.collider.gameObject.tag == "Wall")
            {
                Debug.Log("º®");
                currentGroundJumpCount = GroundJumpCount-1;
                isWallCheck = true;
                return;
            }
        }

        if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 1f))
        {
            if (hit.collider != null)
            {
                currentGroundJumpCount = 0;
                return;
            }
        }


    }
}
