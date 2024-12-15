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

let foo a b = a*b
// PART 2

// There are two new situations
// 1. Ascending/Descending not okay, but removing first mismatch fixes
// 2. Gap too big but removing first one also fixes

let allMismatches list1 list2 =
  let temp = List.zip list1 list2 
  List.fold (fun acc  x->
    if fst x <> snd x then List.append ([fst x]) acc else acc
    ) [] temp
let allMatches list1 list2 =
  let temp = List.zip list1 list2 
  List.fold (fun acc  x->
    if fst x = snd x then List.append ([fst x]) acc else acc
    ) [] temp
let countMatches list1 list2 =
  let temp = List.zip list1 list2 
  let ret =
    List.fold (fun acc  x->
      if fst x = snd x 
        then (List.append ([fst x]) (fst acc), (snd acc)+1)
        else acc
      ) ([],0) temp
  snd ret 

let getUntilMatchFailsN n list1 list2 =
  let temp = List.zip list1 list2 
  let ret =
    List.fold (fun acc  x->
      if fst x <> snd x 
        then 
          if snd acc >0 
            then
              (List.append ([fst x]) (fst acc), (snd acc)-1)
            else acc
        else acc
      ) ([],n) temp
  fst ret 
  
let getUntilMatchFailsX n (list1:int list) (list2:int list):int list =
  let temp = List.zip list1 list2 
  let ret =
    List.fold (fun acc  (x:int*int)->
      if snd acc > 0
        then 
          if fst x <> snd x 
          then
            let newList=List.append [(fst x)] (fst acc)
            (newList,snd acc-1) 
          else 
            (fst acc,snd acc)
        else
            let newList=List.append [(fst x)] (fst acc)
            (newList,snd acc-1) 
        ) (List.empty,n) temp
  fst ret 

