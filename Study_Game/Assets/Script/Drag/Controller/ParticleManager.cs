using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleManager : MonoBehaviour
{
    [Header("Particle Setting")]
    public GameObject _firework;
    public bool isActive = true;
    public float par_time = 0;
    List<Animator> _firework_ani;
    List<GameObject> _firework_list;
    float i = 0;
    public void TimeDelay()
    {
        par_time += Time.fixedDeltaTime;
        if(par_time > i)
        {
            StartCoroutine(CreateParticle(_firework, transform));
            StartCoroutine(CreateParticle(_firework, transform));
            StartCoroutine(CreateParticle(_firework, transform));

            i += 1f;
        }
    }
    public IEnumerator CreateParticle(GameObject particle, Transform particl_eArea)
    {
        var _particle = Instantiate(particle, particl_eArea);
        float PosX = Random.Range(-280f, 280f);
        float PosY = Random.Range(-170f, 170f);
        _particle.GetComponent<RectTransform>().localPosition = new Vector3(PosX, PosY, 0);
        _particle.GetComponent<Animator>().SetTrigger("isActive");
        _particle.GetComponent<Image>().color = Random.ColorHSV();
        yield return new WaitForSecondsRealtime(0.29f);
        Destroy(_particle);
    }
}
