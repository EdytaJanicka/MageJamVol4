using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject character;
    public float speed = 0.5f;

    public Animator animator;
    public AudioSource sound;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        float gravity = 9.8f;
        Vector3 moveAxis = new Vector3(horizontal, -gravity, vertical);
        controller.Move(((moveAxis) * speed * Time.deltaTime));
        
        if(horizontal != 0 || vertical != 0)
        {
            animator.SetBool("Walking", true);
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else
        {
            animator.SetBool("Walking", false);
            sound.Stop();
        }

        if (horizontal > 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 3f * Time.deltaTime);
        else if (horizontal < 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 3f * Time.deltaTime);
        if (vertical > 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 3f * Time.deltaTime);
        else if (vertical < 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 3f * Time.deltaTime);

    }


}
