using Newtonsoft.Json.Linq;
using RamailoGames;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
public class AttemptsPanelManager : MonoBehaviour
{
    public GameObject packageTypePrefab;
    [SerializeField] Transform[] packagePos;
    private int selectedPackage;
    [SerializeField] Transform buyPanel;
    [SerializeField] Transform paymentPanel;
    public TMP_Text infoText;
    // Start is called before the first frame update
    void Start()
    {
        buyPanel.gameObject.SetActive(true);
        paymentPanel.gameObject.SetActive(false);

        int index = 0;
        foreach (JObject obj in ScoreAPI.instance.array.Children<JObject>())
        {
            Data_AttemptPackages datas = JsonUtility.FromJson<Data_AttemptPackages>(obj.ToString());
            PackageType types = Instantiate(packageTypePrefab, packagePos[index]).GetComponent<PackageType>();
            types.package_name = datas.name;
            types.packageButton.onClick.AddListener(() => OnPackageButtonClicked(types.id));
            //types.attempts = datas.attempts;
            types.id = datas.id;
            types.amount = datas.amount;
            types.SetDatas();
            index++;
        }
    }

    public void OnPackageButtonClicked(int id)
    {
        buyPanel.gameObject.SetActive(false);
        paymentPanel.gameObject.SetActive(true);
        selectedPackage = id;
        Debug.Log(selectedPackage);
    }

    [System.Obsolete]
    public void OnPaymentButtonClicked(int id)
    {
        string url;
        if (id == 0)
        {
            url = ScoreAPI.URL + "attempt/esewa/pay?package_id=" + selectedPackage;
        }
        else
        {
            url = ScoreAPI.URL + "attempt/ime_success?RefId=" + selectedPackage+"-"+ GenerateRandomString();
        }
        Debug.Log(url);

        Application.ExternalEval("window.location.href = '" + url + "';");
    }

    string GenerateRandomString()
    {
        const string validCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";
        StringBuilder sb = new StringBuilder();
        System.Random random = new System.Random();
        for (int i = 0; i < 13; i++)
        {
            sb.Append(validCharacters[random.Next(validCharacters.Length)]);
        }
        return sb.ToString();
    }

    private void OnEnable()
    {
        if ((ScoreAPI.instance.playAndWin || ScoreAPI.instance.competition))
        {
            infoText.text = "Your attempts are over choose your package";
        }
        else
        {
            infoText.text = "Choose your package";
        }
    }
}
