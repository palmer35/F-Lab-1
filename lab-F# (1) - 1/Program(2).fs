open System

// Функция для формирования списка цифр числа
let getDigitsList (number: int) : int list =
    number.ToString()
    |> Seq.map (fun c -> int (c.ToString()))
    |> Seq.toList

// Функция для ввода чисел и формирования списка цифр
let rec inputNumbers () =
    printf "Введите число (или 'q' для выхода): "
    let input = Console.ReadLine()
    if input = "q" then
        []
    else
        match Int32.TryParse input with
        | true, number ->
            let digitsList = getDigitsList number
            digitsList @ inputNumbers() // Добавляем цифры числа в список
        | false, _ ->
            printfn "Некорректный ввод. Пожалуйста, введите целое число."
            inputNumbers()

// Основная программа
let main () =
    printfn "Программа для формирования списка цифр введенных чисел."
    let resultList = inputNumbers()
    printfn "Результат: %A" resultList 

// Запуск программы
main()
