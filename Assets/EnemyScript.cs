using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;
    public AnimationClip death;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            animator.Play("DIE");
            Destroy(gameObject, death.length);
        }
    }
}