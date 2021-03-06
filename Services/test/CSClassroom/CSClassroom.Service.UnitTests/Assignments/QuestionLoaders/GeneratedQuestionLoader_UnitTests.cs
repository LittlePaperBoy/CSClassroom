﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC.CSClassroom.Model.Assignments;
using CSC.CSClassroom.Service.Assignments.QuestionLoaders;
using CSC.CSClassroom.Service.UnitTests.TestDoubles;
using CSC.CSClassroom.Service.UnitTests.Utilities;
using Xunit;

namespace CSC.CSClassroom.Service.UnitTests.Assignments.QuestionLoaders
{
	/// <summary>
	/// Unit tests for the GeneratedQuestionLoader class.
	/// </summary>
	public class GeneratedQuestionLoader_UnitTests
	{
		/// <summary>
		/// Ensures that loading a generated question does not throw.
		/// </summary>
		[Fact]
		public async Task LoadQuestionAsync_Succeeds()
		{
			var database = GetDatabase().Build();
			var question = database.Context.GeneratedQuestions.First();
			var loader = new GeneratedQuestionLoader(database.Context, question);

			await loader.LoadQuestionAsync();
		}

		/// <summary>
		/// Builds a database.
		/// </summary>
		private static TestDatabaseBuilder GetDatabase()
		{
			return new TestDatabaseBuilder()
				.AddClassroom("Class1")
				.AddQuestionCategory("Class1", "Category1")
				.AddQuestion("Class1", "Category1", new GeneratedQuestionTemplate());
		}
	}
}
