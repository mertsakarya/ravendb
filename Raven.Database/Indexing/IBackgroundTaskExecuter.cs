﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raven.Database.Config;

namespace Raven.Database.Indexing
{
	public interface IBackgroundTaskExecuter
	{
		IList<TResult> Apply<T, TResult>(WorkContext context, IEnumerable<T> source, Func<T, TResult> func)
			where TResult : class;

		void Repeat(IRepeatedAction action);

		void ExecuteAll<T>(WorkContext context, IList<T> source, Action<T, long> action);

		void ExecuteAllBuffered<T>(WorkContext context, IEnumerable<T> source, Action<IEnumerator<T>> action);
	}

	public interface IRepeatedAction
	{
		TimeSpan RepeatDuration { get; }
		bool IsValid { get; }
		void Execute();
	}
}