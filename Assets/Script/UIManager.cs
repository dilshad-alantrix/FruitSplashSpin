using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] Button Play;
    [SerializeField] Button Quit;
    [SerializeField] Button BackTOHome;
    [SerializeField] Button Menu;
    [SerializeField] Button Shop;
    [SerializeField] Button Info;
    [SerializeField] Button[] Backs;

    [SerializeField] GameObject Homepanel;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject InfoPanel;
    [SerializeField] GameObject Coinpanel;

    [SerializeField] Loading loading;


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

    }

    private void OnEnable()
    {
        Play.onClick.AddListener(play);
        Quit.onClick.AddListener(quit);
        BackTOHome.onClick.AddListener(backToHome);
        Shop.onClick.AddListener(shop);
        Info.onClick.AddListener(info);
        Menu.onClick.AddListener(menu);
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
    }

    private void back()
    {
        Homepanel.SetActive(false);
        GamePanel.SetActive(true);
        Coinpanel.SetActive(false);
        MenuPanel.SetActive(false);
        InfoPanel.SetActive(false);
    }

    private void shop()
    {
        Homepanel.SetActive(false);
         GamePanel.SetActive(true);
        Coinpanel.SetActive(true);
        MenuPanel.SetActive(false);
        InfoPanel.SetActive(false);
    }

    private void info()
    {
        Homepanel.SetActive(false);
        GamePanel.SetActive(true);
        Coinpanel.SetActive(false);
        MenuPanel.SetActive(false);
        InfoPanel.SetActive(true);
    }
    private void menu()
    {
        Homepanel.SetActive(false);
        GamePanel.SetActive(true);
        Coinpanel.SetActive(false);
        MenuPanel.SetActive(true);
        InfoPanel.SetActive(false);
    }
}
