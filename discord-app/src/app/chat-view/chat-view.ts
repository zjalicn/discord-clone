import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Chatbox } from '../chatbox/chatbox';
import { Message } from '../../types/message';
import { IconsModule } from '../shared/icons.module';

@Component({
  selector: 'app-chat-view',
  imports: [Chatbox, IconsModule, FormsModule],
  templateUrl: './chat-view.html',
  styleUrl: './chat-view.css',
})
export class ChatView {
  messages: Message[] = [];

  messageText = '';

  handleSubmitMessage() {
    this.messages.push({
      userId: '1',
      roomId: '1',
      message: this.messageText,
      timestamp: Date.now(),
    });
    this.messageText = '';
  }
}
