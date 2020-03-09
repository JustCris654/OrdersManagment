using System;

namespace _002_StandManagment {
	public class Menu {
		private string _name;        //nome del menu 
		private double _cost;        //costo
		private string _description; //descrizione

		//costruttore
		public Menu ( string name, double cost, string description ) {
			_name        = name;
			_cost        = cost;
			_description = description;
		}

		public string Name => _name; //proprietà per il nome

		public double Cost => _cost; //proprietà per il costo

		public string Description => _description; //proprietà per la descrizione

		//metodo toString del menu
		public override string ToString ( ) {
			return "	Nome: "        + _name        + "\n" +
			       "	Costo: "       + _cost        + "\n" +
			       "	Descrizione: " + _description + "\n";
		}

		//copia superficiale, non ho bisogno di quella profonda
		public Menu ShallowCopy ( ) {
			return (Menu) this.MemberwiseClone();
		}

		//override del metodo equals
		public override bool Equals ( object? obj ) {
			if ( !( obj is Menu ) ) return false;
			return this.IsEquals( (Menu) obj ) && this.GetHashCode() == obj.GetHashCode();
		}

		//metodo isEquals in appoggio al metodo equals per renderlo piu leggibile e semplice
		private bool IsEquals ( Menu other ) {
			return _name == other._name && _cost.Equals( other._cost ) && _description == other._description;
		}

		//override del metodo getHashCode 
		public override int GetHashCode ( ) {
			return HashCode.Combine( _name, _cost, _description );
		}
	}
}