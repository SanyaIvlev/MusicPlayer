using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderUI : MonoBehaviour
{
   [SerializeField] private AudioPlayer _audioPlayer;
   
   private Slider _slider;

   private void Awake()
   {
      _slider = GetComponent<Slider>();
   }

   public void OnVolumeChanged()
   {
      _audioPlayer.SetVolume(_slider.value);
   }
}
