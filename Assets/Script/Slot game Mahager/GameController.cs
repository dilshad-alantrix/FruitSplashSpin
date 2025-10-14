using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using System.Collections;
using CandyCoded.HapticFeedback;
public class GameController : MonoBehaviour
{
    [Header("GamePlay")]
    [SerializeField] private Image[] slotIcons;
    [SerializeField] private SlotMachine[] slots;
    [SerializeField] private Animator Handle_animator;
    [SerializeField] private ParticleSystem coinParticle;


    [Header("UI")]
    [SerializeField] private TMP_Text TextMessage;
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
                SpinButton.interactable = false;
                SpinHandleButton.interactable = false;
                SubButton.interactable = true;
                TextMessage.text = "No More Coins!!";
            }
            else
            {
                SpinButton.interactable = true;
                SubButton.interactable = true;
                AddButton.interactable = true;
                SpinHandleButton.interactable = true;
            }


        }
        else if (slots[0].isSpinning || slots[1].isSpinning
         || slots[2].isSpinning)
        {
            TextMessage.text = "Good Luck!!";
        }
        else
        {
            TextMessage.text = "Press Spin!!";
        }


    }
    
    private void EvaluatResult()
    {
          if (slotIcons[0].sprite == slotIcons[1].sprite && slotIcons[1].sprite == slotIcons[2].sprite)
                {
                    TextMessage.text = "3X JackPot!!";
                    EventManager.OnSpinStop?.Invoke(3);
                    coinParticle.Play();
                    HapticFeedback.MediumFeedback();
                }
                else if (slotIcons[0].sprite != slotIcons[1].sprite && slotIcons[0].sprite == slotIcons[2].sprite)
                {
                    TextMessage.text = "2X !!";
                    EventManager.OnSpinStop?.Invoke(2);
                    HapticFeedback.MediumFeedback();

                }
                else if (slotIcons[0].sprite != slotIcons[1].sprite && slotIcons[1].sprite != slotIcons[2].sprite
                 && slotIcons[0].sprite != slotIcons[2].sprite)
                {
                    TextMessage.text = "1X !!";
                    EventManager.OnSpinStop?.Invoke(1);
                    HapticFeedback.HeavyFeedback();

                }
                else
                {
                    TextMessage.text = "Better Luck Next Time!!";
                }
    }

    
    private void StartSpin()
    {

        _isChecked = false;
        Handle_animator.SetTrigger("HandlePull");
        EventManager.OnSpinStart?.Invoke();
        SpinButton.interactable = false;
        SpinHandleButton.interactable = false;
        SubButton.interactable = false;
        AddButton.interactable = false;
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

