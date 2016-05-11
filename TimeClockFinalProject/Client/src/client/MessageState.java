package client;

import java.io.Serializable;

/**
 * MessageState class implements Serializable and holds instance attribute for
 * the msgState Enumeration and instance attribute for the Object Class and
 * holds getters and setters and constructors for msgState and Object
 *
 * @author Nasr
 */
public final class MessageState implements Serializable {

    /**
     * serialVersionUID instead of default serial version number messageObject a
     * reference to an object class msgState a reference to a msgState
     * Enumeration
     */
    private static final long serialVersionUID = 42L;
    private Object messageContent;
    private MsgEnum msgState;

    /**
     * Default Constructor
     */
    public MessageState() {
    }

    /**
     * @param EmployeeID
     * @param msgState
     */
    public MessageState(Object EmployeeID, MsgEnum msgState) {
        setState(msgState);
        setObject(EmployeeID);
    }

    /**
     * Constructor takes one argument and sets it
     *
     * @param msgState
     */
    public MessageState(MsgEnum msgState) {
        setState(msgState);
    }

    /**
     * Method getter for the object
     *
     * @return messageObject
     */
    public Object getObject() {
        return (Object) getMessageContent();
    }

    /**
     * Method getter for the state
     *
     * @return msgState
     */
    public MsgEnum getState() {
        return msgState;
    }

    /**
     * Setter for Object
     *
     * @param EmployeeID
     */
    public void setObject(Object EmployeeID) {
        this.setMessageContent(EmployeeID);
    }

    /**
     * Setter for Message
     *
     * @param msgState
     */
    public void setState(MsgEnum msgState) {
        this.msgState = msgState;
    }

    /**
     * @return the messageContent
     */
    public Object getMessageContent() {
        return messageContent;
    }

    /**
     * @param messageContent the messageContent to set
     */
    public void setMessageContent(Object messageContent) {
        this.messageContent = messageContent;
    }
}
