type FrontLine = { FrontLine: uint32; PerimeterR: uint32; PerimeterF: uint32 }
let GetFrontLine (area : _[,]) : FrontLine =
    let result = { FrontLine = 0u; PerimeterR = 0u; PerimeterF = 0u; }
    result

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
