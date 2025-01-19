using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
   [Header("Volume Setting")]
   [SerializeField] private TMP_Text volumeTextValue = null;
   [SerializeField] private Slider volumeSlider = null;
   [SerializeField] private float defaultVolume = 1.0f;

   [Header("Levels To Load")]
   private string levelToLoad;
   [SerializeField] private GameObject noSavedGameDialog = null;

   [SerializeField] private GameObject pauseScreen;

   public void NewGameDialogYes()
   {
   
    SceneManager.LoadScene("Cutscene1");
   }

   public void LoadGameDialogYes()
   {
      if(PlayerPrefs.HasKey("SavedLevel"))
      {
         levelToLoad = PlayerPrefs.GetString("SavedLevel");
         SceneManager.LoadScene(levelToLoad);
         Time.timeScale = 1;
      }
      else
      {
         noSavedGameDialog.SetActive(true);
      }
   }

   public void ExitButton()
   {
      Application.Quit();
      //EditorApplication.isPlaying = false;
   }

   public void SetVolume(float volume)
   {
      AudioListener.volume = volume;
      volumeTextValue.text = volume.ToString("0.0");
   }

   public void VolumeApply()
   {
      PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
   }

   public void ResetButton(string MenuType)
   {
      if(MenuType == "Audio")
      {
         AudioListener.volume = defaultVolume;
         volumeSlider.value = defaultVolume;
         volumeTextValue.text = defaultVolume.ToString("0.0");
         VolumeApply();
      }
   }

   public void PauseGame(bool status)
    {
        //If status == true pause | if status == false unpause
        pauseScreen.SetActive(status);

        //When pause status is true change timescale to 0 (time stops)
        //when it's false change it back to 1 (time goes by normally)
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void Backtohome()
   {
      string activeScene = SceneManager.GetActiveScene().name;
   PlayerPrefs.SetString("SavedLevel", activeScene);
    SceneManager.LoadScene("MainMenu");
   }

   public void Backtohomenosave()
   {
    SceneManager.LoadScene("MainMenu");
   }
}
