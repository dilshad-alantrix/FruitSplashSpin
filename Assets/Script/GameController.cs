using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using JetBrains.Annotations;
public class GameController : MonoBehaviour
{

    [SerializeField] SpriteRenderer[] slotIcons;
    [SerializeField] TMP_Text TextMessage;
    [SerializeField] Button button;
    [SerializeField] Animator Handle_animator;
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
         if (slotIcons[0].GetComponent<SlotMachine>().isStotp && slotIcons[1].GetComponent<SlotMachine>().isStotp
         && slotIcons[2].GetComponent<SlotMachine>().isStotp)
        {
            if (_isChecked == false)
            {
                _isChecked = true;


                if (slotIcons[0].sprite == slotIcons[1].sprite && slotIcons[1].sprite == slotIcons[2].sprite)
                {
                    TextMessage.text = "3X You Win!!";
                    CoinManager.Instance.MultiBetCoin(3);
                    AudioManager.Instance.PlaySfx(AudioManager.Instance.CoinTypeOneClip);
                    ParticleManager.Instance.PlayParticle();
                }
                else if (slotIcons[0].sprite != slotIcons[1].sprite && slotIcons[0].sprite == slotIcons[2].sprite)
                {
                    TextMessage.text = "2X !!";
                    CoinManager.Instance.MultiBetCoin(2);
                    AudioManager.Instance.PlaySfx(AudioManager.Instance.CoinTypeTwoClip);
                    ParticleManager.Instance.PlayParticle();
                }
                else if (slotIcons[0].sprite != slotIcons[1].sprite && slotIcons[1].sprite != slotIcons[2].sprite
                 && slotIcons[0].sprite != slotIcons[2].sprite)
                {
                    TextMessage.text = "1X !!";
                    CoinManager.Instance.MultiBetCoin(1);
                    AudioManager.Instance.PlaySfx(AudioManager.Instance.CoinTypeTwoClip);
                    ParticleManager.Instance.PlayParticle();
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
        else if (slotIcons[0].GetComponent<SlotMachine>().isSpinning || slotIcons[1].GetComponent<SlotMachine>().isSpinning
         || slotIcons[2].GetComponent<SlotMachine>().isSpinning)
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
        CoinManager.Instance.SubTotalCoin();
        button.interactable = false;
        foreach (var slot in slotIcons)
        {
            slot.GetComponent<SlotMachine>().spinStart();
        }
    }
}

