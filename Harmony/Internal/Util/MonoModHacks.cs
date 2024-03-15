﻿using MonoMod.RuntimeDetour;
using System.Reflection;

namespace HarmonyLib.Internal.Util;

internal static class MonoModHacks
{
	// ReSharper disable once InconsistentNaming
	private static readonly AccessTools.FieldRef<object, MethodBase> ManagedDetourState_EndOfChain_Ref =
		AccessTools.FieldRefAccess<object, MethodBase>(AccessTools.DeclaredField(
			typeof(DetourManager).GetNestedType("ManagedDetourState", AccessTools.all),
			"EndOfChain"
		));

	// ReSharper disable once InconsistentNaming
	private static readonly AccessTools.FieldRef<MethodDetourInfo, object> MethodDetourInfo_State_Ref =
		AccessTools.FieldRefAccess<MethodDetourInfo, object>("state");

	internal static MethodBase GetEndOfChain(this MethodDetourInfo self) =>
		ManagedDetourState_EndOfChain_Ref(MethodDetourInfo_State_Ref(self));


}
