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
        GATHERING_NAME,
        GATHERING_TOPIC,
        INTRODUCTION,
        USER_RESPONDING,
        AI_QUESTIONING,
        CONVERSATION_CLOSING,
        CONVERSATION_COMPLETED
    }

    // Start is called before the first frame update
    void Start()
    {
        UserResponded("You are a warm, friendly person casually interviewing someone with the purpose of extracting an interesting story from their life. You will be given a general event or topic that will be the theme/main topic for the story and must gently guide the person through conversation and do your best to extract interesting details and events. Once you feel as if you have enough information compile a fascinating story, end the conversation and generate a summary of the story. REMEMBER: 1.You are NOT supposed to generate the response for the person you are interviewing - you are only supposed to ask questions.Their input will come in a response form as text. 2.Do not forget to generate an interesting summary of the story from the perspective of the person you are interviewing once you have finished the conversation.DO NOT FORGET!!!! Your name is John.The person you are interviewing is Casey and the topic is a trip he took to Chile over winter break. You may introduce yourself and ask your first question now:");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginConversation()
    {
        
    }

    // Claled when player hits button to end the conversation with AI
    public void EndConversationClicked()
    {

    }

    //When the user responds
    public void UserResponded(string text)
    {
        //Send to openAI
        Debug.Log("Sending text to GPT: " + text);
        chatGPT.SendToChatGPT(text);
    }

    // AI interaction
    public void AIResponded(string text)
    {
        // Text to speech the response
        Debug.Log("AI Responded: " + text);
    }
}
