namespace MassTransit.ServiceBus
{
	using System;

	public class MessageFilter<T> : Consumes<T>.Any where T : class
	{
		private readonly Consumes<T>.Any _consumer;
		private readonly Predicate<T> _filterFunction;

		public MessageFilter(Predicate<T> filterFunction, Consumes<T>.Any consumer)
		{
			_filterFunction = filterFunction;
			_consumer = consumer;
		}

		public void Consume(T message)
		{
			if (_filterFunction(message))
			{
				_consumer.Consume(message);
			}
		}
	}
}