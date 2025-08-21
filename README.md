# 팀 프로젝트 : Puzzle_Cat

안녕하세요 Unity 11기 14조 입니다.  저희팀은 3D 퍼즐 플랫폼 게임을 구현했습니다.

### **팀원 목록 :**

| 이름 | 태그 | 😺  역할 분담 |
| --- | --- | --- |
| 정승우 | 팀장 | 메인 퍼즐2(사이버펑크 헤킹) + 사운드 |
| 원정우 | 팀원 | 메인 퍼즐1(공 굴리기) + UI |
| 김남진 | 팀원 | 메인 퍼즐3(레이저 퍼즐) + 게임 저장 |
| 김용민 | 팀원 | 메인 월드 + 서브 퍼즐 + 코드 병합 + 엔딩 연출 |
| 이승율 | 팀원 | 플레이어(기본 이동 + 상호작용) |

## I. 게임 개요:

사랑스러운 고양이 주인공이 **집사가 돌아오기 전까지 펼쳐지는 우당탕탕 퍼즐 어드벤처!** 🐾

집 안 곳곳에서 기다리는 기발한 퍼즐과 도전 과제를 해결하며, 고양이만의 모험을 즐겨보세요.

## 특징:

1. 주변의 **다양한 오브젝트와 상호작용**하여 새로운 퍼즐에 진입하세요.
2. 퍼즐을 클리어하면 **서로 다른 크기의 박스**를 보상으로 획득할 수 있습니다.
3. 얻은 박스를 활용해 밀고 **더 높은 위치**로 올라가 새로운 퍼즐에 도전하세요.
4. 퍼즐은 각각 색다른 방식으로 진행됩니다.
    - 긴장감 넘치는 **공 굴리기**
    - 머리를 쓰는 **레이저 게임**
    - 직관력을 시험하는 **아이템 이미지 클릭하기**
5. 최종적으로, 집 안에 숨겨진 **세 개의 메인 퍼즐 진입 포인트(고양이 발 모양 코인)** 를 모두 모아, 집사가 돌아올 때 당당히 맞이하세요!
##

## 참고 이미지 :

