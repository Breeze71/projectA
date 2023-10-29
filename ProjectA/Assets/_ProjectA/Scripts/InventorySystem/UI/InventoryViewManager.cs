using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryViewManager : MonoBehaviour
{
    private static bool isShow;
    [SerializeField] private GameObject[] views;
    private void Awake()
    {
    }
    private void Start()
    {
        isShow = false;
        InputManager.Instance.OnStatusUI_Performed += UI_onoff;
    }
    private void UI_onoff(object sender, EventArgs e)
    {
        if (isShow)
        {
            Hide();
            isShow = false;
        }
        else
        {
            Show();
            isShow = true;
        }
    }
    private void Show()
    {
        for (int i =0;i<views.Length;i++)
        {
            views[i].SetActive(true);
        }
    }
    public void Hide()
    {
        for (int i = 0; i < views.Length; i++)
        {
            views[i].SetActive(false);
        }
    }
}
