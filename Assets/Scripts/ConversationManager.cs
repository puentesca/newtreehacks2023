using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{

    // Conversation flow:

    // 1. Get name
    // 2. Get topic to talk about
    // 3. AI introduces self and asks initial question.
    // Then, cyclic:
    // 4. User responds to question verbally.
    // 5. AI asks followup question
    // Cycle continues until user chooses to end the conversation. At that
    // point, this happens:
    // 6. AI summarizes conversation from perspective of person being
    //      interviewed
    // 7. AI uses summary to generate a tagline for a representative picture
    //      that gets fed into DALL-E 2.
    // 8. Once DALL-E 2 image is generated, it is displayed for 5 seconds, then
    //      game transitions back to 'viewing stories' status

    public ChatGPTWrapper.ChatGPTConversation chatGPT;

    private enum CONVERSATION_STATUS
    {
        IDLE,
        GATHERING_NAME_AND_TOPIC,
        INTRODUCTION,
        USER_CONVERSING,
        CONVERSATION_CLOSING,
        CONVERSATION_COMPLETED
    }


    private CONVERSATION_STATUS currentStatus;
    // Start is called before the first frame update
    void Start()
    {
        currentStatus = CONVERSATION_STATUS.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginConversation()
    {
        currentStatus = CONVERSATION_STATUS.GATHERING_NAME_AND_TOPIC;
        //Prompt user for their name and topic through TTS.
    }

    public void DoIntroductionAndStartConversation(string nameAndTopic)
    {
        currentStatus = CONVERSATION_STATUS.INTRODUCTION;
        chatGPT.SendToChatGPT(GetIntroductionPrompt(nameAndTopic));
    }

    private string GetIntroductionPrompt(string text)
    {
        string message = "You are a warm, friendly person casually interviewing someone with the " +
            "purpose of extracting an interesting story from their life. You will be given a general " +
            "event or topic that will be the theme/main topic for the story and must gently guide " +
            "the person through conversation and do your best to extract interesting details and " +
            "events. Once you feel as if you have enough information compile a fascinating story, " +
            "end the conversation and generate a summary of the story. REMEMBER: 1. You are NOT " +
            "supposed to generate the response for the person you are interviewing - you are only " +
            "supposed to ask questions. Their input will come in a response form as text. 2. Do not " +
            "forget to reasonable engage the person as much as possible with the goal of gathering details" +
            "for a summary of the story, but also to make them feel like they're having fun. As for the " +
            "person you are extracting the information from, they were asked to provide a summary of their" +
            "name and what topic they wanted to talk about. Their response was: '" + text + "'. Your name, " +
            "the interviewer, is John. You may introduce yourself and ask your first question about the topic they " +
            "provided now: ";

        return message;
    }

    private string GetGoodbyePrompt()
    {
        string message = "The conversation has ended. Gracefully and casually thank the person for chatting with you. Also," +
            "mention that you will provide them with a summary of their story and a cool image to go along with it.";
        return message;
    }

    private string GetSummaryPrompt()
    {
        string message = "Great. Now, please generate an interesting summary, from the perspective of" +
            "the person you interviewed, of the story you extracted that they can take back with them and remember. Make " +
            "sure to explain the events that they did from their perspective, anything interesting that happened, etc.";
        return message;
    }

    // Claled when player hits button to end the conversation with AI
    public void EndConversationClicked()
    {
        // have AI summarize and create a tagline for the dalle generation
        currentStatus = CONVERSATION_STATUS.CONVERSATION_CLOSING;
        UserResponded(GetGoodbyePrompt());

        //Add a call to a 4 second wait for the summary prompt to be called.
    }

    //When the user responds
    public void UserResponded(string text)
    {
        if (currentStatus == CONVERSATION_STATUS.GATHERING_NAME_AND_TOPIC)
        {
            DoIntroductionAndStartConversation(text);
        }
        else if(currentStatus == CONVERSATION_STATUS.INTRODUCTION)
        {
            currentStatus = CONVERSATION_STATUS.USER_CONVERSING;
            chatGPT.SendToChatGPT(text);
        }
        else
        {
            //Send to openAI
            Debug.Log("Sending text to GPT: " + text);
            chatGPT.SendToChatGPT(text);
        }
        
    }

    // AI interaction
    public void AIResponded(string text)
    {
        
        // Text to speech the response
        Debug.Log("AI Responded: " + text);

    }
}
