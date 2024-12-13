// HOUSEKEEPING/COMMON
let linesExample = System.IO.File.ReadLines("day2/example.txt")   |> Seq.toList  |> Seq.map(fun x->x.Split(' ')|>Seq.map(fun x->int x)  |> Seq.toList);;
let linesProblem1 = System.IO.File.ReadLines("day2/problem1.txt")   |> Seq.toList  |> Seq.map(fun x->x.Split(' ')|>Seq.map(fun x->int x) |> Seq.toList);;
// let linesProblem2 = System.IO.File.ReadLines("dayX\\\1/problem2.txt")   |> Seq.toList;;

let isAscending lis = (lis |> List.sort)=(lis)
let isDescending lis = (lis |> List.sortDescending)=(lis)

let jumpInterval lis = lis |> List.windowed 2 |> List.map(fun (x:int list)->System.Math.Abs(x.[0]-x.[1]))
let isJumpsTooBig lis = (jumpInterval lis) |> List.max > 2

// let splitBy f input =
//   let i = ref 0d
//   input
//   |> Seq.groupBy (fun x ->
//     //if f x then incr i
//     if f x then (i.Value<-i.Value+1)
//     i.Value)
//   |> Seq.map snd

// let stringListToCharArray (lines:string list)=lines|>List.filter(fun x->x.Length>0)|>List.map(fun x->x.ToCharArray()|>List.ofArray)|>array2D;
// let getNeighbor<'a> (arr:'a [,]) x y :'a option  =
//   try Some arr[x,y] with _->None
// let getNeighborAndCoordinate<'a> (arr:'a [,]) x y :('a*(int*int)) option  =
//   try Some (arr[x,y],(x,y)) with _->None
// let getNeighbors<'a> (myWorld:'a [,]) (myPoint:int*int) (neighborsToGet:(int*int) list):'a list =
//   let rootX,rootY = myPoint
//   neighborsToGet|>List.map(fun x->
//     let newX = rootX + fst x
//     let newY = rootY + snd x
//     getNeighbor<'a> myWorld newX  newY
//   ) |>List.choose id
// let getNeighborsAndCoordinates<'a> (myWorld:'a [,]) (myPoint:int*int) (neighborsToGet:(int*int) list):('a*(int*int)) list =
//   let rootX,rootY = myPoint
//   neighborsToGet|>List.map(fun x->
//     let newX = rootX + fst x
//     let newY = rootY + snd x
//     getNeighborAndCoordinate<'a> myWorld newX  newY
//   ) |>List.choose id


// let lookLeft (arr:'a [,]) x y = arr[0..x-1,y]
// let lookRight (arr:'a [,]) x y = arr[x+1..,y]
// let LookUp (arr:'a [,]) x y = arr[x,0..y-1]
// let LookDown (arr:'a [,]) x y = arr[x,y+1..]

// let getPointsSurroundingAPoint<'a> (myWorld:'a [,]) (myPoint:int*int) =
//   getNeighbors<'a> myWorld myPoint [(-1,-1);(-1,0);(-1,1);(0,-1);(0,1);(1,-1);(0,1);(1,1)]
// let getPointsAndCoordinatesSurroundingAPoint<'a> (myWorld:'a [,]) (myPoint:int*int) =
//   getNeighborsAndCoordinates<'a> myWorld myPoint [(-1,-1);(-1,0);(-1,1);(0,-1);(0,1);(1,-1);(0,1);(1,1)]
// let getRowColumnPointsAndCoordinatesSurroundingAPoint<'a> (myWorld:'a [,]) (myPoint:int*int) =
//   getNeighborsAndCoordinates<'a> myWorld myPoint [(-1,0);(0,-1);(0,1);(1,0)]


// let find2D needle (arr: 'a [,]) = 
//   let rec go x y =
//         if   y >= arr.GetLength 1 then None
//         elif x >= arr.GetLength 0 then go 0 (y+1)
//         elif arr.[x,y] = needle   then Some (x,y)
//         else go (x+1) y
//   go 0 0


// let linesExample = System.IO.File.ReadLines("day1/example.txt")   |> Seq.toList;;
// let getDigits = linesExample |> Seq.map(fun x->x.ToCharArray() |> Seq.filter(fun x->System.Char.IsAsciiDigit x));;let moo=getDigits|>Seq.map(fun x->(Seq.head x,Seq.last x)) |> Seq.toList;;
// let moo=getDigits|>Seq.map(fun x->((Seq.head x),(Seq.last x))) |> Seq.toList |> List.map(fun (x,y)-> string x + string y) |>List.map(fun x-> int x);;
// //let cow=moo|> Seq.map(fun (x,y)->string x + string y)


