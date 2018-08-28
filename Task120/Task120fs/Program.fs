open System.Collections.Generic // СОВЕРШЕННО СИКРЕТНО
// Служебно-боевая задача: РАЗВЕДАТЬ длину линии фронта, периметр наших, периметр фашистов
type FrontLine = { FrontLine: uint32; PerimeterR: uint32; PerimeterF: uint32 }
// Докладывать по средствам связи о прилегающей территории будете следующим образом:
type NeighborStatus =
    | NotExplored   // Территория не разведана; 
    | Perimeter     // Выход из зоны боевых действий, или попросту периметер;
    | ContactLine   // Зона контакта с врагом;
    | Our           // На соседней территории НАШИ.
// Возможные направления для передвижения:
type Direction = | N | E | S | W // Север, Восток, Юг, Запад
// О состоянии миссии докладывать:
type OperationStatus = | InProcess | MissionComplete // В процессе или Миссия Завершена
// О своем положении сообщать в общепринятых координатах
type Position = 
    struct
        val mutable x: uint32
        val mutable y: uint32
        new (_x: uint32, _y: uint32) = { x = _x; y = _y }
    end
// Историю своего передвижения записывать
type IntelligenceKey = // маркеруя с помощью
    struct
        val mutable position: Position      // координат и
        val mutable direction: Direction    // направления движения
        new (pos: Position, dir: Direction) = { position = pos; direction = dir }
    end

// Задача назначается группе военной разведки. 
type MilitaryIntelligence (landingPoint: Position,  // Назначим вам точку дисантирования
                           area: _[,]) =            // в зоне боевых действий
    let map = new Dictionary<IntelligenceKey, NeighborStatus>()                     // С собой ввзять дневник для записи ваших перемещений
    let mutable directionIntelligence = IntelligenceKey(landingPoint, Direction.N)  // и маячек, который будет показывать ваше текущенее положение и направление разведки.
    let warArea = area                                                              // Зона боевых действий обозначена на карте.
    let mutable status = OperationStatus.InProcess                                  // О статусе операции не заывайте докладывать
    let mutable perimeter = 0u  // И вести подсчет периметра территории
    let mutable front = 0u      // и линии фронта

    // По текущему каналу связи будем периодически запрашивать ваши координаты и
    member x.Position = directionIntelligence.position
    // направление движения.
    member x.Direction = directionIntelligence.direction

    // Чтобы проверить прилегающую территорию в конкретном направлении
    member x.CheckNeighbor (dir: Direction) : NeighborStatus =
        let mutable whoIsNeighbor = NeighborStatus.NotExplored
        // Для начала проверте не на границе ли вы и не на выход за территорию ли вы двигаетесь
        if ((dir = N && x.Position.y = 0u) || 
            (dir = S && x.Position.y = uint32(warArea.GetLength(1)) - 1u) ||
            (dir = E && x.Position.x = uint32(warArea.GetLength(0)) - 1u) ||
            (dir = W && x.Position.x = 0u)) then
            // если это так, то не забудте посчитать периметр
            whoIsNeighbor <- NeighborStatus.Perimeter
            perimeter <- perimeter + 1u
        else  // в противном случае
            let mutable lookCell = x.Position
            // наметьте исследуемую, прилегающую территорию
            match dir with
            | N -> lookCell.y <- lookCell.y - 1u
            | S -> lookCell.y <- lookCell.y + 1u
            | E -> lookCell.x <- lookCell.x + 1u
            | W -> lookCell.x <- lookCell.x - 1u
            // и отправьте бойца, чтобы он проверил
            if warArea.[int(lookCell.x), int(lookCell.y)] = warArea.[int(x.Position.x), int(x.Position.y)] then
                whoIsNeighbor <- NeighborStatus.Our         // свои ли там
            else 
                whoIsNeighbor <- NeighborStatus.ContactLine // или там враги
                front <- front + 1u                         // и вы находитесь на линии фронта.
        map.Add(IntelligenceKey(x.Position, dir), whoIsNeighbor)
        whoIsNeighbor   // Не забывайте передачу данных в эфире
            
    // Для успешного завершения операции - двигайтесь по шагам
    member x.NextStep : OperationStatus = 
        // Если вы уже проверяли этот квадрат и направление, то вы вернульсь в изначальную точку
        if map.ContainsKey(directionIntelligence) then
            status <- OperationStatus.MissionComplete   // а значит получили достаточно данных для выполнения задачи.
        else // Если же еще нет, то
            if x.CheckNeighbor directionIntelligence.direction <> Our then // Проверьте соседнюю территорию. Если там не НАШИ,
                // То меняйте напрвыление разведки на 90 градусов по часовой.
                match directionIntelligence.direction with
                | N -> directionIntelligence.direction <- E
                | E -> directionIntelligence.direction <- S
                | S -> directionIntelligence.direction <- W
                | W -> directionIntelligence.direction <- N
            else 
                // Если там НАШИ, то передвигайтесь в направлении своих и меняйте направление разведки на 90 градусов против часовой
                match directionIntelligence.direction with
                | N -> directionIntelligence.direction <- W
                       directionIntelligence.position.y <- directionIntelligence.position.y - 1u
                | E -> directionIntelligence.direction <- N
                       directionIntelligence.position.x <- directionIntelligence.position.x + 1u
                | S -> directionIntelligence.direction <- E
                       directionIntelligence.position.y <- directionIntelligence.position.y + 1u
                | W -> directionIntelligence.direction <- S
                       directionIntelligence.position.x <- directionIntelligence.position.x - 1u
        status // и сообщите о статусе миссии по радио
    
    // Когда миссия завершена, то мы можем получить достоверные данные
    member x.GetFrontInfo : FrontLine =        
        match warArea.[int(x.Position.x),int(x.Position.y)] with
        | 'R' -> { FrontLine = front; // Если мы передвигались по территории НАШИХ, то получаем все значения для отчета.
                   PerimeterR = perimeter + front; 
                   PerimeterF = uint32(warArea.GetLength(0)) * 2u + uint32(warArea.GetLength(1)) * 2u  - perimeter + front }
        | 'F' -> { FrontLine = front; // Если же по территории врага, то аналогичным образом вычисляем значения.
                   PerimeterF = perimeter + front; 
                   PerimeterR = uint32(warArea.GetLength(0)) * 2u + uint32(warArea.GetLength(1)) * 2u  - perimeter + front }

