open System
let replacements = [|("one", "o1ne");("two", "tw2o");("three", "t3hree");("four", "fo4ur");("five", "fi5ve");("six", "s6ix");("seven", "se7ven");("eight", "eig8ht");("nine", "ni9ne");|]

System.IO.File.ReadAllLines "inputs/day1"
    |> Array.map (fun l -> replacements |> Array.fold (fun (acc: string) (k, v) -> acc.Replace(k, v)) l)
    |> Array.map (Seq.toArray >> Array.filter (Char.IsDigit) >> fun l -> int $"{Array.head l}{Array.last l}")
    |> Array.sum |> printfn "%A"
