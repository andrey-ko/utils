﻿//------------------------------------------------------------------------------
// <auto-generated>                                                       
//     This code was generated by a tool.                                       
//                                                                              
//     Changes to this file may cause incorrect behavior and will be lost if    
//     the code is regenerated.                                                 
// </auto-generated>                                                      
//------------------------------------------------------------------------------
namespace utils.langex.examples {
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Threading;
	public partial class Trigger<T> {
		abstract public partial class State {
			public enum Id {
				idle,
				subscribed,
				completed
			}
			public interface IMatch {
				void OnIdle(Idle idle);
				void OnSubscribed(Subscribed subscribed);
				void OnCompleted(Completed completed);
			}
			public interface IMatch<TMatch> {
				TMatch OnIdle(Idle idle);
				TMatch OnSubscribed(Subscribed subscribed);
				TMatch OnCompleted(Completed completed);
			}
			public delegate void OnIdleCallback(Idle idle);
			public delegate void OnSubscribedCallback(Subscribed subscribed);
			public delegate void OnCompletedCallback(Completed completed);
			public delegate TMatch OnIdleCallback<TMatch>(Idle idle);
			public delegate TMatch OnSubscribedCallback<TMatch>(Subscribed subscribed);
			public delegate TMatch OnCompletedCallback<TMatch>(Completed completed);
			public readonly Id id;
			public class Idle: State {
				public Idle(): base(Id.idle) {
				}
				public override void Match(IMatch handler) {
					handler.OnIdle(this);
				}
				public override TMatch Match<TMatch>(IMatch<TMatch> handler) {
					return handler.OnIdle(this);
				}
				public override void Match(OnIdleCallback idle, OnSubscribedCallback subscribed, OnCompletedCallback completed) {
					idle(this);
				}
				public override TMatch Match<TMatch>(OnIdleCallback<TMatch> idle, OnSubscribedCallback<TMatch> subscribed, OnCompletedCallback<TMatch> completed) {
					return idle(this);
				}
				public override bool IsIdle() {
					return true;
				}
				public override Idle AsIdle() {
					return this;
				}
			}
			public class Subscribed: State {
				public readonly Action cont;
				public readonly Subscribed next;
				public Subscribed(Action cont, Subscribed next): base(Id.subscribed) {
					this.cont = cont;
					this.next = next;
				}
				public override void Match(IMatch handler) {
					handler.OnSubscribed(this);
				}
				public override TMatch Match<TMatch>(IMatch<TMatch> handler) {
					return handler.OnSubscribed(this);
				}
				public override void Match(OnIdleCallback idle, OnSubscribedCallback subscribed, OnCompletedCallback completed) {
					subscribed(this);
				}
				public override TMatch Match<TMatch>(OnIdleCallback<TMatch> idle, OnSubscribedCallback<TMatch> subscribed, OnCompletedCallback<TMatch> completed) {
					return subscribed(this);
				}
				public override bool IsSubscribed() {
					return true;
				}
				public override Subscribed AsSubscribed() {
					return this;
				}
			}
			public abstract partial class Completed: State {
				public new enum Id {
					succeded,
					failed
				}
				public new interface IMatch {
					void OnSucceded(Succeded succeded);
					void OnFailed(Failed failed);
				}
				public new interface IMatch<TMatch> {
					TMatch OnSucceded(Succeded succeded);
					TMatch OnFailed(Failed failed);
				}
				public delegate void OnSuccededCallback(Succeded succeded);
				public delegate void OnFailedCallback(Failed failed);
				public delegate TMatch OnSuccededCallback<TMatch>(Succeded succeded);
				public delegate TMatch OnFailedCallback<TMatch>(Failed failed);
				public class Succeded: Completed {
					public readonly T val;
					public Succeded(T val): base(Id.succeded) {
						this.val = val;
					}
					public override void Match(IMatch handler) {
						handler.OnSucceded(this);
					}
					public override TMatch Match<TMatch>(IMatch<TMatch> handler) {
						return handler.OnSucceded(this);
					}
					public override void Match(OnSuccededCallback succeded, OnFailedCallback failed) {
						succeded(this);
					}
					public override TMatch Match<TMatch>(OnSuccededCallback<TMatch> succeded, OnFailedCallback<TMatch> failed) {
						return succeded(this);
					}
					public override bool IsSucceded() {
						return true;
					}
					public override Succeded AsSucceded() {
						return this;
					}
				}
				public class Failed: Completed {
					public readonly Exception error;
					public Failed(Exception error): base(Id.failed) {
						this.error = error;
					}
					public override void Match(IMatch handler) {
						handler.OnFailed(this);
					}
					public override TMatch Match<TMatch>(IMatch<TMatch> handler) {
						return handler.OnFailed(this);
					}
					public override void Match(OnSuccededCallback succeded, OnFailedCallback failed) {
						failed(this);
					}
					public override TMatch Match<TMatch>(OnSuccededCallback<TMatch> succeded, OnFailedCallback<TMatch> failed) {
						return failed(this);
					}
					public override bool IsFailed() {
						return true;
					}
					public override Failed AsFailed() {
						return this;
					}
				}
				protected Completed(Id id): base(State.Id.completed) {
				}
				public abstract void Match(IMatch handler);
				public abstract TMatch Match<TMatch>(IMatch<TMatch> handler);
				public abstract void Match(OnSuccededCallback succeded, OnFailedCallback failed);
				public abstract TMatch Match<TMatch>(OnSuccededCallback<TMatch> succeded, OnFailedCallback<TMatch> failed);
				public virtual bool IsSucceded() {
					return false;
				}
				public virtual bool IsFailed() {
					return false;
				}
				public virtual Succeded AsSucceded() {
					return null;
				}
				public virtual Failed AsFailed() {
					return null;
				}
				public override void Match(State.IMatch handler) {
					handler.OnCompleted(this);
				}
				public override TMatch Match<TMatch>(State.IMatch<TMatch> handler) {
					return handler.OnCompleted(this);
				}
				public override void Match(OnIdleCallback idle, OnSubscribedCallback subscribed, OnCompletedCallback completed) {
					completed(this);
				}
				public override TMatch Match<TMatch>(OnIdleCallback<TMatch> idle, OnSubscribedCallback<TMatch> subscribed, OnCompletedCallback<TMatch> completed) {
					return completed(this);
				}
				public override bool IsCompleted() {
					return true;
				}
				public override Completed AsCompleted() {
					return this;
				}
			}
			protected State(Id id) {
			}
			public abstract void Match(IMatch handler);
			public abstract TMatch Match<TMatch>(IMatch<TMatch> handler);
			public abstract void Match(OnIdleCallback idle, OnSubscribedCallback subscribed, OnCompletedCallback completed);
			public abstract TMatch Match<TMatch>(OnIdleCallback<TMatch> idle, OnSubscribedCallback<TMatch> subscribed, OnCompletedCallback<TMatch> completed);
			public virtual bool IsIdle() {
				return false;
			}
			public virtual bool IsSubscribed() {
				return false;
			}
			public virtual bool IsCompleted() {
				return false;
			}
			public virtual Idle AsIdle() {
				return null;
			}
			public virtual Subscribed AsSubscribed() {
				return null;
			}
			public virtual Completed AsCompleted() {
				return null;
			}
		}
	}
}
