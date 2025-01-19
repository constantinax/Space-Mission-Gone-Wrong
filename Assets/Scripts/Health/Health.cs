using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;} //get apo ola to script alla modify mono apo auto
    private bool dead;

    [Header ("iFrames")]

    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header ("Hurt Sound")]

    [SerializeField] private AudioClip HurtSound;

    private void Awake()
    {
        currentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth); //na min vgei ektos to orio zwwn
        SoundManager.instance.PlaySound(HurtSound);
        if(currentHealth > 0)
        {
            //iframes
            StartCoroutine(Invulnerability()); //pws kaleis to ienumerator method
        }
        else
        {
            //dead
            if(!dead)
            {
            GetComponent<PlayerMovement>().enabled = false; // den tha mporei na kounithei otan pethanei
            StartCoroutine(RestartScene());
            dead = true;
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invulnerability()
    {
        transform.gameObject.tag = "Untagged";
        for(int i = 0; i < numberOfFlashes; i++)  //invulnerability duration
        {
            spriteRend.color = new Color(1,0,0, 0.5f); // kokkino
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2)); //waits gia oso tou poume
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        transform.gameObject.tag = "Player";
    }

    public IEnumerator RestartScene()
    {
        for(int i = 0; i < numberOfFlashes; i++)  //invulnerability duration
        {
            spriteRend.color = new Color(1,0,0, 0.5f); // kokkino
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2)); //waits gia oso tou poume
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        spriteRend.color = new Color(1,0,0, 0.5f); // kokkino
        yield return new WaitForSeconds(iFramesDuration);
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }
}
