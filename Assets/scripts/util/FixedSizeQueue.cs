using System.Collections.Generic;

public class FixedSizeQueue<T>: Queue<T> {

	public int Size { get; private set; }

	private readonly object sync = new object();

	public FixedSizeQueue(int size) {
		Size = size;
	}

	public new void Enqueue(T item) {
		base.Enqueue(item);
		lock (sync) {
			while (base.Count > Size)
				base.Dequeue();
		}
	}
}