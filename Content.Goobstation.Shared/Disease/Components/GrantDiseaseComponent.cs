using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using System;

namespace Content.Goobstation.Shared.Disease;

/// <summary>
/// Generates a random disease and grants it to the entity
/// </summary>
[RegisterComponent]
public sealed partial class GrantDiseaseComponent : Component
{
    /// <summary>
    /// Complexity of disease to grant
    /// </summary>
    [DataField]
    public float Complexity = 20f;

    /// <summary>
    /// The infection progress the disease starts out with
    /// </summary>
    public float Severity = 1f;

    /// <summary>
    /// Disease to use as a base to mutate from
    /// </summary>
    [DataField]
    public EntProtoId BaseDisease = "DiseaseBase";
}
