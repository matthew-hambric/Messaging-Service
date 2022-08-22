namespace Dynamics.MessagingService.Akka.Model;

public record class GetTokenRequest: IWithUserId
{
    public string UserId { get; init; }
    
    public GetTokenRequest(string userId){
        UserId = userId;
    }
}

public record class GetTokenResponse { }

public record class ThrottledResponse { }

public record class GetMessageSequenceNumberRequest: IWithUserId {
    public string UserId { get; init; }

    public GetMessageSequenceNumberRequest(string userId){
        UserId = userId;
    }
}

public record class GetMessageSequenceNumberResponse {
    public int SequenceId { get; init; }
    public GetMessageSequenceNumberResponse(int sequenceId){
        SequenceId = sequenceId;
    }
}