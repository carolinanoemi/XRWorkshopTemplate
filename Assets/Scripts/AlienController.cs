using UnityEngine;


// This script handles the alien's attack action when the Tab key is pressed.

public class AlienController : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            animator.SetTrigger("Attack");
        }
    }
}
