﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace utils {
	public static class CancellationTokenExtensions {
		public static CancellationTokenRegistration Register<T>(this CancellationToken ct, Action<T> action, T state, bool useSynCtx = false) {
			return ct.Register(s => action((T)s), useSynCtx);
		}
	}
}
