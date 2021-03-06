﻿using System.Threading.Tasks;

namespace utils {
	public static class TaskExtensions {
		
		public static void ContinueWith<T>(this Task<T> task, TaskCompletionSource<T> tcs) {
			task.ContinueWith(t => {
				if (t.IsFaulted) {
					tcs.TrySetException(t.Exception);
				} else if (t.IsCanceled) {
					tcs.TrySetCanceled();
				} else {
					tcs.TrySetResult(t.Result);
				}
			}, TaskContinuationOptions.ExecuteSynchronously);
		}
		
	}
}
