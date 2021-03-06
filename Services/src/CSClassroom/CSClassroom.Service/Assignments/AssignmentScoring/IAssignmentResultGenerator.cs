﻿using System;
using System.Collections.Generic;
using System.Text;
using CSC.CSClassroom.Model.Classrooms;
using CSC.CSClassroom.Model.Assignments;
using CSC.CSClassroom.Model.Assignments.ServiceResults;
using CSC.CSClassroom.Model.Users;

namespace CSC.CSClassroom.Service.Assignments.AssignmentScoring
{
	/// <summary>
	/// Generates results for a single user/assignment.
	/// </summary>
	public interface IAssignmentResultGenerator
	{
		/// <summary>
		/// Creates an assignment result.
		/// </summary>
		AssignmentResult CreateAssignmentResult(
			Section section,
			Assignment assignment,
			User user,
			bool admin,
			IList<UserQuestionSubmission> submissions);
	}
}
