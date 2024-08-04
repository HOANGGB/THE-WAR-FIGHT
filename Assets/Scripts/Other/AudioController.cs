
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider volume;
    [SerializeField] Slider music;

    [SerializeField] AudioMixer audioMixerVolume;


    void Start()
    {
        audioMixerVolume.SetFloat("volume",PlayerPrefs.GetFloat("Volume"));
        audioMixerVolume.SetFloat("music",PlayerPrefs.GetFloat("Music"));
        volume.value = PlayerPrefs.GetFloat("Volume");
        music.value = PlayerPrefs.GetFloat("Music");
    }
    public void SetSound(){
        audioMixerVolume.SetFloat("volume",volume.value);
        audioMixerVolume.SetFloat("music",music.value);
        PlayerPrefs.SetFloat("Volume",volume.value);
        PlayerPrefs.SetFloat("Music",music.value);


    }
        
    
}
