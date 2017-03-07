using System.Collections;
using System.Collections.Generic;

public static class Extensions {

	public static void AddRange<T>(this ICollection<T> c, IEnumerable<T> e) {
		foreach (var item in e) c.Add(item);
	}
}
