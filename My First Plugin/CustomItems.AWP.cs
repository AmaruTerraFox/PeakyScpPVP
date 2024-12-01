using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Firearms.Attachments;
using PlayerStatsSystem;
using UnityEngine;

namespace PeakySCPPVP.AWP
{
    [CustomItem(ItemType.GunE11SR)]
    public class AWP : CustomWeapon
    {
        public override ItemType Type { get; set; } = ItemType.GunE11SR;
        public override uint Id { get; set; } = 999;
        public override string Name { get; set; } = "AWP";
        public override string Description { get; set; } = "AWP- 1 пуля, 1 труп";
        public override float Weight { get; set; } = 3.25f;
        public override byte ClipSize { get; set; } = 1;
        public override Vector3 Scale { get; set; } = new Vector3(1.5f, 1.5f, 1.5f);
        public override bool ShouldMessageOnGban { get; } = true;
        public override float Damage { get; set; } = 100;
        public override bool FriendlyFire { get; set; } = true;

        public override SpawnProperties SpawnProperties { get; set; }

        public override AttachmentName[] Attachments { get; set; } = new[]
        {
        AttachmentName.ExtendedBarrel,
        AttachmentName.ScopeSight,
        };
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Shot += OnShot;
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Shot -= OnShot;
            base.UnsubscribeEvents();
        }
        protected override void OnShot(ShotEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;
            ev.Damage = Damage;
        }
    }

}