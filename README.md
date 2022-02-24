# 메이플 유틸 캐릭터 정보 파싱 프로젝트

## About

메이플스토리 캐릭터 장비를 가져오는 공식 API가 없어서 직접 만든 파싱 프로그램입니다.
공식 홈페이지에 정보가 공개된 캐릭터를 검색하여 해당 캐릭터의 기본정보, 기본 스펙, 장착한 장비 아이템, 펫장비, 아케인 심볼을 추출합니다.

## Requirements

* [`.NET 6.0`](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Usage

일반 콘솔 앱

```csharp
// 파싱 객체 만들기
using var mapleutilsParser = MapleUtilsParser.Create(isHeadless: false/* 기본값 true, false로 할 시 디버깅에 도움됨 */);
// 닉네임 검색
var test = await mapleutilsParser.GetCharacterAsync("상빈");
// JSON으로 출력
Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(test));
```

웹 API

```csharp
// Startup.cs
using MapleUtils.Parser.Extensions;

builder.Services.AddMapleUtilsParser();
```

```csharp
// Controller
using MapleUtils.Parser;

[ApiController]
[Route("[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IMapleUtilsParser _parser;

    public CharactersController(IMapleUtilsParser mapleUtilsParser)
    {
        _parser = mapleUtilsParser;
    }

    [HttpGet("/{name}")]
    public async Task<IActionResult> Get(string name)
    {
        var character = await _parser.GetCharacterAsync(name);

        return Ok(character);
    }
}
```

## Test

### 실행

```sh
dotnet test
```

### 추가하기

`MapleUtils.Parser.Test`에 추가

## 파싱되는 스탯

```csharp
public enum StatEnum
{
    Str, // 힘
    Dex, // 덱
    Int, // 인
    Luk, // 럭
    StrP, // 힘퍼
    DexP, // 덱퍼
    IntP, // 인퍼
    LukP, // 럭퍼
    Hp, // HP
    HpP, // HP퍼
    Mp, // MP
    MpP, // MP퍼
    Atk, // 공격력
    AtkP, // 공격력퍼
    MAtk, // 마력
    MAtkP, // 마력퍼
    Def, // 물리방어력
    DefP, // 물리방어력%
    Speed, // 이동속도
    Jump, // 점프력
    IgnoreDef, // 방어율 무시%
    MobDmg, // 일반 몬스터 데미지%
    BossDmg, // 보스 몬스터 데미지%
    Dmg, // 데미지%
    AllStat, // 올스탯
    AllStatP, // 올스탯%
    Crit, // 크리티컬 확률
    CritDmg, // 크리티컬 데미지%
    Buff, // 버프지속시간
    StatusDmg, // 상태이상 데미지
    Arcane, // 아케인포스
    LvNAtk, // Lv n당 공1
    LvNMAtk, // Lv n당 마1
    Lv10Str, // Lv 10당 힘n
    Lv10Dex, // Lv 10당 덱n
    Lv10Int, // Lv 10당 인n
    Lv10Luk, // Lv 10당 럭n
    Meso, // 메소 획득량
    Drop, // 아이템 드롭률
    HpHeal, // 회복
    Passive, // 패시브 1렙
}
```


## Output 예시

```json
{
  "name": "상빈", 
  "world": "크로아",
  "job": "듀얼블레이더",
  "level": 243,
  "imageUrl": "https://avatar.maplestory.nexon.com/Character/180/HEEGIIMGGHGIGPDMLPKLNCFJKDGMDDNNFIDMAHEAJHKIAPKEFNNEODIFICCDANOFGIFJOLPGGIKEGKJDMCNOEHLCDCBJDBBPHNDELKIBBOABODIKNLPEAFDKPBPHIDJLHAOIIGMEKPIBAMEAFIBKNLIHFIOCBJPCPHBDFBCPNBDEHFFBNLAJCIDIMPEAKDBOIKCKPKLOEEEBCBFGDCPFIPBGFOGJGDGBNFEGENMGDMFNIPKECCDMNHMMFCAJNGAI.png",
  "equipments": [
    {
      "grade": "Legendary",
      "star": 15,
      "potential": {
        "grade": "Legendary",
        "effects": [
          {
            "BossDmg": 35
          },
          {
            "Dmg": 12
          },
          {
            "Crit": 12
          }
        ]
      },
      "additional": null,
      "flame": {
        "Dex": 33,
        "Luk": 0,
        "Hp": 0,
        "Mp": 1800,
        "Atk": 133,
        "BossDmg": 0,
        "IgnoreDef": 0,
        "Dmg": 3
      },
      "soul": [
        {
          "AllStat": 15
        }
      ],
      "name": "아케인셰이드 대거",
      "imageUrl": "https://avatar.maplestory.nexon.com/ItemIcon/KEMBJFHA.png",
      "category": "단검",
      "upgrade": 8,
      "base": {
        "Dex": 100,
        "Luk": 100,
        "Hp": 0,
        "Mp": 0,
        "Atk": 276,
        "BossDmg": 30,
        "IgnoreDef": 20,
        "Dmg": 0
      },
      "scroll": {
        "Dex": 40,
        "Luk": 64,
        "Hp": 255,
        "Mp": 255,
        "Atk": 179,
        "BossDmg": 0,
        "IgnoreDef": 0,
        "Dmg": 0
      }
    }
    //...
  ],
  "spec": {
    "statAtkLow": 4677467,
    "statAtkHigh": 5197185,
    "hp": 46151,
    "mp": 28663,
    "str": 1696,
    "dex": 3034,
    "int": 1490,
    "luk": 22508,
    "critDmg": 55,
    "bossDmg": 257,
    "ignoreDef": 86,
    "dmg": 0,
    "resistance": 53,
    "stance": 100,
    "def": 29664,
    "speed": 160,
    "jump": 123,
    "starForce": 230,
    "arcaneForce": 1020,
    "authenticForce": 0,
    "abilities": {
      "BossDmg": 20,
      "StatusDmg": 7
    },
    "hypers": {
      "Atk": 18,
      "MAtk": 18,
      "Luk": 90,
      "Crit": 5,
      "CritDmg": 10,
      "IgnoreDef": 30,
      "Dmg": 33,
      "BossDmg": 39
    }
  },
  "arcanes": [
    {
      "name": "아케인심볼 : 소멸의 여로",
      "stat": {
        "Luk": 1600
      },
      "level": 14,
      "experience": 98,
      "requiredExperience": 207
    },
    {
      "name": "아케인심볼 : 츄츄 아일랜드",
      "stat": {
        "Luk": 1700
      },
      "level": 15,
      "experience": 199,
      "requiredExperience": 236
    },
    {
      "name": "아케인심볼 : 레헬른",
      "stat": {
        "Luk": 1500
      },
      "level": 13,
      "experience": 0,
      "requiredExperience": 180
    },
    {
      "name": "아케인심볼 : 아르카나",
      "stat": {
        "Luk": 1700
      },
      "level": 15,
      "experience": 162,
      "requiredExperience": 236
    },
    {
      "name": "아케인심볼 : 모라스",
      "stat": {
        "Luk": 1700
      },
      "level": 15,
      "experience": 297,
      "requiredExperience": 236
    },
    {
      "name": "아케인심볼 : 에스페라",
      "stat": {
        "Luk": 1700
      },
      "level": 15,
      "experience": 133,
      "requiredExperience": 236
    }
  ],
  "authentics": null,
  "traits": {
    "ambition": 100,
    "insight": 100,
    "willpower": 100,
    "diligence": 100,
    "empathy": 100,
    "charm": 100
  },
  "petEquipments": [
    {
      "name": "노란색 모자",
      "imageUrl": "https://avatar.maplestory.nexon.com/ItemIcon/KEHCJHOA.png",
      "category": "펫장비",
      "upgrade": 0,
      "base": {},
      "scroll": {}
    }
  ],
  "otherEquipments": null
}
```