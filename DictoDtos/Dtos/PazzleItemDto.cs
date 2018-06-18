using System;
using System.Collections.Generic;

namespace DictoInfrasctructure.Dtos
{
    public class PazzleItemDto
    {
        public string Translate { get; set; }

        public string Source { get; set; }

        public CharItemDto[] Original { get; set; }

        public CharItemDto[] Pazzle { get; set; }

        public int WordId { get; set; }


        public static CharItemDto[] GenerateOriginal(string original)
        {
            var originalChars = new CharItemDto[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                originalChars[i] = new CharItemDto(original[i], new List<int>() { i + 1 }, false);
            }

            return originalChars;
        }

        public static CharItemDto[] GeneratePazzle(CharItemDto[] original)
        {
            CharItemDto[] res = new CharItemDto[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                res[i] = CharItemDto.Copy(original[i]);
                res[i].Show = true;
            }

            for (int i = 0; i < res.Length; i++)
            {
                CharItemDto curchar = res[i];
                if (curchar.Catch)
                    continue;
                List<int> listFindChar = new List<int>();
                curchar.Catch = true;
                listFindChar.Add(i + 1);
                for (int j = i + 1; j < res.Length; j++)
                    if (!res[j].Catch && curchar.Char == res[j].Char)
                    {
                        res[j].Order.AddRange(listFindChar);
                        listFindChar.Add(j + 1);
                        res[j].Catch = true;
                    }

                curchar.Order.AddRange(listFindChar);
            }

            Random ran = new Random();
            int n = 100;
            while (n > 0)
            {
                int i = ran.Next(res.Length);
                int prev = i - 1;
                if (prev >= 0)
                {
                    CharItemDto temp = res[i];
                    res[i] = res[prev];
                    res[prev] = temp;
                }
                n--;
            }

            return res;
        }



    }
}