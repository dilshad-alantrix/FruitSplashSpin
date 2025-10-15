using TMPro; 
using UnityEngine.UI;
using UnityEngine;

public class GameUI : MonoBehaviour,Iobserver
{

    [SerializeField] private  Subject ControllerSubject;
    [Header("UI")]
    [SerializeField] private TMP_Text TextMessage;
    [SerializeField] private Button SpinButton;
    [SerializeField] private Button SpinHandleButton;
    [SerializeField] private Button AddButton;
    [SerializeField] private Button SubButton;

    void OnEnable()
    {
        ControllerSubject.AddObserver(this);
    }
    void OnDisable()
    {
        ControllerSubject.RemoveObserver(this);
    }

    public void onNotify(GameState state)
    {
        
        
        if (state == GameState.Spining)
        {
            TextMessage.text = "Good Luck!!";
            SpinButton.interactable = false;
            SpinHandleButton.interactable = false;
            SubButton.interactable = false;
            AddButton.interactable = false;
        }
        else if (state == GameState.Win1x)
        {
            TextMessage.text = "1X !!";
        }
        else if (state == GameState.Win2x)
        {
            TextMessage.text = "2X !!";
        }
        else if (state == GameState.Win3x)
        {
            TextMessage.text = "3X JackPot!!";
        }
        else if (state == GameState.Loose)
        {
            TextMessage.text = "Better Luck Next Time!!";
        }

        else if (state == GameState.NoCoin)
        {
            TextMessage.text = "No More Coins!!";
            SpinButton.interactable = false;
            SpinHandleButton.interactable = false;
            SubButton.interactable = true;
        }
        else
        {
            SpinButton.interactable = true;
            SubButton.interactable = true;
            AddButton.interactable = true;
            SpinHandleButton.interactable = true;
        }
    }
    

   
   
}
