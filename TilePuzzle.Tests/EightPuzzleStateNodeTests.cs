using System;
using System.Collections.Generic;
using Xunit;

namespace TilePuzzle.Tests
{
    public class EightPuzzleStateNodeTests
    {
        [Fact]
        public void CalcHVal_SetsHeuristicValueCorrectly()
        {
            // Arrange
            int[,] start = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            int[,] target = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            var node = new EightPuzzleStateNode(start, target);

            // Act
            node.CalcHVal();

            // Assert
            Assert.Equal(0, node.HVal); // Assuming heuristic value is 0 for solved state
            
        }

        [Fact]
        public void CalcDVal_SetsDepthValueCorrectly()
        {
            // Arrange
            int[,] start = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            int[,] target = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            var node = new EightPuzzleStateNode(start, target);

            // Act
            node.CalcDVal();

            // Assert
            Assert.Equal(0, node.DVal);
        }

        [Fact]
        public void GetValue_ReturnsCorrectCombinedValue()
        {
            // Arrange
            int[,] start = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            int[,] target = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            var node = new EightPuzzleStateNode(start, target);
            node.CalcHVal();
            node.CalcDVal();

            // Act
            int value = node.GetValue();

            // Assert
            Assert.Equal(0, value); // Assuming heuristic value is 0 for solved state
        }

        [Fact]
        public void InsertChildren_GeneratesCorrectChildNodes()
        {
            // Arrange
            int[,] start = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            int[,] target = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            var node = new EightPuzzleStateNode(start, target);
            var children = new List<EightPuzzleStateNode>();

            // Act
            node.InsertChildren(children);

            // Assert
            Assert.NotEmpty(children);
            // Additional assertions can be added to verify the correctness of the child nodes
        }
    }
}