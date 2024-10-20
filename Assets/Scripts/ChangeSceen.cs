using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int SceneID)
    {
        SceneManager.LoadScene(SceneID); // Загрузка сцены по ID
    }

    public void Quit()
    {
        Application.Quit(); // Закрытие приложения
    }
}
