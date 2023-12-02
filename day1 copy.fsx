open System
open System.Text.RegularExpressions
let replacements = dict [("one", 1);("two", 2);("three", 3);("four", 4);("five", 5);("six", 6);("seven", 7);("eight", 8);("nine", 9); ("1", 1);("2", 2);("3", 3);("4", 4);("5", 5);("6", 6);("7", 7);("8", 8);("9", 9)]
let pattern =  @"(one|two|three|four|five|six|seven|eight|nine|1|2|3|4|5|6|7|8|9)";
let input =
    System.IO.File.ReadAllLines "inputs/day1"
        |> Array.map (fun l -> Regex.Matches(l, pattern) |> Seq.toArray)
        |> Array.map (fun d -> $"{replacements[(Array.head d).Value]}{replacements[(Array.last d).Value]}" |> int)

let answer2 = input |> Array.sum
printfn "%A" answer2
