# Informer
Simple message bus for net core and standard

[![license](https://img.shields.io/github/license/rosen369/informer.svg)](https://github.com/Rosen369/Informer/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/dt/informer.svg)](https://www.nuget.org/packages/Informer/)

# Feeds
* NuGet [![NuGet](https://img.shields.io/nuget/v/Informer.svg)](https://www.nuget.org/packages/Informer/)

# Let's get started

From **NuGet**: 
* PM> Install-Package Informer

# Implement a message model

```c#
using Informer;

public class MessageModel : Message
{
    public string Name { get; set; }
}
```

# Subscribe and Unsubscribe

```c#
var messageBus = MessageBus.GetInstance();
var token = messageBus.Subscribe<MessageModel>(s =>
{
    //handle the message
});
messageBus.Unsubscribe(token);
```

# Emit message

```c#
var msg = new MessageModel { Name = "Rosen" };
MessageBus.GetInstance().Emit(msg);
```

# Customer event handler

```c#
public void HaldelMessage(MessageModel message)
{
    //handle the message
}

MessageBus.GetInstance().Subscribe<MessageModel>(HaldelMessage);
```
