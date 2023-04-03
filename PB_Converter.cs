using UnityEngine;
using PhysBone = VRC.SDK3.Dynamics.PhysBone.Components.VRCPhysBone;

/// <summary>
/// PBÇ©ÇÁDBÇê∂ê¨Ç∑ÇÈ
/// </summary>
public class PB_Converter : MonoBehaviour
{
    [SerializeField]
    private float dampingMag;

    [SerializeField]
    private float elasticityMag;

    [SerializeField]
    private float stiffnessMag;

    [SerializeField]
    private float inertMag;

    [SerializeField]
    private float endLengthValue;

    public bool pbDisable;

    public PhysBone[] physBone;

    void Start()
    {
        physBone = GetComponentsInChildren<PhysBone>();

        foreach (var PB in physBone)
        {
            var DB = PB.gameObject.AddComponent<DynamicBone>();
            DB.m_Root = PB.rootTransform;
            DB.m_Damping = PB.pull * dampingMag;
            DB.m_Elasticity = PB.spring * elasticityMag;
            DB.m_Stiffness = PB.stiffness * stiffnessMag;
            DB.m_Inert = PB.immobile * inertMag;
            DB.m_EndLength = endLengthValue;

            if (pbDisable)
            {
                PB.enabled = false;
            }
        }
    }
}

