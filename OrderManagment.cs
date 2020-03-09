using System.Collections.Generic;
using System.Linq;

namespace _002_StandManagment {
	public class OrderManagment {
		private List<Order> _orders; //lista degli ordini

		//costruttore
		public OrderManagment ( ) {
			_orders = new List<Order>();
		}

		public int TotalOrders => _orders.Count; //proprietà che restituisce il numero di ordini totali

		//proprità che restituisce una copia di tutti gli ordini
		public List<Order> AllOrders => new List<Order>( _orders.Select( x => x.DeepCopy() ) );

		//aggiunge un ordine
		public bool AddOrder ( Order order ) {
			if ( _orders.Contains( order ) ) return false; //se l'ordine è già presente restituisce false
			_orders.Add( order );
			return true;
		}


		public string StampOrder ( int orderId ) {
			int index = _orders.FindIndex( x => x.Id == orderId );
			return index == -1 ? "" : _orders[index].ToString(); //se l'ordine non cè restituisce una stringa vuota
		}

		public bool DeleteOrder ( int orderId ) {
			int index = _orders.FindIndex( x => x.Id == orderId );
			if ( index == -1 ) return false; //se l'ordine non cè restituisce false
			if ( _orders[index].IsProcessed )
				return false; //se l'ordine è già stato servito non si può cancellare e restituisce false
			_orders.RemoveAt( index );
			return true;
		}

		public int WaitedTime ( int orderId ) {
			int index = _orders.FindIndex( x => x.Id == orderId );
			if ( index == -1 ) return -1; //se l'ordine non cè restituisco -1
			return _orders[index].WaitedTime;
		}

		public bool SupplyOrder ( int orderId ) {
			int index = _orders.FindIndex( x => x.Id == orderId );
			if ( index == -1 ) return false;                //se l'ordine non cè restituisco false
			if ( _orders[index].IsProcessed ) return false; //se l'ordine è già stato servito restituisco false
			_orders[index].SupllyOrder();
			return _orders[index].IsProcessed;
		}

		public double TotalCollected => _orders.Sum( x => x.IsProcessed ? x.ChoosedMenu.Cost : 0 );

		public int GetNonSupplied => _orders.Count( x => !x.IsProcessed );
	}
}