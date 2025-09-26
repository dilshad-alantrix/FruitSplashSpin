using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{

    public SpriteRenderer[] slotIcons;
    public TMP_Text Text;

    void Start()
    {

    }


    void Update()
    {
        if (slotIcons[0].GetComponent<SlotMachine>().isStotp && slotIcons[1].GetComponent<SlotMachine>().isStotp
         && slotIcons[2].GetComponent<SlotMachine>().isStotp)
        {
            if (slotIcons[0].sprite == slotIcons[1].sprite && slotIcons[1].sprite == slotIcons[2].sprite)
            {
                Text.text = "you win";
            }
            else
            {
                Text.text = "you Loose";
            }
        }
        else if(slotIcons[0].GetComponent<SlotMachine>().isSpinning || slotIcons[1].GetComponent<SlotMachine>().isSpinning
         || slotIcons[2].GetComponent<SlotMachine>().isSpinning)
        {
             Text.text = "Good Luck!!";
        }
        else
        {
          Text.text = "Press Spin!!";
        }

    }

    public void CheckWin()
    {
      
    }
}
