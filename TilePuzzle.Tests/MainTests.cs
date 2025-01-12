using System;
using System.Collections.Generic;
using Xunit;
using TilePuzzle;

namespace TilePuzzleTest
{
    public class SolverTests
    {
        // [Fact]
        // public void TestSolverConstructor()
        // {
        //     Solver solver = new Solver();
        //     Assert.Single(solver.open);
        //     Assert.Empty(solver.closed);
        // }

        [Fact]
        public void TestSolve()
        {
            Solver solver = new Solver();
            solver.Solve();
            Assert.True(solver.Solved);
        }

        // [Fact]
        // public void TestProcess()
        // {
        //     Solver solver = new Solver();
        //     solver.process();
        //     Assert.NotEmpty(solver.closed);
        // }

        // [Fact]
        // public void TestCheckClosed()
        // {
        //     Solver solver = new Solver();
        //     int[,] body = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 0, 8 } };
        //     int[,] target = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
        //     EightPuzzleStateNode node = new EightPuzzleStateNode(body, target);
        //     solver.checkClosed(node);
        //     Assert.Contains(node, solver.open);
        // }

        // [Fact]
        // public void TestPrintback()
        // {
        //     Solver solver = new Solver();
        //     int[,] body = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 0, 8 } };
        //     int[,] target = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
        //     EightPuzzleStateNode node = new EightPuzzleStateNode(body, target);
        //     solver.printback(node);
        //     // Verify output manually
        // }

        [Fact]
        public void TestGetRow()
        {
            int[,] array = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[] row = Solver.GetRow(array, 1);
            Assert.Equal(new int[] { 4, 5, 6 }, row);
        }

        [Fact]
        public void TestEightPuzzleStateNodeComparer()
        {
            int[,] body1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 0, 8 } };
            int[,] target = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            EightPuzzleStateNode node1 = new EightPuzzleStateNode(body1, target);
            EightPuzzleStateNode node2 = new EightPuzzleStateNode(body1, target);
            EightPuzzleStateNodeComparer comparer = new EightPuzzleStateNodeComparer();
            int result = comparer.Compare(node1, node1);
            Assert.Equal(0, result);
            result = comparer.Compare(node1, node2);
            //Global unique identifier is different, so the result should not be 0
            //Can't predict the result, so just check if it's not 0
            Assert.NotEqual(0, result); 
            result = comparer.Compare(node2, node1);
            Assert.NotEqual(0, result);
        }
    }
}