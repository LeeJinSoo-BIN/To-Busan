# To_Busan

## 바이너리 동아리 게임 프로젝트

> 프로젝트 기간: 2021.03 ~ 2021.07<br>
> 참여자 : 이진수, 정윤서, 오지선, 주민지, 김병목, 전경원 <br>
> 유니티 버전 : 2020.3.25f1
--------


<br>


## \*인게임

### 캐릭터
<img src="readme img/character1.png" width = 60>    <img src="readme img/character2.png" width = 60>


### 맵

<img src="readme img/map.png">

### 부품
||||
|:---:|:---:|:---:|
|<img src="readme img/driver.png" width = 60>|<img src="readme img/gear.png" width = 60> |<img src="readme img/iron.png" width = 60> |
|<img src="readme img/oil.png" width = 60> |<img src="readme img/screw.png" width = 60>|x


### 아이템

|||
|:---:|:----:|
|<img src="readme img/night_vision.png" width = 60> <br>아갼 투시경 |<img src="readme img/kit.png" width = 60><br>의료 키트

야간 투시경 : 사용시 일정 시간 동안 시야 증가 (밤에만 사용 가능) <br>
의료 키트 : 플레이어를 치료 가능. 좀비, 감염자에게 사용시 다음 낮에 시민이 됨 (낮에만 사용 가능)

<br>

## \*미완성 버전입니다.
로컬내의 멀티플레이만 구현되었습니다.
대기실에 참여하는 것만 구현된 단계로,
게임이 시작 된 후의 동기화는 구현되지 않았습니다.

<br>

## \*게임 실행  
To_Busan.exe 파일을 실행하면 게임 클라이언트가 실행됩니다.  
start버튼을 누르고 맨위의 입력창에 방이름을 입력한 후  
방 만들기 버튼을 클릭한 후 좀비와 플레이어수를 설정 해주고  
시작버튼을 누르면, 대기실에 입장됩니다.  
좌측 ui의 Ready 버튼을 누르고 Start버튼을 누르면 게임이 시작됩니다.  

<br>

## \*멀티플레이(로컬 내) 테스트하기  
To_Busan.exe파일을 여러번 실행하면, 클라이언트가 여러개 띄워집니다.  
한 클라이언트로 위의 방법으로 방을 만들고,  
다른 클라이언트 들로 똑같은 이름을 입력 후 방 입장하기를 클릭하면,  
대기실에 입장이 가능합니다. 여러 클라이언트가 입장된 것은  
좌측의 UI를 통해 확인 가능합니다.  
모든 플레이어가 Ready버튼을 누르고 호스트가 start버튼을 누르면  
모든 클라이언트가 게임에 접속됩니다.  
[다운로드 링크](https://drive.google.com/file/d/1egmalhgDF-5LARdtleghbrsVnn8v6YX0/view?usp=drive_link)

<br>

## \*게임 룰  

### 승리 조건    
- 시민  
  매 정거장마다 기차를 수리하여  
최종역까지 시민인 상태로 도달시 승리  
  
- 좀비  
  최종역 도착 전까지  
모든 시민을 감염시키면 승리  
  
- 감염자  
시민편에 설 것인지, 좀비편에 설 것인지 선택.  
여부에 따라 시민과 좀비의 승리조건을 따름  
(좀비를 통해 감염되며, 감염 즉시 감염 여부를 알지 못함)  

<br>  

### 게임 진행  
역에 모두가 내리며 게임이 시작 됨  
낮과 밤이 교차로 바뀌며 게임이 진행됨  
  
- 낮  
특별한 제한 조건은 없고  
좀비는 낮에 감염시킬 수 없음  
  
- 밤  
시야의 범위가 좁아짐  
좀비와 시민 모두 피아식별(색깔등으로의 케릭터 구분)이 불가능해짐  
좀비와 감염자는 시민을 감염시킬 수 있게 됨  
  
```기차의 부품을 모두 모으거```나 ```시민이 모두 감염될 때```까지 반복됨  
  
  
### 기차의 부품을 모두 모은 경우)  
1. 모두 기차에 탑승하여 다음 역으로 이동  
이때, 좀비로 부터 감염된 시민은 자신의 감염 여부를 알게 되고,  
시민과 좀비 중 속하게 될 팀을 선택 (추후 변경 불가능)   
  
2. 다음역에 도착할 때 까지 좀비를 찾는 투표를 진행  
이 투표에 뽑힌 인원은 기차 내부의 치료 장치를 통해 시민이 됨  

3. 이후 남은 감염자 및 좀비와 시민의 인원을 알려주고  
다음역에 내려서 이를 반복.  
  
### 시민이 모두 감염된 경우)  
좀비와 좀비편 감염자만 승리

<br>

## \* 조작법

- 이동 : WASD or 방향키 or 마우스 좌클릭 <br>
- 아이템 상자 상호작용 : 우측 하단 FIND 버튼 <br>
- 줌인 줌아아웃 : 마우스 스크롤 <br>
- 미니맵 : 우측 상단 MAP 버튼 or M key <br>
- 아이템 상호작용 : 좌측 하단 인벤토리 아이템 버튼<br>


<br>


## \*역할
| 이름 | 역할 및 구현 기능 |
| --- | --- |
| 이진수 (팀장) | 맵 디자인, 미니맵, 아이템 랜덤 소환,  <br> 아이템 획득, 미션 진행, 낮과 밤 타이머,  <br>총괄 |
| 정윤서 | 맵 디자인, 콜라이더 배치 |
| 오지선, 주민지 | 케릭터 디자인, 시야 제한, 줌 인 아웃, <br> 애니메이션 |
| 김병목, 전경원 | 서버, 메인 페이지, 로비 |