// let linesProb1 = System.IO.File.ReadLines("day1/problem1.txt")   |> Seq.toList;;
// let getDigits1 = linesProb1 |> Seq.map(fun x->x.ToCharArray() |> Seq.filter(fun x->System.Char.IsAsciiDigit x));;let moo=getDigits|>Seq.map(fun x->(Seq.head x,Seq.last x)) |> Seq.toList;;
// let moo1=getDigits1|>Seq.map(fun x->((Seq.head x),(Seq.last x))) |> Seq.toList |> List.map(fun (x,y)-> string x + string y) |>List.map(fun x-> int x);;


// let linesProb2 = System.IO.File.ReadLines("day1/problem2.txt")   |> Seq.toList;;

// let parseLine (lineToPrase:string) = 
//   let rec getNextToken (stringLocation:int) (parsedTokens:string list) =
//     if stringLocation>lineToPrase.Length-1
//       then
//         parsedTokens
//       else 
//         match lineToPrase.Substring(stringLocation,1) 
//           with 
//           |a when a="0" || a="1" || a="2" || a="3" || a="4" || a="5" || a="6" || a="7" || a="8" || a="9"
//             -> 
//                 let newList = [a] |> List.append parsedTokens
//                 getNextToken (stringLocation+1) newList
//           |a when a<>"o" && a<>"t" && a<>"f" && a<>"s" && a<>"e" && a<>"n" && a<>"z"
//             ->
//                 let newList = [a] |> List.append parsedTokens
//                 getNextToken (stringLocation+1) newList
//             |_->

//               let a=lineToPrase.Substring(stringLocation,1)
//               let newList = [a] |> List.append parsedTokens
//               getNextToken (stringLocation+1) newList

//   getNextToken 0 []

// // let wordToNum (s:string) = 
// //   s.Replace("one","1").Replace("two","2").Replace("three","3")

// // let repNum (s:string) (sFrom:string) (sTo:string) (startIndex:int)=
// //   if s.Length < sFrom.Length + startIndex
// //     then s
// //     else  
// //       if s.Substring(startIndex,sFrom.Length) = sFrom 
// //         then s.Substring(0,startIndex) + "" + sTo +  "" + s.Substring(sFrom.Length + startIndex) else s

// // let txtNum (s:string) (position:int) =
// //  let do1 = repNum s "one" "1" position
// //  let do2 = repNum do1 "two" "2" position
// //  let do3 = repNum do2 "three" "3" position
// //  let do4 = repNum do3 "four" "4" position
// //  let do5 = repNum do4 "five" "5" position
// //  let do6 = repNum do5 "six" "6" position
// //  let do7 = repNum do6 "seven" "7" position
// //  let do8 = repNum do7 "eight" "8" position
// //  let do9 = repNum do8 "nine" "9" position
// //  let do0 = repNum do9 "zero" "0" position
// //  do0

// // let HasATextNumber (s:string) =
// //   s.Contains("one")
// //   || s.Contains("two")
// //   || s.Contains("three")
// //   || s.Contains("four")
// //   || s.Contains("five")
// //   || s.Contains("six")
// //   || s.Contains("seven")
// //   || s.Contains("eight")
// //   || s.Contains("nine")
// //   || s.Contains("ten")

// // let dN (x:string) =
// //   let ln = x.Length
// //   [0..ln] |> List.fold(fun acc x->txtNum acc x) x



// //    if stringListToCharArray
//   // |> List.map(fun y->
//   //   y |> List.fold(
//   //       fun (stringLoc, parsedTokens) x->
//   //       if stringLoc>=x.Length-1 
//   //         then (stringLoc,parsedTokens)
//   //         else
//   //           match x.Substring(stringLoc,1) 
//   //             with 
//   //             |a when a="0" || a="1" || a="2" || a="3" || a="4" || a="5" || a="6" || a="7" || a="8" || a="9"
//   //               -> 
//   //                 let newList = ([a] |> List.append parsedTokens)
//   //                 (stringLoc+1,newList)
//   //             |_->(9,["oink"])
//   //   ) (0,[])
