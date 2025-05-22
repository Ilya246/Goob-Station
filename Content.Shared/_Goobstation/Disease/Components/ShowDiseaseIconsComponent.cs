using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared.Disease;

/// <summary>
/// This component allows you to see health status icons above damageable mobs.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class ShowDiseaseIconsComponent : Component
{
    /// <summary>
    /// The minimum product of disease complexity with its progress for the low danger icon to show up.
    /// </summary>
    [DataField, AutoNetworkedField]
    public float? LowThreshold = null;

    /// <summary>
    /// The minimum product of disease complexity with its progress for the medium danger icon to show up. Doesn't show up if null.
    /// </summary>
    [DataField, AutoNetworkedField]
    public float? MediumThreshold = 12f;

    /// <summary>
    /// The minimum product of disease complexity with its progress for the high danger icon to show up. Doesn't show up if null.
    /// </summary>
    [DataField, AutoNetworkedField]
    public float? HighThreshold = null;
}
