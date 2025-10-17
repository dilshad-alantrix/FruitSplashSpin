using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using System.Collections;
using CandyCoded.HapticFeedback;
public class GameController : Subject
{
    [Header("GamePlay")]
    [SerializeField] private Image[] slotIcons;
    [SerializeField] private SlotMachine[] slots;
    [SerializeField] private Animator Handle_animator;
    [SerializeField] private ParticleSystem coinParticle;


    [Header("UI")]

    [SerializeField] private Button SpinButton;
    [SerializeField] private Button SpinHandleButton;
    [SerializeField] private Button AddButton;
    [SerializeField] private Button SubButton;
    
    

    private bool _isChecked;


    void OnEnable()
    {
        SpinButton.onClick.AddListener(StartSpin);
        SpinHandleButton.onClick.AddListener(StartSpin);
    }
    void OnDisable()
    {
        SpinButton.onClick.RemoveListener(StartSpin);
        SpinHandleButton.onClick.RemoveListener(StartSpin);
    }


    void Update()
    {
        CheckSlotState();
    }

    private void CheckSlotState()
    {
        if (slots[0].isStotp && slots[1].isStotp && slots[2].isStotp)
        {
            if (_isChecked == false)
            {
                _isChecked = true;
                RestSlots();

                EvaluatResult();
              
            }

            //Check coin is avilable
            if (!CoinManager.Instance.ChekCons())
            {
                
                NotifyObserver(GameState.NoCoin);
            }
            

        }
        else if (slots[0].isSpinning || slots[1].isSpinning
         || slots[2].isSpinning)
        {
           
             NotifyObserver(GameState.Spining);
        }

    }
    
    private void EvaluatResult()
    {
          if (slotIcons[0].sprite == slotIcons[1].sprite && slotIcons[1].sprite == slotIcons[2].sprite)
                {
                    
                    coinParticle.Play();
                    NotifyObserver(GameState.Win3x);
                    HapticFeedback.MediumFeedback();
                    
                }
                else if (slotIcons[0].sprite != slotIcons[1].sprite && slotIcons[0].sprite == slotIcons[2].sprite)
        {
                  
                    NotifyObserver(GameState.Win2x);
                    HapticFeedback.MediumFeedback();

                }
                else if (slotIcons[0].sprite != slotIcons[1].sprite && slotIcons[1].sprite != slotIcons[2].sprite
                 && slotIcons[0].sprite != slotIcons[2].sprite)
        {           
                   
                    NotifyObserver(GameState.Win1x);
                    HapticFeedback.HeavyFeedback();

                }
                else
                {
                   NotifyObserver(GameState.Loose);
                }
    }

    
    private void StartSpin()
    {

        _isChecked = false;
        Handle_animator.SetTrigger("HandlePull");
        NotifyObserver(GameState.PressSpinBtn);
        foreach (var slot in slotIcons)
        {
            slot.GetComponent<SlotMachine>().spinStart();
        }
    }

    //Reset all slot there initial positon 
    public void RestSlots()
    {

        StartCoroutine(restAllSlot());
        _isChecked = true;
        SpinButton.interactable = true;
        SpinHandleButton.interactable = true;
        AddButton.interactable = true;
        SubButton.interactable = true;
    }

    IEnumerator restAllSlot()
    {
        foreach (var slot in slots)
        {
            slot.enabled = false;
        }
        yield return null;
        foreach (var slot in slots)
        {
            slot.enabled = true;
        }
    }
}

