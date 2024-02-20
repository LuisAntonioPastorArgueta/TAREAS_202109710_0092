Imports System.IO

Module Module1
    Sub Main()
        Dim opcion As Char = ""
        Dim opcion2 As ConsoleKeyInfo
        Dim nombre As String
        Dim numero1, numero2, suma As Integer

        Console.WriteLine("Ingrese su nombre: ")
        nombre = Console.ReadLine()

        Do
            Try
                Console.Clear()
                Console.WriteLine("Bienvenido " & nombre)
                Console.WriteLine("-----------------")
                Console.WriteLine("Seleccione una opción del Menú:")
                Console.WriteLine("1. SUMAR")
                Console.WriteLine("2. Ver historial")
                Console.WriteLine("3. Borrar historial")
                Console.WriteLine("4. Salir")
                opcion2 = Console.ReadKey()
                opcion = opcion2.KeyChar
                Console.Clear()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            Select Case opcion
                Case "1"
                    Try
                        Console.Clear()
                        Console.WriteLine("Ingrese un número entero: ")
                        numero1 = Convert.ToInt32(Console.ReadLine())
                        Console.WriteLine("Ingrese un segundo número entero: ")
                        numero2 = Convert.ToInt32(Console.ReadLine())
                        suma = numero1 + numero2
                        Console.WriteLine("La suma de " & numero1 & " y " & numero2 & " es: " & suma)
                        Console.ReadKey()

                        Dim historial As StreamWriter
                        historial = File.AppendText("salida.txt")
                        historial.WriteLine(numero1 & " + " & numero2 & " = " & suma)
                        historial.Close()
                        Console.WriteLine("Resultado guardado en el historial.")
                        Console.WriteLine("------------------------------------")
                        Console.WriteLine("Presione cualquier tecla para volver")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.ReadKey()
                Case "2"
                    Console.Clear()
                    Try
                        Dim historial As StreamReader
                        historial = File.OpenText("salida.txt")
                        Console.WriteLine("Numero 1 + Número 2 = Resultado")
                        Do Until historial.EndOfStream
                            Console.WriteLine(historial.ReadLine())
                        Loop
                        historial.Close()
                    Catch ex As FileNotFoundException
                        Console.WriteLine("El archivo de historial no existe.”)
                    End Try
                    Console.WriteLine("")
                    Console.WriteLine("Presione cualquier tecla")
                    Console.ReadKey()
                Case "3"
                    Dim historial As String = "salida.txt"
                    File.Delete(historial)
                    Console.WriteLine("Borrar historial")
                    Console.ReadKey()
                Case "4"
                    Console.Clear()
                    Console.WriteLine("¡Hasta pronto!")
                    Exit Do
                    Console.ReadKey()
                Case Else
                    Console.WriteLine("Opción no válida.”)
            End Select
        Loop
    End Sub
End Module
