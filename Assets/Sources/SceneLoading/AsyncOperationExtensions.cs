using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Extensions
{
	public static class AsyncOperationExtensions
	{
		public static AsyncOperationAwaiter GetAwaiter(this AsyncOperation operation) =>
			new AsyncOperationAwaiter(operation);
	}
	
	public struct AsyncOperationAwaiter : INotifyCompletion
	{
		private readonly AsyncOperation _operation;
		private Action _continuation;

		public AsyncOperationAwaiter(AsyncOperation operation)
		{
			_operation = operation;
			_continuation = null;
		}

		public bool IsCompleted => _operation.isDone;

		public AsyncOperation GetResult() => _operation;

		public void OnCompleted(Action continuation)
		{
			_continuation = continuation;
			_operation.completed += OnOperationCompleted;
		}

		private void OnOperationCompleted(AsyncOperation asyncOperation) => 
			_continuation.Invoke();
	}
}