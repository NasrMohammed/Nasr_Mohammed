/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package server;

import java.util.concurrent.Executors;
import java.util.concurrent.ExecutorService;
import java.net.Socket;
import java.net.ServerSocket;

/**
 * Server class handle the message request from client and 
 * and send message back again to client 
 * @author Nasr
 */
public class Server {

    public static void main(String[] args) {

        // Specify the port to use for listening
        int port = 5555;

	// Get an ExecutorService to manage the Thread Pool
        // In this case, we are getting 100 threads to start
        ExecutorService executorService = Executors.newFixedThreadPool(100);

        // Instantiate a ServerScoket to do the listening for connections
        try {
            ServerSocket serverSocket = new ServerSocket(port);

            while (true) {
                // wait for the connection
                Socket socket = serverSocket.accept();

                
                socket.setSoTimeout(3000);

                // hand the connect socket to a new thread and let it run its 
                // course
                executorService.execute(new RequestHandler(socket));

            } // end while
        } catch (Exception ex) {
             MessageState msgS = new MessageState();
             msgS.setState(MsgEnum.SERVERERROR);
        }
    } // end method main
}
