open System.Net.NetworkInformation

open System.Collections.Generic

type FrontLine = 
    { 
        FrontLine: uint32 
        PerimeterR: uint32 
        PerimeterF: uint32 
    }

type NeighborStatus =
    | NotExplored
    | Perimeter
    | ContactLine
    | Our

type Direction = | N | E | S | W

type OperationStatus = | InProcess | MissionComplete

type Position = 
    struct
        val mutable x: uint32
        val mutable y: uint32
        new (_x: uint32, _y: uint32) = { x = _x; y = _y }
    end

type IntelligenceKey =
    struct
        val mutable position: Position
        val mutable direction: Direction
        new (pos: Position, dir: Direction) = { position = pos; direction = dir }
    end

type MilitaryIntelligence (landingPoint: Position,
                           area: _[,]) =
    let map = new Dictionary<IntelligenceKey, NeighborStatus>()
    let mutable directionIntelligence = IntelligenceKey(landingPoint, Direction.N)
    let warArea = area
    let mutable status = OperationStatus.InProcess
    let mutable perimeter = 0u
    let mutable front = 0u

    member x.Position = directionIntelligence.position

    member x.Direction = directionIntelligence.direction

    member x.CheckNeighbor (dir: Direction) : NeighborStatus =
        let mutable whoIsNeighbor = NeighborStatus.NotExplored
        if ((dir = N && x.Position.y = 0u) || 
            (dir = S && x.Position.y = uint32(warArea.GetLength(1)) - 1u) ||
            (dir = E && x.Position.x = uint32(warArea.GetLength(0)) - 1u) ||
            (dir = W && x.Position.x = 0u)) then
            whoIsNeighbor <- NeighborStatus.Perimeter
            perimeter <- perimeter + 1u
        else 
            let mutable lookCell = x.Position
            match dir with
            | N -> lookCell.y <- lookCell.y - 1u
            | S -> lookCell.y <- lookCell.y + 1u
            | E -> lookCell.x <- lookCell.x + 1u
            | W -> lookCell.x <- lookCell.x - 1u

            if warArea.[int(lookCell.x), int(lookCell.y)] = warArea.[int(x.Position.x), int(x.Position.y)] then
                whoIsNeighbor <- NeighborStatus.Our
            else 
                whoIsNeighbor <- NeighborStatus.ContactLine
                front <- front + 1u
        map.Add(IntelligenceKey(x.Position, dir), whoIsNeighbor)
        whoIsNeighbor   
            
    member x.NextStep : OperationStatus = 
        if map.ContainsKey(directionIntelligence) then
            status <- OperationStatus.MissionComplete
        else 
            if x.CheckNeighbor directionIntelligence.direction <> Our then
                match directionIntelligence.direction with
                | N -> directionIntelligence.direction <- E
                | E -> directionIntelligence.direction <- S
                | S -> directionIntelligence.direction <- W
                | W -> directionIntelligence.direction <- N
            else 
                match directionIntelligence.direction with
                | N -> directionIntelligence.direction <- W
                       directionIntelligence.position.y <- directionIntelligence.position.y - 1u
                | E -> directionIntelligence.direction <- N
                       directionIntelligence.position.x <- directionIntelligence.position.x + 1u
                | S -> directionIntelligence.direction <- E
                       directionIntelligence.position.y <- directionIntelligence.position.y + 1u
                | W -> directionIntelligence.direction <- S
                       directionIntelligence.position.x <- directionIntelligence.position.x - 1u
        status
    
    member x.GetFrontInfo : FrontLine =        
        match warArea.[int(x.Position.x),int(x.Position.y)] with
        | 'R' -> { FrontLine = front; 
                   PerimeterR = perimeter + front; 
                   PerimeterF = uint32(warArea.GetLength(0)) * 2u + uint32(warArea.GetLength(1)) * 2u  - perimeter + front }
        | 'F' -> { FrontLine = front; 
                   PerimeterF = perimeter + front; 
                   PerimeterR = uint32(warArea.GetLength(0)) * 2u + uint32(warArea.GetLength(1)) * 2u  - perimeter + front }


let rec GetFrontLine (area : _[,]) : FrontLine =
    let MI = MilitaryIntelligence(Position(0u,0u), area)
    let mutable countSteps = 0
    while MI.NextStep <> MissionComplete do
        countSteps <- countSteps + 1
    MI.GetFrontInfo

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
