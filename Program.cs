using System;

namespace _002_StandManagment {
	class Program {
		static void Main ( string[] args ) {
			Menu menu1 = new Menu( "pasta",  10f, "pasta al ragu" );
			Menu menu2 = new Menu( "carne",  12f, "carne arrosto" );
			Menu menu3 = new Menu( "salumi", 8f,  "salumi vari" );
			Menu menu4 = new Menu( "pasta",  10f, "pasta al ragu" );

			Console.WriteLine( menu1.Equals( menu4 ) + "<- dovrebbe essere true" + "\n" + menu1.Equals( menu2 ) +
			                   "<- dovrebbe essere false" );
			Console.WriteLine( "\n" );


			Order ordine1 = new Order( menu1 );
			Order ordine2 = new Order( menu2 );
			Order ordine3 = new Order( menu3 );
			Order ordine4 = ordine1.DeepCopy();

			Console.WriteLine( "ordine 1: \n" + ordine1 + "\n" );
			Console.WriteLine( "ordine 4: \n" + ordine4 + "\n" );

			Console.WriteLine( ordine1.Id + "   " + ordine2.Id + "   " + ordine3.Id + "<- dovrenbbe essere 1 2 3\n" );

			Console.WriteLine( ordine1.Equals( (object) ordine4 ) + "<- dovrebbe essere true" + "\n" +
			                   ordine1.Equals( (object) ordine2 ) +
			                   "<- dovrebbe essere false" );

			OrderManagment orderManager = new OrderManagment();
			Console.WriteLine( orderManager.AddOrder( ordine1 ) + "<- dovrebbe essere true" );
			Console.WriteLine( orderManager.AddOrder( ordine2 ) + "<- dovrebbe essere true" );
			Console.WriteLine( orderManager.AddOrder( ordine3 ) + "<- dovrebbe essere true" );
			Console.WriteLine( orderManager.AddOrder( ordine4 ) + "<- dovrebbe essere false" );

			Console.WriteLine( orderManager.StampOrder( 1 ) + "<- dovrebbe essere true" );
			Console.WriteLine( orderManager.StampOrder( 5 ) + "<- dovrebbe essere false" );

			Console.WriteLine( orderManager.DeleteOrder( 1 ) + "<- dovrebbe essere true" );
			Console.WriteLine( orderManager.DeleteOrder( 5 ) + "<- dovrebbe essere false" );


			Console.WriteLine( orderManager.WaitedTime( 2 ) + " minuti" );

			Console.WriteLine( orderManager.SupplyOrder( 2 ) + "<- dovrebbe essere true" );
			Console.WriteLine( orderManager.SupplyOrder( 2 ) + "<- dovrebbe essere false" );

			Console.WriteLine( orderManager.GetNonSupplied );

			var ordiniCopiati = orderManager.AllOrders;
			ordiniCopiati[1].SupllyOrder();
			Console.WriteLine( ordiniCopiati[1].IsProcessed + "\n" + orderManager.AllOrders[1].IsProcessed );

			Console.ReadKey();
		}
	}
}