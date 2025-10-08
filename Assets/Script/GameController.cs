using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using System.Collections;
public class GameController : MonoBehaviour
{

    [SerializeField] Image[] slotIcons;
    [SerializeField] SlotMachine[] slots;
    [SerializeField] TMP_Text TextMessage;
    [SerializeField] Button button;
    [SerializeField] Animator Handle_animator;



    public event Action OnSpin;
    public event Action<int> OnStop;

    private bool _isChecked;


    void OnEnable()
    {
        button.onClick.AddListener(startSpin);
    }
    void OnDisable()
    {
        button.onClick.RemoveListener(startSpin);
    }


    void Update()
    {
        Check();
    }

    private void Check()
    {
        if (slots[0].isStotp && slots[1].isStotp && slots[2].isStotp)
        {
            if (_isChecked == false)
            {
                _isChecked = true;


                if (slotIcons[0].sprite == slotIcons[1].sprite && slotIcons[1].sprite == slotIcons[2].sprite)
                {
                    TextMessage.text = "3X JackPot!!";
                    OnStop?.Invoke(3);
                }
                else if (slotIcons[0].sprite != slotIcons[1].sprite && slotIcons[0].sprite == slotIcons[2].sprite)
                {
                    TextMessage.text = "2X !!";
                    OnStop?.Invoke(2);
                }
                else if (slotIcons[0].sprite != slotIcons[1].sprite && slotIcons[1].sprite != slotIcons[2].sprite
                 && slotIcons[0].sprite != slotIcons[2].sprite)
                {
                    TextMessage.text = "1X !!";
                    OnStop?.Invoke(1);
                }
                else
                {
                    TextMessage.text = "Better Luck Next Time!!";
                }
            }

            if (!CoinManager.Instance.ChekCons())
            {
                button.interactable = false;
                TextMessage.text = "No More Coins!!";
            }
            else
            {
                button.interactable = true;

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


    private void startSpin()
    {

        _isChecked = false;
        Handle_animator.SetTrigger("HandlePull");
        OnSpin?.Invoke();
        button.interactable = false;
        foreach (var slot in slotIcons)
        {
            slot.GetComponent<SlotMachine>().spinStart();
        }
    }

    public void restSlots()
    {

        StartCoroutine(restAllSlot());
        _isChecked = true;
          button.interactable = true;
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

