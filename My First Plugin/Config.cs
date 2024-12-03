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

    [Description("Башня куда тепается игрок когда заходит на сервер")]
    public Vector3 InitialSpawnCoordinates { get; set; } = new Vector3(0f, 0f, 0f);

    [Description("Лист координат карты Dust2, вписываешь сколько хочешь координат, они будут выбираться радомно")]
    public List<Vector3> Dust2Random { get; set; } = new List<Vector3>
        {
        new Vector3(0f, 0f, 0f),
        new Vector3(0f, 0f, 0f),
        new Vector3(0f, 0f, 0f),
        };
    [Description("Карты к которым привязаны классы, выбрасываешь карту капитнана то становишься капитаном, и т.д.\nКарты уборщика это карта Д-класса.Крассная карта для обучения ")]
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
        ItemType.KeycardO5
    };
    public ItemType[] GunsList2 { get; set; } =
        {
     (ItemType)999,
     ItemType.GunFSP9,
     ItemType.GunA7,
     ItemType.GunRevolver,
     ItemType.GunCom45,
     ItemType.Jailbird
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
        };//Дробобук
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
        };//калаш только обрезанный
    public ItemType[] AWP { get; set; } =
    {
            (ItemType)999,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45,
            ItemType.Ammo556x45
    };//авп

    public ItemType[] GunFSP9 =
    {
        ItemType.GunFSP9,
        ItemType.Ammo9x19,
        ItemType.Ammo9x19,
        ItemType.Ammo9x19,
        ItemType.Ammo9x19,
        ItemType.Ammo9x19,
        ItemType.Ammo9x19,
        ItemType.Ammo9x19,
        ItemType.Ammo9x19,
        ItemType.Ammo9x19
    };//Оружее пятёрочки

    public ItemType[] GunCom45 =
{
        ItemType.GunCom45,
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
    };//ьбььббббыбыь

    public ItemType[] Jailbird =
{
        ItemType.Jailbird,
        ItemType.ArmorHeavy,
    };//пиздец, что это?

    public ItemType[] GunRevolver =
    {
        ItemType.GunRevolver,
        ItemType.ArmorHeavy,
        ItemType.Ammo44cal,
        ItemType.Ammo44cal,
        ItemType.Ammo44cal,
        ItemType.Ammo44cal,
        ItemType.Ammo44cal,
        ItemType.Ammo44cal,
    };
    public string HintMessage { get; set; } = "<color=#D7D6DF>С</color><color=#D7D6DE>р</color><color=#D7D6DD>а</color><color=#403F3F>ж</color><color=#403F3F>а</color><color=#5E0404>й</color><color=#5F0404>т</color><color=#600404>е</color><color=#601009>с</color><color=#640F09>ь</color><color=#691509>!</color>";
    public string OnPlayerVerifiedMessage { get; set; } = "<color=#5E0404>В</color><color=#690707>ы</color><color=#7A0A0A>б</color><color=#8D0E0E>р</color><color=#A41111>о</color><color=#B51515>ш</color><color=#C81919>е</color><color=#D91D1D>н</color><color=#EC2121>н</color><color=#FF2525>а</color> <color=#FF2A2A>я</color> <color=#FF2E2E>к</color><color=#FF3333>а</color><color=#FF3737>р</color><color=#FF3B3B>т</color><color=#FF4040>а</color> <color=#FF4444>о</color><color=#FF4848>п</color><color=#FF4C4C>р</color><color=#FF5050>е</color><color=#FF5454>д</color><color=#FF5858>е</color><color=#FF5C5C>л</color><color=#FF6060>я</color><color=#FF6464>е</color><color=#FF6868>т</color> <color=#FF6C6C>т</color><color=#FF7070>в</color><color=#FF7474>о</color><color=#FF7878>й</color> <color=#FF7C7C>к</color><color=#FF8080>л</color><color=#FF8484>а</color><color=#FF8888>с</color><color=#FF8C8C>с</color><color=#FF9090>!</color> <color=#3B2ADF>В</color><color=#3A2EDF>ы</color><color=#3932DF>б</color><color=#3836DF>р</color><color=#373ADF>о</color><color=#363EDF>с</color><color=#3542DF>и</color> <color=#334ADF>к</color><color=#324EDF>а</color><color=#3152DF>р</color><color=#3056DF>т</color><color=#2F5ADF>у</color> <color=#2D62DF>т</color><color=#2C66DF>о</color><color=#2B6ADF>г</color><color=#2A6EDF>о</color> <color=#2876DF>к</color><color=#277ADF>л</color><color=#267EDF>а</color><color=#2582DF>с</color><color=#2486DF>с</color><color=#238ADF>а</color> <color=#2192DF>з</color><color=#2096DF>а</color> <color=#1E9EDF>к</color><color=#1DA2DF>о</color><color=#1CA6DF>т</color><color=#1BAADF>о</color><color=#1AAEDF>р</color><color=#19B2DF>ы</color><color=#18B6DF>й</color> <color=#16BEDF>х</color><color=#15C2DF>о</color><color=#14C6DF>ч</color><color=#13CADF>е</color><color=#12CEDF>ш</color><color=#11D2DF>ь</color> <color=#0FDADF>и</color><color=#0EDEDF>г</color><color=#0DE2DF>р</color><color=#0CE6DF>а</color><color=#0BEADF>т</color><color=#0AEEDF>ь</color>";
}

