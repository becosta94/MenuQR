import React, { useState } from 'react';

const ChatBot = () => {
    const [messages, setMessages] = useState([]);
    const [newMessage, setNewMessage] = useState('');

    const handleInputChange = (event) => {
        setNewMessage(event.target.value);
    };

    const handleSendMessage = () => {
        if (newMessage.trim() === '') return;

        // Adiciona a nova mensagem à lista de mensagens
        setMessages([...messages, { text: newMessage, sender: 'user' }]);

        // Simula uma resposta do chat bot após um pequeno atraso
        setTimeout(() => {
            setMessages([...messages, { text: 'Olá! Eu sou o chat bot.', sender: 'bot' }]);
        }, 500);

        // Limpa a caixa de entrada
        setNewMessage('');
    };

    return (
        <div className="chat-bot">
            <div className="chat-messages">
                {messages.map((message, index) => (
                    <div key={index} className={`message ${message.sender}`}>
                        {message.text}
                    </div>
                ))}
            </div>
            <div className="chat-input">
                <input
                    type="text"
                    placeholder="Digite sua mensagem..."
                    value={newMessage}
                    onChange={handleInputChange}
                />
                <button onClick={handleSendMessage}>Enviar</button>
            </div>
        </div>
    );
};

export default ChatBot;