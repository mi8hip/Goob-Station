// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-FileCopyrightText: 2025 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
//
// SPDX-License-Identifier: MIT

using Content.Shared.Atmos.Components;
using Content.Shared.Body.Components;
using Content.Shared.Body.Systems;

namespace Content.Client.Body.Systems;

public sealed class InternalsSystem : SharedInternalsSystem
{
    [Dependency] private readonly SharedUserInterfaceSystem _ui = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<InternalsComponent, AfterAutoHandleStateEvent>(OnInternalsAfterState);
    }

    private void OnInternalsAfterState(Entity<InternalsComponent> ent, ref AfterAutoHandleStateEvent args)
    {
        if (ent.Comp.GasTankEntity != null && _ui.TryGetOpenUi(ent.Comp.GasTankEntity.Value, SharedGasTankUiKey.Key, out var bui))
        {
            bui.Update();
        }
    }
}
