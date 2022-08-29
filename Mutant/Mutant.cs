using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutant
{
    public class Mutant
    {
        public static bool IsMutant(string[] dataSequences)
        {

            if (dataSequences.Any() && dataSequences.Length >= 4)
            {
                var sequencesLength = dataSequences.Length;
                var allowedLetters = new string[] { "A", "C", "G", "T" };
                string sequence = string.Empty;
                int countSequence = 0;


                for (int i = 0; i < dataSequences.Length; i++)
                {
                    if (dataSequences[i].Length != sequencesLength)
                        throw new ValidationException("ADN array must be NxN");

                    countSequence = ValidateMutant(dataSequences[i]) ? countSequence + 1 : countSequence;
                    sequence = dataSequences[0][i].ToString();
                    for (int j = 1; j < dataSequences.Length; j++)
                    {
                        var letter = dataSequences[j][i].ToString();
                        if (!allowedLetters.Contains(letter))
                            throw new ValidationException("ADN contains letter not allowed");

                        sequence += letter;
                    }
                    countSequence = ValidateMutant(sequence) ? countSequence + 1 : countSequence;
                }

                if (countSequence <= 1)
                    for (int i = 1 - dataSequences.Length; i < dataSequences.Length; i++)
                    {
                        sequence = String.Empty;
                        for (int x = -Math.Min(0, i), y = Math.Max(0, i); x < dataSequences.Length && y < dataSequences.Length; x++, y++)
                        {
                            sequence += dataSequences[x][y];
                        }

                        if (sequence.Length >= 4)
                        {
                            countSequence = ValidateMutant(sequence) ? countSequence + 1 : countSequence;
                        }
                    }


                return countSequence > 1;
            }
            else
                throw new ValidationException("ADN is required or ADN must have a total of more than 4");

        }

        private static bool ValidateMutant(string sequence)
        {
            int count = 1;

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                var letter = sequence[i].ToString();
                if (sequence[i+1].ToString() == letter)
                    count++;
            }

            return count >= 4;
        }
    }
}
