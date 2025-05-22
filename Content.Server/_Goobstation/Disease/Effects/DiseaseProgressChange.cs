using Content.Shared.Chemistry.Components;
using Content.Shared.Disease;
using Content.Shared.Disease.Chemistry;
using Content.Shared.EntityEffects;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;

namespace Content.Server.Disease.Chemistry;

/// <summary>
/// Reduces the progress of diseases of chosen type on the entity.
/// </summary>
public sealed partial class DiseaseProgressChange : EntityEffect
{
    /// <summary>
    /// Diseases of which type to affect.
    /// </summary>
    [DataField]
    public ProtoId<DiseaseTypePrototype> AffectedType;

    /// <summary>
    /// How much to add to the disease progress.
    /// </summary>
    [DataField]
    public float ProgressModifier = -0.02f;

    [DataField]
    public bool Scaled = true;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
    {
        return Loc.GetString("reagent-effect-guidebook-disease-progress-change",
            ("chance", Probability),
            ("type", prototype.Index<DiseaseTypePrototype>(AffectedType).LocalizedName),
            ("amount", ProgressModifier));
    }

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (args.EntityManager.TryGetComponent<DiseaseCarrierComponent>(args.TargetEntity, out var carrier))
        {
            foreach (var diseaseUid in carrier.Diseases)
            {
                if (!args.EntityManager.TryGetComponent<DiseaseComponent>(diseaseUid, out var disease))
                    continue;
                if (disease.DiseaseType != AffectedType)
                    continue;

                var sys = args.EntityManager.System<DiseaseSystem>();
                var amt = ProgressModifier;
                if (args is EntityEffectReagentArgs reagentArgs)
                {
                    if (Scaled)
                        amt *= reagentArgs.Quantity.Float();
                    amt *= reagentArgs.Scale.Float();
                }

                sys.ChangeInfectionProgress(diseaseUid, amt, disease);
            }
        }
    }
}
