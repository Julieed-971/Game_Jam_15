using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager> {

    public AudioClip[] ButtonClick;
    public AudioClip[] cardDrawn;
    public AudioClip[] chimeWell;
    public AudioClip[] Spells;
    public AudioClip[] stones;
    public AudioClip[] blips;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayButtonClick() {
        audioSource.PlayOneShot(ButtonClick[0]);
    }
    public void PlayMove(){
        audioSource.PlayOneShot(Spells[1]);
    }
    public void PlayCardDrawn(){
        if (cardDrawn.Length == 0) return;
        int randomIndex = Random.Range(0, cardDrawn.Length);
        audioSource.PlayOneShot(cardDrawn[randomIndex]);
    }
    public void PlaychimeWell() {
        if (chimeWell.Length == 0) return;
        int randomIndex = Random.Range(0, chimeWell.Length);
        audioSource.PlayOneShot(chimeWell[randomIndex]);
    }
    public void PlaySpells() {
        audioSource.PlayOneShot(Spells[0]);
    }
    public void PlayBlips() {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(blips[0]);
    }
    public void PlayStones(int index) {
        audioSource.PlayOneShot(stones[index]);
    }
    public void PlayClip(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }
}
