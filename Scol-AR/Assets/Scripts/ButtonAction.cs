using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction: MonoBehaviour
{
    public void PlayAnimation()
    {
        SceneManager.LoadScene(GlobalVariable.animationToPlay, LoadSceneMode.Single);
    }

    public void ResetElectrons()
    {
        foreach(string currentImages in GlobalVariable.currentImages)
        {
            GlobalVariable.listAtom[currentImages].GetComponent<Atome>().UpdateElectrons(1);
        }
    }
}
