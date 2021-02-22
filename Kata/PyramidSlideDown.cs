using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static int LongestSlideDown(int[][] pyramid)
        {
            while (pyramid.Length > 1)
            {
                SimplifyPyramid();
            }
            
            return pyramid[0][0];

            void SimplifyPyramid()
            {
                for (int X = 0; X < pyramid[pyramid.Length - 2].Length; X++)
                {
                    int MaxInWays = pyramid[pyramid.Length - 1].Skip(X).Take(2).Max();
                    pyramid[pyramid.Length - 2][X] += MaxInWays;
                }
                pyramid = pyramid.Take(pyramid.Length - 1).ToArray();
            }

            //This was my solution, but i could not catch the principle of solution so i search for it and found.
            //But new code i wrote myself.

            /*int Out = 0;
            int PositionX = 0;

            /*foreach (int[] Line in pyramid)
            {
                int[] ToSelect = Line.Skip(PositionX).Take(2).ToArray();
                int Selected = ToSelect.Max();

                if (Selected != ToSelect[0])
                {
                    PositionX++;
                }

                Out += Selected;
            }#1#
            //Full sum should be max!

            for (int I = 0; I < pyramid.Length; I++)
            {
                int[] Line = pyramid[I];
                int[] ToSelect = Line.Skip(PositionX).Take(2).ToArray();
                int Selected = PyramidSum(GetSubPyramid(I, PositionX)) > PyramidSum(GetSubPyramid(I, PositionX + 1))
                    ? ToSelect[0]
                    : ToSelect[1];

                Out += Selected;


                if (Selected != ToSelect[0])
                {
                    PositionX++;
                }
            }

            return Out;

            int PyramidSum(int[][] Pyramid)
            {
                int Sum = 0;
                foreach (int[] Line in Pyramid)
                {
                    Sum += Line.Sum();
                }

                return Sum;
            }
            int[][] GetSubPyramid(int LevelOffset, int Position)
            {
                List<int[]> OutPyramid = new List<int[]>();
                int SlideLevel = 1;
                foreach (int[] Level in pyramid.Skip(LevelOffset))
                {
                    OutPyramid.Add(Level.Skip(Position).Take(SlideLevel++).ToArray());
                }

                return OutPyramid.ToArray();
            }
        }*/
        }
    }
}