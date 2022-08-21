using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioM;
    public AudioListener playerAudio;
    public class Sounds
    {
        public const string objeto = "Efecto1_SFX"; //listo
        public const string objeto2 = "Efecto2_SFX"; //listo
        public const string muerteCocovoodie = "SFX_deadCV2"; //listo
        public const string golpeCocovoodie = "SFX_hitCV"; //listo
        public const string risaCocovoodie = "SFX_laughCV"; //listo 
        public const string ataqueRaqueta = "SwingRacket_SFX"; //listo
        public const string teleportVoodude = "Teleport_SFX"; //listo
        public const string victoriaEffect = "Victory_SFX"; //cuando agarra hueso 
        public const string victorySong = "Victory_Music"; //listo
        public const string disparoVoodude = "VooDudeShoot_SFX"; //usar el que mando Elia //listo
        public const string ataqueVoodude = "VooDudeAttack_SFX"; //buscar //listo
        public const string caminaGB = "Footsteps_SFX"; //no usar
        public const string golpeVoodude = "VooDudeHit_SFX"; //listo
        public const string dañoGB = "SFX_damageGB"; //listo
        public const string muerteGB = "SFX_deathGB"; //listo
        public const string doorOpen = "SFX_dooropen"; //listo
    }

    AudioSource as_Efectos;
    private void Start()
    {
        //playerAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioListener>()
    }
    public void SetGeneralVolume(float _v)
    {
        AudioListener.volume = 0.3f;
    }

    void SetVolumenEffects(float _v)
    {
        as_Efectos.volume = 0.2f;
    }

    public void Play(AudioClip _clip)
    {
        as_Efectos.PlayOneShot(_clip);
    }

    public void Play(string _clipName)
    {
        AudioClip clip = GetSound(_clipName);
        as_Efectos.PlayOneShot(clip);

        /*if(PauseMenu.GameIsPause)
        {
            //s.source.pitch *= .5f;
        }
        */
    }

    AudioClip GetSound(string _clipName)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + _clipName);
        if (clip == null)
        {
            Debug.LogWarning("No se encontro el archivo: " + _clipName);
        }
        return clip;
    }

    void Inicializar()
    {
        as_Efectos = gameObject.AddComponent<AudioSource>();
    }

    static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    [RuntimeInitializeOnLoadMethod]
    static void Init()
    {
        GameObject go = new GameObject("AudioManager");
        DontDestroyOnLoad(go);
        instance = go.AddComponent<AudioManager>();
        instance.Inicializar();
    }
}
