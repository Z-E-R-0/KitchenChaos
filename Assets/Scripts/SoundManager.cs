using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    private float volume = 1f;
    private const string PLAYER_EFFECTS_SOUND_VOLUME = "SoundEffectsVolume";
    private void Awake()
    {
       volume = PlayerPrefs.GetFloat(PLAYER_EFFECTS_SOUND_VOLUME, 1f);
        Instance = this;
    }
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFail += DeliveryManager_OnRecipeFail;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        Player.Instance.OnPickedSometing += Player_OnPickedSometing;
        BaseCounter.OnAnyObjectPlacedHere += BaseCounter_OnAnyObjectPlacedHere;
        TrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyObjectTrashed;
    }

    private void TrashCounter_OnAnyObjectTrashed(object sender, System.EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        PlaySound(audioClipRefsSO.trash, trashCounter.transform.position);
    }

    private void BaseCounter_OnAnyObjectPlacedHere(object sender, System.EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(audioClipRefsSO.objectDrop, baseCounter.transform.position);
    }

    private void Player_OnPickedSometing(object sender, System.EventArgs e)
    {

        PlaySound(audioClipRefsSO.objectPickup, Player.Instance.transform.position);
    }

    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(audioClipRefsSO.chop, cuttingCounter.transform.position);
    }

    private void DeliveryManager_OnRecipeFail(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipRefsSO.deliveryFail, deliveryCounter.transform.position);
    }


    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipRefsSO.deliverySuccess, deliveryCounter.transform.position);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);

    }

    private void PlaySound(AudioClip[] audioCliparray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioCliparray[Random.RandomRange(0, audioCliparray.Length)], position, volume);



    }
    public void PlayFootstepsSound(Vector3 position,float volumeMultiplier)
    {

        PlaySound(audioClipRefsSO.footsteps, position, volumeMultiplier  * volume);

    }
    public void PlayCountdownSound()
    {

        PlaySound(audioClipRefsSO.warning,Vector3.zero);

    }
    public void PlayWarningSound(Vector3 position)
    {

        PlaySound(audioClipRefsSO.warning, position);

    }
    public  void ChangeVolume()
    {
        volume += 0.1f;
        if(volume>1f)
        {
            volume = 0f;

        }

        PlayerPrefs.SetFloat(PLAYER_EFFECTS_SOUND_VOLUME,volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return volume;


    }

}
