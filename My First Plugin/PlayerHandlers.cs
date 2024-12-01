using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System;
using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.Events.EventArgs;
using MEC;
using UnityEngine;
using InventorySystem.Items;
using Exiled.API.Features.Items;
using PluginAPI.Events;
using Exiled.Events.Handlers;
using Player = Exiled.API.Features.Player;
using Exiled.CustomItems.API;
using PeakySCPPVP.AWP;
using PluginAPI.Core.Items;
using PluginAPI.Core;
using Log = Exiled.API.Features.Log;
using Exiled.API.Interfaces;
namespace PeakySCPPVP.EventHaldlers
{
    public class PlayerHandlers
    {


        private Config Config => Plugin.Instance.Config;
        private static readonly System.Random Random = new System.Random();
        private readonly Dictionary<Player, CoroutineHandle> activeCoroutines = new Dictionary<Player, CoroutineHandle>();
        private HashSet<Player> restrictedPlayers = new HashSet<Player>();
        public void OnPlayerVerified(VerifiedEventArgs ev)
        {
            if (ev.Player == null)
            {
                Log.Warn("Плаер не верифицирован (Player is not Verified.)");
                return;
            }
            ev.Player.Role.Set(RoleTypeId.Tutorial, SpawnReason.None);
            ev.Player.IsGodModeEnabled = true;

            if (!Config.IsEnabled)
                return;
            if (Config.InitialSpawnCoordinates == Vector3.zero)
            {
                Log.Warn("Координаты для начальной коробки не указаны!");
                return;
            }

            // TP to korobka
            ev.Player.Position = Config.InitialSpawnCoordinates;
            var coroutine = Timing.RunCoroutine(SpawnAndTeleport(ev.Player, Config));
            activeCoroutines[ev.Player] = coroutine;
            //Выдача карт
            Timing.CallDelayed(0.5f, () =>
         {

             foreach (var item in Config.Cards)
             { 
                   ev.Player.AddItem(item);
             }
         });
        }  

        

        private IEnumerator<float> SpawnAndTeleport(Player player, Config config)
        {
            yield return Timing.WaitForSeconds(120f);

            if (player == null || !config.IsEnabled)
                yield break;

            if (config.Dust2Random == null || config.Dust2Random.Count == 0)
            {
                Log.Warn("Список координат для телепортации пуст!");
                yield break;
            }

            player.IsGodModeEnabled = false;

            int randomIndex = Random.Next(config.Dust2Random.Count);
            Vector3 targetPosition = config.Dust2Random[randomIndex];

            player.Position = targetPosition;

            player.ShowHint("Сражайтесь!", 5f);
        }
        public void OnDroppingItem(DroppingItemEventArgs ev)
        {
            if (ev.Item.Type == ItemType.KeycardMTFCaptain)
            {
                ev.Player.Role.Set(RoleTypeId.NtfCaptain, SpawnReason.None);
                Timing.CallDelayed(0.5f, () =>
                {
                    ev.Player.ClearInventory();

                });
                Timing.CallDelayed(0.5f, () =>
                    {
                        foreach (var item in Config.GunsList1)
                        {
                            ev.Player.AddItem(item);
                        }
                    });
                if (ev.Item.Type == ItemType.GunFRMG0)
                    Timing.CallDelayed(0.3f, () =>
                    {
                        foreach (var item in Config.MtfCaptain)
                        {
                            ev.Player.AddItem(item);

                        }
                        int randomIndex = Random.Next(Config.Dust2Random.Count);
                        ev.Player.Position = Config.Dust2Random[randomIndex];

                    });
                if (ev.Item.Type == ItemType.GunE11SR)
                    Timing.CallDelayed(0.3f, () =>
                    {
                        foreach (var item in Config.MtfSergant)
                        {
                            ev.Player.AddItem(item);
                            int randomIndex = Random.Next(Config.Dust2Random.Count);
                            ev.Player.Position = Config.Dust2Random[randomIndex];
                        }

                    });
                if (ev.Item.Type == ItemType.GunLogicer)
                    Timing.CallDelayed(0.3f, () =>
                    {
                        foreach (var item in Config.ChaosRepressor)
                        {
                            ev.Player.AddItem(item);
                            int randomIndex = Random.Next(Config.Dust2Random.Count);
                            ev.Player.Position = Config.Dust2Random[randomIndex];
                        }

                    });
                if (ev.Item.Type == ItemType.GunCrossvec)
                    Timing.CallDelayed(0.3f, () =>
                    {
                        foreach (var item in Config.MtfPrivate)
                        {
                            ev.Player.AddItem(item);
                            int randomIndex = Random.Next(Config.Dust2Random.Count);
                            ev.Player.Position = Config.Dust2Random[randomIndex];
                        }

                    });


                if (activeCoroutines.TryGetValue(ev.Player, out var handle))
                {
                    Timing.KillCoroutines(handle);
                    activeCoroutines.Remove(ev.Player);
                }


                // Добавляем игрока в список с ограничениями.
                restrictedPlayers.Add(ev.Player);
            }
        }


        public void OnPlayerDied(DiedEventArgs ev)
        {
            if (restrictedPlayers.Contains(ev.Player))
            {
                restrictedPlayers.Remove(ev.Player);
            }
            if (ev.Player == null)
            {
                return;
            }
            if (activeCoroutines.TryGetValue(ev.Player, out var handle))
            {
                Timing.KillCoroutines(handle);
                activeCoroutines.Remove(ev.Player);
            }

            ev.Player.Role.Set(RoleTypeId.Tutorial, SpawnReason.None);

            ev.Player.IsGodModeEnabled = true;

            if (!Config.IsEnabled)
                return;

            if (Config.InitialSpawnCoordinates == Vector3.zero)
            {
                return;
            }

            ev.Player.Position = Config.InitialSpawnCoordinates;
            Timing.CallDelayed(0.5f, () =>
            {

                foreach (var item in Config.Cards)
                {
                    ev.Player.AddItem(item);
                }
            });

        }
    }
}
