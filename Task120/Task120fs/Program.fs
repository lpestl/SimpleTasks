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

    member x.Position = directionIntelligence.position

    member x.Direction = directionIntelligence.direction

    member x.CheckNeighbor (dir: Direction) : NeighborStatus =
        let mutable whoIsNeighbor = NeighborStatus.NotExplored
        if ((dir = N && x.Position.y = 0u) || 
            (dir = S && x.Position.y = uint32(warArea.GetLength(1)) - 1u) ||
            (dir = E && x.Position.x = uint32(warArea.GetLength(0)) - 1u) ||
            (dir = W && x.Position.x = 0u)) then
            whoIsNeighbor <- NeighborStatus.Perimeter
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
        map.Add(IntelligenceKey(x.Position, dir), whoIsNeighbor)
        whoIsNeighbor   

    member x.NextStep : OperationStatus = 
        let mutable dir = directionIntelligence.direction
        let mutable lastDir = directionIntelligence.direction
        while not (x.CheckNeighbor(dir) = Our) && not (map.ContainsKey(IntelligenceKey(x.Position, dir))) do
            lastDir <- dir
            match dir with
            | N -> dir <- E
            | E -> dir <- S
            | S -> dir <- W
            | W -> dir <- N
        
        if map.ContainsKey(IntelligenceKey(x.Position, dir)) then
            status <- OperationStatus.MissionComplete
        else 
            if lastDir = dir then
                match dir with
                | N -> lastDir <- W
                | E -> lastDir <- N
                | S -> lastDir <- E
                | W -> lastDir <- S
            directionIntelligence.direction <- lastDir
            match dir with
            | N -> directionIntelligence.position.y <- directionIntelligence.position.y - 1u
            | E -> directionIntelligence.position.x <- directionIntelligence.position.x + 1u
            | S -> directionIntelligence.position.y <- directionIntelligence.position.y + 1u
            | W -> directionIntelligence.position.x <- directionIntelligence.position.x - 1u
        status
        

let rec GetFrontLine (area : _[,]) : FrontLine =
    let result = { FrontLine = 0u; PerimeterR = 0u; PerimeterF = 0u; }

    if (area.GetLength(0) <> 0) then
        if (area.GetLength(1) <> 0) then
            let a = 5
            printf "%A" a
            //let map = new Dictionary<IntelligenceKey, NeighborStatus>()
            //let mutable directionIntelligence = IntelligenceKey(currentPosition, Direction.N)
            //while (not map.ContainsKey(directionIntelligence)) do
            //    let a = 6
            //    printf "%A" a

    result

[<EntryPoint>]
let main argv = 
    let key1 = new IntelligenceKey(new Position(1u, 2u), Direction.N)
    let key2 = IntelligenceKey(Position(1u, 2u), Direction.N)

    if (key1 = key2) then
        printf "Victory!!!\n"
    else 
        printf "Fail ((\n"

    let mutable key3 = IntelligenceKey(Position(0u, 2u), Direction.N)
    key3.position.x <- 1u
    if (key1 = key3) then
        printf "Victory!!!\n"
    else 
        printf "Fail ((\n"

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
