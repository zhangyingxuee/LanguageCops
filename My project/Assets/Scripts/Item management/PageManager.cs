using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PageManager : MonoBehaviour
{


    public TextMeshProUGUI CurrPage;
    public TextMeshProUGUI TotalPage;
    public GameObject NextPage;
    public GameObject LastPage;
    public GameObject[] Page;
    public GameObject[] Item;
    public GameObject OverviewPage;
    public GameObject SpecificPage;

    private int TPage = 1;
    private int CPage = 1;
    private int ItemCount;

    public void CheckPageNo( PlayerInfo player)
    {
        ItemCount = player.itemCount;
        LastPage.SetActive(false);
        if (ItemCount <= 4)
        {
            TotalPage.text = "1";
            CurrPage.text = "1";
            NextPage.SetActive(false);
        } else
        {
            if (ItemCount % 4 == 0)
            {
                TPage = ItemCount / 4;
            }
            else
            {
                TPage = (ItemCount / 4) + 1;
            }
            
            TotalPage.text = TPage.ToString();
            NextPage.SetActive(true);
        }

    }

    public void Load_first_page()
    {
        OverviewPage.SetActive(true);
        SpecificPage.SetActive(false);
        for (int i = 0; i < TPage; i++)
        {
            if(i == 0)
            {
                Page[i].SetActive(true);
            }
            else
            {
                Page[i].SetActive(false);
            }
        }
    }

    public void nextPage()
    {
        Page[CPage - 1].SetActive(false);
        CPage += 1;
        CurrPage.text = CPage.ToString();
        Page[CPage - 1].SetActive(true);
        LastPage.SetActive(true);
        if (CPage == TPage)
        {
            NextPage.SetActive(false);
        }
    }

    public void lastPage()
    {
        Page[CPage - 1].SetActive(false);
        CPage -= 1;
        CurrPage.text = CPage.ToString();
        Page[CPage - 1].SetActive(true);
        NextPage.SetActive(true);
        if (CPage == 1)
        {
            LastPage.SetActive(false);
        }
    }

    public void OpenSpecificItem(int id)
    {
        OverviewPage.SetActive(false);
        SpecificPage.SetActive(true);
        for (int i = 0; i < TPage * 4; i++)
        {
            if (i != id)
            {
                Item[i].SetActive(false);
            }else
            {
                Item[i].SetActive(true);
            }
        }
    }
    public void CloseSpecificItem()
    {
        OverviewPage.SetActive(true);
        SpecificPage.SetActive(false);
        for (int i = 0; i < TPage; i++)
        {
            if (i != (CPage - 1))
            {
                Page[i].SetActive(false);
            }
            else
            {
                Page[i].SetActive(true);
            }
        }
    }
 }
