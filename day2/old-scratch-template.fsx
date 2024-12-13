// HOUSEKEEPING/COMMON
let linesExample = System.IO.File.ReadLines("day2/example.txt")   |> Seq.toList|> List.map(fun x->x.Split(' ')|>Seq.map(fun x->int x) |>Seq.toList);;
let linesProblem1 = System.IO.File.ReadLines("day2/problem1.txt")   |> Seq.toList|> List.map(fun x->x.Split(' ')|>Seq.map(fun x->int x) |>Seq.toList);;
// let linesProblem2 = System.IO.File.ReadLines("dayX\\\1/problem2.txt")   |> Seq.toList;;

let isAscending (lis:list<int>) = (lis |> List.sort)=(lis)
let isDescending (lis:list<int>) = (lis |> List.sortDescending)=(lis)

let jumpInterval lis = lis |> List.windowed 2 |> List.map(fun (x:int list)->System.Math.Abs(x.[0]-x.[1]))
let jumpsNotTooBig lis = (jumpInterval lis) |> List.max <4
let jumpsNotTooSmall lis = (jumpInterval lis) |> List.min >0
let jumpsOkay lis = jumpsNotTooBig lis && jumpsNotTooSmall lis


let logicCompiled lis = lis |> List.map(fun (x:list<int>)->(jumpsOkay x, isAscending x, isDescending x));;
let isSafe (a:bool,b:bool,c:bool):bool = (a && (b || c))
//
// logicCompiled linesProblem1 |> List.map(fun x->isSafe x) |> List.filter(fun x->x=true)|>List.length;;

// Lesson was to break up any kind of branching logic into separate pieces and test


// PART 2

