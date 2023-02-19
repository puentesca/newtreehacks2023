using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Different states:
    // Viewing stories
    // Conversing

    public ConversationManager convoManager;

    enum STATUS
    {
        VIEWING_STORIES,
        CONVERSING
    }

    private STATUS playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = STATUS.VIEWING_STORIES;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Player wants to tell a new story
    public void StartConversationClicked()
    {
        // Animate character in, animate story UI out
    }

    // Called (theoretically) by animation trigger after transition complete
    public void StartConversationFinished()
    {
        playerStatus = STATUS.CONVERSING;
        convoManager.BeginConversation();
        // Begin actual conversation through ConversationManager
    }

    // Player wants to stop talking about the story
    public void EndConversationClicked()
    {
        // Send message to ConversationManager that the story is requested to be finished
    }

    // Called by the ConversationManager once the entire process of the conversation is over.
    public void EndConversationFinished()
    {
        // Conversation completed - Initiate finished animations
    }

    public void EndConversationAnimationCompleted()
    {
        playerStatus = STATUS.VIEWING_STORIES;
        //
    }
}
