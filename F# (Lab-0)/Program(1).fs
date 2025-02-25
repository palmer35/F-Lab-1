open System

// Функция для проверки, является ли число нечетным
let isOdd number = number % 2 <> 0

// Функция для ввода чисел и формирования списка
let rec inputNumbers () =
    printf "Введите число (или 'q' для выхода): "
    let input = Console.ReadLine()
    if input = "q" then
        []
    else
        match Int32.TryParse input with
        | true, number ->
            let result = isOdd number
            result :: inputNumbers() 
        | false, _ ->
            printfn "Некорректный ввод. Пожалуйста, введите целое число."
            inputNumbers()

// Основная программа
let main () =
    printfn "Программа для формирования списка true/false на основе четности чисел."
    let resultList = inputNumbers()
    printfn "Результат: %A" (resultList) 

// Запуск программы
main()

