using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] float ScrollSpeed = 10f;
     public Sprite[] icons;
    public bool isStotp;
    public bool isSpinning;
    
    
    private Image image;
    private Animator _animator;


    void Start()
    {
        image = GetComponent<Image>();
        _animator = GetComponent<Animator>();
        isStotp = false;
        isSpinning = false;

    }




    public void spinStart()
    {
        int time = Random.Range(4, 7);
        StartCoroutine(spin(time, ScrollSpeed));

    }

    IEnumerator spin(int time, float speed)
    {
        isStotp = false;
        isSpinning = true;
        _animator.SetBool("Spin", true);
        while (time != 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
            _animator.SetFloat("ScrollSpeed", speed);
            speed -= 0.5f;
        }
        _animator.SetBool("Spin", false);
        Invoke("AnimationEvent_Stop", 0.5f);
    }

    private void AnimationEvent_Stop()
    {
        isStotp = true;
        isSpinning = false;
    }

    public void ChangeIcon()
    {
        int index = Random.Range(0, icons.Length);
        image.sprite = icons[index];
    }
    public void PlaySound()
    {
        AudioManager.Instance.PlaySpinSound();
    }


}
