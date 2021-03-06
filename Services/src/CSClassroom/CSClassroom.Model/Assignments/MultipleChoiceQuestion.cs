﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSC.CSClassroom.Model.Assignments
{
	/// <summary>
	/// An exercise with multiple choices to pick.
	/// </summary>
	public class MultipleChoiceQuestion : Question
	{
		/// <summary>
		/// Whether or not to allow multiple correct answers.
		/// </summary>
		[Display
		(
			Name = "Allow Multiple Correct Answers",
			Description = "Select whether or not to allow multiple correct answers. "
				+ "If multiple correct answers are permitted, a submission will only be "
				+ "considered correct if the selected answers exactly match the correct answers."
		)]
		public bool AllowMultipleCorrectAnswers { get; set; }

		/// <summary>
		/// The choices available to pick.
		/// </summary>
		[Display
		(
			Name = "Choices",
			Description = "Enter the choices available to pick."
		)]
		public List<MultipleChoiceQuestionChoice> Choices { get; set; }

		/// <summary>
		/// The type of solver(s) supported for this question.
		/// </summary>
		protected override QuestionSolverType SolverTypes
			=> QuestionSolverType.Interactive | QuestionSolverType.NonInteractive;

		/// <summary>
		/// Returns whether or not the question is a randomly selected question.
		/// </summary>
		public override bool HasChoices => false;

		/// <summary>
		/// Returns whether or not the question is a generated question template.
		/// </summary>
		public override bool IsQuestionTemplate => false;

		/// <summary>
		/// Returns whether or not this question can be duplicated.
		/// </summary>
		public override bool CanDuplicate => true;

		/// <summary>
		/// Returns whether or not this question can be turned into a generated question template.
		/// </summary>
		public override bool CanRandomize => true;

		/// <summary>
		/// The string displayed for the type of question
		/// </summary>
		public override string QuestionTypeDisplay => "Multiple Choice Question";

		/// <summary>
		/// The string displayed for the description of the question type
		/// </summary>
		public override string QuestionTypeDescription =>
			"A question that has multiple choices. The question can be "
			+ "configured to allow the submission exactly one choice, or "
			+ "any number of choices.";

		/// <summary>
		/// Accepts a question visitor.
		/// </summary>
		public override void Accept(IQuestionVisitor questionVisitor)
		{
			questionVisitor.Visit(this);
		}

		/// <summary>
		/// Accepts a question visitor that returns a result.
		/// </summary>
		public override TResult Accept<TResult>(IQuestionResultVisitor<TResult> questionVisitor)
		{
			return questionVisitor.Visit(this);
		}

		/// <summary>
		/// Accepts a question visitor that returns a result.
		/// </summary>
		public override TResult Accept<TResult, TParam1>(
			IQuestionResultVisitor<TResult, TParam1> questionVisitor,
			TParam1 param1)
		{
			return questionVisitor.Visit(this, param1);
		}
	}
}
