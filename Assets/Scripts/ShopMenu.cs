using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopMenuUI;
    public GameObject pauseMenuUI;

    public void Back()
    {
        pauseMenuUI.SetActive(true);
        shopMenuUI.SetActive(false);

    }


}
