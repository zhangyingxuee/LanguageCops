using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmailPageStstem : MonoBehaviour
{
    public GameObject[] Page;
    public TextMeshProUGUI CurrPage;
    public TextMeshProUGUI TotalPage;
    public GameObject NextPage;
    public GameObject LastPage;
    private int CPage = 1;

    public void Load_first_page()
    {
        for (int i = 0; i < Page.Length; i++)
        {
            if (i == 0)
            {
                Page[i].SetActive(true);
            }
            else
            {
                Page[i].SetActive(false);
            }
        }
        CPage = 1;
        CurrPage.text = "1";
        TotalPage.text = Page.Length.ToString();
        LastPage.SetActive(false);
        NextPage.SetActive(true);
    }

    public void nextPage()
    {
        Page[CPage - 1].SetActive(false);
        CPage += 1;
        CurrPage.text = CPage.ToString();
        Page[CPage - 1].SetActive(true);
        LastPage.SetActive(true);
        if (CPage == Page.Length)
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

}
