using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class TiTleScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    public GameObject NormalMenu;
    public GameObject OptionMenu;
    public GameObject ControlesMenu;
    public TMP_Dropdown resolutionDropDown;
    

    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width==Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void Exit() 
    {
        Application.Quit();
    }
    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }
    public void OpenOptions()
    {
        OptionMenu.SetActive(true);
        NormalMenu.SetActive(false);
        ControlesMenu.SetActive(false);
    }
    public void OpenControls()
    {
        ControlesMenu.SetActive(true);
        NormalMenu.SetActive(false);
        OptionMenu.SetActive(false);
    }
    public void OpenNormal()
    {
        ControlesMenu.SetActive(false);
        NormalMenu.SetActive(true);
        OptionMenu.SetActive(false);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
