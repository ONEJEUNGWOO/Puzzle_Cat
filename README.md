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

### 특징:

1. 주변의 **다양한 오브젝트와 상호작용**하여 새로운 퍼즐에 진입하세요.
2. 퍼즐을 클리어하면 **서로 다른 크기의 박스**를 보상으로 획득할 수 있습니다.
3. 얻은 박스를 활용해 밀고 **더 높은 위치**로 올라가 새로운 퍼즐에 도전하세요.
4. 퍼즐은 각각 색다른 방식으로 진행됩니다.
    - 긴장감 넘치는 **공 굴리기**
    - 머리를 쓰는 **레이저 게임**
    - 직관력을 시험하는 **아이템 이미지 클릭하기**
5. 최종적으로, 집 안에 숨겨진 **세 개의 메인 퍼즐 진입 포인트(고양이 발 모양 코인)** 를 모두 모아, 집사가 돌아올 때 당당히 맞이하세요!
##

**참고 이미지 :**
    
<img width="400" height="250" alt="Interaction" src="https://github.com/user-attachments/assets/7a3e9fad-21cb-4778-b640-e66ad41cfaa8" />

상호작용 시 UI 출력
    
![Wall](https://github.com/user-attachments/assets/163b25d1-fab3-4f46-99e5-7df1b2aa8b97)

Cinemachine을 활용한 장애물 충돌 기능
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
  
1. **퍼즐 디자인** (난이도: ★★★☆☆) ✅
   - 다양한 퍼즐을 게임에 디자인하고 구현하여 게임의 핵심 플레이를 제공합니다.
   - 퍼즐의 난이도와 다양성을 고려하여 설계합니다.

</details>

## II. 게임 핵심 기능 구현 설명 :

<details>
<summary>플레이어 이동 과 팔로잉 카메라 구현 :</summary> 
  
1. 123
    
2. 123
    
3. 123
  
</details>

<details>
<summary>플레이어 이동 과 팔로잉 카메라 구현 :</summary> 
  
1. 123
    
2. 123
    
3. 123
  
</details>

<details>
<summary>플레이어 이동 과 팔로잉 카메라 구현 :</summary> 
  
1. 123
    
2. 123
    
3. 123
  
</details>

<details>
<summary>플레이어 이동 과 팔로잉 카메라 구현 :</summary> 
  
1. 123
    
2. 123
    
3. 123
  
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
<summary>플레이어 이동 과 팔로잉 카메라 구현 :</summary> 
  
1. 123
    
2. 123
    
3. 123
  
</details>

<details>
<summary>플레이어 이동 과 팔로잉 카메라 구현 :</summary> 
  
1. 123
    
2. 123
    
3. 123
  
</details>

<details>
<summary>플레이어 이동 과 팔로잉 카메라 구현 :</summary> 
  
1. 123
    
2. 123
    
3. 123
  
</details>

<details>
<summary>플레이어 이동 과 팔로잉 카메라 구현 :</summary> 
  
1. 123
    
2. 123
    
3. 123
  
</details>

<details>
<summary>플레이어 이동 과 팔로잉 카메라 구현 :</summary> 
  
1. 123
    
2. 123
    
3. 123
  
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

<img width="674" height="611" alt="image 6" src="https://github.com/user-attachments/assets/82df2de1-96c9-4e2d-b35a-ea1c79d79988" />


## V. 와이어 프래임:

## VI. 최종 게임 시현 영상 :

## 감사합니다!

