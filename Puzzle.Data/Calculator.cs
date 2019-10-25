using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Puzzle.Service
{
    public class Calculator : ICalculator
    {
        public int run(string input)
        {
            return getScore(input);
        }

        public int getScore(string input)
        {
            int score = 0;
            List<char> goods = new List<char>();
            List<char> pair = new List<char>();
            bool isGarbage = false;
            bool isIgnored = false;
            foreach (char item in input)
            {
                if (isIgnored)
                {
                    isIgnored = false;
                    continue;
                }
                if (item == '!')
                {
                    isIgnored = true;
                    continue;
                }
                if (isGarbage && item != '>')
                {
                    isGarbage = true;
                    continue;
                }
                else
                {
                    isGarbage = false;
                }
                if (item == '<')
                {
                    isGarbage = true;
                    continue;
                }
                if (item == '{' || item == '}')
                {
                    goods.Add(item);
                }
                continue;
            }
            foreach (char item in goods)
            {
                if (item == '}' && pair.Count() != 0)
                {
                    score += pair.Count();
                    pair.RemoveAt(pair.Count() - 1);
                }
                else { pair.Add(item); }
            }
            return score;
        }
    }

    public interface ICalculator
    {
        int run(string input);
        int getScore(string input);
    }
}
