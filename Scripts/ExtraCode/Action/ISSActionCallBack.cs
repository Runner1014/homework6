using UnityEngine;

public enum SSActionEventType : int { Started, Completed }
public enum SSActionTargetType : int { Normal, Catching }

public interface ISSActionCallback
{
    void SSActionEvent(SSAction source,
        SSActionEventType events = SSActionEventType.Completed,
        SSActionTargetType intParam = SSActionTargetType.Normal,
        string strParam = null,
        Object objectParam = null);

}