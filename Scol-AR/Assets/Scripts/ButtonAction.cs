using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction: MonoBehaviour
{
    public GameObject menu;
    public GameObject ui;
    public GameObject periodique;

    public GameObject InputNbElectrons;
    private void Start(){
        InputNbElectrons.GetComponent<UnityEngine.UI.InputField>().text = GlobalVariable.nbElectronsToModif.ToString();
    }

    public void PlayAnimation()
    {
        GlobalVariable.listAtom = new Dictionary<string, GameObject>();
        GlobalVariable.currentImages = new List<string>();
        SceneManager.LoadScene(GlobalVariable.animationToPlay, LoadSceneMode.Single);
    }

    public void ChangeMainScene()
    {
        SceneManager.LoadScene("BlankAR", LoadSceneMode.Single);
    }

    public void ResetElectrons()
    {
        foreach(string currentImages in GlobalVariable.currentImages)
        {
            GlobalVariable.listAtom[currentImages].GetComponent<Atome>().UpdateElectrons(1);
        }
    }

    public void AddElectron()
    {
        GlobalVariable.nbElectronsToModif++;
        InputNbElectrons.GetComponent<UnityEngine.UI.InputField>().text = GlobalVariable.nbElectronsToModif.ToString();

    }

    public void RemoveElectron()
    {
        GlobalVariable.nbElectronsToModif--;
        InputNbElectrons.GetComponent<UnityEngine.UI.InputField>().text = GlobalVariable.nbElectronsToModif.ToString();
    }

    public void UpdateElectrons()
    {
        GlobalVariable.nbElectronsToModif = int.Parse(InputNbElectrons.GetComponent<UnityEngine.UI.InputField>().text);
    }

    public void DisplayMenu()
    {
        menu.SetActive(true);
        ui.SetActive(false);
        periodique.SetActive(false);
    }

    public void HideMenu()
    {
        menu.SetActive(false);
        ui.SetActive(true);
        periodique.SetActive(false);
    }

    public void DisplayPeriodique()
    {
        menu.SetActive(false);
        ui.SetActive(false);
        periodique.SetActive(true);
    }
}
