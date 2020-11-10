using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Rendering.PostProcessing;

public class playerSanity : MonoBehaviour
{

    [HideInInspector] public playerHandler ph;
    [HideInInspector] public lightHandler lh;

    //public PostProcessProfile profile;
    public Material blurMaterial;

    [HideInInspector] public enum inLight
    {
        inLight, notInLight
    };

    public inLight inlight;

    [HideInInspector] public enum sanityLevel
    {
        sane, panic, blur, insane, impulse
    };

    public sanityLevel sanitylevel;

    public Slider sanitySlider;

    [HideInInspector] public float sanity = 100;

    private void Start()
    {
        ph = GetComponent<playerHandler>();
        lh = ph.lightHandler;
        sanitySlider.value = sanity;
        sanitylevel = sanityLevel.sane;
        //profile.GetSetting<Vignette>().intensity.Override(0f);
        blurMaterial.SetFloat("_BlurSize", 0f);
        sanity = 100;
        //profile.GetSetting<LensDistortion>().intensity.Override(-23f);
        //profile.GetSetting<ColorGrading>().saturation.Override(-100 + sanity);
    }

    void Update()
    {
        sanity = Mathf.Clamp(sanity, 0, 100);
        if(transform.GetChild(0).transform.GetChild(0).GetComponent<Light>().enabled) inlight = inLight.inLight;
        else if(lh.lowest <= 10) inlight = inLight.inLight;
        else inlight = inLight.notInLight;

        if(inlight == inLight.inLight)
        {
            if (sanity >= 100) return;
            else sanity += 0.03f;
        }
        else
        {
            if (sanity <= 0) return;
            else sanity -= 0.03f;
        }

        sanitySlider.value = sanity;

        //profile.GetSetting<ColorGrading>().saturation.Override(-100 + sanity);

        //JUDGE SANITY LEVEL
        if (sanity >= 75) sanitylevel = sanityLevel.sane;
        else if (sanity > 50) sanitylevel = sanityLevel.panic;
        else if (sanity > 25) sanitylevel = sanityLevel.blur;
        else if (sanity > 0) sanitylevel = sanityLevel.insane;
        else if (sanity <= 0) sanitylevel = sanityLevel.impulse;

        //SANITY
        if(sanitylevel == sanityLevel.sane)
        {
           // profile.GetSetting<Vignette>().intensity.Override(0f);
           //blurMaterial.SetFloat("_BlurSize", 0f);
           //profile.GetSetting<LensDistortion>().intensity.Override(-23f);
        }
        else
        {
            //profile.GetSetting<Vignette>().intensity.Override(((100 - sanity) / 100) / 3);
            //blurMaterial.SetFloat("_BlurSize", ((100 - sanity) / 100) * 0.059f);
            //profile.GetSetting<LensDistortion>().intensity.Override(-23f - ((100 - sanity)/3));
        }
        if(sanitylevel == sanityLevel.impulse)
        {
            transform.GetChild(0).transform.GetChild(0).GetComponent<Light>().enabled = true;
        }
    }
}
