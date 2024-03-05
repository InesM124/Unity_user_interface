using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;
    private Animator animator;
    public Joystick joystick;
    int score=10;
    public Slider slider;
    public TextMeshProUGUI text;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.3f);
            animator.SetBool("move", true); // Set the "Move" parameter to true when there is movement
        }
        else
        {
            animator.SetBool("move", false); // Set the "Move" parameter to false when there is no movement
        }
        void jump()
        {
            rb.AddForce(new Vector(0,10,0),ForceMode.Impulse);
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Coins"))
            {
                score = score+1;
                text.SetText(score.ToString());
                Destroy(other.gameObject);
            }
           if (other.gameObject.tag.Equals("spike")){


            slider.value -= 10;
            Destroy(other.gameObject);

        }
        }
    }

}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class Movement : MonoBehaviour
// {
//     public float moveSpeed = 5f;
//     public float turnSpeed = 180f;
//     public TextMeshProUGUI text;
//     int score=0;
//     public Joystick joystick;
//     private Rigidbody rb;
//     public Slider slider;

//     void Start()
//     {

//         rb = GetComponent<Rigidbody>();
//     }

//     void Update()
//     {

//         float verticalInput = joystick.Vertical;
//         float horizontalInput = joystick.Horizontal;

     
//         Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
//         rb.MovePosition(rb.position + movement);

  
//         if (movement != Vector3.zero)
//         {
//             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.3f);
//         }




//     }

//    public void jump()
//     {

//         rb.AddForce(new Vector3(0, 10, 0),ForceMode.Impulse);
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.gameObject.tag.Equals("coin"))
//         {
//             score = score+ 1;
//             text.SetText(score.ToString());
//             Destroy(other.gameObject);
//         }
//         if (other.gameObject.tag.Equals("spike")){


//             slider.value -= 10;
//             Destroy(other.gameObject);

//         }
//     }



// }
