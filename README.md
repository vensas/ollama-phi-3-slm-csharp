# ChatBot-Anwendung mit Ollama OpenAI und .NET

## Überblick

Dieses Repository enthält eine einfache ChatBot-Anwendung, die mit .NET und dem Chat-Completion-Service von SemanticKernel erstellt wurde. Die Anwendung ermöglicht eine kontinuierliche Chat-Interaktion, bei der der Benutzer Fragen eingeben und Antworten vom KI-Modell erhalten kann.

## Funktionen

- **Integration des SemanticKernel Chat-Completion-Services**: Die Anwendung nutzt den Chat-Completion-Service von SemanticKernel, um Antworten auf Benutzereingaben zu generieren.
- **Lokaler API-Endpunkt**: Konfiguriert für die Arbeit mit einer lokalen Instanz der Ollama OpenAI API.
- **Interaktive Konsolenanwendung**: Der Chat läuft in einer Konsole und ermöglicht eine Echtzeit-Interaktion mit der KI.

## Voraussetzungen

- .NET SDK
- Lokale Instanz von Ollama, die unter `http://localhost:11434` läuft

## Einrichtung

1. **Repository klonen**:

   ```bash
   git clone https://github.com/vensas/ollama-phi-3-slm-csharp.git
   cd ollama-phi-3-slm-csharp
   ```

2. **Konfiguration des Ollama OpenAI Services**:
   Stellen Sie sicher, dass eine lokale Instanz des Ollama OpenAI Services läuft. Die Anwendung ist so konfiguriert, dass sie sich mit `http://localhost:11434` verbindet.

3. **Anwendung bauen und starten**:
   ```bash
   dotnet run
   ```

## Funktionsweise

- Die Anwendung startet, indem ein Host-Application-Builder erstellt wird.
- Der SemanticKernel Chat-Completion-Service wird mit einer angegebenen Modell-ID und einem Endpunkt registriert.
- Eine neue Chatsitzung wird initiiert, bei der der Benutzer aufgefordert wird, eine Frage einzugeben.
- Die Benutzereingabe wird an den OpenAI-Service gesendet, und die Antwort wird in die Konsole zurückgestreamt.
- Das Gespräch wird fortgesetzt, bis der Benutzer entscheidet, es durch Eingabe eines leeren Eingabefeldes zu beenden.

## Fazit

Diese ChatBot-Anwendung dient als einfache Vorlage zur Integration der Chat-Completion-Fähigkeiten von SemanticKernel in eine .NET-Konsolenanwendung. Sie kann, ja nach Bedarf, weiter ausgebaut werden.

## Blog-Artikel

Du kannst mehr darüber in unserem Blog-Artikel lesen: [Generative KI-Anwendungen mit Phi-3 SML, C# Semantic Kernel und Ollama entwickeln](https://vensas.de/blog/ollama-phi-3-slm-csharp).
