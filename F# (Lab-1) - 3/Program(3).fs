open System

// Функции сложения
let add (a: float * float) (b: float * float) : float * float =
    let (aReal, aImag) = a
    let (bReal, bImag) = b
    (aReal + bReal, aImag + bImag)

//Функция вычитания
let subtract (a: float * float) (b: float * float) : float * float =
    let (aReal, aImag) = a
    let (bReal, bImag) = b
    (aReal - bReal, aImag - bImag)

//Функция умножения
let multiply (a: float * float) (b: float * float) : float * float =
    let (aReal, aImag) = a
    let (bReal, bImag) = b
    (aReal * bReal - aImag * bImag, aReal * bImag + aImag * bReal)

//Функция деления
let divide (a: float * float) (b: float * float) : float * float =
    let (aReal, aImag) = a
    let (bReal, bImag) = b
    let denominator = bReal * bReal + bImag * bImag
    ((aReal * bReal + aImag * bImag) / denominator, (aImag * bReal - aReal * bImag) / denominator)

//Функция возведения в степень
let rec power (a: float * float) (n: int) : float * float =
    match n with
    | 0 -> (1.0, 0.0)
    | 1 -> a
    | _ -> multiply a (power a (n - 1))

// Функция для ввода комплексного числа
let rec inputComplexNumber () : float * float =
    printf "Введите комплексное число (в формате a + bi): "
    let input = Console.ReadLine()
    let parts = input.Split([|'+'; 'i'|], StringSplitOptions.RemoveEmptyEntries)
    if parts.Length <> 2 then
        printfn "Ошибка: неверный формат. Попробуйте снова."
        inputComplexNumber() // Повторный ввод
    else
        try
            let real = parts.[0].Trim() |> float
            let imag = parts.[1].Trim() |> float
            (real, imag)
        with
        | :? System.FormatException ->
            printfn "Ошибка: неверный ввод чисел. Попробуйте снова."
            inputComplexNumber() // Повторный ввод

// Основная программа
let rec main () =
    printfn "Калькулятор комплексных чисел"
    printfn "Доступные операции: +, -, *, /, ^"
    
    let operation =
        let rec getOperation () =
            printf "Введите операцию: "
            let op = Console.ReadLine()
            if List.contains op ["+"; "-"; "*"; "/"; "^"] then
                op
            else
                printfn "Ошибка: неизвестная операция. Попробуйте снова."
                getOperation() // Повторный ввод
        getOperation()

    printfn "Введите первое комплексное число:"
    let num1 = inputComplexNumber()

    let result =
        match operation with
        | "+" ->
            printfn "Введите второе комплексное число:"
            let num2 = inputComplexNumber()
            add num1 num2
        | "-" ->
            printfn "Введите второе комплексное число:"
            let num2 = inputComplexNumber()
            subtract num1 num2
        | "*" ->
            printfn "Введите второе комплексное число:"
            let num2 = inputComplexNumber()
            multiply num1 num2
        | "/" ->
            printfn "Введите второе комплексное число:"
            let num2 = inputComplexNumber()
            divide num1 num2
        | "^" ->
            printf "Введите степень (целое число): "
            let rec getPower () =
                try
                    let n = Console.ReadLine() |> int
                    power num1 n
                with
                | :? System.FormatException ->
                    printfn "Ошибка: неверный ввод степени. Попробуйте снова."
                    getPower() // Повторный ввод
            getPower()
        | _ -> failwith "Неизвестная операция"

    printfn "Результат: %A" result

// Запуск программы
main()