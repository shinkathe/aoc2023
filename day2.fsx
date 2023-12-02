open System

let split (separator: string) (s: string) = s.Split separator
let max = Map [("red", 12); ("green", 13); ("blue", 14)];
let validateSet (acc:  Map<string,int>) (number: int, color: string) =
    Map.add color (acc[color] - number) acc

let data =
    System.IO.File.ReadAllLines "inputs/day2"
        |> Array.map (split ": " >> Array.last >> split "; " >> Array.map(split ", " >> Array.map(split " ") >> Array.map(fun ([|a; b|]) -> (int a, b))))

let part1 =
    data
        |> Array.map (Array.map(Array.fold validateSet max >> Map.toArray)) |> Array.indexed
        |> Array.filter(snd >> Array.forall(Array.forall (fun (_, v2) -> v2 >= 0)))
        |> Array.sumBy(fst >> (+) 1)

let part2 =
    data
    |> Array.map(
        Array.concat
        >> Array.sortByDescending(fst)
        >> fun a -> [|"red"; "green"; "blue"|] |> Array.map (fun (c) -> Array.find (snd >> (=) c) a |> fst) |> Array.reduce ((*)))
    |> Array.sum


printfn "Part1: %A" part1
printfn "Part2: %A" (part2 )
