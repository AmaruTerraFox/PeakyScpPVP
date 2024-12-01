using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using System.ComponentModel;
using UnityEngine;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using Exiled.API.Features;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using PeakySCPPVP.AWP;
    public class Config : IConfig
    {
        [Description("Плагин Включён? \n True-включён \n False-выключен")]
        public bool IsEnabled { get; set; } = true;
        [Description("Не трогай, всё равно не работает :)")]
        public bool Debug { get; set; } = false;

        [Description("Первая координата коробки")]
        public Vector3 InitialSpawnCoordinates { get; set; } = new Vector3(0f, 0f, 0f);

        [Description("Лист координат куда будут телепортироваться игроки")]
        public List<Vector3> Dust2Random { get; set; } = new List<Vector3>
        {
        new Vector3(0f, 0f, 0f),
        new Vector3(0f, 0f, 0f),
        new Vector3(0f, 0f, 0f),
        };
    [Description("Карты к которым привязаны классы ")]
    public ItemType[] Cards { get; set; } =
       {
            ItemType.KeycardMTFCaptain, //Карта капитана
            ItemType.KeycardChaosInsurgency, //Хаос
            ItemType.KeycardScientist, // Учёнка
            ItemType.KeycardJanitor,//Д-класс
            ItemType.KeycardGuard,//Охраник пятёрочки
            ItemType.KeycardFacilityManager//Обучение

       };
    public ItemType[] GunsList1 { get; set; } =
    {
        ItemType.GunFRMG0,
        ItemType.GunE11SR,
        ItemType.GunCrossvec,
        ItemType.GunAK,
        ItemType.GunShotgun,
        ItemType.GunLogicer,
        ItemType.GunShotgun,
        ItemType.KeycardO5
    };
public ItemType[] GunsList2 { get; set; } =
    {
     ItemType.GunFSP9,
     ItemType.GunA7,
     ItemType.GunRevolver,
     ItemType.GunCom45
    };

[Description("снаряжения")]

public ItemType[] GunFRMG0 { get; set; } =
{
            ItemType.GunFRMG0,
            ItemType.ArmorHeavy,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45
};//Пулик
public ItemType[] GunE11SR { get; set; } =
        { 
            ItemType.GunE11SR,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45
        };//эмка
public ItemType[] GunCrossvec { get; set; } =
        {
            ItemType.GunCrossvec,
            ItemType.ArmorHeavy,
            ItemType.Ammo9x19,
            ItemType.Ammo9x19,
            ItemType.Ammo9x19,
            ItemType.Ammo9x19,
            ItemType.Ammo9x19,
            ItemType.Ammo9x19,
            ItemType.Ammo9x19,
            ItemType.Ammo9x19, 
            ItemType.Ammo9x19
        };//Кросвег
public ItemType[] GunLogicer { get; set; } =
        {
            ItemType.GunLogicer,
            ItemType.ArmorHeavy,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39
        };//Пулик то жёлтый
public ItemType[] GunShotgun { get; set; } =
        {

          ItemType.GunShotgun,
          ItemType.ArmorHeavy,
          ItemType.Ammo12gauge,
          ItemType.Ammo12gauge,
          ItemType.Ammo12gauge,
          ItemType.Ammo12gauge,
          ItemType.Ammo12gauge,
          ItemType.Ammo12gauge
        };//Драбовуик
public ItemType[] GunAK { get; set; } =
        {
          ItemType.GunAK,
          ItemType.ArmorHeavy,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39
        };//калаш
public ItemType[] A7 { get; set; } =
        {    
            ItemType.GunA7,
            ItemType.ArmorHeavy,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39,
            ItemType.Ammo762x39
        };//калаш только обрезаный

    };
