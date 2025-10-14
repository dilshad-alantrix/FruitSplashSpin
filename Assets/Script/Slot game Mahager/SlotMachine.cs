using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [Header("Slot settings")]
    [SerializeField] private float ScrollSpeed = 10f;
    [SerializeField] private float ScrollTime = 6f;
    [SerializeField] private Sprite[] icons;
   
    private Image image;
    private Animator _animator;

     public bool isStotp { get; private set; }
     public bool isSpinning{ get; private set; }




    void Start()
    {
        image = GetComponent<Image>();
        _animator = GetComponent<Animator>();
        isStotp = false;
        isSpinning = false;

    }

    
    //Spin start when call GameController
    public void spinStart()
    {
        
        StartCoroutine(spin(ScrollTime, ScrollSpeed));

    }

    IEnumerator spin(float time, float speed)
    {
        isStotp = false;
        isSpinning = true;
        _animator.SetBool("Spin", true);
        while (time != 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
            _animator.SetFloat("ScrollSpeed", speed);
            speed -= 2f;
        }
        _animator.SetBool("Spin", false);
        Invoke("AnimationEvent_Stop", 0.5f);
    }

    private void AnimationEvent_Stop()
    {
        isStotp = true;
        isSpinning = false;
    }

    //Change icon 
    public void ChangeIcon()
    {
        int index = Random.Range(0, icons.Length);
        image.sprite = icons[index];
    }

    //Play slot spin sfx
    public void PlaySound()
    {
       EventManager.OnPlaySlotSfx?.Invoke();
    }


}
