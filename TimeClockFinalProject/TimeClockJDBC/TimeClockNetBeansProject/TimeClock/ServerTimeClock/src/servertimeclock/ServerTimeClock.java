package servertimeclock;

import java.util.concurrent.Executors;
import java.util.concurrent.ExecutorService;
import java.net.Socket;
import java.net.ServerSocket;


public class ServerTimeClock{
	public static void main(String[] args) {
		// Specify the port to use
		int port = 5555;
		
		// Get an ExecutiveService to manage the thread pool
		ExecutorService executiveService = Executors.newFixedThreadPool(100);
		
		try {
			ServerSocket serverSocket = new ServerSocket(port);			
			System.out.println("Instantiated ServerSocket on port: " + port);
			
			while(true) {
				// Wait for a connection request 
				Socket socket = serverSocket.accept();
				
				// set the Socket time out
				socket.setSoTimeout(3000);
				
				// hand the socket to a thread for processing 
				executiveService.execute(new MsgState(socket));
				
			} // end while
		
		} catch (Exception ex) {
			System.out.println("CATASROPHIC FALLURE: Server Stopping.\n"
				+ ex.getMessage());
		}
	} // end method main()
} // end class Server