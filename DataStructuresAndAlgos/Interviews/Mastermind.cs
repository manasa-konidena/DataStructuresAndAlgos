namespace DataStructuresAndAlgos.Interviews;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Write a function for computing the Mastermind hint from a secret and guess.
///     hint = computeHint(secret, guess)
///     Eg. Assume colors Red,Green,Blue,Purple,Yellow,Orange
///     Secret R R P B
///         |    /
///     Guess  R Y B G
///         Hint
///     Number of black pegs = 1 (because of the R in the guess)
///     Number of white pegs = 1 (because of the B in the guess)
/// </summary>
public class Mastermind
{
    
    static void TestTheCode(String[] args)
    {
        var secret = new char[] {'R', 'R', 'P', 'B'};
        var guess = new char[]
        {
            'R',
            'Y',
            'B',
            'G'
        };
        var result = Compute(secret, guess);
        Console.WriteLine($"Black pegs are {result.Item1}, white pegs are {result.Item2}");

        // Invalid secret or a guess
        //  Have a case such that the same letter in the guess could contribute to both black and white pegs
        //  Have a case such that the same letter is not counting for two white pegs
        // Happy path such that all good guesses have the right hint
    }

    static HashSet<char> allowedColors = new HashSet<char>{ 'R','G', 'B', 'P','Y','O'};

    static (int, int) Compute(char[] secret, char[] guess)
    {
        // Validate the secret the guess
        for (int i = 0; i < 4; i++)
        {
            if (!allowedColors.Contains(secret[i])) return (-1, -1);
            if (!allowedColors.Contains(guess[i])) return (-1, -1);
        }

        Dictionary<char, HashSet<int>> colorToPositions = new Dictionary<char, HashSet<int>>();

        // R R P B - i
        // R Y B G - j
        // since at 0, we have Rs - blackPegs = 1, R -> 0

        // R R P B
        // R Y B R

        int blackPegs = 0;
        int whitePegs = 0;
        // Check for Black Pegs
        for (int i = 0; i < 4; i++)
        {
            if (secret[i] == guess[i])
            {
                blackPegs++;
                if (colorToPositions.TryGetValue(secret[i], out HashSet<int> positions)) positions.Add(i);
                else
                    colorToPositions.Add(secret[i], new HashSet<int>{ i });
            }
        }

        // R R P B
        // R Y B R
        // R -> {0}
        // Check for white pegs
        for (int i = 0; i < 4; i++)
        {
            // Find the positions in secret which match this color
            // In those, ignore the ones that exist in positions set
            // Once removed, if there are still left, add them to the dictionary
            var positionsMatchingColor = GetMatchingPositionsFromSecret(guess[i], secret); //  PMC {3}
            if (positionsMatchingColor.Count == 0) continue;

            if (!colorToPositions.TryGetValue(guess[i], out HashSet<int> positionsAlreadyUsed)) // PAU - {0}
            {
                var firstPos = positionsMatchingColor.First();
                whitePegs++;
                colorToPositions.Add(guess[i], new HashSet<int>
                {
                    firstPos
                });
            }
            else //
            {
                if (positionsAlreadyUsed.Contains(i)) continue;
                var validPositions = positionsMatchingColor.Except(positionsAlreadyUsed).Except(new HashSet<int>
                {
                    i
                });
                if (validPositions.Count() == 0) continue;
                whitePegs++; // WP - 0
                positionsAlreadyUsed.Add(validPositions.First()); // PAU - {0}
            }
        }

        return (blackPegs, whitePegs);
    }

    static HashSet<int> GetMatchingPositionsFromSecret(char color, char[] secret)
    {
        var result = new HashSet<int>();
        for (int i = 0; i < 4; i++)
        {
            if (secret[i] == color) result.Add(i);
        }

        return result;
    }
}