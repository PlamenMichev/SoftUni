function solve() {
   let messageBoxElement = document.getElementById('chat_input');
   let sendButtonElement = document.getElementById('send');

   sendButtonElement.addEventListener('click', () => {
      let currentMessageElement = document.createElement('div');
      currentMessageElement.className = 'message my-message';
      currentMessageElement.textContent += messageBoxElement.value;
      let chatElement = document.getElementById('chat_messages');
      chatElement.appendChild(currentMessageElement);
      messageBoxElement.value = '';
   })
}


