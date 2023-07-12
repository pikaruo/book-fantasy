using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    [Header("System Musik")]
    public GameObject[] switchMusicMute; // * 0 = on, 1 = off
    public Slider volumeMusikSlider;

    [Header("System SFX")]
    public GameObject[] switchSfxMute; // * 0 = on, 1 = off
    public Slider volumeSFXSlider;

    private void Start()
    {

        // * musik
        if (AudioManager.Instance.audioSourceMusik.mute == true)
        {
            switchMusicMute[1].SetActive(true);
            switchMusicMute[0].SetActive(false);
        }
        else
        {
            switchMusicMute[1].SetActive(false);
            switchMusicMute[0].SetActive(true);
        }

        volumeMusikSlider.value = AudioManager.Instance.audioSourceMusik.volume;

        // * sfx
        if (AudioManager.Instance.audioSourceSFX.mute == true)
        {
            switchSfxMute[1].SetActive(true);
            switchSfxMute[0].SetActive(false);
        }
        else
        {
            switchSfxMute[1].SetActive(false);
            switchSfxMute[0].SetActive(true);
        }

        volumeSFXSlider.value = AudioManager.Instance.audioSourceSFX.volume;
    }

    #region musik

    public void VolumeMusik()
    {
        AudioManager.Instance.audioSourceMusik.volume = volumeMusikSlider.value;

        if (volumeMusikSlider.value <= volumeMusikSlider.minValue)
        {
            AudioManager.Instance.audioSourceMusik.mute = true;
            switchMusicMute[1].SetActive(true);
            switchMusicMute[0].SetActive(false);
        }
        else
        {
            AudioManager.Instance.audioSourceMusik.mute = false;
            switchMusicMute[1].SetActive(false);
            switchMusicMute[0].SetActive(true);
        }
    }

    public void MusikMute()
    {
        AudioManager.Instance.MusikMute();

        if (AudioManager.Instance.audioSourceMusik.mute == true)
        {
            switchMusicMute[1].SetActive(true);
            switchMusicMute[0].SetActive(false);
        }
        else
        {
            switchMusicMute[1].SetActive(false);
            switchMusicMute[0].SetActive(true);
        }
    }

    #endregion

    #region sfx

    public void VolumeSfx()
    {
        AudioManager.Instance.audioSourceSFX.volume = volumeSFXSlider.value;

        if (volumeSFXSlider.value <= volumeSFXSlider.minValue)
        {
            AudioManager.Instance.audioSourceSFX.mute = true;
            switchSfxMute[1].SetActive(true);
            switchSfxMute[0].SetActive(false);
        }
        else
        {
            AudioManager.Instance.audioSourceSFX.mute = false;
            switchSfxMute[1].SetActive(false);
            switchSfxMute[0].SetActive(true);
        }
    }

    public void SfxMute()
    {
        AudioManager.Instance.SfxMute();

        if (AudioManager.Instance.audioSourceSFX.mute == true)
        {
            switchSfxMute[1].SetActive(true);
            switchSfxMute[0].SetActive(false);
        }
        else
        {
            switchSfxMute[1].SetActive(false);
            switchSfxMute[0].SetActive(true);
        }
    }

    #endregion

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All Data PlayerPrefs has deleted!");
    }
}
