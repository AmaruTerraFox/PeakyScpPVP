using Exiled.API.Features;
using System;
using static PlayerList;
using System.Collections.Generic;
using Exiled.API.Enums;
using PlayerRoles;
using PeakySCPPVP.EventHaldlers;
using InventorySystem.Items;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Features;
using Exiled.CustomItems;
using PeakySCPPVP.AWP;
using MEC;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;

namespace PeakySCPPVP

{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override string Name => "PVP Plugin";
        public override string Prefix => "PVP Plugin";
        public override string Author => "Amaru";
        public override Version Version => new Version(0, 5, 0);
        public override PluginPriority Priority => PluginPriority.Medium;
        public override void OnEnabled()
        {
            Instance = this;
            Exiled.Events.Handlers.Player.Verified += new PlayerHandlers().OnPlayerVerified;
            Exiled.Events.Handlers.Player.DroppingItem += new PlayerHandlers().OnDroppingItem;
            // Регистрируем кастомное оружие AWP
            CustomItem.RegisterItems();


            Log.Info("-----------------------");
            Log.Info("PVP Plugin включён");
            Log.Info("-----------------------");
            base.OnEnabled();

        }
        public override void OnDisabled()
        {
            Instance = null;
            Exiled.Events.Handlers.Player.Verified -= new PlayerHandlers().OnPlayerVerified;
            Exiled.Events.Handlers.Player.DroppingItem -= new PlayerHandlers().OnDroppingItem;
            CustomItem.UnregisterItems();
            Log.Info("Основной плагин PeakySCP PVP выключен!");
            base.OnDisabled();
        }
    }
}