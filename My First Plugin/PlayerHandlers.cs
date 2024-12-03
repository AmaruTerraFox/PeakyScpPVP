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

            // TP to korobka and start korutina
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
            if (restrictedPlayers.Contains(ev.Player))
            {
                ev.IsAllowed = false;
                return;
            }
            if (ev.Item.Type == ItemType.KeycardMTFCaptain)
            {
                ev.Player.Role.Set(RoleTypeId.NtfCaptain, SpawnReason.None);
                Timing.CallDelayed(0.5f, () =>
                {
                    ev.Player.ClearInventory();
                    ev.Player.Position = Config.InitialSpawnCoordinates;

                });
                Timing.CallDelayed(0.5f, () =>
                    {
                        foreach (var item in Config.GunsList1)
                        {
                            ev.Player.AddItem(item);
                        }
                    });
            }
            if (ev.Item.Type == ItemType.KeycardChaosInsurgency)
            {
                ev.Player.Role.Set(RoleTypeId.ChaosRepressor, SpawnReason.None);
                Timing.CallDelayed(0.5f, () =>
                {
                    ev.Player.ClearInventory();
                    ev.Player.Position = Config.InitialSpawnCoordinates;

                });
                Timing.CallDelayed(0.5f, () =>
                {
                    foreach (var item in Config.GunsList1)
                    {
                        ev.Player.AddItem(item);
                    }
                });
            }
            if (ev.Item.Type == ItemType.KeycardFacilityManager)
            {
                ev.Player.Role.Set(RoleTypeId.Tutorial, SpawnReason.None);
                Timing.CallDelayed(0.5f, () =>
                {
                    ev.Player.ClearInventory();
                    ev.Player.Position = Config.InitialSpawnCoordinates;

                });
                Timing.CallDelayed(0.5f, () =>
                {
                    foreach (var item in Config.GunsList1)
                    {
                        ev.Player.AddItem(item);
                    }
                });
            }
            if (ev.Item.Type == ItemType.KeycardGuard)
            {
                ev.Player.Role.Set(RoleTypeId.FacilityGuard, SpawnReason.None);
                Timing.CallDelayed(0.5f, () =>
                {
                    ev.Player.ClearInventory();
                    ev.Player.Position = Config.InitialSpawnCoordinates;

                });
                Timing.CallDelayed(0.5f, () =>
                {
                    foreach (var item in Config.GunsList1)
                    {
                        ev.Player.AddItem(item);
                    }
                });
            }
            if (ev.Item.Type == ItemType.KeycardJanitor)
            {
                ev.Player.Role.Set(RoleTypeId.ClassD, SpawnReason.None);
                Timing.CallDelayed(0.5f, () =>
                {
                    ev.Player.ClearInventory();
                    ev.Player.Position = Config.InitialSpawnCoordinates;

                });

                Timing.CallDelayed(0.5f, () =>
                {
                    foreach (var item in Config.GunsList1)
                    {
                        ev.Player.AddItem(item);
                    }
                });
            }
            if (ev.Item.Type == ItemType.KeycardO5)
            {
                Timing.CallDelayed(0.3f, () =>
                {
                    ev.Player.ClearInventory();

                });
                Timing.CallDelayed(0.5f, () =>
                {
                    foreach (var item in Config.GunsList2)
                    {
                        ev.Player.AddItem(item);

                    }
                });
            }
            //###########################################
            //###########################################
            //####               Пушки             ######
            //###########################################
            //###########################################

            if (ev.Item.Type == ItemType.GunFRMG0)
                Timing.CallDelayed(0.3f, () =>
                {
                    foreach (var item in Config.GunFRMG0)
                    {
                        ev.Player.AddItem(item);

                    }
                    int randomIndex = Random.Next(Config.Dust2Random.Count);
                    ev.Player.Position = Config.Dust2Random[randomIndex];
                    restrictedPlayers.Add(ev.Player);

                });

                if (ev.Item.Type == ItemType.GunE11SR)
                    Timing.CallDelayed(0.3f, () =>
                    {
                        foreach (var item in Config.GunE11SR)
                        {
                            ev.Player.AddItem(item);
                            int randomIndex = Random.Next(Config.Dust2Random.Count);
                            ev.Player.Position = Config.Dust2Random[randomIndex];
                            restrictedPlayers.Add(ev.Player);
                        }

                    });

                if (ev.Item.Type == ItemType.GunCrossvec)
                    Timing.CallDelayed(0.3f, () =>
                    {
                        foreach (var item in Config.GunCrossvec)
                        {
                            ev.Player.AddItem(item);
                            int randomIndex = Random.Next(Config.Dust2Random.Count);
                            ev.Player.Position = Config.Dust2Random[randomIndex];
                            restrictedPlayers.Add(ev.Player);
                        }

                    });

                if (ev.Item.Type == ItemType.GunLogicer)
                    Timing.CallDelayed(0.3f, () =>
                    {
                        foreach (var item in Config.GunLogicer)
                        {
                            ev.Player.AddItem(item);
                            int randomIndex = Random.Next(Config.Dust2Random.Count);
                            ev.Player.Position = Config.Dust2Random[randomIndex];
                            restrictedPlayers.Add(ev.Player);
                        }

                    });
            if (ev.Item.Type == ItemType.GunShotgun)
                Timing.CallDelayed(0.3f, () =>
                {
                    foreach (var item in Config.GunShotgun)
                    {
                        ev.Player.AddItem(item);
                    }
                    int randomIndex = Random.Next(Config.Dust2Random.Count);
                    ev.Player.Position = Config.Dust2Random[randomIndex];
                    restrictedPlayers.Add(ev.Player);
                });

            if (ev.Item.Type == ItemType.GunAK)
                Timing.CallDelayed(0.3f, () =>
                {
                    foreach (var item in Config.GunAK)
                    {
                        ev.Player.AddItem(item);
                    }
                    int randomIndex = Random.Next(Config.Dust2Random.Count);
                    ev.Player.Position = Config.Dust2Random[randomIndex];
                    restrictedPlayers.Add(ev.Player);
                });

            if (ev.Item.Type == ItemType.GunFSP9)
                Timing.CallDelayed(0.3f, () =>
                {
                    foreach (var item in Config.GunFSP9)
                    {
                        ev.Player.AddItem(item);
                    }
                    int randomIndex = Random.Next(Config.Dust2Random.Count);
                    ev.Player.Position = Config.Dust2Random[randomIndex];
                    restrictedPlayers.Add(ev.Player);
                });

            if (ev.Item.Type == ItemType.GunA7)
                Timing.CallDelayed(0.3f, () =>
                {
                    foreach (var item in Config.GunCom45)
                    {
                        ev.Player.AddItem(item);
                    }
                    int randomIndex = Random.Next(Config.Dust2Random.Count);
                    ev.Player.Position = Config.Dust2Random[randomIndex];
                    restrictedPlayers.Add(ev.Player);
                });

            if (ev.Item.Type == ItemType.GunCom45)
                Timing.CallDelayed(0.3f, () =>
                {
                    foreach (var item in Config.GunCom45)
                    {
                        ev.Player.AddItem(item);
                    }
                    int randomIndex = Random.Next(Config.Dust2Random.Count);
                    ev.Player.Position = Config.Dust2Random[randomIndex];
                    restrictedPlayers.Add(ev.Player);
                });

            if (ev.Item.Type == ItemType.Jailbird)
                Timing.CallDelayed(0.3f, () =>
                {
                    foreach (var item in Config.Jailbird)
                    {
                        ev.Player.AddItem(item);
                    }
                    int randomIndex = Random.Next(Config.Dust2Random.Count);
                    ev.Player.Position = Config.Dust2Random[randomIndex];
                    restrictedPlayers.Add(ev.Player);
                });


            if (activeCoroutines.TryGetValue(ev.Player, out var handle))
                {
                    Timing.KillCoroutines(handle);
                    activeCoroutines.Remove(ev.Player);
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