<details>
<summary>펼쳐보기</summary>

 ![123](https://github.com/user-attachments/assets/e28698ee-b9f7-41c7-9d71-bf1a90a980e7)

 Esc 클릭 시 UI 팝업

 ![123](https://github.com/user-attachments/assets/e53e44af-1095-4fea-8845-2b4edb760407)

 공굴리기 퍼즐

 ![사펑 퍼즐](https://github.com/user-attachments/assets/35dc4a0c-0876-4267-88f1-311e095a84a8)

 해킹 퍼즐

 ![레이저 퍼즐](https://github.com/user-attachments/assets/0ccda290-3ea6-4cb5-91fd-7aa7d0750698)

 레이저 퍼즐
    
 ![Wall](https://github.com/user-attachments/assets/163b25d1-fab3-4f46-99e5-7df1b2aa8b97)

 Cinemachine을 활용한 장애물 충돌 기능  
  
</details>

##
    
### 필수 기능 :  (구현 완료)
<details>
<summary>펼쳐보기</summary> 
  
1. **퍼즐 디자인** (난이도: ★★★☆☆) ✅
   - 다양한 퍼즐을 게임에 디자인하고 구현하여 게임의 핵심 플레이를 제공합니다.
   - 퍼즐의 난이도와 다양성을 고려하여 설계합니다.
    
2. **플레이어 캐릭터 및 컨트롤** (난이도: ★★★☆☆) ✅
   - 플레이어 캐릭터를 제작하고, 캐릭터를 조작할 수 있는 컨트롤러를 구현합니다.
   - 필요한 도구나 능력을 제공하여 퍼즐을 해결할 수 있도록 합니다.
    
3. **퍼즐 해결 시스템** (난이도: ★★★☆☆) ✅
   - 퍼즐 해결에 필요한 시스템을 구현하고, 퍼즐의 상호작용 및 해결 방법을 설계합니다.
   - 퍼즐 요소의 동작 메커니즘과 규칙을 구현합니다.
    
4. **장애물 및 트랩** (난이도: ★★★☆☆) ✅
   - 장애물과 트랩을 게임에 추가하여 플레이어의 도전을 높이고 퍼즐과 조화롭게 결합시킵니다.
    
5. **목표 지점** (난이도: ★★☆☆☆) ✅
   - 퍼즐을 풀고 목표 지점에 도달할 수 있는 목표 지점을 제공합니다.
   - 목표 지점 도달로 레벨 완료를 처리합니다.
    
6. **게임 진행 상태 및 저장** (난이도: ★★★☆☆) ✅
   - 퍼즐 해결 상태와 게임 진행 상태를 저장하고 관리하는 시스템을 구현합니다.
   - 플레이어의 진척 상황을 추적하고 레벨 별로 관리합니다.
    
7. **사운드 및 음악** (난이도: ★☆☆☆☆) ✅
   - 게임에 사운드 효과와 음악을 추가하여 게임의 분위기를 개선합니다.
    
8. **UI 애니메이션 추가** (난이도: ★★★☆☆) ✅
   - UI 노출, 전환 시 자연스럽게 이동, 페이드, 크기 변화 등 애니메이션을 추가합니다.
   - UI 애니메이션 (Unity 기본 Animator, 외부 라이브러리 Dotween)
  
</details>

##

### 선택 기능 :  (구현 완료)
<details>
<summary>펼쳐보기</summary> 
  
1. **고급 퍼즐 요소** (난이도: ★★★★☆) ✅
   - 퍼즐의 난이도를 높이기 위해 고급 퍼즐 요소를 도입합니다.
   - 복합적인 논리나 물리학 요소를 활용한 퍼즐을 추가합니다.

</details>

## II. 게임 핵심 기능 구현 설명 :

<details>
<summary>LaserRaycaster :</summary> 
  
1. 레이저를 발사할 수 있는 오브젝트들이 갖는 컴포넌트로, 외부에서 발사 할 레이저의 정보를 리스트에 등록하면 해당 리스트를 바탕으로 레이저를 발사함

```csharp
// 외부에서 레이저 정보를 등록할 때 사용하는 함수, 이미 등록된 정보라면 종료
public void AddLaserInfo(LaserRaycastInfo info)
{
    if (laserRaycastInfos.Contains(info))
        return;
    else
        laserRaycastInfos.Add(info);
}
```

2. 레이저를 발사 할 방향으로 레이캐스트를 하여 레이저를 렌더링하고, 만약 레이캐스트에 감지된 대상이 레이저와 상호작용이 가능한 오브젝트라면 해당 오브젝트의 기능을 실행한다.

```csharp
// 각 레이저 정보를 바탕으로 Raycast를 실행 및 라인렌더러 렌더링
if (Physics.Raycast(currentPos, currentDir, out RaycastHit hit, laserRaycastInfos[i].maxDistance))
{
    lineRenderers[i].positionCount++;
    lineRenderers[i].SetPosition(lineRenderers[i].positionCount - 1, hit.point);

    ILaserInteractable interactable = hit.collider.transform.parent.GetComponent<ILaserInteractable>();
    if (interactable != null)
    {
        interactable.OnLaserHit(new LaserHitInfo(hit.point, currentDir, hit.normal, laserRaycastInfos[i].laserColor));
    }
}
```

3. 기존의 설계 구조에서는 레이저를 한 개만 발사하는 것을 고려하여 라인렌더러를 한 개만 가지고 구성했으나, 특정 상황에서는 2개 이상의 레이저를 구분하여 발사할 필요가 있어서 자식 오브젝트로 라인렌더러를 여러개 가질 수 있게 구조를 변경함
  
</details>

<details>
<summary>PuzzleManager :</summary> 
각 각 포인트에서 퍼즐로 진입하게 되는 시점과 데이터를 받아오는 과정, 그리고 그 데이터에 따른 퍼즐을 생성하고 퍼즐을 클리어 하게 되면 현재 퍼즐이 파괴되면서 클리어 한 상태로 만드는 과정을 제일 열심히 만들었습니다.

1. 퍼즐 진입 하는 시점 :
   - 클래스에서 InteractableObject를 상속받아서 override로 메서드를 실행해줍니다.
   - 그러면 현재 오브젝트가 가지고있는 ScriptableObject의 정보를 PuzzleManager에 넘겨줍니다.
   ```csharp
   public MiniGame games;

   public Transform rewardSpawnPoint;

   public override void Interact()
   {
       base.Interact();
       PuzzleManager.Instance.PuzzleIn(games, rewardSpawnPoint);
       PuzzleDataManager.Instance.Clear += Setactive;
   }

   ```
   - 그리고 만약에 클리어 하게되면 현재 interact 된 오브젝트를 setactive(false) 해주기 위해서 Delegate를 등록해주었습니다.
     
2. 퍼즐 데이터 넘어온 뒤 :
   - PuzzleManager 에서 퍼즐의 데이터와 보상이 생성될 위치를 받습니다.
   ```csharp
     public void PuzzleIn(MiniGame data, Transform rwdTrs)
   ```
   - 그리고 현재 puzzleManager가 들고있는 데이터를 한번 null로 초기화를 해주고
   ```csharp
   miniGame = null;
   currentRwdTrs = null;
   ```
   - 게임에서 플레이어 혹은 전체적으로 바뀌어야 되는 정보를 게임매니저에서 세팅해줍니다
   ```csharp
   OnPuzzleZoneEnter?.Invoke(data);
   ```
    
3. 게임 매니저에서 OnPuzzleZoneEnter에 델리게이트를 사용 : 
   - 현재 플레이어의 상태를 바꾸어주는 메서드를 등록해놓았습니다.
   ```csharp
   private void HandlePuzzleIn(MiniGame data)
   {
       if (data.isGravityUse)
       {
           Physics.gravity = data.GravityScale;
       }

       PlayerInput input = CharacterManager.Instance.Player.GetComponent<PlayerInput>();

       if (input != null)
       {
           input.SwitchCurrentActionMap("BallPuzzle");
       }

       Cursor.lockState = CursorLockMode.None;
   }  
   ```
   - 그리고 만약에 이전에 있던 퍼즐 오브젝트가 있으면 파괴해주는 방어 코드입니다.
    ```csharp
    if (obj != null)
    {
        DestroyObj();
    }
    ```
   - 그리고 나서 매니저가 들고있는 정보에 받아온 정보를 넣어주고 생성해줍니다.
    ```csharp
    miniGame = data;
    currentRwdTrs = rwdTrs;
    obj = Instantiate(data.levels, transform.position, transform.rotation, transform);
    ```
   - 그리고 각 퍼즐에서 클리어 조건을 달성하면 퍼즐 매니저에서 PuzzleClear 메서드를 실행해줍니다.
   - 그러면 현재 들어있는 데이터에서 보상이 있는지 확인하고 있으면 보상을 생성해줍니다.
    ```csharp
    if (miniGame.reward != null && currentRwdTrs != null)
    {
      SpawnReward();
      Debug.Log("Spawn!");
    }
    ```
   - 그리고 나서 게임을 클리어 했다는 정보를 현재 데이터를 넘겨서 관리를 해줍니다.  
    ```csharp
    PuzzleDataManager.Instance.isGameCleared(miniGame);
    ```
   - 퍼즐이 종료된 후 게임의 상태를 다시 원래대로 돌려줍니다.
    ```csharp
    PuzzleExit();
    ```

4. 이런식으로 최대한 각자 자기 할일만 할수있게 만들어놓았습니다.
  
</details>

<details>
<summary>BallSpawner,FloorController,EndPoint :</summary> 
  
1. E키를 통해 공을 생성하고 WASD를 통해 공이 닿아있는 바닥을 움직여 EndPoint에 도착 시 게임이 클리어 되는 구조 입니다. 추가적인 기능으로 순간이동,회전하는 장애물 등이 구현 되어 있습니다.
   ```csharp
      public void OnSpawnBall(InputAction.CallbackContext context)    //공의 프리팹을 스폰하는 메서드 입니다.
      {
          if (context.phase != InputActionPhase.Started || curPrefab != null) return;

          curPrefab = Instantiate(ballPrefab, transform.position, Quaternion.identity);

          isReset = false;
          Debug.Log(curPrefab);
      }
   ```
    
2. 프리팹을 생성하고 과정에서 캐싱 및 중복생성 방지하는 기능을 실행합니다.
   ```csharp
      public void OnSetMoveValue(InputAction.CallbackContext context)	//인풋 시스템을 통해 받아온 벡터를 로테이션에 맞는 값으로 변경 및 적용해주는 메서드 입니다.
      {
          if (!canMove) return;

          if (context.phase == InputActionPhase.Performed )
          {
              curMovementInput = context.ReadValue<Vector2>();
              changeZValue = new Vector3(-curMovementInput.x, 0, -curMovementInput.y);
          }
          else if (context.phase == InputActionPhase.Canceled)
          {
              curMovementInput = Vector2.zero;
              changeZValue = Vector3.zero;
          }
      }
   ```
    
3. Vector2로 입력받은 값을 필요한 Vector3로 변경해 사용하기 위한 기능을 실행합니다.
   ```csharp
      private void OnCollisionEnter(Collision collision)	//충돌이 있다면 충돌한 물체를 확인 후 공이라면 게임 클리어를 실행하는 메서드 입니다.
      {
          if (!collision.gameObject.CompareTag("Ball") || isClear) return;

          PuzzleManager.Instance.PuzzleClear();
          //gameClearUI.SetActive(true);
          //Debug.Log("게임 클리어 UI띄우기");
      }
   ```

4. Collider를 통해 충돌을 감지 후 충돌체의 정보에 따라 게임 클리어 기능을 실행합니다.
  
</details>

<details>
<summary>플레이어 이동 과 팔로잉 카메라 구현 :</summary>

1. 이동과 팔로잉 카메라 유니티에서의 기본 구조는 Player 오브젝트한에 모형을 나타내는 Kitty와 메인 카메라를 담아줄 CameraContainer를 만들었습니다.
        
   <img width="359" height="339" alt="Player1" src="https://github.com/user-attachments/assets/b7d2fd6a-79fa-420e-ae4a-0affba027b46" />
        
2. 그리고  Player에서 캐릭터에 충돌, 동작, 키입력 카메라에 팔로잉과 좌우, 상하 이동제한 괄리등을 모두 제어 합니다.
            
   <img width="833" height="652" alt="Player2" src="https://github.com/user-attachments/assets/c32e591e-ba73-4458-8746-4cae670800e4" />
            
3. 코드 관련 해석: 
                
```csharp
[Header("Moverment")] // 동작 관련 부분
public Transform kittyTransform; 
// 공양이와 카메라의 이동을 불리하기 위해 고양이 오브젝트의 transform을 가지고 왔습니다.
private Vector2 curMovementInput;
// Input system에서 받아오는 키보드 입력 값을 저장할 변수입니다. 
public LayerMask groundLayerMask;
// 점프 구현 시 지면을 감지하기 위해 지정 레이어를 저장할 변수입니다.
                
[Header("Look")] // 카메라 관련 부분
public Transform cameraContainer; 
// 카메라가 팔로이하는 오브젝트를 저장할 변수입니다.
public float lookSensitivity; // 민감도 변수
private float camCurXRot; // 카메라 상하 delta 값 저장 변수
private float camCurYRot; // 카메라 좌우 delta 값 저장 변수
private Vector2 mouseDelta; // Input system에서 받아오는 마우스 delta 값을 저장할 변수입니다.
private Vector3 cameraAngle; // 카메라 각도를 저장하는 변수
                
private Rigidbody _rigidbody; // Player에 rigidbody를 저장하는 변수
```
                
```csharp
void FixedUpdate()
{
    Move(); // 이동 메서드는 연산이 필요하기 때문에 FixedUpdate에 넣었습니다.
}
                
void LateUpdate()
{
    CameraLook(); // 마지막에 카메라에 delta 값은 마지막에 작동하는 LateUpdate를 사용했습니다.
}
```
                
```csharp
public void OnMove(InputAction.CallbackContext context)
{
    if (context.phase == InputActionPhase.Performed)
    {
        curMovementInput = context.ReadValue<Vector2>();
        // 키보드에 입력되는 값을 읽어서 curMovementInput 변수에 저장합니다.

        // 기존에 키보드 입력 값을 읽어오는 방법은 다음과 같았습니다:

        // float curMoveX = Input.GetAxis("Horizontal"); // 수평 이동 입력을 가져옵니다.
        // float curMoveY = Input.GetAxis("Vertical"); // 수직 이동 입력을 가져옵니다.
        // Vector2 curMovementInput = new Vector2(curMoveX, curMoveY);
        // 변화하는 이동 값을 저장할 Vector2를 만듭니다. 안에는 수평 및 수직 이동 값이 들어갑니다.
        // 하지만 Input 시스템을 사용하면 변수를 따라 선언해서 입력 값을 읽어올 필요가 없이 
        // context.ReadValue<Vector2>();를 이용해 curMovementInput에 저장해 줍니다. 
    }
    else if (context.phase == InputActionPhase.Canceled)
    {
        curMovementInput = Vector2.zero;
    }
}
```
                
```csharp
public void OnLook(InputAction.CallbackContext context)
 {
     mouseDelta = context.ReadValue<Vector2>();
     // 마우스 이동 값을 읽어와 mouseDelta 변수에 저장합니다.

     // 기존에 마우스 이동 값을 읽어오는 방법은 다음과 같았습니다:

     // float curMouseX = Input.GetAxis("Mouse X"); // 마우스의 수평 이동 입력을 가져옵니다.
     // float curMouseY = Input.GetAxis("Mouse Y"); // 마우스의 수직 이동 입력을 가져옵니다.
     // Vector2 mouseDelta = new Vector2(curMouseX, curMouseY);
     // 마우스 델타를 저장할 Vector2를 만듭니다. 안에는 마우스 수평 및 수직 이동 값이 들어갑니다.
     // 프로그래밍에서는 "델타"라는 용어가 변화량을 나타내는 데 사용됩니다. (이전과 현제 값의 차이를 나타낸다.)
     // 하지만 Input 시스템을 사용하면 변수를 따라 선언해서 마우스의 이동 값을 읽어올 필요가 없이 
     // context.ReadValue<Vector2>();를 이용해 mouseDelta에 저장해 줍니다.
 }
```
                
```csharp
void Move()
{
    // 카메라가 바라보는 전방 방향에서 y축(상하)을 제거하여, 평면(지면)에서의 전방 벡터를 구함
    Vector3 lookForward = new Vector3(cameraContainer.forward.x, 0f, cameraContainer.forward.z).normalized;

    // 카메라의 오른쪽 방향에서도 y축을 제거하여, 평면(지면)에서의 오른쪽 벡터를 구함
    Vector3 lookRight = new Vector3(cameraContainer.right.x, 0f, cameraContainer.right.z).normalized;

    // 플레이어 입력 (x, y)에 따라 이동 방향 계산
    // W/S → 전후 이동 (lookForward * y), A/D → 좌우 이동 (lookRight * x)
    Vector3 dir = lookForward * curMovementInput.y + lookRight * curMovementInput.x;
    
    // 방향 벡터가 (0,0,0)이 아닐 때에만 실행 (즉, 입력이 있을 때만 실행)
    if (dir != Vector3.zero)
    {
        // 이동 방향을 바라보는 회전(Quaternion) 생성
        Quaternion targetRotation = Quaternion.LookRotation(dir);

        // 현재 회전에서 목표 회전으로 서서히 회전
        // Slerp → 회전을 부드럽게 처리 (특히 180도 회전 시 부자연스러운 튀는 현상 방지)
        kittyTransform.rotation = Quaternion.Slerp
        (
            kittyTransform.rotation,   // 현재 회전값
            targetRotation,            // 목표 회전값 (이동 방향)
            5f * Time.deltaTime        // 보간 속도 (값이 클수록 빠르게 회전)
        );

        // Rigidbody를 이용하여 실제 이동 처리
        // dir(방향) * moveSpeed(속도) * Time.fixedDeltaTime(물리 프레임 보정)
        _rigidbody.MovePosition(_rigidbody.position + dir * moveSpeed * Time.fixedDeltaTime);
    } 
}
```
                
```csharp
void CameraLook()
{
    // 현재 카메라의 회전값(EulerAngles, 즉 x/y/z 오일러 각도)을 가져옴
    cameraAngle = cameraContainer.rotation.eulerAngles;

    // 마우스 좌우 이동(mouseDelta.x)에 따라 Y축(수평 회전, 좌우 시야 회전) 갱신
    // → lookSensitivity는 마우스 감도
    camCurYRot = cameraAngle.y + mouseDelta.x * lookSensitivity;

    // 마우스 상하 이동(mouseDelta.y)에 따라 X축(상하 회전, 위아래 시야 회전) 갱신
    // → 마우스를 위로 올리면 각도가 감소하도록 - 연산
    camCurXRot = cameraAngle.x - mouseDelta.y * lookSensitivity;

    // X축(상하 회전)을 제한해서, 고개가 너무 꺾이지 않도록 보정
    if (camCurXRot < 180) 
    {
        // 고개를 앞으로 숙이는 각도 → -1° ~ 50° 사이로 제한
        camCurXRot = Mathf.Clamp(camCurXRot, -1f, 50f);
    }
    else 
    {
        // 고개를 뒤로 젖히는 각도 → 335° ~ 359° 사이로 제한
        // (Unity의 EulerAngles는 0~360도로 표현되기 때문에 335~359는 거의 -25° ~ 0° 구간과 동일)
        camCurXRot = Mathf.Clamp(camCurXRot, 335f, 359f);
    }
    
    // 계산된 X, Y 회전을 쿼터니언으로 변환해 카메라 컨테이너에 적용
    // Z축 회전은 고정(0) → 시야가 기울어지지 않도록 함
    cameraContainer.rotation = Quaternion.Euler(camCurXRot, camCurYRot, 0);
}
```
</details>                

## III. 트러블 슈팅 :

<details>
<summary>센서 과연산 문제 :</summary> 
  
1. 문제 정의: 특정 상황에서 게임이 거의 멈춰서 작동이 되지 않는 문제가 발생함
    
2. 사실 수집: 원인을 찾기 위해 해당 퍼즐의 일부 요소를 비활성화하여 문제가 발생하는 부분을 탐색함, 이후 센서와 반사판이 존재 할 때 문제가 발생하는 것을 확인
    
3. 원인 추론: 센서는 센서에 레이저가 감지되면 장애물 오브젝트를 이동시키고 그에 따른 레이저를 다시 계산함 → 그 결과 센서가 감지하던 레이저도 다시 계산하고 감지하면서 무한 루프에 빠지는 것으로 추정

4. 조치: 센서의 작동 방식을 레이저가 한 번이라도 감지되면 활성화 상태를 유지하는 것으로 수정함

5. 결과: 정상적으로 작동되는 것을 확인
  
</details>

<details>
<summary>반사판 스택 오버플로우 :</summary> 
  
1. 문제 정의: 특정 상황에서 스택 오버플로우가 발생
    
2. 사실 수집: 해당 문제는 두 레이저가 서로 반대에서 2개 이상의 같은 반사판에 레이저를 발사하게 되면 발생하는 것을 확인
    
3. 원인 추론: 반사판은 레이저가 감지되면 해당 레이저 정보를 리스트에 등록하고 현재 발사하는 레이저를 모두 지우고 리스트의 레이저 정보를 바탕으로 다시 생성하는 로직임 → 레이저가 한개일 때는 문제가 없으나, 2개가 반대방향으로 발사하면 서로 레이저 정보 등록과 생성을 반복하게 되면서 발생한 것으로 추정
   
4. 조치: 레이저 정보 최대 등록 횟수를 지정
   
5. 결과: 스택 오버플로우가 발생하지 않는 것을 확인
  
</details>

<details>
<summary>레이저 계산 작동 기준 오류 :</summary> 
  
1. 문제 정의: 오브젝트의 위치나 회전을 변경한 이후 레이저가 이전의 정보를 기준으로 계산되는 문제가 발생
    
2. 사실 수집: 브레이크 포인트를 걸었을 때, 회전을 변경하는 부분이 수행되었으나 실제 값은 변하지 않은 것을 확인
    
3. 원인 추론: 레이저의 계산과 실제 트랜스폼의 변환 시점이 달라서 발생한 것으로 추론

4. 조치: Physics.SyncTransforms()을 사용 → 잘 작동하지만 부하가 크다는 말을 듣고 일단 보류, 코루틴을 통해 0.02초 후에 계산하도록 수정

5. 결과: 육안으로 레이저가 사라지는 것이 보이지 않게 잘 작동하는 것을 확인
  
</details>

<details>
<summary>확장성을 고려한 퍼즐 데이터 구조 리팩토링 :</summary> 
  
1. 문제 상황 (The Problem) : 
   - 프로젝트 초기에는 게임 클리어 여부를 관리하기 위해 GameManager에 List<bool> isMainCleared 와 List<bool> isSubCleared를 두고, 각 퍼즐의 인덱스(index)를 이용해 클리어 상태를 저장하는 방식을 사용했습니다.
   - 이 방식은 초기 구현은 간단했지만, 프로젝트 규모가 커지면서 다음과 같은 심각한 문제점들이 예측되었습니다.
   - 불안정성: 기획 변경으로 퍼즐의 순서가 바뀌거나 중간에 새로운 퍼즐이 추가될 경우, 모든 인덱스가 꼬여 데이터가 엉뚱하게 기록될 위험이 매우 컸습니다.
   - 낮은 확장성: 메인/서브 외에 '히든' 퍼즐 같은 새로운 타입이 추가될 때마다 GameManager에 새로운 List<bool>를 추가해야 하는, 비효율적이고 지저분한 구조였습니다.
   - 세이브/로드의 어려움: 나중에 JSON으로 게임 진행 상황을 저장하고 불러와야 할 때, 인덱스 기반의 List 구조는 데이터를 안전하게 관리하고 복원하기에 너무 복잡하고 위험했습니다.
       
2. 해결 과정 (The Solution) : 
   - 이러한 문제들을 근본적으로 해결하기 위해, '순서'에 의존하는 방식에서 벗어나 각 데이터가 '고유한 이름'을 갖는, 보다 견고한 '데이터베이스' 구조로 시스템 전체를 리팩토링했습니다.
   - 고유 ID 부여: 모든 퍼즐 정보가 담긴 MiniGame 스크립터블 오브젝트에, index 대신 절대 중복되지 않는 string GameID (예: "gravity_maze_01")를 부여했습니다. 이는 데이터베이스의 'Primary Key'와 같은 역할을 합니다.
   - Dictionary 기반 데이터베이스 구축: GameManager가 가지고 있던 여러 List<bool>를, PuzzleDataManager라는 전문 관리자를 새로 만들어 그 안의 Dictionary<string, bool> puzzleClearData 하나로 통합했습니다.
   - Dictionary를 사용함으로써, 퍼즐의 클리어 여부를 GameID(Key)를 통해 O(1) 시간 복잡도로 매우 빠르고 안전하게 조회하고 수정할 수 있게 되었습니다.
   - ID 기반 보고 체계 확립: 이제 퍼즐을 클리어하면, PuzzleManager는 PuzzleDataManager에게 index가 아닌 GameID를 전달하여 "ID가 OOO인 퍼즐이 클리어됐다"고 보고합니다. 그럼 PuzzleDataManager는 puzzleClearData[GameID] = true; 와 같이 해당 ID의 값을 수정합니다.
   - 게임 클리어 조건 분리: 전체 게임 클리어 조건은, PuzzleDataManager가 List<MiniGame> mainPuzzleCheck 라는 '필수 클리어 목표' 리스트를 따로 들고 있도록 설계했습니다. 이 리스트에 등록된 모든 퍼즐의 GameID가 데이터베이스에서 true인지 확인하는 방식으로, '전체 데이터 관리'와 '게임 클리어 조건'의 책임을 명확하게 분리했습니다.
     
3. 결과 및 깨달음 (The Outcome) : 
   - List<bool>에서 Dictionary<string, bool>와 string ID를 사용하는 구조로 변경함으로써, 다음과 같은 개선을 이룰 수 있었습니다.
   - 견고함: 퍼즐의 순서나 개수가 변경되어도 데이터가 꼬일 걱정이 없는 안정적인 시스템을 구축했습니다.
   - 확장성: 새로운 종류의 퍼즐이 추가되어도, 기존 코드를 거의 수정할 필요 없이 데이터만 추가하면 되므로 확장성이 크게 향상되었습니다.
   - 유지보수성: 퍼즐 데이터와 관련된 모든 책임이 PuzzleDataManager 한 곳에 모여있어, 코드 추적 및 수정이 매우 용이해졌습니다.
   - 세이브/로드 최적화: Dictionary 구조는 JSON으로 직렬화하기에 매우 이상적인 형태이므로, 추후 세이브/로드 기능을 구현할 때의 복잡성을 크게 줄였습니다.
  
</details>

<details>
<summary>플레이어 점프 불가 현상 :</summary> 
  
1. 문제 현상: Rigidbody가 부착된 움직이는 발판 위에서 플레이어의 점프가 작동하지 않았다. 발판의 Rigidbody를 제거하거나 Is Kinematic을 활성화하면 점프가 되는 기이한 현상이 발생했다.
    
2. 디버깅 과정 (가설 검증) :
    - 처음에는 OnCollisionEnter의 작동 조건이나, Raycast가 Rigidbody가 있는 오브젝트를 통과하는 물리 엔진의 특이사항 등 복잡한 원인을 의심했다.
    - 하지만 발판의 Rigidbody를 제거했을 때 점프가 된다는 점에서, 두 Rigidbody 간의 상호작용에 문제가 있음을 직감했다.
    - Is Kinematic을 켰을 때도 점프가 되는 것을 보고, '힘(Force)' 계산에 영향을 미치는 핵심적인 변수 값에 문제가 있을 것이라는 촉이 발동했다.
    - 근본 원인: 플레이어의 Rigidbody에 설정된 **Mass(질량) 값이 비정상적으로 높은 20으로 설정되어 있었다. ForceMode.Impulse는 질량의 영향을 받기 때문에, Mass가 1인 발판 위에서 점프하려고 할 때 플레이어의 무게 때문에 힘이 거의 상쇄되어 점프가 되지 않았던 것이다.
  
</details>

<details>
<summary>터널링 문제 :</summary> 
  
1. 문제 정의: 연산 속도 보다 빠른 속도로 충돌이 일어날 경우 충돌 감지를 하지 못하는 문제가 발생했습니다. 그로 인해 공이 바닥을 통과하는 현상등이 있었습니다.
    
2. 사실 수집: 공이 통과하는 상황을 찾기 위해 여러 상황을 확인 해 본 결과 속도가 빠를 경우 통과한다는 점을 파악했습니다.
    
3. 원인 추론: RIgidbody interpolate,Collision Detection을 수정 > 통과하는 속도의 최저값이 높아짐 > 하지만 여전히 뚫림현상 존재 > Collider 크기를 키우기 > 정상 작동 하지만 다른 방법이 필요해 보였습니다.

4. 조치: 속도로 공을 쳐내는 것이 아닌 물리 힘을 적용 시켜 공이 스스로 포물선을 그릴 수 있도록 수정 하였습니다

5. 결과: 정상적으로 작동되는 것을 확인 했습니다
  
</details>

<details>
<summary>Rigidbody 충돌 문제 :</summary> 
  
1. 문제 정의: 바닥 로테이션 정렬 도중 자식들의 로테이션 값이 변경 되어 정렬이 제대로 되지 않는 문제가 발생했습니다.
    
2. 사실 수집: 바닥이 이동중에만 자식의 로테이션이 현재 위지로 고정되는 것을 확인 했습니다.
    
3. 원인 추론: 스크립트 내부에서 자식의 로테이션 정보는 전혀 없었기 때문에 외부의 문제라고 판단 > 리지드 바디가 문제인 것이 확인 > 이동중 갑자기 값을 변경 하려 함 > 자식들 끼리 리지드바디 충돌이 일어나는 것으로 추측하였습니다.

4. 조치: 자식들의 리지드 바디를 제거해 주었습니다.

5. 결과: 자식들의 로테이션이 변하는 과정이 사라졌습니다. 정상적으로 작동되는 것을 확인 했습니다.
  
</details>

<details>
<summary>UI애니메이션 이벤트 등록 문제 :</summary> 
  
1. 문제 정의: UI매니저의 메서드를 등록하려 하였지만 각자 UI에는 UI매니저 컴퍼넌트가 존재하지 않아 이벤트 등록이 불가능 했습니다.
    
2. 사실 수집: 현재 메서드가 UI매니저의 역할이 맞는지 확인 > UI매니저의 역할이라 판단 했습니다.
    
3. 원인 추론: UI매니저가 아닌 UI스스로 관리를 한다면 책임분리원칙이 지켜지지 않는다고 판단하였습니다.

4. 조치: 프록시 스크립트를 통해 UI매니저의 메서드를 호출 하고 이벤트에 연결을 시켜줄 스크립트를 작성 하였습니다.

5. 결과: 책임 분리가 가능 하였고 이벤트 등록도 정상적으로 작동되는 것을 확인 했습니다.
  
</details>

<details>
<summary>UI매니저 하위 UI관리시 캐싱 문제 :</summary> 
  
1. 문제 정의: 하위 UI들을 캐싱 하는 과정에서 하나 하나 전부 캐싱 할 경우 확장성 및 휴먼이슈 등이 발생 할 가능성이 너무 높았습니다.
    
2. 사실 수집: 현재와 같이 인스펙터창에서 연결을 하나하나 해 줄 경우 씬이동 혹은 누락등의 문제가 발생 할 수 있음 > 리스트로 관리를 하면 확장성이 좋아 질 것으로 판단 > 리스트의 관리를 딕셔너리를 통해 한다면 더 편하게 사용이 가능 할 것 같았습니다.
    
3. 원인 추론: 현재 전부 하나하나 변수를 정해 캐싱을 하는 과정에서 누락이 발생 할 수 있고 확장성이 좋지 않아졌습니다. 그 과정을 리스트와 딕셔너리를 통해 관리 한다면 더욱 객체지향적인 코드가 될 것 같습니다.

4. 조치:  리스트로 캐싱을 해 준 후 딕셔너리로 리스트를 관리해 주었습니다.

5. 결과: 확장성이 좋아 졌고 관리를 하는것이 훨씬 수월해 졌습니다.
  
</details>

<details>
<summary>Cinemachine 카메라 사용 후 카메라가 이중으로 회전 하는 문제 :</summary> 

1. Cinemachine을 사용해서 카메라가 캐릭터를 따라 가던 도중 장애물이 캐릭터를 가리는 현상을 수정하려했습니다.
    
   <img width="833" height="717" alt="troubleshooting" src="https://github.com/user-attachments/assets/52ab5c9a-fe6b-4e81-8b05-78089b92ee4f" />

2. 그래서 FreeLook Camera를 사용했고 Follow에는 CameraContainer를 LookAt에는 Kitty를 적용하여 장애물에 가려지지 않게 수정을 했지만 캐리터에 이동이 입력된는 키와 상 반대되는 방향으로 간는 버그가 발생 했습니다
  
3. 해결 방법 : Follow에 있던 오브젝트를 None으로하니 문제가 해결됐습니다. 
  
4. 원인 : 카메라의 팔로우는 이미 Move() 메서드에서 구현이 완료됐는데 FreeLook Camera의 Follow 에 CameraContainer을 넣어 rotation을 다시한번 돌리게 해서 이동에 문제가 발생한 거였습니다.
  
</details>

  

## IV. 클래스 다이어그램 :

 <details>
 <summary>펼쳐보기</summary> 
  
  <img width="674" height="611" alt="image 6" src="https://github.com/user-attachments/assets/82df2de1-96c9-4e2d-b35a-ea1c79d79988" />

 </details>

## V. 와이어 프래임:

 <details>
 <summary>펼쳐보기</summary> 
  
  ```csharp
 [게임 시작]
   │
   ▼
[메인 월드]
   │
   ├─▶ [빨간 공 상호작용] → [퍼즐 시작] → [성공: 박스 획득] 
   │                                   └─ [실패: 재도전]
   │
   ├─▶ [박스 사용 → 높은 곳 이동]
   │
   └─▶ [메인 퍼즐 #1] 
   └─▶ [메인 퍼즐 #2] 
   └─▶ [메인 퍼즐 #3]
           │
           ▼
    [3개 클리어 완료]
           │
           ▼
       [엔딩 화면]
  ```

 </details>

## VI. 최종 게임 시현 영상 :

## 감사합니다!

