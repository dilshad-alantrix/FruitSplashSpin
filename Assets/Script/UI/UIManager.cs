using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
     
    [Header("UI Buttons")]
    [SerializeField] private Button Play;
    [SerializeField] private Button Quit;
    [SerializeField] private Button BackTOHome;
    [SerializeField] private Button Menu;
    [SerializeField] private Button Shop;
    [SerializeField] private Button Info;
    [SerializeField] private Button wheel;
    [SerializeField] private Button[] Backs;
    
    [Header("UI Panels")]
    [SerializeField] private GameObject Homepanel;
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject InfoPanel;
    [SerializeField] private GameObject Coinpanel;
    [SerializeField] private GameObject WheelPanel;
    [SerializeField] private GameObject BaackgroundPanel;

    [SerializeField] private GameObject MenuIcon;

    [SerializeField] private Loading loading;

    public event Action OnUIButtonPress;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Homepanel.SetActive(true);
        GamePanel.SetActive(false);
        Coinpanel.SetActive(false);
        MenuPanel.SetActive(false);
        InfoPanel.SetActive(false);
        BaackgroundPanel.SetActive(false);

    }

    private void OnEnable()
    {
        Play.onClick.AddListener(play);
        Quit.onClick.AddListener(quit);
        BackTOHome.onClick.AddListener(backToHome);
        Shop.onClick.AddListener(shop);
        Info.onClick.AddListener(info);
        Menu.onClick.AddListener(menu);
        wheel.onClick.AddListener(SpinnigWheel);
        foreach (var btn in Backs)
        {
            btn.onClick.AddListener(back);
        }

    }
    private void OnDisable()
    {
        Play.onClick.RemoveListener(play);
        Quit.onClick.RemoveListener(quit);
        BackTOHome.onClick.RemoveListener(backToHome);
        Shop.onClick.RemoveListener(shop);
        Info.onClick.RemoveListener(info);
        Menu.onClick.RemoveListener(menu);
        wheel.onClick.AddListener(SpinnigWheel);
        foreach (var btn in Backs)
        {
            btn.onClick.RemoveListener(back);
        }
    }

    private void play()
    {
        loading.Load();
        Homepanel.SetActive(false);
        GamePanel.SetActive(true);
        Coinpanel.SetActive(false);
        MenuPanel.SetActive(false);
        InfoPanel.SetActive(false);
        MenuIcon.SetActive(true);
        WheelPanel.SetActive(false);
        BaackgroundPanel.SetActive(false);

        OnUIButtonPress?.Invoke();
       

    }
    private void quit()
    {
        Application.Quit();
    }

    private void backToHome()
    {
        loading.Load();
        Homepanel.SetActive(true);
        GamePanel.SetActive(false);
        Coinpanel.SetActive(false);
        MenuPanel.SetActive(false);
        InfoPanel.SetActive(false);
        OnUIButtonPress?.Invoke();
   
    }

    private void back()
    {
        Homepanel.SetActive(false);
        GamePanel.SetActive(true);
        Coinpanel.SetActive(false);
        MenuPanel.SetActive(false);
        InfoPanel.SetActive(false);
        MenuIcon.SetActive(true);
        WheelPanel.SetActive(false);
         BaackgroundPanel.SetActive(false);

        OnUIButtonPress?.Invoke();
    }

    private void shop()
    {
        Homepanel.SetActive(false);
         GamePanel.SetActive(true);
        Coinpanel.SetActive(true);
        MenuPanel.SetActive(false);
        InfoPanel.SetActive(false);
        WheelPanel.SetActive(false);
         BaackgroundPanel.SetActive(true);

        OnUIButtonPress?.Invoke();
    }

    private void info()
    {
        Homepanel.SetActive(false);
        GamePanel.SetActive(true);
        Coinpanel.SetActive(false);
        MenuPanel.SetActive(false);
        InfoPanel.SetActive(true);
        WheelPanel.SetActive(false);
         BaackgroundPanel.SetActive(true);

        OnUIButtonPress?.Invoke();
    }
    private void menu()
    {
        Homepanel.SetActive(false);
        GamePanel.SetActive(true);
        Coinpanel.SetActive(false);
        MenuPanel.SetActive(true);
        InfoPanel.SetActive(false);
        MenuIcon.SetActive(false);
        WheelPanel.SetActive(false);
        BaackgroundPanel.SetActive(true);

        OnUIButtonPress?.Invoke();

    }
    private void SpinnigWheel()
    {
        Homepanel.SetActive(false);
        GamePanel.SetActive(true);
        Coinpanel.SetActive(false);
        MenuPanel.SetActive(false);
        InfoPanel.SetActive(false);
        WheelPanel.SetActive(true);
        BaackgroundPanel.SetActive(true);

        OnUIButtonPress?.Invoke();

    }

}
