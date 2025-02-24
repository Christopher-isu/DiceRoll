'ChristopherZ
'Spring 2025
'RCET2265
'Roll of the Dice
'

Option Explicit On 'forces all variables to be declared
Option Strict On 'forces all data types to match

Module DiceRoll

    Sub Main()
        Dim random As New Random()
        Dim rollCounts(11) As Integer
        Dim userResponse As String

        Do
            ' Roll two six-sided dice 1,000 times
            For i As Integer = 1 To 1000
                Randomize() 'initialize random number generator
                Dim roll1 As Integer = random.Next(1, 7) ' First dice roll
                Dim roll2 As Integer = random.Next(1, 7) ' Second dice roll
                Dim sum As Integer = roll1 + roll2 ' Sum of dice rolls
                rollCounts(sum - 2) += 1 ' Increment the count for the sum of the dice rolls
            Next

            ' Display the results in a horizontal table format
            Console.WriteLine("                      Roll Results")
            Console.WriteLine("=======================================================")

            ' display roll results in top row
            For result As Integer = 2 To 12 'loop through each possible roll result
                Console.Write(result.ToString().PadLeft(3) & " |") 'display the possible roll result
            Next
            Console.WriteLine()

            ' Separation line
            For result As Integer = 2 To 12 'for each value draw a separation line
                Console.Write("-----")
            Next
            Console.WriteLine()

            ' display roll counts in bottom row
            For result As Integer = 2 To 12 'loop through count for each result
                Console.Write(rollCounts(result - 2).ToString().PadLeft(3) & " |") 'display the count of each roll result
            Next
            Console.WriteLine()

            ' Prompt user to roll again or quit
            Console.WriteLine() 'add a blank line
            Console.WriteLine("Type 'R' to roll again or 'Q' to quit:") 'prompt user to roll again or quit
            userResponse = Console.ReadLine().ToLower()

            If userResponse = "q" Then 'if user types 'q' then exit the loop
                Exit Do
            ElseIf userResponse = "r" Then 'if user types 'r' then clear the roll counts and roll again
                Array.Clear(rollCounts, 0, rollCounts.Length) ' Clear the roll counts
            Else
                Console.WriteLine("Invalid input. Please type 'R' to roll again or 'Q' to quit.")
            End If

        Loop While userResponse <> "q"

    End Sub

End Module
