using System;
using System.Collections.Generic;
using Xunit;

namespace TilePuzzle.Tests
{
    public class EightPuzzleTests
    {
        [Fact]
        public void DefaultConstructor_InitializesPuzzleCorrectly()
        {
            // Arrange
            var expectedBody = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 0 }
            };

            // Act
            var puzzle = new EightPuzzle();

            // Assert
            Assert.Equal(expectedBody, puzzle.body);
        }

        [Fact]
        public void ParameterizedConstructor_InitializesPuzzleCorrectly()
        {
            // Arrange
            var initialBody = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 0 }
            };

            // Act
            var puzzle = new EightPuzzle(initialBody);

            // Assert
            Assert.Equal(initialBody, puzzle.body);
        }

        [Fact]
        public void GetEmpty_ReturnsCorrectIndex()
        {
            // Arrange
            var initialBody = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 0 }
            };
            var puzzle = new EightPuzzle(initialBody);

            // Act
            int emptyIndex = puzzle.GetEmpty();

            // Assert
            Assert.Equal(8, emptyIndex);
        }

        [Fact]
        public void InsertMoves_AddsCorrectPossibleMoves()
        {
            // Arrange
            var initialBody = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 0 }
            };
            var puzzle = new EightPuzzle(initialBody);
            var expectedMoves = new List<int> { 5, 7 };

            // Act
            var moves = new List<int>();
            puzzle.insertMoves(moves);

            // Assert
            Assert.Equal(expectedMoves, moves);
        }

        [Fact]
        public void TakeMove_UpdatesPuzzleStateCorrectly()
        {
            // Arrange
            var initialBody = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 0 }
            };
            var puzzle = new EightPuzzle(initialBody);
            var expectedBody = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 0 },
                { 7, 8, 6 }
            };

            // Act
            puzzle.TakeMove(5);

            // Assert
            Assert.Equal(expectedBody, puzzle.body);
        }
    }
}