// А между тем, развед группа уже получила вводные
let rec GetFrontLine (area : _[,]) : FrontLine =
    // и была дисантирована в точке 0, 0...
    let MI = MilitaryIntelligence(Position(0u,0u), area)
    let mutable countSteps = 0              // Передвигаясь последовательно,
    while MI.NextStep <> MissionComplete do // до победного,
        countSteps <- countSteps + 1        // шаг за шагом...
    MI.GetFrontInfo                         // были получены все необходимые сведенья.

[<EntryPoint>]
let main argv = 
    let area01 = array2D [ ['R';'R'];
                           ['R';'F'] ]
    // Answer Should Be FrontLine = 2; PerimeterR = 8; PerimeterF = 4
    let answer01 = GetFrontLine area01
    printf "FrontLine = %A; PerimeterR = %A; PerimeterF = %A;\n" answer01.FrontLine answer01.PerimeterR answer01.PerimeterF

    let area02 = array2D [ ['R';'R';'R';'R';'R';'R'];
                           ['R';'R';'F';'F';'R';'R'];
                           ['F';'R';'R';'F';'F';'R'];
                           ['F';'F';'F';'F';'R';'R'] ]
    // Answer Should Be FrontLine = 14; PerimeterR = 28; PerimeterF = 20
    let answer02 = GetFrontLine area02
    printf "FrontLine = %A; PerimeterR = %A; PerimeterF = %A;\n" answer02.FrontLine answer02.PerimeterR answer02.PerimeterF
    
    let area03 = array2D [ ['R';'R';'R';'R'];
                           ['R';'F';'F';'R'];
                           ['R';'R';'R';'R'] ]
    // Answer Should Be FrontLine = 6; PerimeterR = 20; PerimeterF = 6
    let answer03 = GetFrontLine area03
    printf "FrontLine = %A; PerimeterR = %A; PerimeterF = %A;\n" answer03.FrontLine answer03.PerimeterR answer03.PerimeterF

    0 // return an integer exit code
