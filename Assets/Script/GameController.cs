using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

    public SpriteRenderer[] slotIcons;
    public TMP_Text TextMessage;
    public Button button;
    private bool isChecked;



    void Update()
    {
        if (slotIcons[0].GetComponent<SlotMachine>().isStotp && slotIcons[1].GetComponent<SlotMachine>().isStotp
         && slotIcons[2].GetComponent<SlotMachine>().isStotp)
        {
            if (isChecked == false)
            {
                isChecked = true;


                if (slotIcons[0].sprite == slotIcons[1].sprite && slotIcons[1].sprite == slotIcons[2].sprite)
                {
                    TextMessage.text = "3X You Win!!";
                    CoinManager.instance.MultiBetCoin(3);
                    AudioManager.instance.PlaySfx(AudioManager.instance.CoinTypeOneClip);
                    ParticleManager.instance.PlayParticle();
                }
                else if (slotIcons[0].sprite != slotIcons[1].sprite && slotIcons[0].sprite == slotIcons[2].sprite)
                {
                    TextMessage.text = "2X !!";
                    CoinManager.instance.MultiBetCoin(2);
                    AudioManager.instance.PlaySfx(AudioManager.instance.CoinTypeTwoClip);
                    ParticleManager.instance.PlayParticle();
                }
                else if (slotIcons[0].sprite != slotIcons[1].sprite && slotIcons[1].sprite != slotIcons[2].sprite && slotIcons[0].sprite != slotIcons[2].sprite)
                {
                    TextMessage.text = "1X !!";
                    CoinManager.instance.MultiBetCoin(1);
                    AudioManager.instance.PlaySfx(AudioManager.instance.CoinTypeTwoClip);
                    ParticleManager.instance.PlayParticle();
                }
                else
                {
                    TextMessage.text = "Better Luck Next Time!!";
                }
            }

            if (!CoinManager.instance.ChekCons())
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
       

    

    public void startSpin()
    {

        isChecked = false;
        CoinManager.instance.SubTotalCoin();
        button.interactable = false;
        foreach (var slot in slotIcons)
        {
            slot.GetComponent<SlotMachine>().spinStart();
        }
    }
}

