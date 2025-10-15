using System.Collections;
using UnityEngine;

public class SpinningWheel : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float SpinSpeed;

     public int  reward { get; private set; }
     public bool onGetReward; 

    public void spin()
    {
        float Speed = Random.Range(SpinSpeed,20);
        StartCoroutine(StartSpin(Speed));

    }

    IEnumerator StartSpin(float speed)
    {
        if (animator == null)
            yield break;
        animator.SetTrigger("Spin");
        onGetReward = false;
        while (speed > 0)
        {
            yield return new WaitForSeconds(1f);
            speed = Mathf.Max(0,speed-3);
            animator.SetFloat("Speed", speed);

        }
        onGetReward = true;

        
    }
    
    public void Reward(int amound)
    {
        reward = amound;
    }
 

}
