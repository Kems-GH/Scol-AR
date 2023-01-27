using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneChanger()
    {
        SceneManager.LoadScene("Fission");
        Debug.Log("test");
    }
}