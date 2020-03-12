using System;
using System.Globalization;

namespace _002_StandManagment {
	public class
		// IEquatable <Order> serve per riscrivere il metodo equals che viene usato dal metodo estensivo contains
		Order : IEquatable<Order> {
		private static int
			NUM = 0; //variabile statica che determina l'Id nel costruttorein modo che gli Id delle ordinazioni sono sequenziali e non a caso


		private int      _id;          //numero dell'ordinazione
		private Menu     _choosedMenu; //menu scelto
		private DateTime _supplied;    //ora di erogazione dell'ordine
		private bool     _isProcessed; //false se il menù è in elaborazione, true se è già stato servito
		private int      _waitedTime;

		//costruttore
		public Order ( Menu choosedMenu ) {
			_choosedMenu = choosedMenu;
			_id          = ++NUM;
			_supplied    = DateTime.Now;
			_isProcessed = false;
			_waitedTime  = 0;
		}

		public int Id => _id; //proprietà per l'ID

		public Menu ChoosedMenu => _choosedMenu; //proprietà per il menu scelto

		public bool IsProcessed => _isProcessed; //proprità menù servito o no

		public int WaitedTime { //tempo passato dall'ordinazione ad ora
			get {
				if ( !IsProcessed ) {
					TimeSpan timeSpan = DateTime.Now - _supplied;
					return timeSpan.Minutes;
				}

				return _waitedTime;
			}
		}

		public void SupllyOrder ( ) {  //il menu viene servito
			_waitedTime  = WaitedTime; //determino il tempo atteso e lo salvo			
			_isProcessed = true;
		}

		//override del metodo tostring
		public override string ToString ( ) {
			return "ID dell'ordinazione:  " + _id                  + "\n" +
			       "Menù scelto:  "         + _choosedMenu         + "\n" +
			       "Ora ordinazione: "      + _supplied.ToString() + "\n" +
			       "Servito: "              + _isProcessed         + "\n";
		}
		
		//copia profonda dato che l'oggetto contiene altri oggetti
		public Order DeepCopy ( ) {
			Order order = (Order) this.MemberwiseClone();
			order._choosedMenu = _choosedMenu.ShallowCopy();
			return order;
		}

		//override del metodo Equals
		public override bool Equals ( object obj ) {
			return obj is Order order && IsEquals( order );
		}

		//definizione del metodo equals utilizzato dal metodo contains
		public bool Equals ( Order other ) {
			return this.IsEquals( other );
		}

		//metodo isEquals in appoggio al metodo equals per renderlo piu leggibile e semplice
		private bool IsEquals ( Order other ) {
			return _id == other._id                    && _choosedMenu.Equals( other._choosedMenu ) &&
			       _supplied.Equals( other._supplied ) && _isProcessed == other._isProcessed;
		}

		//override del metodo getHashCode 
		public override int GetHashCode ( ) {
			return HashCode.Combine( _id, _choosedMenu, _supplied, _isProcessed );
		}
	}
}