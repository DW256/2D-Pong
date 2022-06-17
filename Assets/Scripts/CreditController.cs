using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditController : MenuController
{
    public string AuthorName;
    public string IdDtsFga;
    public string PortofolioUrl;

    public Text PortofolioPanelText;
    public Text CreditText;

    public GameObject PortofolioPanel;

    void Start()
    {
        PortofolioPanelText.text = string.Format("ARE YOU SURE YOU WANT TO VISIT {0} ?", PortofolioUrl);
        CreditText.text = string.Format("{0}\n{1}\n{2}", AuthorName, IdDtsFga, PortofolioUrl);
    }

    public void openPortofolioPanel()
    {
        PortofolioPanel.SetActive(true);
    }

    public void closePortofolioPanel()
    {
        PortofolioPanel.SetActive(false);
    }

    public void openPortofolioUrl()
    {
        Application.OpenURL(PortofolioUrl);
    }
}
